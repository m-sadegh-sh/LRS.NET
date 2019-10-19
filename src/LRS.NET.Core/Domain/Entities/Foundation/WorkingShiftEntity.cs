namespace LRS.NET.Core.Domain.Entities.Foundation {
	using System;

	using LRS.NET.Core.Domain.Entities.Security;

	public class WorkingShiftEntity : WorkingTimeEntityBase {
		public virtual UserEntity Operator { get; set; }
		public virtual DateTime StartDateUtc { get; set; }
		public virtual DateTime EndDateUtc { get; set; }

		public override string ToString() {
			return string.Format("{0} ({1})", Shift, Operator);
		}
	}
}