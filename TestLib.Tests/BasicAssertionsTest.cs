using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib.Framework;
using Assert = TestLib.Framework.Assert;

namespace TestLib.Tests {
	public partial class AssertTest {
		private class ExceptionTest : Exception {
			public ExceptionTest() : base() { }
			public ExceptionTest(Exception innerException) : base(string.Empty, innerException) { }
		}
		private class DerivedExceptionTest : ExceptionTest {
			public DerivedExceptionTest() : base() { }
			public DerivedExceptionTest(Exception innerException) : base(innerException) { }
		}

		private static void EmptyNoThrow() {
			// Intentionally blank
		}

		private static void ThrowsPlain() {
			throw new Exception();
		}

		private static void ThrowsDerived() {
			throw new DerivedExceptionTest();
		}

		private static void ThrowsBase() {
			throw new ExceptionTest();
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void Fail() {
			Assert.ThrowsExact<AssertionException>(Assert.Failure);
			Assert.ThrowsExact<AssertionException>(() => Assert.Fail());
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void True() {
			Assert.Throws<ArgumentNullException>(() => Assert.True(null as Func<bool>));
			Assert.DoesNotThrow(() => Assert.True(true));
			Assert.DoesNotThrow(() => Assert.True(() => true));
			Assert.ThrowsExact<AssertionException>(() => Assert.True(false));
			Assert.ThrowsExact<AssertionException>(() => Assert.True(null as bool?));
			Assert.ThrowsExact<AssertionException>(() => Assert.True(() => false));
			Assert.ThrowsExact<AssertionException>(() => Assert.True(() => null as bool?));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void False() {
			Assert.Throws<ArgumentNullException>(() => Assert.False(null as Func<bool>));
			Assert.DoesNotThrow(() => Assert.False(false));
			Assert.DoesNotThrow(() => Assert.False(() => false));
			Assert.ThrowsExact<AssertionException>(() => Assert.False(true));
			Assert.ThrowsExact<AssertionException>(() => Assert.False(null as bool?));
			Assert.ThrowsExact<AssertionException>(() => Assert.False(() => true));
			Assert.ThrowsExact<AssertionException>(() => Assert.False(() => null as bool?));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void Throws() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.Throws<AssertionException>(null));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.Throws(typeof(AssertionException), null));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.Throws(null, EmptyNoThrow));
			Assert.ThrowsExact<ArgumentException>(() => Assert.Throws(typeof(AssertTest), EmptyNoThrow));
			Assert.DoesNotThrow(() => Assert.Throws(typeof(Exception), ThrowsPlain));
			Assert.DoesNotThrow(() => Assert.Throws(typeof(SystemException), () => { throw new SystemException(""); }));
			Assert.DoesNotThrow(() => Assert.Throws(typeof(ArgumentException), () => { throw new ArgumentException(""); }));
			Assert.DoesNotThrow(() => Assert.Throws(typeof(ArgumentNullException), () => { throw new ArgumentNullException(""); }));
			Assert.DoesNotThrow(() => Assert.Throws(typeof(DerivedExceptionTest), ThrowsDerived));
			Assert.DoesNotThrow(() => Assert.Throws(typeof(ExceptionTest), ThrowsDerived));

			Assert.ThrowsExact<AssertionException>(() => Assert.Throws(typeof(DerivedExceptionTest), ThrowsBase));
			Assert.DoesNotThrow(() => Assert.Throws<Exception>(ThrowsPlain));
			Assert.DoesNotThrow(() => Assert.Throws<SystemException>(() => { throw new SystemException(""); }));
			Assert.DoesNotThrow(() => Assert.Throws<ArgumentException>(() => { throw new ArgumentException(""); }));
			Assert.DoesNotThrow(() => Assert.Throws<ArgumentNullException>(() => { throw new ArgumentNullException(""); }));
			Assert.DoesNotThrow(() => Assert.Throws<DerivedExceptionTest>(ThrowsDerived));
			Assert.DoesNotThrow(() => Assert.Throws<ExceptionTest>(ThrowsDerived));
			Assert.ThrowsExact<AssertionException>(() => Assert.Throws<ArgumentException>(EmptyNoThrow));
			Assert.ThrowsExact<AssertionException>(() => Assert.Throws<NotSupportedException>(() => { throw new ArgumentNullException(); }));

			Assert.ThrowsExact<AssertionException>(() => Assert.Throws(typeof(NotSupportedException), () => { throw new ArgumentNullException(); }));
			Assert.DoesNotThrow(() => Assert.Throws(typeof(DerivedExceptionTest), ThrowsDerived));
			Assert.DoesNotThrow(() => Assert.Throws(typeof(ExceptionTest), ThrowsDerived));

			try {
				Assert.Throws<ArgumentNullException>(() => { throw new InvalidOperationException("Testing"); });
				// This should not occur
				throw new InvalidOperationException();
			}
			catch (AssertionException e) {
				if (e.InnerException.GetType() != typeof(InvalidOperationException)) {
					// This should not occur
					throw;
				}
			}
			catch (Exception) {
				// This should not occur
				throw;
			}
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void ThrowsPredicate() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.Throws<AssertionException>(null, e => e != null));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.Throws<AssertionException>(EmptyNoThrow, null as Func<AssertionException, bool>));
			Assert.DoesNotThrow(() => Assert.Throws<Exception>(ThrowsPlain, e => e != null));

			Assert.ThrowsExact<AssertionException>(() => Assert.Throws<DerivedExceptionTest>(ThrowsBase, e => e != null));
			Assert.ThrowsExact<AssertionException>(() => Assert.Throws<ArgumentException>(EmptyNoThrow, e => e != null));
			Assert.ThrowsExact<AssertionException>(() => Assert.Throws<NotSupportedException>(() => { throw new ArgumentNullException(); }, e => e != null));
			Assert.DoesNotThrow(() => Assert.Throws<DerivedExceptionTest>(ThrowsDerived, e => e != null));
			Assert.DoesNotThrow(() => Assert.Throws<ExceptionTest>(ThrowsDerived, e => e != null));
			Assert.ThrowsExact<AssertionException>(() => Assert.Throws<DerivedExceptionTest>(ThrowsDerived, e => e == null));
			Assert.ThrowsExact<AssertionException>(() => Assert.Throws<ExceptionTest>(ThrowsDerived, e => e == null));

			try {
				Assert.Throws<ArgumentNullException>(() => { throw new InvalidOperationException("Testing"); }, e => e != null);
				// This should not occur
				throw new InvalidOperationException();
			}
			catch (AssertionException e) {
				if (e.InnerException.GetType() != typeof(InvalidOperationException)) {
					// This should not occur
					throw;
				}
			}
			catch (Exception) {
				// This should not occur
				throw;
			}

			Assert.ThrowsExact<AssertionException>(() => Assert.Throws<Exception>(() => { throw new Exception(); }, e => e.InnerException != null));
			Assert.DoesNotThrow(() => Assert.Throws<Exception>(() => { throw new Exception("Test", new InvalidOperationException("Inner")); }, e => e.InnerException != null && e.InnerException.GetType() == typeof(InvalidOperationException) && e.InnerException.Message == "Inner"));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void ThrowsExact() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.ThrowsExact<AssertionException>(null));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.ThrowsExact(typeof(AssertionException), null));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.ThrowsExact(null, EmptyNoThrow));
			Assert.ThrowsExact<ArgumentException>(() => Assert.ThrowsExact(typeof(AssertTest), EmptyNoThrow));
			Assert.DoesNotThrow(() => Assert.ThrowsExact(typeof(Exception), ThrowsPlain));
			Assert.DoesNotThrow(() => Assert.ThrowsExact(typeof(DerivedExceptionTest), ThrowsDerived));
			Assert.DoesNotThrow(() => Assert.ThrowsExact(typeof(SystemException), () => { throw new SystemException(""); }));
			Assert.DoesNotThrow(() => Assert.ThrowsExact(typeof(ArgumentException), () => { throw new ArgumentException(""); }));
			Assert.DoesNotThrow(() => Assert.ThrowsExact(typeof(ArgumentNullException), () => { throw new ArgumentNullException(""); }));

			Assert.ThrowsExact<AssertionException>(() => Assert.ThrowsExact(typeof(DerivedExceptionTest), ThrowsBase));
			Assert.DoesNotThrow(() => Assert.ThrowsExact<Exception>(ThrowsPlain));
			Assert.DoesNotThrow(() => Assert.ThrowsExact<SystemException>(() => { throw new SystemException(""); }));
			Assert.DoesNotThrow(() => Assert.ThrowsExact<ArgumentException>(() => { throw new ArgumentException(""); }));
			Assert.DoesNotThrow(() => Assert.ThrowsExact<ArgumentNullException>(() => { throw new ArgumentNullException(""); }));
			Assert.DoesNotThrow(() => Assert.ThrowsExact<DerivedExceptionTest>(ThrowsDerived));
			Assert.ThrowsExact<AssertionException>(() => Assert.ThrowsExact<ExceptionTest>(ThrowsDerived));
			Assert.ThrowsExact<AssertionException>(() => Assert.ThrowsExact<ArgumentException>(EmptyNoThrow));
			Assert.ThrowsExact<AssertionException>(() => Assert.ThrowsExact<NotSupportedException>(() => { throw new ArgumentNullException(); }));

			Assert.ThrowsExact<AssertionException>(() => Assert.ThrowsExact(typeof(NotSupportedException), () => { throw new ArgumentNullException(); }));
			Assert.DoesNotThrow(() => Assert.ThrowsExact(typeof(DerivedExceptionTest), ThrowsDerived));
			Assert.ThrowsExact<AssertionException>(() => Assert.ThrowsExact(typeof(ExceptionTest), ThrowsDerived));

			try {
				Assert.ThrowsExact<ArgumentNullException>(() => { throw new InvalidOperationException("Testing"); });
				// This should not occur
				throw new InvalidOperationException();
			}
			catch (AssertionException e) {
				if (e.InnerException.GetType() != typeof(InvalidOperationException)) {
					// This should not occur
					throw;
				}
			}
			catch (Exception) {
				// This should not occur
				throw;
			}
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void ThrowsExactPredicate() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.ThrowsExact<AssertionException>(null, e => e != null));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.ThrowsExact<AssertionException>(EmptyNoThrow, null as Func<AssertionException, bool>));
			Assert.DoesNotThrow(() => Assert.ThrowsExact<Exception>(ThrowsPlain, e => e != null));

			Assert.ThrowsExact<AssertionException>(() => Assert.ThrowsExact<DerivedExceptionTest>(ThrowsBase, e => e != null));
			Assert.ThrowsExact<AssertionException>(() => Assert.ThrowsExact<ArgumentException>(EmptyNoThrow, e => e != null));
			Assert.ThrowsExact<AssertionException>(() => Assert.ThrowsExact<NotSupportedException>(() => { throw new ArgumentNullException(); }, e => e != null));
			Assert.DoesNotThrow(() => Assert.ThrowsExact<DerivedExceptionTest>(ThrowsDerived, e => e != null));
			Assert.ThrowsExact<AssertionException>(() => Assert.ThrowsExact<ExceptionTest>(ThrowsDerived, e => e != null));
			Assert.ThrowsExact<AssertionException>(() => Assert.ThrowsExact<DerivedExceptionTest>(ThrowsDerived, e => e == null));
			Assert.ThrowsExact<AssertionException>(() => Assert.ThrowsExact<ExceptionTest>(ThrowsDerived, e => e == null));

			try {
				Assert.ThrowsExact<ArgumentNullException>(() => { throw new InvalidOperationException("Testing"); }, e => e != null);
				// This should not occur
				throw new InvalidOperationException();
			}
			catch (AssertionException e) {
				if (e.InnerException.GetType() != typeof(InvalidOperationException)) {
					// This should not occur
					throw;
				}
			}
			catch (Exception) {
				// This should not occur
				throw;
			}

			Assert.ThrowsExact<AssertionException>(() => Assert.ThrowsExact<Exception>(() => { throw new Exception(); }, e => e.InnerException != null));
			Assert.DoesNotThrow(() => Assert.ThrowsExact<Exception>(() => { throw new Exception("Test", new InvalidOperationException("Inner")); }, e => e.InnerException != null && e.InnerException.GetType() == typeof(InvalidOperationException) && e.InnerException.Message == "Inner"));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void DoesNotThrow() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.DoesNotThrow(null));
			Assert.ThrowsExact<AssertionException>(() => Assert.DoesNotThrow(() => { throw new ArgumentException("Testing"); }));
			Assert.DoesNotThrow(() => Assert.DoesNotThrow(EmptyNoThrow));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void ExceptionAttachments() {
			var exception = new AssertionException("Testing {0}", 123);

			try {
				Assert.DoesNotThrow(() => { throw new ArgumentException(); }, exception);
			}
			catch (AssertionException e) {
				Assert.Equal(e.Message, "Testing 123");
			}
		}
	}
}
