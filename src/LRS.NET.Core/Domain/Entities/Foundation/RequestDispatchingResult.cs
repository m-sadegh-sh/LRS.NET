namespace LRS.NET.Core.Domain.Entities.Foundation {
	public enum RequestDispatchingResult : byte {
		Unknown = 0,
		Pending = 1,
		Confirmed = 2,
		Cancelled = 4
	}
}