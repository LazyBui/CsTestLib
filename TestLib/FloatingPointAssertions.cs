using System;

namespace TestLib.Framework {
	public partial class Assert {
		/// <summary>
		/// Asserts that <paramref name="value" /> is the Not a Number value.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNaN(float value, AssertionException exception = null) {
			if (!float.IsNaN(value)) throw exception ?? new AssertionException($"{nameof(value)} was not NaN");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is the Not a Number value.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNaN(double value, AssertionException exception = null) {
			if (!double.IsNaN(value)) throw exception ?? new AssertionException($"{nameof(value)} was not NaN");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is not the Not a Number value.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotNaN(float value, AssertionException exception = null) {
			if (float.IsNaN(value)) throw exception ?? new AssertionException($"{nameof(value)} was NaN");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is not the Not a Number value.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotNaN(double value, AssertionException exception = null) {
			if (double.IsNaN(value)) throw exception ?? new AssertionException($"{nameof(value)} was NaN");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is either a positive or negative infinity value.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsInfinity(float value, AssertionException exception = null) {
			if (!float.IsInfinity(value)) throw exception ?? new AssertionException($"{nameof(value)} was not infinity");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is either a positive or negative infinity value.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsInfinity(double value, AssertionException exception = null) {
			if (!double.IsInfinity(value)) throw exception ?? new AssertionException($"{nameof(value)} was not infinity");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is not a positive or negative infinity value.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotInfinity(float value, AssertionException exception = null) {
			if (float.IsInfinity(value)) throw exception ?? new AssertionException($"{nameof(value)} was infinity");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is not a positive or negative infinity value.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotInfinity(double value, AssertionException exception = null) {
			if (double.IsInfinity(value)) throw exception ?? new AssertionException($"{nameof(value)} was infinity");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is a positive infinity value.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsPositiveInfinity(float value, AssertionException exception = null) {
			if (!float.IsPositiveInfinity(value)) throw exception ?? new AssertionException($"{nameof(value)} was not +infinity");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is a positive infinity value.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsPositiveInfinity(double value, AssertionException exception = null) {
			if (!double.IsPositiveInfinity(value)) throw exception ?? new AssertionException($"{nameof(value)} was not +infinity");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is a not positive infinity value.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotPositiveInfinity(float value, AssertionException exception = null) {
			if (float.IsPositiveInfinity(value)) throw exception ?? new AssertionException($"{nameof(value)} was +infinity");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is a not positive infinity value.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotPositiveInfinity(double value, AssertionException exception = null) {
			if (double.IsPositiveInfinity(value)) throw exception ?? new AssertionException($"{nameof(value)} was +infinity");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is a negative infinity value.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNegativeInfinity(float value, AssertionException exception = null) {
			if (!float.IsNegativeInfinity(value)) throw exception ?? new AssertionException($"{nameof(value)} was not -infinity");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is a negative infinity value.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNegativeInfinity(double value, AssertionException exception = null) {
			if (!double.IsNegativeInfinity(value)) throw exception ?? new AssertionException($"{nameof(value)} was not -infinity");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is not a negative infinity value.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotNegativeInfinity(float value, AssertionException exception = null) {
			if (float.IsNegativeInfinity(value)) throw exception ?? new AssertionException($"{nameof(value)} was -infinity");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is not a negative infinity value.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotNegativeInfinity(double value, AssertionException exception = null) {
			if (double.IsNegativeInfinity(value)) throw exception ?? new AssertionException($"{nameof(value)} was -infinity");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is an infinity value or a Not a Number value.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsSpecialFloatValue(float value, AssertionException exception = null) {
			if (!float.IsInfinity(value) && !float.IsNaN(value)) throw exception ?? new AssertionException($"{nameof(value)} was not a special floating point value");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is an infinity value or a Not a Number value.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsSpecialFloatValue(double value, AssertionException exception = null) {
			if (!double.IsInfinity(value) && !double.IsNaN(value)) throw exception ?? new AssertionException($"{nameof(value)} was not a special floating point value");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is not either an infinity value or a Not a Number value.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotSpecialFloatValue(float value, AssertionException exception = null) {
			if (float.IsInfinity(value) || float.IsNaN(value)) throw exception ?? new AssertionException($"{nameof(value)} was a special floating point value");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is not either an infinity value or a Not a Number value.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotSpecialFloatValue(double value, AssertionException exception = null) {
			if (double.IsInfinity(value) || double.IsNaN(value)) throw exception ?? new AssertionException($"{nameof(value)} was a special floating point value");
		}

		/// <summary>
		/// Asserts that <paramref name="value1" /> is within <paramref name="delta" /> of <paramref name="value2" />.
		/// </summary>
		/// <param name="value1">The left value to compare.</param>
		/// <param name="value2">The right value to compare.</param>
		/// <param name="delta">The maximum difference they may be before an exception should be thrown.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsWithinDelta(float value1, float value2, float delta, AssertionException exception = null) {
			if (Math.Abs(value1 - value2) > delta) throw exception ?? new AssertionException($"{nameof(value1)} and {nameof(value2)} were not within {nameof(delta)}");
		}

		/// <summary>
		/// Asserts that <paramref name="value1" /> is within <paramref name="delta" /> of <paramref name="value2" />.
		/// </summary>
		/// <param name="value1">The left value to compare.</param>
		/// <param name="value2">The right value to compare.</param>
		/// <param name="delta">The maximum difference they may be before an exception should be thrown.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsWithinDelta(double value1, double value2, double delta, AssertionException exception = null) {
			if (Math.Abs(value1 - value2) > delta) throw exception ?? new AssertionException($"{nameof(value1)} and {nameof(value2)} were not within {nameof(delta)}");
		}
	}
}
