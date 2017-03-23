using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib.Framework.Util;
using Assert = TestLib.Framework.Assert;

namespace TestLib.Tests.Util {
	[TestClass]
	public class EqualityComparerStatefulTest {
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
			Assert.ThrowsExact<ArgumentNullException>(() => new EqualityComparerStateful<int>(null));
			Assert.DoesNotThrow(() => new EqualityComparerStateful<int>((lhs, rhs) => lhs == rhs));
		}

		[TestMethod]
		public void Equals() {
			var comparer = new EqualityComparerStateful<int>((lhs, rhs) => lhs == rhs);
			Assert.True(comparer.Equals(1, 1));
			Assert.True(comparer.Equals(-1, -1));
			Assert.False(comparer.Equals(-1, 1));
			Assert.False(comparer.Equals(1, -1));

			Assert.False(comparer.Equals(2, 1));
			Assert.False(comparer.Equals(-2, -1));
			Assert.False(comparer.Equals(1, 2));
			Assert.False(comparer.Equals(-1, -2));
			Assert.False(comparer.Equals(2, -1));
			Assert.False(comparer.Equals(-2, 1));
			Assert.False(comparer.Equals(1, -2));
			Assert.False(comparer.Equals(-1, 2));

			var stringComparer = new EqualityComparerStateful<string>((lhs, rhs) => lhs == rhs);
			Assert.True(stringComparer.Equals("ABC", "ABC"));
			Assert.True(stringComparer.Equals(null, null));
			Assert.False(stringComparer.Equals("ABC", "abc"));
			Assert.False(stringComparer.Equals("abc", "ABC"));
			Assert.False(stringComparer.Equals("ABC", "CBA"));
			Assert.False(stringComparer.Equals("ABCD", "ABC"));
			Assert.False(stringComparer.Equals("ABC", "ABCD"));
			Assert.False(stringComparer.Equals("ABC", null));
			Assert.False(stringComparer.Equals(null, "ABC"));

			var objComparer = new EqualityComparerStateful<Testing>((lhs, rhs) => lhs.B.Length == rhs.A);
			var obj1 = new Testing(5, "ABC");
			var obj2 = new Testing(3, "NA");
			var obj3 = new Testing(2, "ABCDE");
			Assert.True(objComparer.Equals(obj1, obj2));
			Assert.False(objComparer.Equals(obj1, obj3));

			Assert.False(objComparer.Equals(obj2, obj1));
			Assert.True(objComparer.Equals(obj2, obj3));

			Assert.True(objComparer.Equals(obj3, obj1));
			Assert.False(objComparer.Equals(obj3, obj2));
		}

		[TestMethod]
		public new void GetHashCode() {
			var obj1 = new Testing(5, "ABC");
			var obj2 = new Testing(3, "NA");
			var obj3 = new Testing(2, "ABCDE");
			var obj4 = new Testing(5, "NA");
			var obj5 = new Testing(7, null);

			var comparer = new EqualityComparerStateful<int>((lhs, rhs) => lhs == rhs, obj => obj.GetHashCode());
			Assert.Equal(comparer.GetHashCode(5), 5.GetHashCode());
			Assert.Equal(comparer.GetHashCode(3), 3.GetHashCode());
			Assert.Equal(comparer.GetHashCode(67), 67.GetHashCode());

			var stringComparer = new EqualityComparerStateful<string>((lhs, rhs) => lhs == rhs);
			Assert.Equal(stringComparer.GetHashCode("ABC"), "ABC".GetHashCode());
			Assert.Equal(stringComparer.GetHashCode("CBA"), "CBA".GetHashCode());
			Assert.Equal(stringComparer.GetHashCode("abcd"), "abcd".GetHashCode());
			Assert.Equal(stringComparer.GetHashCode(null), 0);

			var objComparer = new EqualityComparerStateful<Testing>((lhs, rhs) => lhs.A == rhs.A, obj => obj.A.GetHashCode() * 2);
			Assert.Equal(objComparer.GetHashCode(obj1), obj1.A.GetHashCode() * 2);
			Assert.Equal(objComparer.GetHashCode(obj2), obj2.A.GetHashCode() * 2);
			Assert.Equal(objComparer.GetHashCode(obj3), obj3.A.GetHashCode() * 2);
			Assert.Equal(objComparer.GetHashCode(obj4), obj4.A.GetHashCode() * 2);
			Assert.Equal(objComparer.GetHashCode(obj5), obj5.A.GetHashCode() * 2);
		}
	}
}
