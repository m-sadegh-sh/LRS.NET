namespace LRS.NET.Core.Domain.Entities.Payment {
	using System;

	using LRS.NET.Core.Domain.Entities.Foundation;

	public class FundEntity : EntityBase {
		public virtual int Amount { get; set; }
		public virtual BankEntity Bank { get; set; }
		public virtual BranchEntity Branch { get; set; }
		public virtual DateTime? DueDateUtc { get; set; }
		public virtual BorrowerEntity Payer { get; set; }
		public virtual SettlementStatus Status { get; set; }
		public virtual string Description { get; set; }
		public virtual LoanRequestEntity Request { get; set; }
		public virtual string SerialNumber { get; set; }
		public virtual string ShabaCode { get; set; }
		public virtual OrderEntity Order { get; set; }
	}
}