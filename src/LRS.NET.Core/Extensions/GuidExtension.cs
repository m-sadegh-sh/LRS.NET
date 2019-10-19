namespace LRS.NET.Core.Extensions {
	using System;

	public static class GuidExtension {
		public static bool IsEmpty(this Guid value) {
			return value.Equals(Guid.Empty);
		}
	}
}