namespace LRS.NET.Core.Extensions {
	using System.Collections.Generic;
	using System.Linq;

	public static class GenericExtensions {
		public static bool IsEmpty<T>(this IEnumerable<T> source) {
			return source == null || !source.Any();
		}
	}
}