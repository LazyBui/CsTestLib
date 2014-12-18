using System;
using System.IO;

namespace Test {
	internal sealed class ProcessSpawnerWithCombinedAndSplitErrAndOut : IProcessSpawner {
		private ProcessSpawnerWithSplitErrAndOut m_split = null;
		private ProcessSpawnerWithCombinedErrAndOut m_combined = null;

		public bool Started { get; private set; }
		public bool Exited { get; private set; }

		public ProcessSpawnerWithCombinedAndSplitErrAndOut(string pFileName) {
			m_split = new ProcessSpawnerWithSplitErrAndOut(pFileName);
			m_combined = new ProcessSpawnerWithCombinedErrAndOut(pFileName);
		}

		public ProcessSpawnerWithCombinedAndSplitErrAndOut(string pFileName, params object[] pArguments) {
			m_split = new ProcessSpawnerWithSplitErrAndOut(pFileName, pArguments);
			m_combined = new ProcessSpawnerWithCombinedErrAndOut(pFileName, pArguments);
		}

		public ProcessSpawnerWithCombinedAndSplitErrAndOut(string pFileName, ICommandLineArgumentEscaper pEscaper, params object[] pArguments) {
			m_split = new ProcessSpawnerWithSplitErrAndOut(pFileName, pEscaper, pArguments);
			m_combined = new ProcessSpawnerWithCombinedErrAndOut(pFileName, pEscaper, pArguments);
		}

		public ProcessSpawnerWithCombinedAndSplitErrAndOut(FileInfo pFile) {
			m_split = new ProcessSpawnerWithSplitErrAndOut(pFile);
			m_combined = new ProcessSpawnerWithCombinedErrAndOut(pFile);
		}

		public ProcessSpawnerWithCombinedAndSplitErrAndOut(FileInfo pFile, params object[] pArguments) {
			m_split = new ProcessSpawnerWithSplitErrAndOut(pFile, pArguments);
			m_combined = new ProcessSpawnerWithCombinedErrAndOut(pFile, pArguments);
		}

		public ProcessSpawnerWithCombinedAndSplitErrAndOut(FileInfo pFile, ICommandLineArgumentEscaper pEscaper, params object[] pArguments) {
			m_split = new ProcessSpawnerWithSplitErrAndOut(pFile, pEscaper, pArguments);
			m_combined = new ProcessSpawnerWithCombinedErrAndOut(pFile, pEscaper, pArguments);
		}

		private ProcessResult ProduceResult(ProcessResult pSplitResult, ProcessResult pCombinedResult) {
			if (pSplitResult.ExitCode != pCombinedResult.ExitCode) {
				throw new InvalidDataException("Exit codes were not consistent between the two executions");
			}

			// Take the larger run time in order to populate this information
			bool useSplitTimes =
				(pSplitResult.ExitTime - pSplitResult.StartTime) >
				(pCombinedResult.ExitTime - pCombinedResult.StartTime);

			return new ProcessResult(
				pFullOutput: pSplitResult.FullOutput,
				pFullError: pSplitResult.FullError,
				pFullBuffer: pCombinedResult.FullBuffer,
				pExitCode: pCombinedResult.ExitCode,
				pStartTime:
					useSplitTimes ?
					pSplitResult.StartTime :
					pCombinedResult.StartTime,
				pExitTime:
					useSplitTimes ?
					pSplitResult.ExitTime :
					pCombinedResult.ExitTime,
				pPrivilegedProcessorTime:
					pSplitResult.PrivilegedProcessorTime > pCombinedResult.PrivilegedProcessorTime ?
					pSplitResult.PrivilegedProcessorTime :
					pCombinedResult.PrivilegedProcessorTime,
				pUserProcessorTime:
					pSplitResult.UserProcessorTime > pCombinedResult.UserProcessorTime ?
					pSplitResult.UserProcessorTime :
					pCombinedResult.UserProcessorTime,
				pTotalProcessorTime:
					pSplitResult.TotalProcessorTime > pCombinedResult.TotalProcessorTime ?
					pSplitResult.TotalProcessorTime :
					pCombinedResult.TotalProcessorTime,
				pPeakPagedMemorySize: Math.Max(pSplitResult.PeakPagedMemorySize, pCombinedResult.PeakPagedMemorySize),
				pPeakVirtualMemorySize: Math.Max(pSplitResult.PeakVirtualMemorySize, pCombinedResult.PeakVirtualMemorySize),
				pPeakWorkingSet: Math.Max(pSplitResult.PeakWorkingSet, pCombinedResult.PeakWorkingSet)
			);
		}

		public ProcessResult Run() {
			return WaitForExit();
		}

		public void Start() {
			if (Exited) throw new InvalidOperationException("Must not execute the process twice");
			if (Started) throw new InvalidOperationException("Must not execute the process twice");

			m_split.Start();
			m_combined.Start();
			Started = true;
		}

		public ProcessResult WaitForExit() {
			if (Exited) throw new InvalidOperationException("Must not execute the process twice");
			if (!Started) Start();
			var splitResult = m_split.WaitForExit();
			var combinedResult = m_combined.WaitForExit();
			Exited = true;
			return ProduceResult(splitResult, combinedResult);
		}

		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing) {
			if (disposing) {
				m_split.Dispose();
				m_combined.Dispose();
			}
		}
	}
}
