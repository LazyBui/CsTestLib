using System;
using System.Collections;
using System.Collections.Generic;

namespace TestLib.Framework {
	public partial class Assert {
		/// <summary>
		/// Asserts that <paramref name="value" /> compares either greater or equal to <paramref name="lowerBound" />.
		/// </summary>
		/// <typeparam name="TValue">The type of the values.</typeparam>
		/// <param name="value">The value to test.</param>
		/// <param name="lowerBound">The lower bound of the range.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="lowerBound" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void GreaterThanEqual<TValue>(TValue value, TValue lowerBound, AssertionException exception = null) where TValue : IComparable<TValue> {
			if (lowerBound == null) throw new ArgumentNullException(nameof(lowerBound));
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (lowerBound.CompareTo(value) > 0) throw exception ?? new AssertionException($"Value ({value}) fell below expected range: {lowerBound} or more");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> compares strictly greater to <paramref name="lowerBound" />.
		/// </summary>
		/// <typeparam name="TValue">The type of the values.</typeparam>
		/// <param name="value">The value to test.</param>
		/// <param name="lowerBound">The lower bound of the range.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="lowerBound" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void GreaterThan<TValue>(TValue value, TValue lowerBound, AssertionException exception = null) where TValue : IComparable<TValue> {
			if (lowerBound == null) throw new ArgumentNullException(nameof(lowerBound));
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (lowerBound.CompareTo(value) >= 0) throw exception ?? new AssertionException($"Value ({value}) fell below expected range: more than {lowerBound}");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> compares either less or equal to <paramref name="upperBound" />.
		/// </summary>
		/// <typeparam name="TValue">The type of the values.</typeparam>
		/// <param name="value">The value to test.</param>
		/// <param name="upperBound">The upper bound of the range.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="upperBound" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void LessThanEqual<TValue>(TValue value, TValue upperBound, AssertionException exception = null) where TValue : IComparable<TValue> {
			if (upperBound == null) throw new ArgumentNullException(nameof(upperBound));
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (upperBound.CompareTo(value) < 0) throw exception ?? new AssertionException($"Value ({value}) fell above expected range: {upperBound} or less");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> compares strictly less to <paramref name="upperBound" />.
		/// </summary>
		/// <typeparam name="TValue">The type of the values.</typeparam>
		/// <param name="value">The value to test.</param>
		/// <param name="upperBound">The upper bound of the range.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="upperBound" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void LessThan<TValue>(TValue value, TValue upperBound, AssertionException exception = null) where TValue : IComparable<TValue> {
			if (upperBound == null) throw new ArgumentNullException(nameof(upperBound));
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (upperBound.CompareTo(value) <= 0) throw exception ?? new AssertionException($"Value ({value}) fell above expected range: less than {upperBound}");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> compares either greater or equal to <paramref name="lowerBound" /> AND less or equal to <paramref name="upperBound" />.
		/// </summary>
		/// <typeparam name="TValue">The type of the values.</typeparam>
		/// <param name="value">The value to test.</param>
		/// <param name="lowerBound">The lower bound of the range.</param>
		/// <param name="upperBound">The upper bound of the range.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="lowerBound" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="upperBound" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void InRangeEqual<TValue>(TValue value, TValue lowerBound, TValue upperBound, AssertionException exception = null) where TValue : IComparable<TValue> {
			if (lowerBound == null) throw new ArgumentNullException(nameof(lowerBound));
			if (upperBound == null) throw new ArgumentNullException(nameof(upperBound));
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (lowerBound.CompareTo(value) > 0) throw exception ?? new AssertionException($"Value ({value}) fell below expected range: {lowerBound}-{upperBound} inclusive");
			if (upperBound.CompareTo(value) < 0) throw exception ?? new AssertionException($"Value ({value}) fell above expected range: {lowerBound}-{upperBound} inclusive");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> compares strictly greater to <paramref name="lowerBound" /> AND strictly less to <paramref name="upperBound" />.
		/// </summary>
		/// <typeparam name="TValue">The value of the type to test.</typeparam>
		/// <param name="value">The value to test.</param>
		/// <param name="lowerBound">The lower bound of the range.</param>
		/// <param name="upperBound">The upper bound of the range.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="lowerBound" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="upperBound" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void InRange<TValue>(TValue value, TValue lowerBound, TValue upperBound, AssertionException exception = null) where TValue : IComparable<TValue> {
			if (lowerBound == null) throw new ArgumentNullException(nameof(lowerBound));
			if (upperBound == null) throw new ArgumentNullException(nameof(upperBound));
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (lowerBound.CompareTo(value) >= 0) throw exception ?? new AssertionException($"Value ({value}) fell below expected range: {lowerBound}-{upperBound} exclusive");
			if (upperBound.CompareTo(value) <= 0) throw exception ?? new AssertionException($"Value ({value}) fell above expected range: {lowerBound}-{upperBound} exclusive");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> compares either greater or equal to <paramref name="upperBound" /> AND less or equal to <paramref name="lowerBound" />.
		/// </summary>
		/// <typeparam name="TValue">The type of the values.</typeparam>
		/// <param name="value">The value to test.</param>
		/// <param name="lowerBound">The lower bound of the range.</param>
		/// <param name="upperBound">The upper bound of the range.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="lowerBound" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="upperBound" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void NotInRangeEqual<TValue>(TValue value, TValue lowerBound, TValue upperBound, AssertionException exception = null) where TValue : IComparable<TValue> {
			if (lowerBound == null) throw new ArgumentNullException(nameof(lowerBound));
			if (upperBound == null) throw new ArgumentNullException(nameof(upperBound));
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (lowerBound.CompareTo(value) < 0 && upperBound.CompareTo(value) > 0) throw exception ?? new AssertionException($"Value ({value}) fell into range {lowerBound}-{upperBound} inclusive");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> compares strictly greater to <paramref name="upperBound" /> AND strictly less to <paramref name="lowerBound" />.
		/// </summary>
		/// <typeparam name="TValue">The type of the values.</typeparam>
		/// <param name="value">The value to test.</param>
		/// <param name="lowerBound">The lower bound of the range.</param>
		/// <param name="upperBound">The upper bound of the range.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="lowerBound" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="upperBound" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void NotInRange<TValue>(TValue value, TValue lowerBound, TValue upperBound, AssertionException exception = null) where TValue : IComparable<TValue> {
			if (lowerBound == null) throw new ArgumentNullException(nameof(lowerBound));
			if (upperBound == null) throw new ArgumentNullException(nameof(upperBound));
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (lowerBound.CompareTo(value) <= 0 && upperBound.CompareTo(value) >= 0) throw exception ?? new AssertionException($"Value ({value}) fell into range {lowerBound}-{upperBound} exclusive");
		}

		/// <summary>
		/// Asserts that two specified objects are equal given a specific comparer.
		/// </summary>
		/// <typeparam name="TValue">The type of the values.</typeparam>
		/// <param name="left">The left object to compare.</param>
		/// <param name="right">The right object to compare.</param>
		/// <param name="comparer">The comparer used to compare the objects.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="comparer" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void Equal<TValue>(TValue left, TValue right, IEqualityComparer<TValue> comparer, AssertionException exception = null) {
			if (comparer == null) throw new ArgumentNullException(nameof(comparer));
			if (!IsEqual(left, right, comparer)) throw exception ?? new AssertionException("Expected equal values");
		}

		/// <summary>
		/// Asserts that two specified objects are equal given a specific comparer.
		/// </summary>
		/// <param name="left">The left object to compare.</param>
		/// <param name="right">The right object to compare.</param>
		/// <param name="comparer">The comparer used to compare the objects.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="comparer" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void Equal(object left, object right, IEqualityComparer comparer, AssertionException exception = null) {
			if (comparer == null) throw new ArgumentNullException(nameof(comparer));
			if (!IsEqual(left, right, comparer)) throw exception ?? new AssertionException("Expected equal values");
		}

		/// <summary>
		/// Asserts that two specified objects are equal.
		/// null and null are considered equal.
		/// The types must also be consistent in order to compare equal (so you cannot compare sbyte with int, for example).
		/// </summary>
		/// <param name="left">The left object to compare.</param>
		/// <param name="right">The right object to compare.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void Equal(object left, object right, AssertionException exception = null) {
			if (!IsEqual(left, right)) throw exception ?? new AssertionException("Expected equal values");
		}

		/// <summary>
		/// Asserts that two specified objects are not equal given a specific comparer.
		/// </summary>
		/// <typeparam name="TValue">The type of the values.</typeparam>
		/// <param name="left">The left object to compare.</param>
		/// <param name="right">The right object to compare.</param>
		/// <param name="comparer">The comparer used to compare the objects.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="comparer" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void NotEqual<TValue>(TValue left, TValue right, IEqualityComparer<TValue> comparer, AssertionException exception = null) {
			if (comparer == null) throw new ArgumentNullException(nameof(comparer));
			if (IsEqual(left, right, comparer)) throw exception ?? new AssertionException("Expected unequal values");
		}

		/// <summary>
		/// Asserts that two specified objects are not equal given a specific comparer.
		/// </summary>
		/// <param name="left">The left object to compare.</param>
		/// <param name="right">The right object to compare.</param>
		/// <param name="comparer">The comparer used to compare the objects.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="comparer" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void NotEqual(object left, object right, IEqualityComparer comparer, AssertionException exception = null) {
			if (comparer == null) throw new ArgumentNullException(nameof(comparer));
			if (IsEqual(left, right, comparer)) throw exception ?? new AssertionException("Expected unequal values");
		}

		/// <summary>
		/// Asserts that two specified objects are not equal.
		/// null and null are considered equal.
		/// The types must also be consistent in order to compare equal (so this assertion would be relatively useless if you were comparing sbyte with int, for example).
		/// </summary>
		/// <param name="left">The left object to compare.</param>
		/// <param name="right">The right object to compare.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void NotEqual(object left, object right, AssertionException exception = null) {
			if (IsEqual(left, right)) throw exception ?? new AssertionException("Expected unequal values");
		}
	}
}
