namespace LRS.NET.Core.Domain {
	using LRS.NET.Core.Domain.Entities;

	public abstract class AttributeBase : EntityBase {
		public virtual string SystemName { get; set; }
		public virtual string DisplayName { get; set; }
		public virtual string Description { get; set; }
	}
}