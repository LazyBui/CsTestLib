using System;

namespace TestLib.Framework {
	public partial class Assert {
		/// <summary>
		/// Allows a user to invoke a test failure.
		/// </summary>
		public static readonly Action Failure = () => Fail(null);

		/// <summary>
		/// Asserts that the test has failed.
		/// </summary>
		/// <param name="exception">Optional exception to add as an <see cref="Exception.InnerException" />.</param>
		/// <exception cref="AssertionException">Unconditionally produces this exception.</exception>
		public static void Fail(Exception exception = null) {
			throw AssertionException.GenerateWithInnerException(exception, "Test has failed");
		}

		/// <summary>
		/// Asserts that a condition is true.
		/// </summary>
		/// <param name="condition">The condition to evaluate for truth.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void True(bool condition, AssertionException exception = null) {
			if (!condition) throw exception ?? new AssertionException("Condition was false");
		}

		/// <summary>
		/// Asserts that a condition is true.
		/// </summary>
		/// <param name="condition">The condition to evaluate for truth.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void True(bool? condition, AssertionException exception = null) {
			if (condition == null || !condition.Value) throw exception ?? new AssertionException("Condition was null or false");
		}

		/// <summary>
		/// Asserts that a condition is true.
		/// </summary>
		/// <param name="condition">The condition to evaluate for truth.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="condition" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void True(Func<bool> condition, AssertionException exception = null) {
			if (condition == null) throw new ArgumentNullException(nameof(condition));
			if (!condition()) throw exception ?? new AssertionException("Condition was false");
		}

		/// <summary>
		/// Asserts that a condition is true.
		/// </summary>
		/// <param name="condition">The condition to evaluate for truth.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="condition" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void True(Func<bool?> condition, AssertionException exception = null) {
			if (condition == null) throw new ArgumentNullException(nameof(condition));
			bool? result = condition();
			if (result == null || !result.Value) throw exception ?? new AssertionException("Condition was null or false");
		}

		/// <summary>
		/// Asserts that a condition is false.
		/// </summary>
		/// <param name="condition">The condition to evaluate for truth.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void False(bool condition, AssertionException exception = null) {
			if (condition) throw exception ?? new AssertionException("Condition was true");
		}

		/// <summary>
		/// Asserts that a condition is false.
		/// </summary>
		/// <param name="condition">The condition to evaluate for truth.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void False(bool? condition, AssertionException exception = null) {
			if (condition == null || condition.Value) throw exception ?? new AssertionException("Condition was null or true");
		}

		/// <summary>
		/// Asserts that a condition is false.
		/// </summary>
		/// <param name="condition">The condition to evaluate for truth.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="condition" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void False(Func<bool> condition, AssertionException exception = null) {
			if (condition == null) throw new ArgumentNullException(nameof(condition));
			if (condition()) throw exception ?? new AssertionException("Condition was true");
		}

		/// <summary>
		/// Asserts that a condition is false.
		/// </summary>
		/// <param name="condition">The condition to evaluate for truth.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="condition" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void False(Func<bool?> condition, AssertionException exception = null) {
			if (condition == null) throw new ArgumentNullException(nameof(condition));
			bool? result = condition();
			if (result == null || result.Value) throw exception ?? new AssertionException("Condition was null or true");
		}

		/// <summary>
		/// Asserts that a specific exception or a more derived type is thrown by <paramref name="action" />.
		/// </summary>
		/// <typeparam name="TException">The type of the exception.</typeparam>
		/// <param name="action">The action to perform and evaluate for exception content.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="action" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void Throws<TException>(Action action, AssertionException exception = null) where TException : Exception {
			Throws(typeof(TException), action, ex => true, exception: exception);
		}

		/// <summary>
		/// Asserts that a specific exception or a more derived type is thrown by <paramref name="action" /> and <paramref name="isValidException" /> predicate is satisfied.
		/// </summary>
		/// <typeparam name="TException">The type of the exception.</typeparam>
		/// <param name="action">The action to perform and evaluate for exception content.</param>
		/// <param name="isValidException">A filter that determines whether the specified exception is expected. Can be used to check specific properties of the exception such as <see cref="Exception.InnerException" />.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="action" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="isValidException" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void Throws<TException>(Action action, Func<TException, bool> isValidException, AssertionException exception = null) where TException : Exception {
			if (action == null) throw new ArgumentNullException(nameof(action));
			if (isValidException == null) throw new ArgumentNullException(nameof(isValidException));

			Type type = typeof(TException);
			bool thrown = false;
			try {
				action();
			}
			catch (Exception e) {
				thrown = true;
				Type thrownType = e.GetType();
				if (!thrownType.EqualsOrInherits(type)) {
					throw exception ?? GetUnexpectedExceptionTypeException(e, thrownType, type);
				}
				if (!isValidException((TException)e)) {
					throw exception ?? GetDidNotMatchPredicateException(e);
				}
			}

			if (!thrown) throw exception ?? GetExpectedExceptionWasNotThrownException();
		}

		/// <summary>
		/// Asserts that a specific exception or a more derived type is thrown by <paramref name="action" />.
		/// </summary>
		/// <param name="type">The type of the exception expected.</param>
		/// <param name="action">The action to perform and evaluate for exception content.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentException"><paramref name="type" /> is not a type derived from <see cref="Exception" />.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="action" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void Throws(Type type, Action action, AssertionException exception = null) {
			Throws(type, action, ex => true, exception: exception);
		}

		/// <summary>
		/// Asserts that a specific exception or a more derived type is thrown by <paramref name="action" /> and <paramref name="isValidException" /> predicate is satisfied.
		/// </summary>
		/// <param name="type">The type of the exception expected.</param>
		/// <param name="action">The action to perform and evaluate for exception content.</param>
		/// <param name="isValidException">A filter that determines whether the specified exception is expected. Can be used to check specific properties of the exception such as <see cref="Exception.InnerException" />.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentException"><paramref name="type" /> is not a type derived from <see cref="Exception" />.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="action" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="isValidException" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void Throws(Type type, Action action, Func<Exception, bool> isValidException, AssertionException exception = null) {
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (action == null) throw new ArgumentNullException(nameof(action));
			if (isValidException == null) throw new ArgumentNullException(nameof(isValidException));
			ValidateTypeInheritingFromException(type);

			bool thrown = false;
			try {
				action();
			}
			catch (Exception e) {
				thrown = true;
				Type thrownType = e.GetType();
				if (!thrownType.EqualsOrInherits(type)) {
					throw exception ?? GetUnexpectedExceptionTypeException(e, thrownType, type);
				}
				if (!isValidException(e)) {
					throw exception ?? GetDidNotMatchPredicateException(e);
				}
			}

			if (!thrown) throw exception ?? GetExpectedExceptionWasNotThrownException();
		}

		/// <summary>
		/// Asserts that a specific exception is thrown by <paramref name="action" />.
		/// </summary>
		/// <typeparam name="TException">The type of the exception.</typeparam>
		/// <param name="action">The action to perform and evaluate for exception content.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="action" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void ThrowsExact<TException>(Action action, AssertionException exception = null) where TException : Exception {
			ThrowsExact(typeof(TException), action, ex => true, exception: exception);
		}

		/// <summary>
		/// Asserts that a specific exception is thrown by <paramref name="action" /> and <paramref name="isValidException" /> predicate is satisfied.
		/// </summary>
		/// <typeparam name="TException">The type of the exception.</typeparam>
		/// <param name="action">The action to perform and evaluate for exception content.</param>
		/// <param name="isValidException">A filter that determines whether the specified exception is expected. Can be used to check specific properties of the exception such as <see cref="Exception.InnerException" />.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="action" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="isValidException" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void ThrowsExact<TException>(Action action, Func<TException, bool> isValidException, AssertionException exception = null) where TException : Exception {
			if (action == null) throw new ArgumentNullException(nameof(action));
			if (isValidException == null) throw new ArgumentNullException(nameof(isValidException));

			Type type = typeof(TException);
			bool thrown = false;
			try {
				action();
			}
			catch (Exception e) {
				thrown = true;
				Type thrownType = e.GetType();
				if (thrownType != type) {
					throw exception ?? GetUnexpectedExceptionTypeException(e, thrownType, type);
				}
				if (!isValidException((TException)e)) {
					throw exception ?? GetDidNotMatchPredicateException(e);
				}
			}

			if (!thrown) throw exception ?? GetExpectedExceptionWasNotThrownException();
		}

		/// <summary>
		/// Asserts that a specific exception is thrown by <paramref name="action" />.
		/// </summary>
		/// <param name="type">The type of the exception expected.</param>
		/// <param name="action">The action to perform and evaluate for exception content.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentException"><paramref name="type" /> is not a type derived from <see cref="Exception" />.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="action" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void ThrowsExact(Type type, Action action, AssertionException exception = null) {
			ThrowsExact(type, action, ex => true, exception: exception);
		}

		/// <summary>
		/// Asserts that a specific exception is thrown by <paramref name="action" /> and <paramref name="isValidException" /> predicate is satisfied.
		/// </summary>
		/// <param name="type">The type of the exception expected.</param>
		/// <param name="action">The action to perform and evaluate for exception content.</param>
		/// <param name="isValidException">A filter that determines whether the specified exception is expected. Can be used to check specific properties of the exception such as <see cref="Exception.InnerException" />.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentException"><paramref name="type" /> is not a type derived from <see cref="Exception" />.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="action" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="isValidException" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void ThrowsExact(Type type, Action action, Func<Exception, bool> isValidException, AssertionException exception = null) {
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (action == null) throw new ArgumentNullException(nameof(action));
			if (isValidException == null) throw new ArgumentNullException(nameof(isValidException));
			ValidateTypeInheritingFromException(type);

			bool thrown = false;
			try {
				action();
			}
			catch (Exception e) {
				thrown = true;
				Type thrownType = e.GetType();
				if (thrownType != type) {
					throw exception ?? GetUnexpectedExceptionTypeException(e, thrownType, type);
				}
				if (!isValidException(e)) {
					throw exception ?? GetDidNotMatchPredicateException(e);
				}
			}

			if (!thrown) throw exception ?? GetExpectedExceptionWasNotThrownException();
		}

		/// <summary>
		/// Asserts that an action does not throw at all.
		/// </summary>
		/// <param name="action">The action to perform and evaluate for exception content.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="action" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void DoesNotThrow(Action action, AssertionException exception = null) {
			if (action == null) throw new ArgumentNullException(nameof(action));

			try {
				action();
			}
			catch (Exception e) {
				throw exception ?? AssertionException.GenerateWithInnerException(e, "Unexpected exception");
			}
		}

		private static void ValidateTypeInheritingFromException(Type type) {
			if (!type.EqualsOrInherits(typeof(Exception))) throw new ArgumentException("Type must be or derive from System.Exception", nameof(type));
		}

		private static AssertionException GetUnexpectedExceptionTypeException(Exception inner, Type thrownType, Type expectedType) =>
			AssertionException.GenerateWithInnerException(
				inner,
				$"Exception type '{thrownType.FullName}' was unexpected, expected '{expectedType.FullName}'");

		private static AssertionException GetExpectedExceptionWasNotThrownException() =>
			new AssertionException("Expected exception was not thrown");

		private static AssertionException GetDidNotMatchPredicateException(Exception inner) =>
			AssertionException.GenerateWithInnerException(
				inner,
				"Exception did not match the predicate");
	}
}
