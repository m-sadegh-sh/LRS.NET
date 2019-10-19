namespace LRS.NET.Core.Domain.Entities.Foundation {
	public enum LoanRequestStatus : byte {
		Submitted = 0,
		Refused = 1,
		Following = 2,
		Dispatching = 4,
		DispatchFailed = 8
	}
}