namespace LRS.NET.Core {
	using System.Linq;

	public static class ValueExtensions {
		public static string GetValue<TEnum>(this TEnum value) {
			var valueAttribute = typeof (TEnum).GetMember(value.ToString())[0].GetCustomAttributes(typeof (ValueAttribute), false).FirstOrDefault();

			return valueAttribute != null ? ((ValueAttribute) valueAttribute).Value : null;
		}
	}
}