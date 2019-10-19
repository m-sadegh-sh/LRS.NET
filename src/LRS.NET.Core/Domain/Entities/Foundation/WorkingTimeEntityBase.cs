namespace LRS.NET.Core.Domain.Entities.Foundation {
	public abstract class WorkingTimeEntityBase : EntityBase {
		public virtual ShiftEntity Shift { get; set; }
	}
}