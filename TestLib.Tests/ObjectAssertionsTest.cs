using System;
using TestLib.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = TestLib.Framework.Assert;

namespace TestLib.Tests {
	public partial class AssertTest {
		[TestMethod]
		[TestCategory("TestLib")]
		public void Null() {
			Assert.DoesNotThrow(() => Assert.Null(null as string));
			Assert.DoesNotThrow(() => Assert.Null(null as int?));
			Assert.ThrowsExact<AssertionException>(() => Assert.Null(new object()));
			Assert.ThrowsExact<AssertionException>(() => Assert.Null((1 as int?)));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void NotNull() {
			Assert.DoesNotThrow(() => Assert.NotNull(new object()));
			Assert.DoesNotThrow(() => Assert.NotNull((1 as int?)));
			Assert.ThrowsExact<AssertionException>(() => Assert.NotNull(null as string));
			Assert.ThrowsExact<AssertionException>(() => Assert.NotNull(null as int?));
		}

		[TestMethod]
		[TestCategory("TestLib")]
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
		[TestCategory("TestLib")]
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
