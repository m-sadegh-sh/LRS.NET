namespace LRS.NET.Core.Domain.Entities.Foundation {
	public class RequestDispatchingEntity : RequestTrackingEntityBase {
		public virtual RequestDispatchingResult Result { get; set; }
	}
}