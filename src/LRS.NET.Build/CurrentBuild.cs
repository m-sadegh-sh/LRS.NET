namespace LRS.NET.Build {
	using System.Reflection;

	public class CurrentBuild {
		public const string Company = "Mohammad Sadegh Shad™";

		public const string Copyright = "Copyright © LRS.NET™ Inc 2013";

		public const string Trademark = "LRS.NET™";

		public const string Version = "0.8.*";

		public const string FileVersion = "0.8.0.0";

		public static string CurrentVersion {
			get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
		}
	}
}