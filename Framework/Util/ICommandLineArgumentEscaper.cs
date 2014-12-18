using System;
using System.Collections.Generic;

namespace Test {
	internal interface ICommandLineArgumentEscaper {
		string Escape(IEnumerable<object> pRawArguments);
	}
}
