namespace LRS.NET.Core.Extensions {
	using System;

	using FarsiLibrary.Utils;

	public static class DateTimeExtensions {
		public static long GetTimestamp(this DateTime value) {
			var timestamp = (long) (value - new DateTime(1970, 1, 1)).TotalSeconds;

			return timestamp;
		}

		public static string ToPersianDateString(this DateTime value, bool toWritten = true) {
			return toWritten ? PersianDateConverter.ToPersianDate(value).ToWritten() : PersianDateConverter.ToPersianDate(value).ToString();
		}

		public static PersianDate ToPersianDate(this DateTime value) {
			return PersianDateConverter.ToPersianDate(value);
		}

		public static DateTime ToGeorgianDate(this PersianDate value) {
			return PersianDateConverter.ToGregorianDateTime(value);
		}
	}
}