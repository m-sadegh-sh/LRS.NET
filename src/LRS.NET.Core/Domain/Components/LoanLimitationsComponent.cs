namespace LRS.NET.Core.Domain.Components {
	public class LoanLimitationsComponent : IComponent {
		public virtual int MaximumSponsorshipCount { get; set; }
		public virtual int MaximumSponsorshipAmount { get; set; }
		public virtual bool ApprovalRequired { get; set; }
		public virtual bool ChequeRequired { get; set; }
		public virtual bool ArrearAllowed { get; set; }
	}
}