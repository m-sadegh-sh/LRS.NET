namespace LRS.NET.Core.Domain.Entities.Payment {
	public enum TransferTarget : byte {
		Company = 0,
		Borrower = 1,
		Sponsor = 2,
		Miscellaneous = 4
	}
}