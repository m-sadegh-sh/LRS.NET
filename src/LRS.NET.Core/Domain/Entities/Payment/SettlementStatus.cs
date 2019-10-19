namespace LRS.NET.Core.Domain.Entities.Payment {
	public enum SettlementStatus : byte {
		NotSettled = 0,
		Settled = 1,
		Extended = 2,
		Replaced = 4,
		Cancelled = 8
	}
}