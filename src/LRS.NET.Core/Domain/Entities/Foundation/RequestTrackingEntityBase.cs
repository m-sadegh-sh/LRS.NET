namespace LRS.NET.Core.Domain.Entities.Foundation {
	using System;

	public abstract class RequestTrackingEntityBase : WorkingTimeEntityBase {
		public virtual LoanRequestEntity Request { get; set; }

		public virtual DateTime TrackDateUtc { get; set; }
		public virtual string Comment { get; set; }
	}
}