﻿using System;
using TestLib.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = TestLib.Framework.Assert;

namespace TestLib.Tests {
	public partial class AssertTest {
		[TestMethod]
		[TestCategory("TestLib")]
		public void IsNaN() {
			Assert.DoesNotThrow(() => Assert.IsNaN(float.NaN));
			Assert.DoesNotThrow(() => Assert.IsNaN(double.NaN));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNaN(float.PositiveInfinity));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNaN(float.NegativeInfinity));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNaN(1.34f));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNaN(double.PositiveInfinity));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNaN(double.NegativeInfinity));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNaN(1.34d));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsNotNaN() {
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotNaN(float.NaN));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotNaN(double.NaN));
			Assert.DoesNotThrow(() => Assert.IsNotNaN(float.PositiveInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotNaN(float.NegativeInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotNaN(1.34f));
			Assert.DoesNotThrow(() => Assert.IsNotNaN(double.PositiveInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotNaN(double.NegativeInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotNaN(1.34d));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsInfinity() {
			Assert.ThrowsExact<AssertionException>(() => Assert.IsInfinity(float.NaN));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsInfinity(double.NaN));
			Assert.DoesNotThrow(() => Assert.IsInfinity(float.PositiveInfinity));
			Assert.DoesNotThrow(() => Assert.IsInfinity(float.NegativeInfinity));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsInfinity(1.34f));
			Assert.DoesNotThrow(() => Assert.IsInfinity(double.PositiveInfinity));
			Assert.DoesNotThrow(() => Assert.IsInfinity(double.NegativeInfinity));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsInfinity(1.34d));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsNotInfinity() {
			Assert.DoesNotThrow(() => Assert.IsNotInfinity(float.NaN));
			Assert.DoesNotThrow(() => Assert.IsNotInfinity(double.NaN));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotInfinity(float.PositiveInfinity));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotInfinity(float.NegativeInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotInfinity(1.34f));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotInfinity(double.PositiveInfinity));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotInfinity(double.NegativeInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotInfinity(1.34d));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsPositiveInfinity() {
			Assert.ThrowsExact<AssertionException>(() => Assert.IsPositiveInfinity(float.NaN));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsPositiveInfinity(double.NaN));
			Assert.DoesNotThrow(() => Assert.IsPositiveInfinity(float.PositiveInfinity));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsPositiveInfinity(float.NegativeInfinity));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsPositiveInfinity(1.34f));
			Assert.DoesNotThrow(() => Assert.IsPositiveInfinity(double.PositiveInfinity));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsPositiveInfinity(double.NegativeInfinity));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsPositiveInfinity(1.34d));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsNotPositiveInfinity() {
			Assert.DoesNotThrow(() => Assert.IsNotPositiveInfinity(float.NaN));
			Assert.DoesNotThrow(() => Assert.IsNotPositiveInfinity(double.NaN));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotPositiveInfinity(float.PositiveInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotPositiveInfinity(float.NegativeInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotPositiveInfinity(1.34f));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotPositiveInfinity(double.PositiveInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotPositiveInfinity(double.NegativeInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotInfinity(1.34d));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsNegativeInfinity() {
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNegativeInfinity(float.NaN));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNegativeInfinity(double.NaN));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNegativeInfinity(float.PositiveInfinity));
			Assert.DoesNotThrow(() => Assert.IsNegativeInfinity(float.NegativeInfinity));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNegativeInfinity(1.34f));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNegativeInfinity(double.PositiveInfinity));
			Assert.DoesNotThrow(() => Assert.IsNegativeInfinity(double.NegativeInfinity));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNegativeInfinity(1.34d));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsNotNegativeInfinity() {
			Assert.DoesNotThrow(() => Assert.IsNotNegativeInfinity(float.NaN));
			Assert.DoesNotThrow(() => Assert.IsNotNegativeInfinity(double.NaN));
			Assert.DoesNotThrow(() => Assert.IsNotNegativeInfinity(float.PositiveInfinity));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotNegativeInfinity(float.NegativeInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotNegativeInfinity(1.34f));
			Assert.DoesNotThrow(() => Assert.IsNotNegativeInfinity(double.PositiveInfinity));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotNegativeInfinity(double.NegativeInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotNegativeInfinity(1.34d));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsSpecialFloatValue() {
			Assert.DoesNotThrow(() => Assert.IsSpecialFloatValue(float.NaN));
			Assert.DoesNotThrow(() => Assert.IsSpecialFloatValue(double.NaN));
			Assert.DoesNotThrow(() => Assert.IsSpecialFloatValue(float.PositiveInfinity));
			Assert.DoesNotThrow(() => Assert.IsSpecialFloatValue(float.NegativeInfinity));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsSpecialFloatValue(1.34f));
			Assert.DoesNotThrow(() => Assert.IsSpecialFloatValue(double.PositiveInfinity));
			Assert.DoesNotThrow(() => Assert.IsSpecialFloatValue(double.NegativeInfinity));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsSpecialFloatValue(1.34d));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsNotSpecialFloatValue() {
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSpecialFloatValue(float.NaN));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSpecialFloatValue(double.NaN));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSpecialFloatValue(float.PositiveInfinity));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSpecialFloatValue(float.NegativeInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotSpecialFloatValue(1.34f));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSpecialFloatValue(double.PositiveInfinity));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSpecialFloatValue(double.NegativeInfinity));
			Assert.DoesNotThrow(() => Assert.IsNotSpecialFloatValue(1.34d));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsWithinDelta() {
			Assert.DoesNotThrow(() => Assert.IsWithinDelta(0.0001f, 0.0002f, 0.0001f));
			Assert.DoesNotThrow(() => Assert.IsWithinDelta(0.0001d, 0.0002d, 0.0001d));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsWithinDelta(0.0001f, 0.0002f, 0.00002f));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsWithinDelta(0.0001d, 0.0002d, 0.00002d));
		}
	}
}
