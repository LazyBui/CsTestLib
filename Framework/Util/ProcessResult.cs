using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Test {
	internal sealed class ProcessResult {
		public string FullOutput { get; private set; }
		public string FullError { get; private set; }
		public string FullBuffer { get; private set; }
		public int ExitCode { get; private set; }
		public DateTime StartTime { get; private set; }
		public DateTime ExitTime { get; private set; }
		public TimeSpan PrivilegedProcessorTime { get; private set; }
		public TimeSpan UserProcessorTime { get; private set; }
		public TimeSpan TotalProcessorTime { get; private set; }
		public long PeakPagedMemorySize { get; private set; }
		public long PeakVirtualMemorySize { get; private set; }
		public long PeakWorkingSet { get; private set; }

		public ProcessResult(
			string pFullOutput,
			string pFullError,
			string pFullBuffer,
			int pExitCode,
			DateTime pStartTime,
			DateTime pExitTime,
			TimeSpan pPrivilegedProcessorTime,
			TimeSpan pUserProcessorTime,
			TimeSpan pTotalProcessorTime,
			long pPeakPagedMemorySize,
			long pPeakVirtualMemorySize,
			long pPeakWorkingSet
		) {
			FullOutput = pFullOutput;
			FullError = pFullError;
			FullBuffer = pFullBuffer;
			ExitCode = pExitCode;
			StartTime = pStartTime;
			ExitTime = pExitTime;
			PrivilegedProcessorTime = pPrivilegedProcessorTime;
			UserProcessorTime = pUserProcessorTime;
			TotalProcessorTime = pTotalProcessorTime;
			PeakPagedMemorySize = pPeakPagedMemorySize;
			PeakVirtualMemorySize = pPeakVirtualMemorySize;
			PeakWorkingSet = pPeakWorkingSet;
		}
	}
}
