using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test {
	public partial class AssertTest {
		[TestMethod]
		public void Null() {
			Assert.DoesNotThrow(() => Assert.Null(null));
			Assert.Throws<AssertionException>(() => Assert.Null(new object()));
		}

		[TestMethod]
		public void NotNull() {
			Assert.DoesNotThrow(() => Assert.NotNull(new object()));
			Assert.Throws<AssertionException>(() => Assert.NotNull(null));
		}

		[TestMethod]
		public void IsType() {
			Assert.Throws<ArgumentNullException>(() => Assert.IsType<string>(null));
			Assert.Throws<AssertionException>(() => Assert.IsType<int>("hello"));
			Assert.Throws<AssertionException>(() => Assert.IsType<int?>(1));
			Assert.Throws<AssertionException>(() => Assert.IsType<int>(1L));
			Assert.DoesNotThrow(() => Assert.IsType<int>(1));
		}

		[TestMethod]
		public void IsNotType() {
			Assert.Throws<ArgumentNullException>(() => Assert.IsNotType<string>(null));
			Assert.Throws<AssertionException>(() => Assert.IsNotType<int>(1));
			Assert.DoesNotThrow(() => Assert.IsNotType<int?>(1));
			Assert.DoesNotThrow(() => Assert.IsNotType<int>(1L));
			Assert.DoesNotThrow(() => Assert.IsNotType<int>("hello"));
		}

		[TestMethod]
		public void IsAssignableFromType() {
			Assert.Throws<ArgumentNullException>(() => Assert.IsAssignableFromType<string>(null));
			Assert.Throws<AssertionException>(() => Assert.IsAssignableFromType<int>("hello"));
			Assert.Throws<AssertionException>(() => Assert.IsAssignableFromType<int>(1L));
			Assert.DoesNotThrow(() => Assert.IsAssignableFromType<int>(new int?(1)));
			Assert.DoesNotThrow(() => Assert.IsAssignableFromType<int>(1));
		}

		[TestMethod]
		public void IsNotAssignableFromType() {
			Assert.Throws<ArgumentNullException>(() => Assert.IsNotAssignableFromType<string>(null));
			Assert.Throws<AssertionException>(() => Assert.IsNotAssignableFromType<int>(1));
			Assert.DoesNotThrow(() => Assert.IsNotAssignableFromType<long>(1));
			Assert.Throws<AssertionException>(() => Assert.IsNotAssignableFromType<int>(new int?(1)));
			Assert.DoesNotThrow(() => Assert.IsNotAssignableFromType<int>("hello"));
		}

		[TestMethod]
		public void Same() {
			Assert.DoesNotThrow(() => Assert.Same<object>(null, null));
			Assert.DoesNotThrow(() => {
				object o = new object();
				Assert.Same(o, o);
			});
			Assert.Throws<AssertionException>(() => Assert.Same(new object(), null));
			Assert.Throws<AssertionException>(() => Assert.Same(new object(), new object()));
		}

		[TestMethod]
		public void NotSame() {
			Assert.Throws<AssertionException>(() => Assert.NotSame<object>(null, null));
			Assert.Throws<AssertionException>(() => {
				object o = new object();
				Assert.NotSame(o, o);
			});
			Assert.DoesNotThrow(() => Assert.NotSame(new object(), null));
			Assert.DoesNotThrow(() => Assert.NotSame(new object(), new object()));
		}
	}
}
