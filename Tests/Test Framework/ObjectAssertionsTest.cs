using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test {
	public partial class AssertTest {
		[TestMethod]
		public void Null() {
			Assert.DoesNotThrow(() => Assert.Null(null));
			Assert.ThrowsExact<AssertionException>(() => Assert.Null(new object()));
		}

		[TestMethod]
		public void NotNull() {
			Assert.DoesNotThrow(() => Assert.NotNull(new object()));
			Assert.ThrowsExact<AssertionException>(() => Assert.NotNull(null));
		}

		[TestMethod]
		public void Same() {
			Assert.DoesNotThrow(() => Assert.Same<object>(null, null));
			Assert.DoesNotThrow(() => {
				object o = new object();
				Assert.Same(o, o);
			});
			Assert.ThrowsExact<AssertionException>(() => Assert.Same(new object(), null));
			Assert.ThrowsExact<AssertionException>(() => Assert.Same(null, new object()));
			Assert.ThrowsExact<AssertionException>(() => Assert.Same(new object(), new object()));
		}

		[TestMethod]
		public void NotSame() {
			Assert.ThrowsExact<AssertionException>(() => Assert.NotSame<object>(null, null));
			Assert.ThrowsExact<AssertionException>(() => {
				object o = new object();
				Assert.NotSame(o, o);
			});
			Assert.DoesNotThrow(() => Assert.NotSame(new object(), null));
			Assert.DoesNotThrow(() => Assert.NotSame(null, new object()));
			Assert.DoesNotThrow(() => Assert.NotSame(new object(), new object()));
		}
	}
}
