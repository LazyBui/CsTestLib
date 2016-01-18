using System;

namespace TestLib.Framework.Util {
	/// <summary>
	/// Represents whether input was handled.
	/// </summary>
	public enum ProcessInputHandleResult {
		/// <summary>
		/// Indicates that input was given and the output buffer should be cleared.
		/// </summary>
		Handled,
		/// <summary>
		/// Indicates that no input was given and the output buffer should not be cleared.
		/// </summary>
		Ignored,
	}
}
