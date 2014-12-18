using System;

namespace Test {
	/// <summary>
	/// Represents an execution of a <see cref="System.Diagnostics.Process" /> object and obtains meaningful information from it to allow assertions on execution properties.
	/// </summary>
	internal interface IProcessSpawner : IDisposable {
		/// <summary>
		/// Indicates that the process has started.
		/// </summary>
		bool Started { get; }
		/// <summary>
		/// Indicates that the process has completed.
		/// </summary>
		bool Exited { get; }

		/// <summary>
		/// Executes the specified process.
		/// </summary>
		/// <returns>A <see cref="Test.ProcessResult" /> object representing the execution.</returns>
		ProcessResult Run();
	}
}
