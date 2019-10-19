namespace LRS.NET.Core.Domain.Entities.Foundation {
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	using LRS.NET.Core.Domain.Components;

	public abstract class PeopleEntityBase : EntityBase {
		private ICollection<CellNumberComponent> _otherNumbers;

		public virtual NameComponent FullName { get; set; }
		public virtual JobEntity Job { get; set; }
		public virtual string JobAddress { get; set; }
		public virtual string HomeAddress { get; set; }
		public virtual CellNumberComponent Phone { get; set; }
		public virtual CellNumberComponent Mobile { get; set; }
		public virtual string Email { get; set; }

		public virtual ICollection<CellNumberComponent> OtherNumbers {
			get { return _otherNumbers ?? (_otherNumbers = new ObservableCollection<CellNumberComponent>()); }
			set { _otherNumbers = value; }
		}
	}
}