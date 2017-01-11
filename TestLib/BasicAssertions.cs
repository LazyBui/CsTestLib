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
		public static void Fail(Exception exception = null) {
			throw AssertionException.GenerateWithInnerException(exception, "Test has failed");
		}

		/// <summary>
		/// Asserts that a condition is true.
		/// </summary>
		public static void True(bool condition, AssertionException exception = null) {
			if (!condition) throw exception ?? new AssertionException("Condition was false");
		}

		/// <summary>
		/// Asserts that a condition is true.
		/// </summary>
		public static void True(bool? condition, AssertionException exception = null) {
			if (condition == null || !condition.Value) throw exception ?? new AssertionException("Condition was null or false");
		}

		/// <summary>
		/// Asserts that a condition is true.
		/// </summary>
		public static void True(Func<bool> condition, AssertionException exception = null) {
			if (condition == null) throw new ArgumentNullException(nameof(condition));
			if (!condition()) throw exception ?? new AssertionException("Condition was false");
		}

		/// <summary>
		/// Asserts that a condition is true.
		/// </summary>
		public static void True(Func<bool?> condition, AssertionException exception = null) {
			if (condition == null) throw new ArgumentNullException(nameof(condition));
			bool? result = condition();
			if (result == null || !result.Value) throw exception ?? new AssertionException("Condition was null or false");
		}

		/// <summary>
		/// Asserts that a condition is false.
		/// </summary>
		public static void False(bool condition, AssertionException exception = null) {
			if (condition) throw exception ?? new AssertionException("Condition was true");
		}

		/// <summary>
		/// Asserts that a condition is false.
		/// </summary>
		public static void False(bool? condition, AssertionException exception = null) {
			if (condition == null || condition.Value) throw exception ?? new AssertionException("Condition was null or true");
		}

		/// <summary>
		/// Asserts that a condition is false.
		/// </summary>
		public static void False(Func<bool> condition, AssertionException exception = null) {
			if (condition == null) throw new ArgumentNullException(nameof(condition));
			if (condition()) throw exception ?? new AssertionException("Condition was true");
		}

		/// <summary>
		/// Asserts that a condition is false.
		/// </summary>
		public static void False(Func<bool?> condition, AssertionException exception = null) {
			if (condition == null) throw new ArgumentNullException(nameof(condition));
			bool? result = condition();
			if (result == null || result.Value) throw exception ?? new AssertionException("Condition was null or true");
		}

		/// <summary>
		/// Asserts that a specific exception or a more derived type is thrown by <paramref name="action" />.
		/// </summary>
		public static void Throws<TException>(Action action, AssertionException exception = null) where TException : Exception {
			if (action == null) throw new ArgumentNullException(nameof(action));
			Throws(typeof(TException), action, exception: exception);
		}
		
		/// <summary>
		/// Asserts that a specific exception or a more derived type is thrown by <paramref name="action" /> and <paramref name="isValidException" /> predicate is satisfied.
		/// </summary>
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
					throw exception ?? AssertionException.GenerateWithInnerException(e, $"Exception type was unexpected, expected {type.Name} or a subclass");
				}
				if (!isValidException((TException)e)) {
					throw exception ?? AssertionException.GenerateWithInnerException(e, $"Exception did not match the predicate");
				}
			}

			if (!thrown) throw exception ?? new AssertionException("Expected exception was not thrown");
		}

		/// <summary>
		/// Asserts that a specific exception or a more derived type is thrown by <paramref name="action" />.
		/// </summary>
		public static void Throws(Type type, Action action, AssertionException exception = null) {
			if (action == null) throw new ArgumentNullException(nameof(action));
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (!type.EqualsOrInherits(typeof(Exception))) throw new ArgumentException("Type must derive from System.Exception", nameof(type));

			bool thrown = false;
			try {
				action();
			}
			catch (Exception e) {
				thrown = true;
				Type thrownType = e.GetType();
				if (!thrownType.EqualsOrInherits(type)) {
					throw exception ?? AssertionException.GenerateWithInnerException(e, $"Exception type was unexpected, expected {type.Name} or a subclass");
				}
			}

			if (!thrown) throw exception ?? new AssertionException("Expected exception was not thrown");
		}

		/// <summary>
		/// Asserts that a specific exception is thrown by <paramref name="action" />.
		/// </summary>
		public static void ThrowsExact<TException>(Action action, AssertionException exception = null) where TException : Exception {
			if (action == null) throw new ArgumentNullException(nameof(action));
			ThrowsExact(typeof(TException), action, exception: exception);
		}

		/// <summary>
		/// Asserts that a specific exception is thrown by <paramref name="action" /> and <paramref name="isValidException" /> predicate is satisfied.
		/// </summary>
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
				if (e.GetType() != type) {
					throw exception ?? AssertionException.GenerateWithInnerException(e, $"Exception type was unexpected, expected {type.Name}");
				}
				if (!isValidException((TException)e)) {
					throw exception ?? AssertionException.GenerateWithInnerException(e, $"Exception did not match the predicate");
				}
			}

			if (!thrown) throw exception ?? new AssertionException("Expected exception was not thrown");
		}

		/// <summary>
		/// Asserts that a specific exception is thrown by <paramref name="action" />.
		/// </summary>
		public static void ThrowsExact(Type type, Action action, AssertionException exception = null) {
			if (action == null) throw new ArgumentNullException(nameof(action));
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (!type.EqualsOrInherits(typeof(Exception))) throw new ArgumentException("Type must derive from System.Exception", nameof(type));

			bool thrown = false;
			try {
				action();
			}
			catch (Exception e) {
				thrown = true;
				if (e.GetType() != type) {
					throw exception ?? AssertionException.GenerateWithInnerException(e, $"Exception type was unexpected, expected {type.Name}");
				}
			}

			if (!thrown) throw exception ?? new AssertionException("Expected exception was not thrown");
		}

		/// <summary>
		/// Asserts that an action does not throw at all.
		/// </summary>
		public static void DoesNotThrow(Action action, AssertionException exception = null) {
			if (action == null) throw new ArgumentNullException(nameof(action));

			try {
				action();
			}
			catch (Exception e) {
				throw exception ?? AssertionException.GenerateWithInnerException(e, "Unexpected exception");
			}
		}
	}
}
