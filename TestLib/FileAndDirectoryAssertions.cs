using System;
using System.IO;
using System.Linq;

namespace TestLib.Framework {
	public partial class Assert {
		/// <summary>
		/// Asserts that <paramref name="file" /> exists.
		/// </summary>
		/// <param name="file">The file to check.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="file" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void FileExists(string file, AssertionException exception = null) {
			if (file == null) throw new ArgumentNullException(nameof(file));
			if (!File.Exists(file)) throw exception ?? new AssertionException("File did not exist");
		}

		/// <summary>
		/// Asserts that <paramref name="file" /> exists.
		/// </summary>
		/// <param name="file">The file to check.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="file" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void FileExists(FileInfo file, AssertionException exception = null) {
			if (file == null) throw new ArgumentNullException(nameof(file));
			if (!file.Exists) throw exception ?? new AssertionException("File did not exist");
		}

		/// <summary>
		/// Asserts that <paramref name="file" /> does not exist.
		/// </summary>
		/// <param name="file">The file to check.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="file" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void FileNotExists(string file, AssertionException exception = null) {
			if (file == null) throw new ArgumentNullException(nameof(file));
			if (File.Exists(file)) throw exception ?? new AssertionException("File exists");
		}

		/// <summary>
		/// Asserts that <paramref name="file" /> does not exist.
		/// </summary>
		/// <param name="file">The file to check.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="file" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void FileNotExists(FileInfo file, AssertionException exception = null) {
			if (file == null) throw new ArgumentNullException(nameof(file));
			if (file.Exists) throw exception ?? new AssertionException("File exists");
		}

		/// <summary>
		/// Asserts that two specified files are equal.
		/// This has a very high threshold for equality: byte-by-byte binary equality.
		/// If you need a looser definition of equality, this is unsupported at this time.
		/// </summary>
		/// <param name="file1">The file to check.</param>
		/// <param name="file2">The file to check.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentException"><paramref name="file1" /> doesn't exist.</exception>
		/// <exception cref="ArgumentException"><paramref name="file2" /> doesn't exist.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="file1" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="file2" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void FilesEqual(string file1, string file2, AssertionException exception = null) {
			if (file1 == null) throw new ArgumentNullException(nameof(file1));
			if (file2 == null) throw new ArgumentNullException(nameof(file2));

			FileInfo info1 = new FileInfo(file1);
			FileInfo info2 = new FileInfo(file2);

			FilesEqual(info1, info2, exception: exception);
		}

		/// <summary>
		/// Asserts that two specified files are equal.
		/// This has a very high threshold for equality: byte-by-byte binary equality.
		/// If you need a looser definition of equality, this is unsupported at this time.
		/// </summary>
		/// <param name="file1">The file to check.</param>
		/// <param name="file2">The file to check.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentException"><paramref name="file1" /> doesn't exist.</exception>
		/// <exception cref="ArgumentException"><paramref name="file2" /> doesn't exist.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="file1" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="file2" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void FilesEqual(FileInfo file1, string file2, AssertionException exception = null) {
			if (file1 == null) throw new ArgumentNullException(nameof(file1));
			if (file2 == null) throw new ArgumentNullException(nameof(file2));

			FileInfo info2 = new FileInfo(file2);

			FilesEqual(file1, info2, exception: exception);
		}

		/// <summary>
		/// Asserts that two specified files are equal.
		/// This has a very high threshold for equality: byte-by-byte binary equality.
		/// If you need a looser definition of equality, this is unsupported at this time.
		/// </summary>
		/// <param name="file1">The file to check.</param>
		/// <param name="file2">The file to check.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentException"><paramref name="file1" /> doesn't exist.</exception>
		/// <exception cref="ArgumentException"><paramref name="file2" /> doesn't exist.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="file1" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="file2" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void FilesEqual(string file1, FileInfo file2, AssertionException exception = null) {
			if (file1 == null) throw new ArgumentNullException(nameof(file1));
			if (file2 == null) throw new ArgumentNullException(nameof(file2));

			FileInfo info1 = new FileInfo(file1);

			FilesEqual(info1, file2, exception: exception);
		}

		/// <summary>
		/// Asserts that two specified files are equal.
		/// This has a very high threshold for equality: byte-by-byte binary equality.
		/// If you need a looser definition of equality, this is unsupported at this time.
		/// </summary>
		/// <param name="file1">The file to check.</param>
		/// <param name="file2">The file to check.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentException"><paramref name="file1" /> doesn't exist.</exception>
		/// <exception cref="ArgumentException"><paramref name="file2" /> doesn't exist.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="file1" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="file2" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void FilesEqual(FileInfo file1, FileInfo file2, AssertionException exception = null) {
			if (file1 == null) throw new ArgumentNullException(nameof(file1));
			if (file2 == null) throw new ArgumentNullException(nameof(file2));

			if (!file1.Exists) throw new ArgumentException("File must exist", nameof(file1));
			if (!file2.Exists) throw new ArgumentException("File must exist", nameof(file2));

			if (file1.Length != file2.Length) {
				throw exception ?? new AssertionException("Specified files are not equal");
			}

			if (string.Compare(file1.FullName, file2.FullName, StringComparison.InvariantCultureIgnoreCase) == 0) {
				// If they're the same file, we can safely not do anything else
				return;
			}

			using (FileStream fs1 = file1.OpenRead(), fs2 = file2.OpenRead()) {
				const int readSize = 65536;
				byte[] buffer1 = new byte[readSize];
				byte[] buffer2 = new byte[readSize];
				do {
					int read1 = fs1.Read(buffer1, 0, readSize);
					int read2 = fs2.Read(buffer2, 0, readSize);
					if (read1 != read2) {
						throw exception ?? new AssertionException("Specified files are not equal");
					}
					if (!Enumerable.SequenceEqual(buffer1, buffer2)) {
						throw exception ?? new AssertionException("Specified files are not equal");
					}
					if (read1 < readSize) {
						break;
					}
				} while (true);
			}
		}

		/// <summary>
		/// Asserts that two specified files are not equal.
		/// This has a very high threshold for equality: byte-by-byte binary equality.
		/// If you need a looser definition of equality, this is unsupported at this time.
		/// </summary>
		/// <param name="file1">The file to check.</param>
		/// <param name="file2">The file to check.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentException"><paramref name="file1" /> doesn't exist.</exception>
		/// <exception cref="ArgumentException"><paramref name="file2" /> doesn't exist.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="file1" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="file2" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void FilesNotEqual(string file1, string file2, AssertionException exception = null) {
			if (file1 == null) throw new ArgumentNullException(nameof(file1));
			if (file2 == null) throw new ArgumentNullException(nameof(file2));

			FileInfo info1 = new FileInfo(file1);
			FileInfo info2 = new FileInfo(file2);

			FilesNotEqual(info1, info2, exception: exception);
		}

		/// <summary>
		/// Asserts that two specified files are not equal.
		/// This has a very high threshold for equality: byte-by-byte binary equality.
		/// If you need a looser definition of equality, this is unsupported at this time.
		/// </summary>
		/// <param name="file1">The file to check.</param>
		/// <param name="file2">The file to check.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentException"><paramref name="file1" /> doesn't exist.</exception>
		/// <exception cref="ArgumentException"><paramref name="file2" /> doesn't exist.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="file1" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="file2" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void FilesNotEqual(FileInfo file1, string file2, AssertionException exception = null) {
			if (file1 == null) throw new ArgumentNullException(nameof(file1));
			if (file2 == null) throw new ArgumentNullException(nameof(file2));

			FileInfo info2 = new FileInfo(file2);

			FilesNotEqual(file1, info2, exception: exception);
		}

		/// <summary>
		/// Asserts that two specified files are not equal.
		/// This has a very high threshold for equality: byte-by-byte binary equality.
		/// If you need a looser definition of equality, this is unsupported at this time.
		/// </summary>
		/// <param name="file1">The file to check.</param>
		/// <param name="file2">The file to check.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentException"><paramref name="file1" /> doesn't exist.</exception>
		/// <exception cref="ArgumentException"><paramref name="file2" /> doesn't exist.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="file1" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="file2" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void FilesNotEqual(string file1, FileInfo file2, AssertionException exception = null) {
			if (file1 == null) throw new ArgumentNullException(nameof(file1));
			if (file2 == null) throw new ArgumentNullException(nameof(file2));

			FileInfo info1 = new FileInfo(file1);

			FilesNotEqual(info1, file2, exception: exception);
		}

		/// <summary>
		/// Asserts that two specified files are not equal.
		/// This has a very high threshold for equality: byte-by-byte binary equality.
		/// If you need a looser definition of equality, this is unsupported at this time.
		/// </summary>
		/// <param name="file1">The file to check.</param>
		/// <param name="file2">The file to check.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentException"><paramref name="file1" /> doesn't exist.</exception>
		/// <exception cref="ArgumentException"><paramref name="file2" /> doesn't exist.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="file1" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="file2" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void FilesNotEqual(FileInfo file1, FileInfo file2, AssertionException exception = null) {
			if (file1 == null) throw new ArgumentNullException(nameof(file1));
			if (file2 == null) throw new ArgumentNullException(nameof(file2));

			if (!file1.Exists) throw new ArgumentException("File must exist", nameof(file1));
			if (!file2.Exists) throw new ArgumentException("File must exist", nameof(file2));

			if (file1.Length != file2.Length) {
				return;
			}

			if (string.Compare(file1.FullName, file2.FullName, StringComparison.InvariantCultureIgnoreCase) == 0) {
				// If they're the same file, we can safely not do anything else
				throw exception ?? new AssertionException("Specified files are equal");
			}

			using (FileStream fs1 = file1.OpenRead(), fs2 = file2.OpenRead()) {
				const int readSize = 65536;
				byte[] buffer1 = new byte[readSize];
				byte[] buffer2 = new byte[readSize];
				do {
					int read1 = fs1.Read(buffer1, 0, readSize);
					int read2 = fs2.Read(buffer2, 0, readSize);
					if (read1 != read2) {
						return;
					}
					if (!Enumerable.SequenceEqual(buffer1, buffer2)) {
						return;
					}
					if (read1 < readSize) {
						break;
					}
				} while (true);
			}

			throw exception ?? new AssertionException("Specified files are equal");
		}

		/// <summary>
		/// Asserts that <paramref name="dir" /> exists.
		/// </summary>
		/// <param name="dir">The directry to check.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentException"><paramref name="dir" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void DirectoryExists(string dir, AssertionException exception = null) {
			if (dir == null) throw new ArgumentNullException(nameof(dir));
			if (!Directory.Exists(dir)) throw exception ?? new AssertionException("Directory did not exist");
		}

		/// <summary>
		/// Asserts that <paramref name="dir" /> exists.
		/// </summary>
		/// <param name="dir">The directry to check.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentException"><paramref name="dir" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void DirectoryExists(DirectoryInfo dir, AssertionException exception = null) {
			if (dir == null) throw new ArgumentNullException(nameof(dir));
			if (!dir.Exists) throw exception ?? new AssertionException("Directory did not exist");
		}

		/// <summary>
		/// Asserts that <paramref name="dir" /> does not exist.
		/// </summary>
		/// <param name="dir">The directry to check.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentException"><paramref name="dir" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void DirectoryNotExists(string dir, AssertionException exception = null) {
			if (dir == null) throw new ArgumentNullException(nameof(dir));
			if (Directory.Exists(dir)) throw exception ?? new AssertionException("Directory exists");
		}

		/// <summary>
		/// Asserts that <paramref name="dir" /> does not exist.
		/// </summary>
		/// <param name="dir">The directry to check.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentException"><paramref name="dir" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void DirectoryNotExists(DirectoryInfo dir, AssertionException exception = null) {
			if (dir == null) throw new ArgumentNullException(nameof(dir));
			if (dir.Exists) throw exception ?? new AssertionException("Directory exists");
		}
	}
}
