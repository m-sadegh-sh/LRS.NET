namespace LRS.NET.Core.Domain.Entities.Foundation {
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	public class SponsorEntity : PeopleEntityBase {
		private ICollection<SponsorTypeEntity> _types;
		private ICollection<BankEntity> _sponsorableBanks;
		private ICollection<BranchEntity> _sponsorableBranches;

		public virtual ICollection<SponsorTypeEntity> Types {
			get { return _types ?? (_types = new ObservableCollection<SponsorTypeEntity>()); }
			set { _types = value; }
		}

		public ICollection<BankEntity> SponsorableBanks {
			get { return _sponsorableBanks ?? (_sponsorableBanks = new ObservableCollection<BankEntity>()); }
			set { _sponsorableBanks = value; }
		}

		public ICollection<BranchEntity> SponsorableBranches {
			get { return _sponsorableBranches ?? (_sponsorableBranches = new ObservableCollection<BranchEntity>()); }
			set { _sponsorableBranches = value; }
		}

		public virtual string PersonnelCode { get; set; }
		public virtual MarriageStatus MarriageStatus { get; set; }
		public virtual SponsorshipStatus Status { get; set; }
	}
}