using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test {
	public partial class AssertTest {
		private class UniqueTestClass {
			public int Property { get; set; }
		}

		[TestMethod]
		public void Empty() {
			Assert.Throws<ArgumentNullException>(() => Assert.Empty<int>(null));
			Assert.DoesNotThrow(() => Assert.Empty(new int[] { }));
			Assert.DoesNotThrow(() => Assert.Empty(string.Empty));
			Assert.Throws<AssertionException>(() => Assert.Empty(new[] { 1, 2, 3 }));
		}

		[TestMethod]
		public void NotEmpty() {
			Assert.Throws<ArgumentNullException>(() => Assert.NotEmpty<int>(null));
			Assert.Throws<AssertionException>(() => Assert.NotEmpty(new int[] { }));
			Assert.Throws<AssertionException>(() => Assert.NotEmpty(string.Empty));
			Assert.DoesNotThrow(() => Assert.NotEmpty(new[] { 1, 2, 3 }));
		}

		[TestMethod]
		public void All() {
			Assert.Throws<ArgumentNullException>(() => Assert.All(null as int[], v => v == 0));
			Assert.Throws<ArgumentNullException>(() => Assert.All(new int[] { }, null));
			Assert.Throws<ArgumentException>(() => Assert.All(new int[] { }, v => v == 0));

			Assert.Throws<AssertionException>(() => Assert.All(new int[] { 1, 2, 3, 4, 5 }, v => v <= 3));
			Assert.DoesNotThrow(() => Assert.All(new int[] { 1, 2, 3, 4, 5 }, v => v < 10));
			Assert.Throws<AssertionException>(() => Assert.All(new int[] { 1, 2, 3, 4, 5 }, v => v == 1));
		}

		[TestMethod]
		public void None() {
			Assert.Throws<ArgumentNullException>(() => Assert.None(null as int[], v => v == 0));
			Assert.Throws<ArgumentNullException>(() => Assert.None(new int[] { }, null));
			Assert.Throws<ArgumentException>(() => Assert.None(new int[] { }, v => v == 0));

			Assert.Throws<AssertionException>(() => Assert.None(new int[] { 1, 2, 3, 4, 5 }, v => v >= 3));
			Assert.DoesNotThrow(() => Assert.None(new int[] { 1, 2, 3, 4, 5 }, v => v > 10));
			Assert.Throws<AssertionException>(() => Assert.None(new int[] { 1, 2, 3, 4, 5 }, v => v == 1));
		}

		[TestMethod]
		public void Any() {
			Assert.Throws<ArgumentNullException>(() => Assert.Any(null as int[], v => v == 0));
			Assert.Throws<ArgumentNullException>(() => Assert.Any(new int[] { }, null));
			Assert.Throws<ArgumentException>(() => Assert.Any(new int[] { }, v => v == 0));

			Assert.DoesNotThrow(() => Assert.Any(new int[] { 1, 2, 3, 4, 5 }, v => v >= 3));
			Assert.DoesNotThrow(() => Assert.Any(new int[] { 1, 2, 3, 4, 5 }, v => v < 10));
			Assert.Throws<AssertionException>(() => Assert.Any(new int[] { 1, 2, 3, 4, 5 }, v => v > 10));
			Assert.DoesNotThrow(() => Assert.Any(new int[] { 1, 2, 3, 4, 5 }, v => v == 1));
		}

		[TestMethod]
		public void Only() {
			Assert.Throws<ArgumentNullException>(() => Assert.Only(null as int[], v => v == 0));
			Assert.Throws<ArgumentNullException>(() => Assert.Only(new int[] { }, null));
			Assert.Throws<ArgumentException>(() => Assert.Only(new int[] { }, v => v == 0));

			Assert.Throws<AssertionException>(() => Assert.Only(new int[] { 1, 2, 3, 4, 5 }, v => v >= 3));
			Assert.Throws<AssertionException>(() => Assert.Only(new int[] { 1, 2, 3, 4, 5 }, v => v < 10));
			Assert.Throws<AssertionException>(() => Assert.Only(new int[] { 1, 2, 3, 4, 5 }, v => v > 10));
			Assert.DoesNotThrow(() => Assert.Only(new int[] { 1, 2, 3, 4, 5 }, v => v == 1));
		}

		[TestMethod]
		public void Exactly() {
			Assert.Throws<ArgumentNullException>(() => Assert.Exactly(null as int[], 1, v => v == 0));
			Assert.Throws<ArgumentNullException>(() => Assert.Exactly(new int[] { }, 1, null));
			Assert.Throws<ArgumentException>(() => Assert.Exactly(new int[] { }, 1, v => v == 0));
			Assert.Throws<ArgumentException>(() => Assert.Exactly(new int[] { 0 }, -1, v => v == 0));

			Assert.DoesNotThrow(() => Assert.Exactly(new int[] { 1, 2, 3, 4, 5 }, 3, v => v >= 3));
			Assert.DoesNotThrow(() => Assert.Exactly(new int[] { 1, 2, 3, 4, 5 }, 5, v => v < 10));
			Assert.Throws<AssertionException>(() => Assert.Exactly(new int[] { 1, 2, 3, 4, 5 }, 4, v => v < 10));
			Assert.Throws<AssertionException>(() => Assert.Exactly(new int[] { 1, 2, 3, 4, 5 }, 6, v => v < 10));
			Assert.Throws<AssertionException>(() => Assert.Exactly(new int[] { 1, 2, 3, 4, 5 }, 5, v => v > 10));
			Assert.Throws<AssertionException>(() => Assert.Exactly(new int[] { 1, 2, 3, 4, 5 }, 5, v => v == 1));
		}

		[TestMethod]
		public void CountSequence() {
			Assert.Throws<ArgumentNullException>(() => Assert.Count(null as int[], 1));
			Assert.Throws<ArgumentException>(() => Assert.Count(new int[] { }, 1));
			Assert.Throws<ArgumentException>(() => Assert.Count(new int[] { 0 }, -1));

			Assert.DoesNotThrow(() => Assert.Count(new int[] { 1, 2, 3, 4, 5 }, 5));
			Assert.Throws<AssertionException>(() => Assert.Count(new int[] { 1, 2, 3, 4, 5 }, 4));
			Assert.Throws<AssertionException>(() => Assert.Count(new int[] { 1, 2, 3, 4, 5 }, 6));
		}

		[TestMethod]
		public void CountElement() {
			Assert.Throws<ArgumentNullException>(() => Assert.Count(null as int[], 1, 1));
			Assert.Throws<ArgumentException>(() => Assert.Count(new int[] { }, 1, 1));
			Assert.Throws<ArgumentException>(() => Assert.Count(new int[] { 0 }, -1, 0));

			Assert.DoesNotThrow(() => Assert.Count(new int[] { 1, 2, 3, 4, 5 }, 1, 1));
			Assert.Throws<AssertionException>(() => Assert.Count(new int[] { 1, 4, 3, 4, 5 }, 2, 3));
			Assert.Throws<AssertionException>(() => Assert.Count(new int[] { 1, 4, 3, 4, 5 }, 3, 4));
		}

		[TestMethod]
		public void Contains() {
			Assert.Throws<ArgumentNullException>(() => Assert.Contains<int>(null, 1));
			Assert.Throws<ArgumentException>(() => Assert.Contains<int>(new int[] { }, 1));
			Assert.Throws<AssertionException>(() => Assert.Contains(new int[] { 2 }, 1));
			Assert.DoesNotThrow(() => Assert.Contains(new int[] { 2 }, 2));
		}

		[TestMethod]
		public void DoesNotContain() {
			Assert.Throws<ArgumentNullException>(() => Assert.DoesNotContain<int>(null, 1));
			Assert.Throws<ArgumentException>(() => Assert.DoesNotContain<int>(new int[] { }, 1));
			Assert.DoesNotThrow(() => Assert.DoesNotContain(new int[] { 2 }, 1));
			Assert.Throws<AssertionException>(() => Assert.DoesNotContain(new int[] { 2 }, 2));
		}

		[TestMethod]
		public void Unique() {
			Assert.Throws<ArgumentNullException>(() => Assert.Unique(null as int[]));
			Assert.Throws<ArgumentNullException>(() => Assert.Unique(new int[] { 2, 3 }, null as Func<int, int>));
			Assert.Throws<ArgumentNullException>(() => Assert.Unique(new int[] { 2, 3 }, null as Func<int, int, bool>));
			Assert.Throws<ArgumentException>(() => Assert.Unique(new int[] { }));
			Assert.Throws<ArgumentException>(() => Assert.Unique(new int[] { 1 }));

			Assert.DoesNotThrow(() => Assert.Unique(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
			Assert.Throws<AssertionException>(() => Assert.Unique(new int[] { 2, 2, 3, 4, 5, 6, 7, 8, 9 }));

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
			Assert.Throws<AssertionException>(() => Assert.Unique(throws, (v1, v2) => v1.Property == v2.Property));

			Assert.DoesNotThrow(() => Assert.Unique(doesNotThrow, v => v.Property));
			Assert.Throws<AssertionException>(() => Assert.Unique(throws, v => v.Property));
		}

		[TestMethod]
		public void NotUnique() {
			Assert.Throws<ArgumentNullException>(() => Assert.NotUnique(null as int[]));
			Assert.Throws<ArgumentNullException>(() => Assert.NotUnique(new int[] { 2, 3 }, null as Func<int, int>));
			Assert.Throws<ArgumentNullException>(() => Assert.NotUnique(new int[] { 2, 3 }, null as Func<int, int, bool>));
			Assert.Throws<ArgumentException>(() => Assert.NotUnique(new int[] { }));
			Assert.Throws<ArgumentException>(() => Assert.NotUnique(new int[] { 1 }));

			Assert.Throws<AssertionException>(() => Assert.NotUnique(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
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
			Assert.Throws<AssertionException>(() => Assert.NotUnique(throws, (v1, v2) => v1.Property == v2.Property));

			Assert.DoesNotThrow(() => Assert.NotUnique(doesNotThrow, v => v.Property));
			Assert.Throws<AssertionException>(() => Assert.NotUnique(throws, v => v.Property));
		}

		[TestMethod]
		public void StartsWith() {
			Assert.Throws<ArgumentNullException>(() => Assert.StartsWith(null, new int[0]));
			Assert.Throws<ArgumentNullException>(() => Assert.StartsWith(new int[0], null));
			Assert.Throws<ArgumentException>(() => Assert.StartsWith(new int[0], new int[1]));
			Assert.Throws<ArgumentException>(() => Assert.StartsWith(new int[1], new int[0]));
			Assert.Throws<ArgumentException>(() => Assert.StartsWith(new int[1], new int[2]));

			Assert.DoesNotThrow(() => Assert.StartsWith("hello", "hel"));
			Assert.DoesNotThrow(() => Assert.StartsWith(new[] { 1, 2, 3, 4 }, new[] { 1, 2 }));
			Assert.Throws<AssertionException>(() => Assert.StartsWith("hello", "jel"));
			Assert.Throws<AssertionException>(() => Assert.StartsWith(new[] { 1, 2, 3, 4 }, new[] { 2, 3 }));
		}

		[TestMethod]
		public void EndsWith() {
			Assert.Throws<ArgumentNullException>(() => Assert.EndsWith(null, new int[0]));
			Assert.Throws<ArgumentNullException>(() => Assert.EndsWith(new int[0], null));
			Assert.Throws<ArgumentException>(() => Assert.EndsWith(new int[0], new int[1]));
			Assert.Throws<ArgumentException>(() => Assert.EndsWith(new int[1], new int[0]));
			Assert.Throws<ArgumentException>(() => Assert.EndsWith(new int[1], new int[2]));

			Assert.DoesNotThrow(() => Assert.EndsWith("hello", "llo"));
			Assert.DoesNotThrow(() => Assert.EndsWith(new[] { 1, 2, 3, 4 }, new[] { 3, 4 }));
			Assert.Throws<AssertionException>(() => Assert.EndsWith("hello", "kko"));
			Assert.Throws<AssertionException>(() => Assert.EndsWith(new[] { 1, 2, 3, 4 }, new[] { 2, 3 }));
		}
	}
}
