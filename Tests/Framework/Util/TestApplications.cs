﻿using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test {
	internal static class TestApplications {
		private const string BinaryDirectory = "../../Tests/Framework/Util/";
		public const string InvalidBinary = "WillNeverExist.exe";
		public static readonly FileInfo InvalidBinaryInfo = new FileInfo(InvalidBinary);

		public const string SimpleInterspersed = BinaryDirectory + "_SimpleInterspersed.exe";
		public static readonly FileInfo SimpleInterspersedInfo = new FileInfo(SimpleInterspersed);
		public static readonly string SimpleInterspersedSource = @"
using System;

namespace CsTestConsole {
	class Program {
		static int Main(string[] args) {
			Console.Error.WriteLine(""abc"");
			Console.Out.WriteLine(""def"");
			Console.Error.WriteLine(""abc"");
			Console.Out.WriteLine(""def"");
			Console.Error.WriteLine(""abc"");
			Console.Out.WriteLine(""def"");
			Console.Out.WriteLine(""def"");
			Console.Error.WriteLine(""abc"");

			foreach (var c in ""abcdef"") {
				Console.Out.Write(c);
				Console.Error.Write(c);
			}

			return 3;
		}
	}
}
";

		public const string BlankLinesInterspersed = BinaryDirectory + "_BlankLinesInterspersed.exe";
		public static readonly FileInfo BlankLinesInterspersedInfo = new FileInfo(BlankLinesInterspersed);
		public static readonly string BlankLinesInterspersedSource = @"
using System;

namespace CsTestConsole {
	class Program {
		static void Main(string[] args) {
			Console.Error.WriteLine(""abc"");
			Console.Error.WriteLine("""");
			Console.Out.WriteLine(""def"");
			Console.Out.WriteLine("""");
			Console.Error.WriteLine(""abc"");
			Console.Out.WriteLine(""def"");
			Console.Out.WriteLine("""");
			Console.Error.WriteLine(""abc"");
			Console.Out.WriteLine(""def"");
			Console.Out.WriteLine(""def"");
			Console.Error.WriteLine("""");
			Console.Error.WriteLine(""abc"");
		}
	}
}
";

		public const string NoOutput = BinaryDirectory + "_NoOutput.exe";
		public static readonly FileInfo NoOutputInfo = new FileInfo(NoOutput);
		public static readonly string NoOutputSource = @"
using System;

namespace CsTestConsole {
	class Program {
		static void Main(string[] args) {

		}
	}
}
";
	}
}