namespace LRS.NET.Core.Domain.Entities.Foundation {
	using System;

	public class ShiftEntity : EntityBase {
		public virtual string Title { get; set; }
		public virtual DateTime StartDateUtc { get; set; }
		public virtual DateTime EndDateUtc { get; set; }

		public override string ToString() {
			return string.Format("{0} ({1}, {2})", Title, StartDateUtc, EndDateUtc);
		}
	}
}