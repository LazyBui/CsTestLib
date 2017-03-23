using System;

namespace TestLib.Framework {
	public partial class Assert {
		/// <summary>
		/// Asserts that the type of a specified object matches the specified type.
		/// </summary>
		/// <typeparam name="TType">The type to check.</typeparam>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsType<TType>(object value, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (value.GetType() != typeof(TType)) throw exception ?? new AssertionException("Given type: {0}\nExpected type: {1}", value.GetType(), typeof(TType));
		}

		/// <summary>
		/// Asserts that the type of a specified object matches the specified type.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="type">The expected type of the object.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsType(object value, Type type, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (value.GetType() != type) throw exception ?? new AssertionException("Given type: {0}\nExpected type: {1}", value.GetType(), type);
		}

		/// <summary>
		/// Asserts that the type of a specified object does not match the specified type.
		/// </summary>
		/// <typeparam name="TType">The type to check.</typeparam>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotType<TType>(object value, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (value.GetType() == typeof(TType)) throw exception ?? new AssertionException("Type is the specified type");
		}

		/// <summary>
		/// Asserts that the type of a specified object does not match the specified type.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="type">The type of the object that is not permitted.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotType(object value, Type type, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (value.GetType() == type) throw exception ?? new AssertionException("Type is the specified type");
		}

		/// <summary>
		/// Asserts that the type of a specified object is assignable from the specified type.
		/// </summary>
		/// <typeparam name="TType">The type to check.</typeparam>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsAssignableFromType<TType>(object value, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (!value.GetType().IsAssignableFrom(typeof(TType))) throw exception ?? new AssertionException("Type is not assignable from the specificed type");
		}

		/// <summary>
		/// Asserts that the type of a specified object is assignable from the specified type.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="type">The type of the object that should be assignable to <paramref name="value" />.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsAssignableFromType(object value, Type type, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (!value.GetType().IsAssignableFrom(type)) throw exception ?? new AssertionException("Type is not assignable from the specificed type");
		}

		/// <summary>
		/// Asserts that the type of a specified object is not assignable from the specified type.
		/// </summary>
		/// <typeparam name="TType">The type to check.</typeparam>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotAssignableFromType<TType>(object value, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (value.GetType().IsAssignableFrom(typeof(TType))) throw exception ?? new AssertionException("Type is assignable from the specified type");
		}

		/// <summary>
		/// Asserts that the type of a specified object is not assignable from the specified type.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="type">The type of the object that should not be assignable to <paramref name="value" />.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotAssignableFromType(object value, Type type, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (value.GetType().IsAssignableFrom(type)) throw exception ?? new AssertionException("Type is assignable from the specified type");
		}
	}
}
