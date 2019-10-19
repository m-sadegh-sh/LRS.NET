namespace LRS.NET.Core.Domain.Entities.Foundation {
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	using LRS.NET.Core.Domain.Components;
	using LRS.NET.Core.Domain.Entities.Globalization;

	public class BranchEntity : EntityBase {
		private ICollection<CellNumberComponent> _contactNumbers;

		public virtual string BranchCode { get; set; }
		public virtual BankEntity Bank { get; set; }
		public virtual BankEmployee Chief { get; set; }
		public virtual BankEmployee CreditOfficer { get; set; }
		public virtual CityEntity City { get; set; }
		public virtual string Address { get; set; }

		public virtual ICollection<CellNumberComponent> ContactNumbers {
			get { return _contactNumbers ?? (_contactNumbers = new ObservableCollection<CellNumberComponent>()); }
			set { _contactNumbers = value; }
		}

		public virtual LoanLimitationsComponent Limitations { get; set; }
	}
}