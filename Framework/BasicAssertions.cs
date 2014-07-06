using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Test {
	internal partial class Assert {
		/// <summary>
		/// Asserts that a condition is true.
		/// </summary>
		public static void True(bool pCondition, AssertionException pException = null) {
			if (!pCondition) throw pException ?? new AssertionException("Condition was false");
		}

		/// <summary>
		/// Asserts that a condition is false.
		/// </summary>
		public static void False(bool pCondition, AssertionException pException = null) {
			if (pCondition) throw pException ?? new AssertionException("Condition was true");
		}

		/// <summary>
		/// Asserts that a specific exception is thrown by the action.
		/// </summary>
		public static void Throws<TException>(Action pAction, AssertionException pException = null) where TException : Exception {
			if (pAction == null) throw new ArgumentNullException("pAction");

			bool thrown = false;
			try {
				pAction();
			}
			catch (Exception e) {
				thrown = true;
				if (e.GetType() != typeof(TException)) {
					throw pException ?? AssertionException.GenerateWithInnerException(e, "Exception type was unexpected");
				}
			}

			if (!thrown) throw pException ?? new AssertionException("Expected exception was not thrown");
		}

		/// <summary>
		/// Asserts that an action does not throw at all.
		/// </summary>
		public static void DoesNotThrow(Action pAction, AssertionException pException = null) {
			if (pAction == null) throw new ArgumentNullException("pAction");

			try {
				pAction();
			}
			catch (Exception e) {
				throw pException ?? AssertionException.GenerateWithInnerException(e, "Unexpected exception");
			}
		}
	}
}
