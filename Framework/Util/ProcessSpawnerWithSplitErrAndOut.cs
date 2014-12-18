using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Test {
	internal sealed class ProcessSpawnerWithSplitErrAndOut : IProcessSpawner {
		private Process m_process = null;
		private StringBuilder m_output = new StringBuilder(1024);
		private StringBuilder m_error = new StringBuilder(1024);
		private long m_procPeakPagedMemorySize;
		private long m_procPeakVirtualMemorySize;
		private long m_procPeakWorkingSet;

		public bool Started { get; private set; }
		public bool Exited { get; private set; }

		public ProcessSpawnerWithSplitErrAndOut(string pFileName) { Initialize(pFileName, null, null); }
		public ProcessSpawnerWithSplitErrAndOut(string pFileName, params object[] pArguments) { Initialize(pFileName, new WindowsCommandLineArgumentEscaper(), pArguments); }
		public ProcessSpawnerWithSplitErrAndOut(string pFileName, ICommandLineArgumentEscaper pEscaper, params object[] pArguments) { Initialize(pFileName, pEscaper, pArguments); }
		public ProcessSpawnerWithSplitErrAndOut(FileInfo pFile) { Initialize(pFile, null, null); }
		public ProcessSpawnerWithSplitErrAndOut(FileInfo pFile, params object[] pArguments) { Initialize(pFile, new WindowsCommandLineArgumentEscaper(), pArguments); }
		public ProcessSpawnerWithSplitErrAndOut(FileInfo pFile, ICommandLineArgumentEscaper pEscaper, params object[] pArguments) { Initialize(pFile, pEscaper, pArguments); }

		private void Initialize(string pFileName, ICommandLineArgumentEscaper pEscaper, params object[] pArguments) {
			if (pFileName == null) throw new ArgumentNullException("pFileName");
			if (pFileName.Length == 0) throw new ArgumentException("String is blank", "pFileName");
			Initialize(new FileInfo(pFileName), pEscaper, pArguments);
		}

		private void Initialize(FileInfo pFile, ICommandLineArgumentEscaper pEscaper, params object[] pArguments) {
			if (pFile == null) throw new ArgumentNullException("pFile");
			if (!pFile.Exists) throw new FileNotFoundException("File not found", pFile.FullName);
			if (pArguments != null && pArguments.Any()) {
				if (pEscaper == null) throw new ArgumentNullException("pEscaper");
			}

			var startInfo = new ProcessStartInfo() {
				FileName = pFile.FullName,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				RedirectStandardInput = true,
				UseShellExecute = false,
			};

			if (pArguments != null && pArguments.Any()) {
				startInfo.Arguments = pEscaper.Escape(pArguments);
			}

			m_process = new Process() {
				StartInfo = startInfo,
				EnableRaisingEvents = true,
			};

			m_process.OutputDataReceived += (sender, args) => {
				if (args.Data == null) return;
				if (m_output.Length != 0) m_output.AppendLine();
				m_output.Append(args.Data);
			};

			m_process.ErrorDataReceived += (sender, args) => {
				if (args.Data == null) return;
				if (m_error.Length != 0) m_error.AppendLine();
				m_error.Append(args.Data);
			};
		}

		private ProcessResult ProduceResult() {
			return new ProcessResult(
				pFullOutput: m_output.ToString(),
				pFullError: m_error.ToString(),
				pFullBuffer: null,
				pExitCode: m_process.ExitCode,
				pStartTime: m_process.StartTime,
				pExitTime: m_process.ExitTime,
				pPrivilegedProcessorTime: m_process.PrivilegedProcessorTime,
				pUserProcessorTime: m_process.UserProcessorTime,
				pTotalProcessorTime: m_process.TotalProcessorTime,
				pPeakPagedMemorySize: m_procPeakPagedMemorySize,
				pPeakVirtualMemorySize: m_procPeakVirtualMemorySize,
				pPeakWorkingSet: m_procPeakWorkingSet
			);
		}

		public ProcessResult Run() {
			return WaitForExit();
		}

		public void Start() {
			if (Exited) throw new InvalidOperationException("Must not execute the process twice");
			if (Started) throw new InvalidOperationException("Must not execute the process twice");
			Started = true;
			m_process.Start();
			m_process.BeginOutputReadLine();
			m_process.BeginErrorReadLine();
		}

		public ProcessResult WaitForExit() {
			if (Exited) throw new InvalidOperationException("Must not execute the process twice");
			if (!Started) Start();

			while (true) {
				if (!m_process.HasExited) {
					m_procPeakPagedMemorySize = m_process.PeakPagedMemorySize64;
					m_procPeakVirtualMemorySize = m_process.PeakVirtualMemorySize64;
					m_procPeakWorkingSet = m_process.PeakWorkingSet64;
				}
				else break;
			}

			// Allow any outstanding events to finish
			m_process.WaitForExit();

			Exited = true;
			return ProduceResult();
		}

		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing) {
			if (disposing) {
				m_process.Dispose();
			}
		}
	}
}
