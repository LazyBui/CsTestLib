using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test {
	public partial class AssertTest {
		[TestMethod]
		public void IsNaN() {
			Assert.DoesNotThrow(() => Assert.IsNaN(float.NaN));
			Assert.DoesNotThrow(() => Assert.IsNaN(double.NaN));
			Assert.Throws<AssertionException>(() => Assert.IsNaN(float.PositiveInfinity));
			Assert.Throws<AssertionException>(() => Assert.IsNaN(float.NegativeInfinity));
			Assert.Throws<AssertionException>(() => Assert.IsNaN(1.34f));
			Assert.Throws<AssertionException>(() => Assert.IsNaN(double.PositiveInfinity));
			Assert.Throws<AssertionException>(() => Assert.IsNaN(double.NegativeInfinity));
			Assert.Throws<AssertionException>(() => Assert.IsNaN(1.34d));
		}

		[TestMethod]
		public void IsNotNaN() {
			Assert.Throws<AssertionException>(() => Assert.IsNotNaN(float.NaN));
			Assert.Throws<AssertionException>(() => Assert.IsNotNaN(double.NaN));
			Assert.DoesNotThrow(() => Assert.IsNotNaN(float.PositiveInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotNaN(float.NegativeInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotNaN(1.34f));
			Assert.DoesNotThrow(() => Assert.IsNotNaN(double.PositiveInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotNaN(double.NegativeInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotNaN(1.34d));
		}

		[TestMethod]
		public void IsInfinity() {
			Assert.Throws<AssertionException>(() => Assert.IsInfinity(float.NaN));
			Assert.Throws<AssertionException>(() => Assert.IsInfinity(double.NaN));
			Assert.DoesNotThrow(() => Assert.IsInfinity(float.PositiveInfinity));
			Assert.DoesNotThrow(() => Assert.IsInfinity(float.NegativeInfinity));
			Assert.Throws<AssertionException>(() => Assert.IsInfinity(1.34f));
			Assert.DoesNotThrow(() => Assert.IsInfinity(double.PositiveInfinity));
			Assert.DoesNotThrow(() => Assert.IsInfinity(double.NegativeInfinity));
			Assert.Throws<AssertionException>(() => Assert.IsInfinity(1.34d));
		}

		[TestMethod]
		public void IsNotInfinity() {
			Assert.DoesNotThrow(() => Assert.IsNotInfinity(float.NaN));
			Assert.DoesNotThrow(() => Assert.IsNotInfinity(double.NaN));
			Assert.Throws<AssertionException>(() => Assert.IsNotInfinity(float.PositiveInfinity));
			Assert.Throws<AssertionException>(() => Assert.IsNotInfinity(float.NegativeInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotInfinity(1.34f));
			Assert.Throws<AssertionException>(() => Assert.IsNotInfinity(double.PositiveInfinity));
			Assert.Throws<AssertionException>(() => Assert.IsNotInfinity(double.NegativeInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotInfinity(1.34d));
		}

		[TestMethod]
		public void IsPositiveInfinity() {
			Assert.Throws<AssertionException>(() => Assert.IsPositiveInfinity(float.NaN));
			Assert.Throws<AssertionException>(() => Assert.IsPositiveInfinity(double.NaN));
			Assert.DoesNotThrow(() => Assert.IsPositiveInfinity(float.PositiveInfinity));
			Assert.Throws<AssertionException>(() => Assert.IsPositiveInfinity(float.NegativeInfinity));
			Assert.Throws<AssertionException>(() => Assert.IsPositiveInfinity(1.34f));
			Assert.DoesNotThrow(() => Assert.IsPositiveInfinity(double.PositiveInfinity));
			Assert.Throws<AssertionException>(() => Assert.IsPositiveInfinity(double.NegativeInfinity));
			Assert.Throws<AssertionException>(() => Assert.IsPositiveInfinity(1.34d));
		}

		[TestMethod]
		public void IsNotPositiveInfinity() {
			Assert.DoesNotThrow(() => Assert.IsNotPositiveInfinity(float.NaN));
			Assert.DoesNotThrow(() => Assert.IsNotPositiveInfinity(double.NaN));
			Assert.Throws<AssertionException>(() => Assert.IsNotPositiveInfinity(float.PositiveInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotPositiveInfinity(float.NegativeInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotPositiveInfinity(1.34f));
			Assert.Throws<AssertionException>(() => Assert.IsNotPositiveInfinity(double.PositiveInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotPositiveInfinity(double.NegativeInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotInfinity(1.34d));
		}

		[TestMethod]
		public void IsNegativeInfinity() {
			Assert.Throws<AssertionException>(() => Assert.IsNegativeInfinity(float.NaN));
			Assert.Throws<AssertionException>(() => Assert.IsNegativeInfinity(double.NaN));
			Assert.Throws<AssertionException>(() => Assert.IsNegativeInfinity(float.PositiveInfinity));
			Assert.DoesNotThrow(() => Assert.IsNegativeInfinity(float.NegativeInfinity));
			Assert.Throws<AssertionException>(() => Assert.IsNegativeInfinity(1.34f));
			Assert.Throws<AssertionException>(() => Assert.IsNegativeInfinity(double.PositiveInfinity));
			Assert.DoesNotThrow(() => Assert.IsNegativeInfinity(double.NegativeInfinity));
			Assert.Throws<AssertionException>(() => Assert.IsNegativeInfinity(1.34d));
		}

		[TestMethod]
		public void IsNotNegativeInfinity() {
			Assert.DoesNotThrow(() => Assert.IsNotNegativeInfinity(float.NaN));
			Assert.DoesNotThrow(() => Assert.IsNotNegativeInfinity(double.NaN));
			Assert.DoesNotThrow(() => Assert.IsNotNegativeInfinity(float.PositiveInfinity));
			Assert.Throws<AssertionException>(() => Assert.IsNotNegativeInfinity(float.NegativeInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotNegativeInfinity(1.34f));
			Assert.DoesNotThrow(() => Assert.IsNotNegativeInfinity(double.PositiveInfinity));
			Assert.Throws<AssertionException>(() => Assert.IsNotNegativeInfinity(double.NegativeInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotNegativeInfinity(1.34d));
		}

		[TestMethod]
		public void IsFloatValue() {
			Assert.Throws<AssertionException>(() => Assert.IsFloatValue(float.NaN));
			Assert.Throws<AssertionException>(() => Assert.IsFloatValue(double.NaN));
			Assert.Throws<AssertionException>(() => Assert.IsFloatValue(float.PositiveInfinity));
			Assert.Throws<AssertionException>(() => Assert.IsFloatValue(float.NegativeInfinity));
			Assert.DoesNotThrow(() => Assert.IsFloatValue(1.34f));
			Assert.Throws<AssertionException>(() => Assert.IsFloatValue(double.PositiveInfinity));
			Assert.Throws<AssertionException>(() => Assert.IsFloatValue(double.NegativeInfinity));
			Assert.DoesNotThrow(() => Assert.IsFloatValue(1.34d));
		}

		[TestMethod]
		public void IsNotFloatValue() {
			Assert.DoesNotThrow(() => Assert.IsNotFloatValue(float.NaN));
			Assert.DoesNotThrow(() => Assert.IsNotFloatValue(double.NaN));
			Assert.DoesNotThrow(() => Assert.IsNotFloatValue(float.PositiveInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotFloatValue(float.NegativeInfinity));
			Assert.Throws<AssertionException>(() => Assert.IsNotFloatValue(1.34f));
			Assert.DoesNotThrow(() => Assert.IsNotFloatValue(double.PositiveInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotFloatValue(double.NegativeInfinity));
			Assert.Throws<AssertionException>(() => Assert.IsNotFloatValue(1.34d));
		}
	}
}
