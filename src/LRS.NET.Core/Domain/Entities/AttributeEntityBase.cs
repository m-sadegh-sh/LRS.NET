namespace LRS.NET.Core.Domain.Entities {
	public abstract class AttributeEntityBase<TKey> : EntityBase where TKey : struct {
		public virtual TKey Key { get; set; }
		public virtual string Value { get; set; }

		public virtual TValue As<TValue>(TValue defaultValue = default (TValue)) {
			return ValueResolveHelpers.ResolveValue(this, defaultValue);
		}
	}
}