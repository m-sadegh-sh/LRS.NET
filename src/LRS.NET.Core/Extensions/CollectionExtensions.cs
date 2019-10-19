namespace LRS.NET.Core.Extensions {
	using System.Collections.Generic;
	using System.Linq;

	public static class CollectionExtensions {
		public static int IndexOf<T>(this ICollection<T> source, T item) {
			if (source == null)
				return -1;

			var i = 0;
			foreach (var it in source) {
				if (Equals(it, item))
					return i;

				i++;
			}

			return -1;
		}

		public static T Prev<T>(this ICollection<T> source, T @this) {
			return RelativeWith(source, @this, -1);
		}

		public static T Next<T>(this ICollection<T> source, T @this) {
			return RelativeWith(source, @this, 1);
		}

		private static T RelativeWith<T>(this ICollection<T> source, T @this, int differential) {
			if (source == null)
				return default(T);

			if (source.Contains(@this)) {
				var indexOfOther = source.IndexOf(@this) + differential;
				return source.ElementAtOrDefault(indexOfOther);
			}

			return default(T);
		}
	}
}