using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Test {
	internal sealed class WindowsCommandLineArgumentEscaper : ICommandLineArgumentEscaper {
		private const string Quote = @"""";
		public string Escape(IEnumerable<object> pRawArguments) {
			return string.Join(" ",
				pRawArguments.Select(a => EscapeArgument(a.ToString())));
		}

		private string EscapeArgument(string pRawArgument) {
			string output;
			output = Regex.Replace(pRawArgument, @"(\\*)" + "\"", @"$1$1\" + "\"");
			output = Regex.Replace(output, @"(\\+)$", @"$1$1");
			return Quote + output + Quote;
		}
	}
}
