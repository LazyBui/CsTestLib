using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib.Framework.Util;
using Assert = TestLib.Framework.Assert;

namespace TestLib.Tests.Util {
	[TestClass]
	public class EqualityComparerStatelessTest {
		private class Testing {
			public int A { get; private set; }
			public string B { get; private set; }

			public Testing(int a, string b) {
				A = a;
				B = b;
			}
		}

		[TestMethod]
		public void Constructor() {
			Assert.ThrowsExact<ArgumentNullException>(() => new EqualityComparerStateless<Testing, int>(null));
			Assert.DoesNotThrow(() => new EqualityComparerStateless<Testing, int>(obj => obj.A));
		}

		[TestMethod]
		public void Equals() {
			var obj1 = new Testing(5, "ABC");
			var obj2 = new Testing(3, "NA");
			var obj3 = new Testing(2, "ABCDE");
			var obj4 = new Testing(5, "NA");
			var obj5 = new Testing(7, null);

			var comparer = new EqualityComparerStateless<Testing, int>(obj => obj.A);
			Assert.True(comparer.Equals(obj1, obj1));
			Assert.False(comparer.Equals(obj1, obj2));
			Assert.False(comparer.Equals(obj1, obj3));
			Assert.True(comparer.Equals(obj1, obj4));
			Assert.False(comparer.Equals(obj1, obj5));

			Assert.False(comparer.Equals(obj2, obj1));
			Assert.True(comparer.Equals(obj2, obj2));
			Assert.False(comparer.Equals(obj2, obj3));
			Assert.False(comparer.Equals(obj2, obj4));
			Assert.False(comparer.Equals(obj2, obj5));

			Assert.False(comparer.Equals(obj3, obj1));
			Assert.False(comparer.Equals(obj3, obj2));
			Assert.True(comparer.Equals(obj3, obj3));
			Assert.False(comparer.Equals(obj3, obj4));
			Assert.False(comparer.Equals(obj3, obj5));

			Assert.True(comparer.Equals(obj4, obj1));
			Assert.False(comparer.Equals(obj4, obj2));
			Assert.False(comparer.Equals(obj4, obj3));
			Assert.True(comparer.Equals(obj4, obj4));
			Assert.False(comparer.Equals(obj4, obj5));

			Assert.False(comparer.Equals(obj5, obj1));
			Assert.False(comparer.Equals(obj5, obj2));
			Assert.False(comparer.Equals(obj5, obj3));
			Assert.False(comparer.Equals(obj5, obj4));
			Assert.True(comparer.Equals(obj5, obj5));

			var stringComparer = new EqualityComparerStateless<Testing, string>(obj => obj.B);
			Assert.True(stringComparer.Equals(obj1, obj1));
			Assert.False(stringComparer.Equals(obj1, obj2));
			Assert.False(stringComparer.Equals(obj1, obj3));
			Assert.False(stringComparer.Equals(obj1, obj4));
			Assert.False(stringComparer.Equals(obj1, obj5));

			Assert.False(stringComparer.Equals(obj2, obj1));
			Assert.True(stringComparer.Equals(obj2, obj2));
			Assert.False(stringComparer.Equals(obj2, obj3));
			Assert.True(stringComparer.Equals(obj2, obj4));
			Assert.False(stringComparer.Equals(obj2, obj5));

			Assert.False(stringComparer.Equals(obj3, obj1));
			Assert.False(stringComparer.Equals(obj3, obj2));
			Assert.True(stringComparer.Equals(obj3, obj3));
			Assert.False(stringComparer.Equals(obj3, obj4));
			Assert.False(stringComparer.Equals(obj3, obj5));

			Assert.False(stringComparer.Equals(obj4, obj1));
			Assert.True(stringComparer.Equals(obj4, obj2));
			Assert.False(stringComparer.Equals(obj4, obj3));
			Assert.True(stringComparer.Equals(obj4, obj4));
			Assert.False(stringComparer.Equals(obj4, obj5));

			Assert.False(stringComparer.Equals(obj5, obj1));
			Assert.False(stringComparer.Equals(obj5, obj2));
			Assert.False(stringComparer.Equals(obj5, obj3));
			Assert.False(stringComparer.Equals(obj5, obj4));
			Assert.True(stringComparer.Equals(obj5, obj5));
		}

		[TestMethod]
		public new void GetHashCode() {
			var obj1 = new Testing(5, "ABC");
			var obj2 = new Testing(3, "NA");
			var obj3 = new Testing(2, "ABCDE");
			var obj4 = new Testing(5, "NA");
			var obj5 = new Testing(7, null);

			var comparer = new EqualityComparerStateless<Testing, int>(obj => obj.A);
			Assert.Equal(comparer.GetHashCode(obj1), obj1.A.GetHashCode());
			Assert.Equal(comparer.GetHashCode(obj2), obj2.A.GetHashCode());
			Assert.Equal(comparer.GetHashCode(obj3), obj3.A.GetHashCode());
			Assert.Equal(comparer.GetHashCode(obj4), obj4.A.GetHashCode());
			Assert.Equal(comparer.GetHashCode(obj5), obj5.A.GetHashCode());

			var stringComparer = new EqualityComparerStateless<Testing, string>(obj => obj.B);
			Assert.Equal(stringComparer.GetHashCode(obj1), obj1.B.GetHashCode());
			Assert.Equal(stringComparer.GetHashCode(obj2), obj2.B.GetHashCode());
			Assert.Equal(stringComparer.GetHashCode(obj3), obj3.B.GetHashCode());
			Assert.Equal(stringComparer.GetHashCode(obj4), obj4.B.GetHashCode());
			Assert.Equal(stringComparer.GetHashCode(obj5), 0);
		}
	}
}
