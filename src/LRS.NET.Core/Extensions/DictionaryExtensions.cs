namespace LRS.NET.Core.Extensions {
	using System.Collections.Generic;

	using CuttingEdge.Conditions;

	public static class DictionaryExtensions {
		public static void TryToAdd<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue value, bool replaceIfExists = false) {
			Condition.Requires(source).IsNotNull();

			if (source.ContainsKey(key)) {
				if (replaceIfExists)
					source[key] = value;
			} else
				source.Add(key, value);
		}
	}
}