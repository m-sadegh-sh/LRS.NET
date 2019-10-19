namespace LRS.NET.Core {
	using System;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Net;
	using System.Text.RegularExpressions;

	using LRS.NET.Core.Extensions;

	public static class PatternValidator {
		private const string EMAIL_PATTERN = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)\b";
		private const string URL_PATTERN = @"(http|https|ftp)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
		private const string PHONE_NUMBER_PATTERN = @"^(0[1-9][0-9]{9,10})$";
		private const string MOBILE_NUMBER_PATTERN = @"^(09[1-9][0-9]{8})$";

		public static bool IsValidIp(string input) {
			if (input == null)
				return false;

			IPAddress ip;
			if (IPAddress.TryParse(input, out ip))
				return true;

			return false;
		}

		public static bool IsValidEmail(string input) {
			if (string.IsNullOrEmpty(input))
				return false;

			return Regex.IsMatch(input, EMAIL_PATTERN);
		}

		public static bool IsValidUrl(string input) {
			if (string.IsNullOrEmpty(input))
				return false;

			return Regex.IsMatch(input, URL_PATTERN);
		}

		public static bool IsValidPhoneNumber(string input) {
			if (string.IsNullOrEmpty(input))
				return false;

			return Regex.IsMatch(input, PHONE_NUMBER_PATTERN);
		}

		public static bool IsValidMobileNumber(string input) {
			if (string.IsNullOrEmpty(input))
				return false;

			return Regex.IsMatch(input, MOBILE_NUMBER_PATTERN);
		}

		public static bool IsValidPath(string value) {
			if (string.IsNullOrEmpty(value))
				return false;

			return value.Any(ch => Path.GetInvalidPathChars().Any(ipc => ipc == ch));
		}

		public static bool IsValidTimeZoneId(string input) {
			if (string.IsNullOrEmpty(input))
				return false;

			try {
				TimeZoneInfo.FindSystemTimeZoneById(input);
				return true;
			} catch (TimeZoneNotFoundException) {
				return false;
			}
		}

		public static bool IsValidCultureCode(string input) {
			if (string.IsNullOrEmpty(input))
				return false;

			try {
				CultureInfo.CreateSpecificCulture(input);
				return true;
			} catch (CultureNotFoundException) {
				return false;
			}
		}

		public static bool IsValidSlug(string input) {
			if (string.IsNullOrEmpty(input))
				return false;

			return input.Slugify() == input;
		}
	}
}