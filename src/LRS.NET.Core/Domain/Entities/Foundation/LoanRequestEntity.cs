namespace LRS.NET.Core.Domain.Entities.Foundation {
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	public class LoanRequestEntity : WorkingTimeEntityBase {
		private ICollection<SponsorRequestEntity> _requiredSponsors;
		private ICollection<RequestDispatchingEntity> _dispatches;

		public virtual BranchEntity Branch { get; set; }

		public virtual ICollection<SponsorRequestEntity> RequiredSponsors {
			get { return _requiredSponsors ?? (_requiredSponsors = new ObservableCollection<SponsorRequestEntity>()); }
			set { _requiredSponsors = value; }
		}

		public virtual BorrowerEntity Borrower { get; set; }
		public virtual SponsorEntity DefaultSponsor { get; set; }

		public virtual LoanRequestStatus Status { get; set; }
		public virtual int CompanyPercentage { get; set; }
		public virtual int SponsorPercentage { get; set; }

		public ICollection<RequestDispatchingEntity> Dispatches {
			get { return _dispatches ?? (_dispatches = new ObservableCollection<RequestDispatchingEntity>()); }
			set { _dispatches = value; }
		}
	}
}