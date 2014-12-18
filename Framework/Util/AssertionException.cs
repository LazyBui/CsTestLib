using System;

namespace Test {
	/// <summary>
	/// The exception that all assertions will throw if the assertion fails.
	/// </summary>
	internal sealed class AssertionException : Exception {
		public AssertionException(string pMessage) : base(pMessage) { }
		public AssertionException(string pMessage, params object[] pArgs) : base(string.Format(pMessage, pArgs)) { }
		private AssertionException(string pMessage, Exception pInnerException) : base(pMessage, pInnerException) { }

		public static AssertionException GenerateWithInnerException(Exception pInnerException, string pFormat, params object[] pArgs) {
			return new AssertionException(string.Format(pFormat, pArgs), pInnerException);
		}
	}
}
