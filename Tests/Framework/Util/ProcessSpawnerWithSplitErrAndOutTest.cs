using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test {
	[TestClass]
	public class ProcessSpawnerWithSplitErrAndOutTest {
		[TestMethod]
		[TestCategory("Framework.Util")]
		public void Constructor() {
			// File only
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithSplitErrAndOut(null as string); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithSplitErrAndOut(null as FileInfo); });
			Assert.ThrowsExact<ArgumentException>(() => { new ProcessSpawnerWithSplitErrAndOut(string.Empty); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.InvalidBinary); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.InvalidBinaryInfo); });
			Assert.DoesNotThrow(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.SimpleInterspersed); });
			Assert.DoesNotThrow(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.SimpleInterspersedInfo); });

			// File/args only
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithSplitErrAndOut(null as string, null as object[]); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithSplitErrAndOut(null as FileInfo, null as object[]); });
			Assert.ThrowsExact<ArgumentException>(() => { new ProcessSpawnerWithSplitErrAndOut(string.Empty, null as object[]); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.InvalidBinary, null as object[]); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.InvalidBinaryInfo, null as object[]); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithSplitErrAndOut(null as string, "abc"); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithSplitErrAndOut(null as FileInfo, "abc"); });
			Assert.ThrowsExact<ArgumentException>(() => { new ProcessSpawnerWithSplitErrAndOut(string.Empty, "abc"); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.InvalidBinary, "abc"); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.InvalidBinaryInfo, "abc"); });
			Assert.DoesNotThrow(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.SimpleInterspersed, null as object[]); });
			Assert.DoesNotThrow(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.SimpleInterspersedInfo, null as object[]); });
			Assert.DoesNotThrow(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.SimpleInterspersed, "abc"); });
			Assert.DoesNotThrow(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.SimpleInterspersedInfo, "abc"); });

			// File/escaper/args
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithSplitErrAndOut(null as string, new WindowsCommandLineArgumentEscaper(), null as object[]); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithSplitErrAndOut(null as FileInfo, new WindowsCommandLineArgumentEscaper(), null as object[]); });
			Assert.ThrowsExact<ArgumentException>(() => { new ProcessSpawnerWithSplitErrAndOut(string.Empty, new WindowsCommandLineArgumentEscaper(), null as object[]); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.InvalidBinary, new WindowsCommandLineArgumentEscaper(), null as object[]); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.InvalidBinaryInfo, new WindowsCommandLineArgumentEscaper(), null as object[]); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithSplitErrAndOut(null as string, null, null as object[]); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithSplitErrAndOut(null as FileInfo, null, null as object[]); });
			Assert.ThrowsExact<ArgumentException>(() => { new ProcessSpawnerWithSplitErrAndOut(string.Empty, null, null as object[]); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.InvalidBinary, null, null as object[]); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.InvalidBinaryInfo, null, null as object[]); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithSplitErrAndOut(null as string, new WindowsCommandLineArgumentEscaper(), "abc"); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithSplitErrAndOut(null as FileInfo, new WindowsCommandLineArgumentEscaper(), "abc"); });
			Assert.ThrowsExact<ArgumentException>(() => { new ProcessSpawnerWithSplitErrAndOut(string.Empty, new WindowsCommandLineArgumentEscaper(), "abc"); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.InvalidBinary, new WindowsCommandLineArgumentEscaper(), "abc"); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.InvalidBinaryInfo, new WindowsCommandLineArgumentEscaper(), "abc"); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithSplitErrAndOut(null as string, null, "abc"); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithSplitErrAndOut(null as FileInfo, null, "abc"); });
			Assert.ThrowsExact<ArgumentException>(() => { new ProcessSpawnerWithSplitErrAndOut(string.Empty, null, "abc"); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.InvalidBinary, null, "abc"); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.InvalidBinaryInfo, null, "abc"); });
			Assert.DoesNotThrow(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.SimpleInterspersed, null, null as object[]); });
			Assert.DoesNotThrow(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.SimpleInterspersedInfo, null, null as object[]); });
			Assert.DoesNotThrow(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.SimpleInterspersed, new WindowsCommandLineArgumentEscaper(), null as object[]); });
			Assert.DoesNotThrow(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.SimpleInterspersedInfo, new WindowsCommandLineArgumentEscaper(), null as object[]); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.SimpleInterspersed, null, "abc"); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.SimpleInterspersedInfo, null, "abc"); });
			Assert.DoesNotThrow(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.SimpleInterspersed, new WindowsCommandLineArgumentEscaper(), "abc"); });
			Assert.DoesNotThrow(() => { new ProcessSpawnerWithSplitErrAndOut(TestApplications.SimpleInterspersedInfo, new WindowsCommandLineArgumentEscaper(), "abc"); });
		}

		[TestMethod]
		[TestCategory("Framework.Util")]
		public void SimpleInterspersed() {
			ProcessSpawnerWithSplitErrAndOut process = null;
			ProcessResult result = null;

			Assert.DoesNotThrow(() => {
				process = new ProcessSpawnerWithSplitErrAndOut(TestApplications.SimpleInterspersedInfo);
				result = process.Run();
			});
			Assert.NotNull(process);
			Assert.NotNull(result);
			Assert.Equal(result.ExitCode, 3);
			Assert.GreaterThan(result.PeakPagedMemorySize, 0);
			Assert.GreaterThan(result.PeakVirtualMemorySize, 0);
			Assert.GreaterThan(result.PeakWorkingSet, 0);
			Assert.NotEqual(result.StartTime, DateTime.MinValue);
			Assert.NotEqual(result.ExitTime, DateTime.MinValue);
			Assert.GreaterThan(result.ExitTime - result.StartTime, TimeSpan.Zero);
			Assert.Null(result.FullBuffer);
			Assert.NotNull(result.FullOutput);
			Assert.NotNull(result.FullError);
			Assert.Equal(result.FullOutput, @"def
def
def
def
abcdef");
			Assert.Equal(result.FullError, @"abc
abc
abc
abc
abcdef");
		}

		[TestMethod]
		[TestCategory("Framework.Util")]
		public void BlankLinesInterspersed() {
			ProcessSpawnerWithSplitErrAndOut process = null;
			ProcessResult result = null;

			Assert.DoesNotThrow(() => {
				process = new ProcessSpawnerWithSplitErrAndOut(TestApplications.BlankLinesInterspersedInfo);
				result = process.Run();
			});
			Assert.NotNull(process);
			Assert.NotNull(result);
			Assert.Null(result.FullBuffer);
			Assert.NotNull(result.FullOutput);
			Assert.NotNull(result.FullError);
			Assert.Equal(result.ExitCode, 0);
			Assert.GreaterThan(result.PeakPagedMemorySize, 0);
			Assert.GreaterThan(result.PeakVirtualMemorySize, 0);
			Assert.GreaterThan(result.PeakWorkingSet, 0);
			Assert.NotEqual(result.StartTime, DateTime.MinValue);
			Assert.NotEqual(result.ExitTime, DateTime.MinValue);
			Assert.GreaterThan(result.ExitTime - result.StartTime, TimeSpan.Zero);
			Assert.Equal(result.FullOutput, @"def

def

def
def");
			Assert.Equal(result.FullError, @"abc

abc
abc

abc");
		}

		[TestMethod]
		[TestCategory("Framework.Util")]
		public void NoOutput() {
			ProcessSpawnerWithSplitErrAndOut process = null;
			ProcessResult result = null;

			Assert.DoesNotThrow(() => {
				process = new ProcessSpawnerWithSplitErrAndOut(TestApplications.NoOutputInfo);
				result = process.Run();
			});
			Assert.NotNull(process);
			Assert.NotNull(result);
			Assert.Equal(result.ExitCode, 0);
			Assert.GreaterThan(result.PeakPagedMemorySize, 0);
			Assert.GreaterThan(result.PeakVirtualMemorySize, 0);
			Assert.GreaterThan(result.PeakWorkingSet, 0);
			Assert.NotEqual(result.StartTime, DateTime.MinValue);
			Assert.NotEqual(result.ExitTime, DateTime.MinValue);
			Assert.GreaterThan(result.ExitTime - result.StartTime, TimeSpan.Zero);
			Assert.Null(result.FullBuffer);
			Assert.NotNull(result.FullOutput);
			Assert.NotNull(result.FullError);
			Assert.Equal(result.FullOutput, @"");
			Assert.Equal(result.FullError, @"");
		}
	}
}
