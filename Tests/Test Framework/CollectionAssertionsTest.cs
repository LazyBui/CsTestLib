using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test {
	public partial class AssertTest {
		private class UniqueTestClass {
			public int Property { get; set; }
		}

		[TestMethod]
		public void Empty() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.Empty<int>(null));
			Assert.DoesNotThrow(() => Assert.Empty(new int[] { }));
			Assert.DoesNotThrow(() => Assert.Empty(string.Empty));
			Assert.ThrowsExact<AssertionException>(() => Assert.Empty(new[] { 1, 2, 3 }));
		}

		[TestMethod]
		public void NotEmpty() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.NotEmpty<int>(null));
			Assert.ThrowsExact<AssertionException>(() => Assert.NotEmpty(new int[] { }));
			Assert.ThrowsExact<AssertionException>(() => Assert.NotEmpty(string.Empty));
			Assert.DoesNotThrow(() => Assert.NotEmpty(new[] { 1, 2, 3 }));
		}

		[TestMethod]
		public void All() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.All(null as int[], v => v == 0));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.All(new int[] { }, null));
			Assert.ThrowsExact<ArgumentException>(() => Assert.All(new int[] { }, v => v == 0));

			Assert.ThrowsExact<AssertionException>(() => Assert.All(new int[] { 1, 2, 3, 4, 5 }, v => v <= 3));
			Assert.DoesNotThrow(() => Assert.All(new int[] { 1, 2, 3, 4, 5 }, v => v < 10));
			Assert.ThrowsExact<AssertionException>(() => Assert.All(new int[] { 1, 2, 3, 4, 5 }, v => v == 1));
		}

		[TestMethod]
		public void None() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.None(null as int[], v => v == 0));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.None(new int[] { }, null));
			Assert.ThrowsExact<ArgumentException>(() => Assert.None(new int[] { }, v => v == 0));

			Assert.ThrowsExact<AssertionException>(() => Assert.None(new int[] { 1, 2, 3, 4, 5 }, v => v >= 3));
			Assert.DoesNotThrow(() => Assert.None(new int[] { 1, 2, 3, 4, 5 }, v => v > 10));
			Assert.ThrowsExact<AssertionException>(() => Assert.None(new int[] { 1, 2, 3, 4, 5 }, v => v == 1));
		}

		[TestMethod]
		public void Any() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.Any(null as int[], v => v == 0));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.Any(new int[] { }, null));
			Assert.ThrowsExact<ArgumentException>(() => Assert.Any(new int[] { }, v => v == 0));

			Assert.DoesNotThrow(() => Assert.Any(new int[] { 1, 2, 3, 4, 5 }, v => v >= 3));
			Assert.DoesNotThrow(() => Assert.Any(new int[] { 1, 2, 3, 4, 5 }, v => v < 10));
			Assert.ThrowsExact<AssertionException>(() => Assert.Any(new int[] { 1, 2, 3, 4, 5 }, v => v > 10));
			Assert.DoesNotThrow(() => Assert.Any(new int[] { 1, 2, 3, 4, 5 }, v => v == 1));
		}

		[TestMethod]
		public void Only() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.Only(null as int[], v => v == 0));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.Only(new int[] { }, null));
			Assert.ThrowsExact<ArgumentException>(() => Assert.Only(new int[] { }, v => v == 0));

			Assert.ThrowsExact<AssertionException>(() => Assert.Only(new int[] { 1, 2, 3, 4, 5 }, v => v >= 3));
			Assert.ThrowsExact<AssertionException>(() => Assert.Only(new int[] { 1, 2, 3, 4, 5 }, v => v < 10));
			Assert.ThrowsExact<AssertionException>(() => Assert.Only(new int[] { 1, 2, 3, 4, 5 }, v => v > 10));
			Assert.DoesNotThrow(() => Assert.Only(new int[] { 1, 2, 3, 4, 5 }, v => v == 1));
		}

		[TestMethod]
		public void Exactly() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.Exactly(null as int[], 1, v => v == 0));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.Exactly(new int[] { }, 1, null));
			Assert.ThrowsExact<ArgumentException>(() => Assert.Exactly(new int[] { }, 1, v => v == 0));
			Assert.ThrowsExact<ArgumentException>(() => Assert.Exactly(new int[] { 0 }, -1, v => v == 0));

			Assert.DoesNotThrow(() => Assert.Exactly(new int[] { 1, 2, 3, 4, 5 }, 3, v => v >= 3));
			Assert.DoesNotThrow(() => Assert.Exactly(new int[] { 1, 2, 3, 4, 5 }, 5, v => v < 10));
			Assert.ThrowsExact<AssertionException>(() => Assert.Exactly(new int[] { 1, 2, 3, 4, 5 }, 4, v => v < 10));
			Assert.ThrowsExact<AssertionException>(() => Assert.Exactly(new int[] { 1, 2, 3, 4, 5 }, 6, v => v < 10));
			Assert.ThrowsExact<AssertionException>(() => Assert.Exactly(new int[] { 1, 2, 3, 4, 5 }, 5, v => v > 10));
			Assert.ThrowsExact<AssertionException>(() => Assert.Exactly(new int[] { 1, 2, 3, 4, 5 }, 5, v => v == 1));
		}

		[TestMethod]
		public void CountSequence() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.Count(null as int[], 1));
			Assert.ThrowsExact<ArgumentException>(() => Assert.Count(new int[] { }, 1));
			Assert.ThrowsExact<ArgumentException>(() => Assert.Count(new int[] { 0 }, -1));

			Assert.DoesNotThrow(() => Assert.Count(new int[] { 1, 2, 3, 4, 5 }, 5));
			Assert.ThrowsExact<AssertionException>(() => Assert.Count(new int[] { 1, 2, 3, 4, 5 }, 4));
			Assert.ThrowsExact<AssertionException>(() => Assert.Count(new int[] { 1, 2, 3, 4, 5 }, 6));
		}

		[TestMethod]
		public void CountElement() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.Count(null as int[], 1, 1));
			Assert.ThrowsExact<ArgumentException>(() => Assert.Count(new int[] { }, 1, 1));
			Assert.ThrowsExact<ArgumentException>(() => Assert.Count(new int[] { 0 }, -1, 0));

			Assert.DoesNotThrow(() => Assert.Count(new int[] { 1, 2, 3, 4, 5 }, 1, 1));
			Assert.ThrowsExact<AssertionException>(() => Assert.Count(new int[] { 1, 4, 3, 4, 5 }, 2, 3));
			Assert.ThrowsExact<AssertionException>(() => Assert.Count(new int[] { 1, 4, 3, 4, 5 }, 3, 4));
		}

		[TestMethod]
		public void Contains() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.Contains<int>(null, 1));
			Assert.ThrowsExact<ArgumentException>(() => Assert.Contains<int>(new int[] { }, 1));
			Assert.ThrowsExact<AssertionException>(() => Assert.Contains(new int[] { 2 }, 1));
			Assert.DoesNotThrow(() => Assert.Contains(new int[] { 2 }, 2));
		}

		[TestMethod]
		public void DoesNotContain() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.DoesNotContain<int>(null, 1));
			Assert.ThrowsExact<ArgumentException>(() => Assert.DoesNotContain<int>(new int[] { }, 1));
			Assert.DoesNotThrow(() => Assert.DoesNotContain(new int[] { 2 }, 1));
			Assert.ThrowsExact<AssertionException>(() => Assert.DoesNotContain(new int[] { 2 }, 2));
		}

		[TestMethod]
		public void Unique() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.Unique(null as int[]));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.Unique(new int[] { 2, 3 }, null as Func<int, int>));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.Unique(new int[] { 2, 3 }, null as Func<int, int, bool>));
			Assert.ThrowsExact<ArgumentException>(() => Assert.Unique(new int[] { }));
			Assert.ThrowsExact<ArgumentException>(() => Assert.Unique(new int[] { 1 }));

			Assert.DoesNotThrow(() => Assert.Unique(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
			Assert.ThrowsExact<AssertionException>(() => Assert.Unique(new int[] { 2, 2, 3, 4, 5, 6, 7, 8, 9 }));

			var doesNotThrow = new UniqueTestClass[] {
				new UniqueTestClass() { Property = 1 },
				new UniqueTestClass() { Property = 2 },
				new UniqueTestClass() { Property = 3 },
				new UniqueTestClass() { Property = 4 },
				new UniqueTestClass() { Property = 5 },
			};

			var throws = new UniqueTestClass[] {
				new UniqueTestClass() { Property = 2 },
				new UniqueTestClass() { Property = 2 },
				new UniqueTestClass() { Property = 3 },
				new UniqueTestClass() { Property = 4 },
				new UniqueTestClass() { Property = 5 },
			};

			Assert.DoesNotThrow(() => Assert.Unique(doesNotThrow, (v1, v2) => v1.Property == v2.Property));
			Assert.ThrowsExact<AssertionException>(() => Assert.Unique(throws, (v1, v2) => v1.Property == v2.Property));

			Assert.DoesNotThrow(() => Assert.Unique(doesNotThrow, v => v.Property));
			Assert.ThrowsExact<AssertionException>(() => Assert.Unique(throws, v => v.Property));
		}

		[TestMethod]
		public void NotUnique() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.NotUnique(null as int[]));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.NotUnique(new int[] { 2, 3 }, null as Func<int, int>));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.NotUnique(new int[] { 2, 3 }, null as Func<int, int, bool>));
			Assert.ThrowsExact<ArgumentException>(() => Assert.NotUnique(new int[] { }));
			Assert.ThrowsExact<ArgumentException>(() => Assert.NotUnique(new int[] { 1 }));

			Assert.ThrowsExact<AssertionException>(() => Assert.NotUnique(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
			Assert.DoesNotThrow(() => Assert.NotUnique(new int[] { 2, 2, 3, 4, 5, 6, 7, 8, 9 }));

			var throws = new UniqueTestClass[] {
				new UniqueTestClass() { Property = 1 },
				new UniqueTestClass() { Property = 2 },
				new UniqueTestClass() { Property = 3 },
				new UniqueTestClass() { Property = 4 },
				new UniqueTestClass() { Property = 5 },
			};

			var doesNotThrow = new UniqueTestClass[] {
				new UniqueTestClass() { Property = 2 },
				new UniqueTestClass() { Property = 2 },
				new UniqueTestClass() { Property = 3 },
				new UniqueTestClass() { Property = 4 },
				new UniqueTestClass() { Property = 5 },
			};

			Assert.DoesNotThrow(() => Assert.NotUnique(doesNotThrow, (v1, v2) => v1.Property == v2.Property));
			Assert.ThrowsExact<AssertionException>(() => Assert.NotUnique(throws, (v1, v2) => v1.Property == v2.Property));

			Assert.DoesNotThrow(() => Assert.NotUnique(doesNotThrow, v => v.Property));
			Assert.ThrowsExact<AssertionException>(() => Assert.NotUnique(throws, v => v.Property));
		}

		[TestMethod]
		public void StartsWith() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.StartsWith(null, new int[0]));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.StartsWith(new int[0], null));
			Assert.ThrowsExact<ArgumentException>(() => Assert.StartsWith(new int[0], new int[1]));
			Assert.ThrowsExact<ArgumentException>(() => Assert.StartsWith(new int[1], new int[0]));
			Assert.ThrowsExact<ArgumentException>(() => Assert.StartsWith(new int[1], new int[2]));

			Assert.DoesNotThrow(() => Assert.StartsWith("hello", "hel"));
			Assert.DoesNotThrow(() => Assert.StartsWith(new[] { 1, 2, 3, 4 }, new[] { 1, 2 }));
			Assert.ThrowsExact<AssertionException>(() => Assert.StartsWith("hello", "jel"));
			Assert.ThrowsExact<AssertionException>(() => Assert.StartsWith(new[] { 1, 2, 3, 4 }, new[] { 2, 3 }));
		}

		[TestMethod]
		public void EndsWith() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.EndsWith(null, new int[0]));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.EndsWith(new int[0], null));
			Assert.ThrowsExact<ArgumentException>(() => Assert.EndsWith(new int[0], new int[1]));
			Assert.ThrowsExact<ArgumentException>(() => Assert.EndsWith(new int[1], new int[0]));
			Assert.ThrowsExact<ArgumentException>(() => Assert.EndsWith(new int[1], new int[2]));

			Assert.DoesNotThrow(() => Assert.EndsWith("hello", "llo"));
			Assert.DoesNotThrow(() => Assert.EndsWith(new[] { 1, 2, 3, 4 }, new[] { 3, 4 }));
			Assert.ThrowsExact<AssertionException>(() => Assert.EndsWith("hello", "kko"));
			Assert.ThrowsExact<AssertionException>(() => Assert.EndsWith(new[] { 1, 2, 3, 4 }, new[] { 2, 3 }));
		}

		[TestMethod]
		public void IsSubsetOf() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsSubsetOf(null, new int[0]));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsSubsetOf(new int[0], null));
			Assert.ThrowsExact<ArgumentException>(() => Assert.IsSubsetOf(new int[0], new int[1]));
			Assert.ThrowsExact<ArgumentException>(() => Assert.IsSubsetOf(new int[1], new int[0]));
			Assert.ThrowsExact<ArgumentException>(() => Assert.IsSubsetOf(new int[1], new int[2]));
			Assert.DoesNotThrow(() => Assert.IsSubsetOf(new[] { 1 }, new[] { 1 }));

			Assert.DoesNotThrow(() => Assert.IsSubsetOf("Musky", "usk"));
			Assert.DoesNotThrow(() => Assert.IsSubsetOf("Musky", "Musky"));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsSubsetOf("Musky", "Husky"));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsSubsetOf("Musky", "elk"));
			Assert.DoesNotThrow(() => Assert.IsSubsetOf(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3 }));
			Assert.DoesNotThrow(() => Assert.IsSubsetOf(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4, 5 }));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsSubsetOf(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 6 }));
		}

		[TestMethod]
		public void IsNotSubsetOf() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsNotSubsetOf(null, new int[0]));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsNotSubsetOf(new int[0], null));
			Assert.ThrowsExact<ArgumentException>(() => Assert.IsNotSubsetOf(new int[0], new int[1]));
			Assert.ThrowsExact<ArgumentException>(() => Assert.IsNotSubsetOf(new int[1], new int[0]));
			Assert.ThrowsExact<ArgumentException>(() => Assert.IsNotSubsetOf(new int[1], new int[2]));
			Assert.DoesNotThrow(() => Assert.IsNotSubsetOf(new[] { 1 }, new[] { 0 }));

			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSubsetOf("Musky", "usk"));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSubsetOf("Musky", "Musky"));
			Assert.DoesNotThrow(() => Assert.IsNotSubsetOf("Musky", "Husky"));
			Assert.DoesNotThrow(() => Assert.IsNotSubsetOf("Musky", "elk"));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSubsetOf(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3 }));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSubsetOf(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4, 5 }));
			Assert.DoesNotThrow(() => Assert.IsNotSubsetOf(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 6 }));
		}

		[TestMethod]
		public void IsStrictSubsetOf() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsStrictSubsetOf(null, new int[0]));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsStrictSubsetOf(new int[0], null));
			Assert.ThrowsExact<ArgumentException>(() => Assert.IsStrictSubsetOf(new int[0], new int[1]));
			Assert.ThrowsExact<ArgumentException>(() => Assert.IsStrictSubsetOf(new int[1], new int[0]));
			Assert.ThrowsExact<ArgumentException>(() => Assert.IsStrictSubsetOf(new int[1], new int[2]));
			Assert.ThrowsExact<ArgumentException>(() => Assert.IsStrictSubsetOf(new[] { 1 }, new[] { 1 }));

			Assert.DoesNotThrow(() => Assert.IsSubsetOf("Musky", "usk"));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsSubsetOf("Musky", "elk"));
			Assert.DoesNotThrow(() => Assert.IsSubsetOf(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3 }));
			Assert.DoesNotThrow(() => Assert.IsSubsetOf(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4, 5 }));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsSubsetOf(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 6 }));
		}

		[TestMethod]
		public void IsNotStrictSubsetOf() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsNotStrictSubsetOf(null, new int[0]));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsNotStrictSubsetOf(new int[0], null));
			Assert.ThrowsExact<ArgumentException>(() => Assert.IsNotStrictSubsetOf(new int[0], new int[1]));
			Assert.ThrowsExact<ArgumentException>(() => Assert.IsNotStrictSubsetOf(new int[1], new int[0]));
			Assert.ThrowsExact<ArgumentException>(() => Assert.IsNotStrictSubsetOf(new int[1], new int[2]));
			Assert.ThrowsExact<ArgumentException>(() => Assert.IsNotStrictSubsetOf(new[] { 1 }, new[] { 1 }));

			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSubsetOf("Musky", "usk"));
			Assert.DoesNotThrow(() => Assert.IsNotSubsetOf("Musky", "elk"));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSubsetOf(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3 }));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSubsetOf(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4, 5 }));
			Assert.DoesNotThrow(() => Assert.IsNotSubsetOf(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 6 }));
		}
	}
}
