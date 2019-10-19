namespace LRS.NET.Core.Extensions {
	using System;
	using System.Text;
	using System.Text.RegularExpressions;

	using CuttingEdge.Conditions;

	public static class StringExtensions {
		public static string ToStringOrDefault(this object value) {
			return (value ?? string.Empty).ToString();
		}

		public static string NotNullOrDefault(this string value) {
			return value ?? string.Empty;
		}

		public static string NotNullOrProvided(this string value, string provided) {
			Condition.Requires(provided).IsNotNull();

			return string.IsNullOrEmpty(value) ? provided : value;
		}

		public static string TrimOrDefault(this string value) {
			return value.NotNullOrDefault().Trim();
		}

		public static string EnsureLength(string value, int maxLength) {
			if (string.IsNullOrEmpty(value))
				return string.Empty;

			if (value.Length > maxLength)
				value = value.Substring(0, maxLength);

			return value;
		}

		public static string ReplaceDeeply(this string input, string oldValue, string newValue) {
			if (string.IsNullOrEmpty(input))
				return "";

			while (input.IndexOf(oldValue, StringComparison.Ordinal) > -1)
				input = input.Replace(oldValue, newValue);

			return input;
		}

		public static string Slugify(this string value) {
			Condition.Requires(value).IsNotNull();

			var slug = value.RemoveAccent().ToLower();
			slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");
			slug = Regex.Replace(slug, @"\s+", " ").Trim();
			slug = Regex.Replace(slug, @"\s", "-");

			return slug;
		}

		public static string RemoveAccent(this string value) {
			var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);

			return Encoding.ASCII.GetString(bytes);
		}
	}
}