namespace LRS.NET.Core.Domain.Entities.Globalization {
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.ComponentModel.DataAnnotations;

	using LRS.NET.Core.Domain.Entities.Foundation;
	using LRS.NET.Resources;

	public class CityEntity : EntityBase {
		private ProvinceEntity _province;
		private string _name;
		private ICollection<BranchEntity> _branches;

		[Display(Name = "Label_City_Province", ResourceType = typeof (Controls))]
		[Required(ErrorMessageResourceName = "Error_Required_Selectable", ErrorMessageResourceType = typeof (Validations))]
		public virtual ProvinceEntity Province {
			get { return _province; }
			set { SetPropertyAndValidate(ref _province, value); }
		}

		[Display(Name = "Label_City_Name", ResourceType = typeof (Controls))]
		[Required(ErrorMessageResourceName = "Error_Required", ErrorMessageResourceType = typeof (Validations))]
		[StringLength(60, ErrorMessageResourceName = "Error_InvalidLength", ErrorMessageResourceType = typeof (Validations))]
		public virtual string Name {
			get { return _name; }
			set { SetPropertyAndValidate(ref _name, value); }
		}

		public ICollection<BranchEntity> Branches {
			get { return _branches ?? (_branches = new ObservableCollection<BranchEntity>()); }
			set { _branches = value; }
		}
	}
}