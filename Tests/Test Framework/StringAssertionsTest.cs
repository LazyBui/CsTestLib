using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test {
	public partial class AssertTest {
		[TestMethod]
		public void IsMatch() {
			Assert.Throws<ArgumentNullException>(() => Assert.IsMatch(null as Regex, string.Empty));
			Assert.Throws<ArgumentNullException>(() => Assert.IsMatch(new Regex(string.Empty), null));

			Assert.Throws<AssertionException>(() => Assert.IsMatch("abc", "cba"));
			Assert.Throws<AssertionException>(() => Assert.IsMatch(new Regex("abc"), "cba"));
			Assert.DoesNotThrow(() => Assert.IsMatch("abc", "abc"));
			Assert.DoesNotThrow(() => Assert.IsMatch(new Regex("abc"), "abc"));
		}

		[TestMethod]
		public void IsNotMatch() {
			Assert.Throws<ArgumentNullException>(() => Assert.IsNotMatch(null as Regex, string.Empty));
			Assert.Throws<ArgumentNullException>(() => Assert.IsNotMatch(new Regex(string.Empty), null));

			Assert.DoesNotThrow(() => Assert.IsNotMatch("abc", "cba"));
			Assert.DoesNotThrow(() => Assert.IsNotMatch(new Regex("abc"), "cba"));
			Assert.Throws<AssertionException>(() => Assert.IsNotMatch("abc", "abc"));
			Assert.Throws<AssertionException>(() => Assert.IsNotMatch(new Regex("abc"), "abc"));
		}

		[TestMethod]
		public void MatchCount() {
			Assert.Throws<ArgumentNullException>(() => Assert.MatchCount(null as Regex, string.Empty, 1));
			Assert.Throws<ArgumentNullException>(() => Assert.MatchCount(new Regex(string.Empty), null, 1));
			Assert.Throws<ArgumentException>(() => Assert.MatchCount(new Regex(string.Empty), string.Empty, -1));

			Assert.DoesNotThrow(() => Assert.MatchCount(new Regex("abc"), "abcabc", 2));
			Assert.Throws<AssertionException>(() => Assert.MatchCount(new Regex("abc"), "abcabc", 1));
			Assert.Throws<AssertionException>(() => Assert.MatchCount(new Regex("abc"), "abcabc", 3));
			Assert.Throws<AssertionException>(() => Assert.MatchCount(new Regex("abc"), "cba", 1));
			Assert.Throws<AssertionException>(() => Assert.MatchCount(new Regex("abc"), "cba", 2));
			Assert.DoesNotThrow(() => Assert.MatchCount(new Regex("abc"), "cba", 0));
			Assert.DoesNotThrow(() => Assert.MatchCount("abc", "abcabc", 2));
			Assert.Throws<AssertionException>(() => Assert.MatchCount("abc", "abcabc", 1));
			Assert.Throws<AssertionException>(() => Assert.MatchCount("abc", "abcabc", 3));
			Assert.Throws<AssertionException>(() => Assert.MatchCount("abc", "cba", 1));
			Assert.Throws<AssertionException>(() => Assert.MatchCount("abc", "cba", 2));
			Assert.DoesNotThrow(() => Assert.MatchCount("abc", "cba", 0));
		}
	}
}
