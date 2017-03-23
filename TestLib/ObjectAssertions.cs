using System;

namespace TestLib.Framework {
	public partial class Assert {
		/// <summary>
		/// Asserts that <paramref name="value" /> is null.
		/// </summary>
		/// <typeparam name="TValue">The type of the values.</typeparam>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void Null<TValue>(TValue value, AssertionException exception = null) where TValue : class {
			if (!object.ReferenceEquals(value, null)) throw exception ?? new AssertionException("Object was not null");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is null.
		/// </summary>
		/// <typeparam name="TValue">The type of the values.</typeparam>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void Null<TValue>(TValue? value, AssertionException exception = null) where TValue : struct {
			if (value.HasValue) throw exception ?? new AssertionException("Object was not null");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is not null.
		/// </summary>
		/// <typeparam name="TValue">The type of the values.</typeparam>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void NotNull<TValue>(TValue value, AssertionException exception = null) where TValue : class {
			if (object.ReferenceEquals(value, null)) throw exception ?? new AssertionException("Object was null");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is not null.
		/// </summary>
		/// <typeparam name="TValue">The type of the values.</typeparam>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void NotNull<TValue>(TValue? value, AssertionException exception = null) where TValue : struct {
			if (!value.HasValue) throw exception ?? new AssertionException("Object was null");
		}

		/// <summary>
		/// Asserts that <paramref name="left" /> is the same object reference as <paramref name="right" />.
		/// </summary>
		/// <typeparam name="TValue">The type of the values.</typeparam>
		/// <param name="left">The left object to compare.</param>
		/// <param name="right">The right object to compare.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void Same<TValue>(TValue left, TValue right, AssertionException exception = null) where TValue : class {
			if (!object.ReferenceEquals(left, right)) throw exception ?? new AssertionException("Expected equal references");
		}

		/// <summary>
		/// Asserts that <paramref name="left" /> is not the same object reference as <paramref name="right" />.
		/// </summary>
		/// <typeparam name="TValue">The type of the values.</typeparam>
		/// <param name="left">The left object to compare.</param>
		/// <param name="right">The right object to compare.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void NotSame<TValue>(TValue left, TValue right, AssertionException exception = null) where TValue : class {
			if (object.ReferenceEquals(left, right)) throw exception ?? new AssertionException("Expected different references");
		}
	}
}
