using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test {
	public partial class AssertTest {
		private const string ExistingFile = "Test.dll";
		private const string NonExistingFile = "abc.txt";
		private const string ExistingDirectory = "../../Framework/";
		private const string NonExistingDirectory = "NotAValidDirectory";
		private static FileInfo ExistingFileInfo = new FileInfo(ExistingFile);
		private static FileInfo NonExistingFileInfo = new FileInfo(NonExistingFile);
		private static DirectoryInfo ExistingDirectoryInfo = new DirectoryInfo(ExistingDirectory);
		private static DirectoryInfo NonExistingDirectoryInfo = new DirectoryInfo(NonExistingDirectory);

		private const string EqualCompareFile1 = "../../Tests/Test Framework/eq1.bin";
		private const string EqualCompareFile2 = "../../Tests/Test Framework/eq2.bin";
		private const string NotEqualCompareFileLength = "../../Tests/Test Framework/difflength.bin";
		private const string NotEqualCompareFileData = "../../Tests/Test Framework/diffcontent.bin";
		private static FileInfo EqualCompareFileInfo1 = new FileInfo(EqualCompareFile1);
		private static FileInfo EqualCompareFileInfo2 = new FileInfo(EqualCompareFile2);
		private static FileInfo NotEqualCompareFileLengthInfo = new FileInfo(NotEqualCompareFileLength);
		private static FileInfo NotEqualCompareFileDataInfo = new FileInfo(NotEqualCompareFileData);

		[TestMethod]
		public void FileExists() {
			Assert.Throws<ArgumentNullException>(() => Assert.FileExists(null as string));
			Assert.Throws<ArgumentNullException>(() => Assert.FileExists(null as FileInfo));
			Assert.Throws<AssertionException>(() => Assert.FileExists(NonExistingFile));
			Assert.Throws<AssertionException>(() => Assert.FileExists(NonExistingFileInfo));
			Assert.Throws<AssertionException>(() => Assert.FileExists(new FileInfo(NonExistingFile)));
			Assert.DoesNotThrow(() => Assert.FileExists(ExistingFile));
			Assert.DoesNotThrow(() => Assert.FileExists(ExistingFileInfo));
		}

		[TestMethod]
		public void FileNotExists() {
			Assert.Throws<ArgumentNullException>(() => Assert.FileNotExists(null as string));
			Assert.Throws<ArgumentNullException>(() => Assert.FileNotExists(null as FileInfo));
			Assert.DoesNotThrow(() => Assert.FileNotExists(NonExistingFile));
			Assert.DoesNotThrow(() => Assert.FileNotExists(NonExistingFileInfo));
			Assert.DoesNotThrow(() => Assert.FileNotExists(new FileInfo(NonExistingFile)));
			Assert.Throws<AssertionException>(() => Assert.FileNotExists(ExistingFile));
			Assert.Throws<AssertionException>(() => Assert.FileNotExists(ExistingFileInfo));
		}

		[TestMethod]
		public void DirectoryExists() {
			Assert.Throws<ArgumentNullException>(() => Assert.DirectoryExists(null as string));
			Assert.Throws<ArgumentNullException>(() => Assert.DirectoryExists(null as DirectoryInfo));
			Assert.Throws<AssertionException>(() => Assert.DirectoryExists(NonExistingDirectory));
			Assert.Throws<AssertionException>(() => Assert.DirectoryExists(NonExistingDirectoryInfo));
			Assert.Throws<AssertionException>(() => Assert.DirectoryExists(new DirectoryInfo(NonExistingDirectory)));
			Assert.DoesNotThrow(() => Assert.DirectoryExists(ExistingDirectory));
			Assert.DoesNotThrow(() => Assert.DirectoryExists(ExistingDirectoryInfo));
		}

		[TestMethod]
		public void DirectoryNotExists() {
			Assert.Throws<ArgumentNullException>(() => Assert.DirectoryNotExists(null as string));
			Assert.Throws<ArgumentNullException>(() => Assert.DirectoryNotExists(null as DirectoryInfo));
			Assert.DoesNotThrow(() => Assert.DirectoryNotExists(NonExistingDirectory));
			Assert.DoesNotThrow(() => Assert.DirectoryNotExists(NonExistingDirectoryInfo));
			Assert.DoesNotThrow(() => Assert.DirectoryNotExists(new DirectoryInfo(NonExistingDirectory)));
			Assert.Throws<AssertionException>(() => Assert.DirectoryNotExists(ExistingDirectory));
			Assert.Throws<AssertionException>(() => Assert.DirectoryNotExists(ExistingDirectoryInfo));
		}

		[TestMethod]
		public void FilesEqual() {
			Assert.Throws<ArgumentNullException>(() => Assert.FilesEqual(null as string, EqualCompareFile2));
			Assert.Throws<ArgumentNullException>(() => Assert.FilesEqual(null as string, EqualCompareFileInfo2));
			Assert.Throws<ArgumentNullException>(() => Assert.FilesEqual(null as FileInfo, EqualCompareFile2));
			Assert.Throws<ArgumentNullException>(() => Assert.FilesEqual(null as FileInfo, EqualCompareFileInfo2));
			Assert.Throws<ArgumentNullException>(() => Assert.FilesEqual(EqualCompareFile1, null as string));
			Assert.Throws<ArgumentNullException>(() => Assert.FilesEqual(EqualCompareFile1, null as FileInfo));
			Assert.Throws<ArgumentNullException>(() => Assert.FilesEqual(EqualCompareFileInfo1, null as string));
			Assert.Throws<ArgumentNullException>(() => Assert.FilesEqual(EqualCompareFileInfo1, null as FileInfo));

			Assert.Throws<ArgumentException>(() => Assert.FilesEqual(string.Empty, EqualCompareFile2));
			Assert.Throws<ArgumentException>(() => Assert.FilesEqual(EqualCompareFile1, string.Empty));

			Assert.Throws<ArgumentException>(() => Assert.FilesEqual(NonExistingFile, ExistingFile));
			Assert.Throws<ArgumentException>(() => Assert.FilesEqual(NonExistingFileInfo, ExistingFile));
			Assert.Throws<ArgumentException>(() => Assert.FilesEqual(NonExistingFile, ExistingFileInfo));
			Assert.Throws<ArgumentException>(() => Assert.FilesEqual(NonExistingFileInfo, ExistingFileInfo));
			Assert.Throws<ArgumentException>(() => Assert.FilesEqual(ExistingFile, NonExistingFile));
			Assert.Throws<ArgumentException>(() => Assert.FilesEqual(ExistingFile, NonExistingFileInfo));
			Assert.Throws<ArgumentException>(() => Assert.FilesEqual(ExistingFileInfo, NonExistingFile));
			Assert.Throws<ArgumentException>(() => Assert.FilesEqual(ExistingFileInfo, NonExistingFileInfo));

			Assert.DoesNotThrow(() => Assert.FilesEqual(EqualCompareFile1, EqualCompareFile1));
			Assert.DoesNotThrow(() => Assert.FilesEqual(EqualCompareFile1, EqualCompareFileInfo1));
			Assert.DoesNotThrow(() => Assert.FilesEqual(EqualCompareFileInfo1, EqualCompareFile1));
			Assert.DoesNotThrow(() => Assert.FilesEqual(EqualCompareFileInfo1, EqualCompareFileInfo1));

			Assert.DoesNotThrow(() => Assert.FilesEqual(EqualCompareFile1, EqualCompareFile2));
			Assert.DoesNotThrow(() => Assert.FilesEqual(EqualCompareFileInfo1, EqualCompareFileInfo2));
			Assert.DoesNotThrow(() => Assert.FilesEqual(EqualCompareFile1, EqualCompareFileInfo2));
			Assert.DoesNotThrow(() => Assert.FilesEqual(EqualCompareFileInfo1, EqualCompareFile2));

			Assert.Throws<AssertionException>(() => Assert.FilesEqual(EqualCompareFile1, NotEqualCompareFileLength));
			Assert.Throws<AssertionException>(() => Assert.FilesEqual(EqualCompareFile1, NotEqualCompareFileLengthInfo));
			Assert.Throws<AssertionException>(() => Assert.FilesEqual(EqualCompareFileInfo1, NotEqualCompareFileLength));
			Assert.Throws<AssertionException>(() => Assert.FilesEqual(EqualCompareFileInfo1, NotEqualCompareFileLengthInfo));

			Assert.Throws<AssertionException>(() => Assert.FilesEqual(EqualCompareFile1, NotEqualCompareFileData));
			Assert.Throws<AssertionException>(() => Assert.FilesEqual(EqualCompareFile1, NotEqualCompareFileDataInfo));
			Assert.Throws<AssertionException>(() => Assert.FilesEqual(EqualCompareFileInfo1, NotEqualCompareFileData));
			Assert.Throws<AssertionException>(() => Assert.FilesEqual(EqualCompareFileInfo1, NotEqualCompareFileDataInfo));
		}

		[TestMethod]
		public void FilesNotEqual() {
			Assert.Throws<ArgumentNullException>(() => Assert.FilesNotEqual(null as string, EqualCompareFile2));
			Assert.Throws<ArgumentNullException>(() => Assert.FilesNotEqual(null as string, EqualCompareFileInfo2));
			Assert.Throws<ArgumentNullException>(() => Assert.FilesNotEqual(null as FileInfo, EqualCompareFile2));
			Assert.Throws<ArgumentNullException>(() => Assert.FilesNotEqual(null as FileInfo, EqualCompareFileInfo2));
			Assert.Throws<ArgumentNullException>(() => Assert.FilesNotEqual(EqualCompareFile1, null as string));
			Assert.Throws<ArgumentNullException>(() => Assert.FilesNotEqual(EqualCompareFile1, null as FileInfo));
			Assert.Throws<ArgumentNullException>(() => Assert.FilesNotEqual(EqualCompareFileInfo1, null as string));
			Assert.Throws<ArgumentNullException>(() => Assert.FilesNotEqual(EqualCompareFileInfo1, null as FileInfo));

			Assert.Throws<ArgumentException>(() => Assert.FilesNotEqual(string.Empty, EqualCompareFile2));
			Assert.Throws<ArgumentException>(() => Assert.FilesNotEqual(EqualCompareFile1, string.Empty));

			Assert.Throws<ArgumentException>(() => Assert.FilesNotEqual(NonExistingFile, ExistingFile));
			Assert.Throws<ArgumentException>(() => Assert.FilesNotEqual(NonExistingFileInfo, ExistingFile));
			Assert.Throws<ArgumentException>(() => Assert.FilesNotEqual(NonExistingFile, ExistingFileInfo));
			Assert.Throws<ArgumentException>(() => Assert.FilesNotEqual(NonExistingFileInfo, ExistingFileInfo));
			Assert.Throws<ArgumentException>(() => Assert.FilesNotEqual(ExistingFile, NonExistingFile));
			Assert.Throws<ArgumentException>(() => Assert.FilesNotEqual(ExistingFile, NonExistingFileInfo));
			Assert.Throws<ArgumentException>(() => Assert.FilesNotEqual(ExistingFileInfo, NonExistingFile));
			Assert.Throws<ArgumentException>(() => Assert.FilesNotEqual(ExistingFileInfo, NonExistingFileInfo));

			Assert.Throws<AssertionException>(() => Assert.FilesNotEqual(EqualCompareFile1, EqualCompareFile1));
			Assert.Throws<AssertionException>(() => Assert.FilesNotEqual(EqualCompareFile1, EqualCompareFileInfo1));
			Assert.Throws<AssertionException>(() => Assert.FilesNotEqual(EqualCompareFileInfo1, EqualCompareFile1));
			Assert.Throws<AssertionException>(() => Assert.FilesNotEqual(EqualCompareFileInfo1, EqualCompareFileInfo1));

			Assert.Throws<AssertionException>(() => Assert.FilesNotEqual(EqualCompareFile1, EqualCompareFile2));
			Assert.Throws<AssertionException>(() => Assert.FilesNotEqual(EqualCompareFileInfo1, EqualCompareFileInfo2));
			Assert.Throws<AssertionException>(() => Assert.FilesNotEqual(EqualCompareFile1, EqualCompareFileInfo2));
			Assert.Throws<AssertionException>(() => Assert.FilesNotEqual(EqualCompareFileInfo1, EqualCompareFile2));

			Assert.DoesNotThrow(() => Assert.FilesNotEqual(EqualCompareFile1, NotEqualCompareFileLength));
			Assert.DoesNotThrow(() => Assert.FilesNotEqual(EqualCompareFile1, NotEqualCompareFileLengthInfo));
			Assert.DoesNotThrow(() => Assert.FilesNotEqual(EqualCompareFileInfo1, NotEqualCompareFileLength));
			Assert.DoesNotThrow(() => Assert.FilesNotEqual(EqualCompareFileInfo1, NotEqualCompareFileLengthInfo));

			Assert.DoesNotThrow(() => Assert.FilesNotEqual(EqualCompareFile1, NotEqualCompareFileData));
			Assert.DoesNotThrow(() => Assert.FilesNotEqual(EqualCompareFile1, NotEqualCompareFileDataInfo));
			Assert.DoesNotThrow(() => Assert.FilesNotEqual(EqualCompareFileInfo1, NotEqualCompareFileData));
			Assert.DoesNotThrow(() => Assert.FilesNotEqual(EqualCompareFileInfo1, NotEqualCompareFileDataInfo));
		}
	}
}
