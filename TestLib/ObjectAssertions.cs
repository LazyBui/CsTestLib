using System;

namespace TestLib.Framework {
	public partial class Assert {
		/// <summary>
		/// Asserts that <paramref name="value" /> is null.
		/// </summary>
		public static void Null<TValue>(TValue value, AssertionException exception = null) where TValue : class {
			if (!object.ReferenceEquals(value, null)) throw exception ?? new AssertionException("Object was not null");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is null.
		/// </summary>
		public static void Null<TValue>(TValue? value, AssertionException exception = null) where TValue : struct {
			if (value.HasValue) throw exception ?? new AssertionException("Object was not null");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is not null.
		/// </summary>
		public static void NotNull<TValue>(TValue value, AssertionException exception = null) where TValue : class {
			if (object.ReferenceEquals(value, null)) throw exception ?? new AssertionException("Object was null");
		}

		/// <summary>
		/// Asserts that <paramref name="value" /> is not null.
		/// </summary>
		public static void NotNull<TValue>(TValue? value, AssertionException exception = null) where TValue : struct {
			if (!value.HasValue) throw exception ?? new AssertionException("Object was null");
		}

		/// <summary>
		/// Asserts that <paramref name="left" /> is the same object reference as <paramref name="right" />.
		/// </summary>
		public static void Same<TValue>(TValue left, TValue right, AssertionException exception = null) where TValue : class {
			if (!object.ReferenceEquals(left, right)) throw exception ?? new AssertionException("Expected equal references");
		}

		/// <summary>
		/// Asserts that <paramref name="left" /> is not the same object reference as <paramref name="right" />.
		/// </summary>
		public static void NotSame<TValue>(TValue left, TValue right, AssertionException exception = null) where TValue : class {
			if (object.ReferenceEquals(left, right)) throw exception ?? new AssertionException("Expected different references");
		}
	}
}
