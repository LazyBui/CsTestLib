using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test {
	[TestClass]
	public class ProcessSpawnerWithCombinedAndSplitErrAndOutTest {
		[TestMethod]
		[TestCategory("Framework.Util")]
		public void Constructor() {
			// File only
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(null as string); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(null as FileInfo); });
			Assert.ThrowsExact<ArgumentException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(string.Empty); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.InvalidBinary); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.InvalidBinaryInfo); });
			Assert.DoesNotThrow(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.SimpleInterspersed); });
			Assert.DoesNotThrow(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.SimpleInterspersedInfo); });

			// File/args only
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(null as string, null as object[]); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(null as FileInfo, null as object[]); });
			Assert.ThrowsExact<ArgumentException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(string.Empty, null as object[]); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.InvalidBinary, null as object[]); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.InvalidBinaryInfo, null as object[]); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(null as string, "abc"); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(null as FileInfo, "abc"); });
			Assert.ThrowsExact<ArgumentException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(string.Empty, "abc"); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.InvalidBinary, "abc"); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.InvalidBinaryInfo, "abc"); });
			Assert.DoesNotThrow(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.SimpleInterspersed, null as object[]); });
			Assert.DoesNotThrow(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.SimpleInterspersedInfo, null as object[]); });
			Assert.DoesNotThrow(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.SimpleInterspersed, "abc"); });
			Assert.DoesNotThrow(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.SimpleInterspersedInfo, "abc"); });

			// File/escaper/args
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(null as string, new WindowsCommandLineArgumentEscaper(), null as object[]); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(null as FileInfo, new WindowsCommandLineArgumentEscaper(), null as object[]); });
			Assert.ThrowsExact<ArgumentException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(string.Empty, new WindowsCommandLineArgumentEscaper(), null as object[]); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.InvalidBinary, new WindowsCommandLineArgumentEscaper(), null as object[]); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.InvalidBinaryInfo, new WindowsCommandLineArgumentEscaper(), null as object[]); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(null as string, null, null as object[]); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(null as FileInfo, null, null as object[]); });
			Assert.ThrowsExact<ArgumentException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(string.Empty, null, null as object[]); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.InvalidBinary, null, null as object[]); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.InvalidBinaryInfo, null, null as object[]); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(null as string, new WindowsCommandLineArgumentEscaper(), "abc"); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(null as FileInfo, new WindowsCommandLineArgumentEscaper(), "abc"); });
			Assert.ThrowsExact<ArgumentException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(string.Empty, new WindowsCommandLineArgumentEscaper(), "abc"); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.InvalidBinary, new WindowsCommandLineArgumentEscaper(), "abc"); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.InvalidBinaryInfo, new WindowsCommandLineArgumentEscaper(), "abc"); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(null as string, null, "abc"); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(null as FileInfo, null, "abc"); });
			Assert.ThrowsExact<ArgumentException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(string.Empty, null, "abc"); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.InvalidBinary, null, "abc"); });
			Assert.ThrowsExact<FileNotFoundException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.InvalidBinaryInfo, null, "abc"); });
			Assert.DoesNotThrow(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.SimpleInterspersed, null, null as object[]); });
			Assert.DoesNotThrow(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.SimpleInterspersedInfo, null, null as object[]); });
			Assert.DoesNotThrow(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.SimpleInterspersed, new WindowsCommandLineArgumentEscaper(), null as object[]); });
			Assert.DoesNotThrow(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.SimpleInterspersedInfo, new WindowsCommandLineArgumentEscaper(), null as object[]); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.SimpleInterspersed, null, "abc"); });
			Assert.ThrowsExact<ArgumentNullException>(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.SimpleInterspersedInfo, null, "abc"); });
			Assert.DoesNotThrow(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.SimpleInterspersed, new WindowsCommandLineArgumentEscaper(), "abc"); });
			Assert.DoesNotThrow(() => { new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.SimpleInterspersedInfo, new WindowsCommandLineArgumentEscaper(), "abc"); });
		}

		[TestMethod]
		[TestCategory("Framework.Util")]
		public void SimpleInterspersed() {
			ProcessSpawnerWithCombinedAndSplitErrAndOut process = null;
			ProcessResult result = null;

			Assert.DoesNotThrow(() => {
				process = new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.SimpleInterspersed);
				result = process.Run();
			});
			Assert.NotNull(process);
			Assert.NotNull(result);
			Assert.Equal(result.ExitCode, 3);
			Assert.NotNull(result.FullBuffer);
			Assert.NotNull(result.FullOutput);
			Assert.NotNull(result.FullError);
			Assert.Equal(result.FullBuffer, @"abc
def
abc
def
abc
def
def
abc
aabbccddeeff");
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
			ProcessSpawnerWithCombinedAndSplitErrAndOut process = null;
			ProcessResult result = null;

			Assert.DoesNotThrow(() => {
				process = new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.BlankLinesInterspersed);
				result = process.Run();
			});
			Assert.NotNull(process);
			Assert.NotNull(result);
			Assert.Equal(result.ExitCode, 0);
			Assert.NotNull(result.FullBuffer);
			Assert.NotNull(result.FullOutput);
			Assert.NotNull(result.FullError);
			Assert.Equal(result.FullBuffer, @"abc

def

abc
def

abc
def
def

abc");
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
			ProcessSpawnerWithCombinedAndSplitErrAndOut process = null;
			ProcessResult result = null;

			Assert.DoesNotThrow(() => {
				process = new ProcessSpawnerWithCombinedAndSplitErrAndOut(TestApplications.NoOutput);
				result = process.Run();
			});
			Assert.NotNull(process);
			Assert.NotNull(result);
			Assert.Equal(result.ExitCode, 0);
			Assert.NotNull(result.FullBuffer);
			Assert.NotNull(result.FullOutput);
			Assert.NotNull(result.FullError);
			Assert.Equal(result.FullBuffer, @"");
			Assert.Equal(result.FullOutput, @"");
			Assert.Equal(result.FullError, @"");
		}
	}
}
