using System;

namespace Test {
	internal interface IProcessSpawner : IDisposable {
		bool Started { get; }
		bool Exited { get; }

		ProcessResult Run();
		void Start();
		ProcessResult WaitForExit();
	}
}
