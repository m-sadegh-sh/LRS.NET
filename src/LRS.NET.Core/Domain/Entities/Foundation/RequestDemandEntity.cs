namespace LRS.NET.Core.Domain.Entities.Foundation {
	public class RequestDemandEntity : RequestTrackingEntityBase {
		public virtual RequestDemandStatus Status { get; set; }
	}
}