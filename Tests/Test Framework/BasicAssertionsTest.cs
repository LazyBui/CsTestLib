using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test {
	public partial class AssertTest {
		[TestMethod]
		public void True() {
			Assert.DoesNotThrow(() => Assert.True(true));
			Assert.Throws<AssertionException>(() => Assert.True(false));
		}

		[TestMethod]
		public void False() {
			Assert.DoesNotThrow(() => Assert.False(false));
			Assert.Throws<AssertionException>(() => Assert.False(true));
		}

		[TestMethod]
		public void Throws() {
			try {
				Assert.Throws<AssertionException>(null);
				throw new AssertionException("Throw did not throw when it should"); 
			}
			catch (ArgumentNullException) { }

			try {
				Assert.Throws<ArgumentException>(() => { throw new ArgumentException("Testing"); });
			}
			catch (Exception) {
				// This should not occur
				throw;
			}

			try {
				Assert.Throws<ArgumentNullException>(() => { throw new ArgumentException("Testing"); });
			}
			catch (AssertionException e) {
				if (e.InnerException.GetType() != typeof(ArgumentException)) {
					// This should not occur
					throw;
				}
			}
			catch (Exception) {
				// This should not occur
				throw;
			}

			bool thrown = false;
			try {
				Assert.Throws<ArgumentException>(() => { });
			}
			catch (AssertionException) {
				thrown = true;
			}
			catch (Exception) {
				// This should not occur
				throw;
			}
			if (!thrown) throw new AssertionException("Throw did not throw when it should");
		}

		[TestMethod]
		public void DoesNotThrow() {
			try {
				Assert.DoesNotThrow(null);
				throw new AssertionException("DoesNotThrow did not throw when it should");
			}
			catch (ArgumentNullException) { }

			bool thrown = false;
			try {
				Assert.DoesNotThrow(() => { throw new ArgumentException("Testing"); });
			}
			catch (Exception) {
				thrown = true;
			}
			if (!thrown) throw new AssertionException("Should have thrown, test failure");

			try {
				Assert.DoesNotThrow(() => { });
			}
			catch (Exception) {
				throw new AssertionException("Should not have thrown, test failure");
			}
		}

		[TestMethod]
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
