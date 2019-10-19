namespace LRS.NET.Core.Domain {
	using LRS.NET.Core.Domain.Entities;

	using TB.ComponentModel;

	public static class ValueResolveHelpers {
		public static TValue ResolveValue<TKey, TValue>(AttributeEntityBase<TKey> attribute, TValue defaultValue) where TKey : struct {
			if (attribute == null)
				return defaultValue;

			if (!attribute.Value.CanConvertTo<TValue>())
				return defaultValue;

			var convertedValue = attribute.Value.ConvertTo<TValue>();

			return convertedValue;
		}
	}
}