namespace LRS.NET.Core.Domain.Entities.Globalization {
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.ComponentModel.DataAnnotations;

	using LRS.NET.Resources;

	public class CountryEntity : EntityBase {
		private string _name;
		private ICollection<ProvinceEntity> _provinces;

		[Display(Name = "Label_Country_Name", ResourceType = typeof (Controls))]
		[Required(ErrorMessageResourceName = "Error_Required", ErrorMessageResourceType = typeof (Validations))]
		[StringLength(60, ErrorMessageResourceName = "Error_InvalidLength", ErrorMessageResourceType = typeof (Validations))]
		public virtual string Name {
			get { return _name; }
			set { SetPropertyAndValidate(ref _name, value); }
		}

		public virtual ICollection<ProvinceEntity> Provinces {
			get { return _provinces ?? (_provinces = new ObservableCollection<ProvinceEntity>()); }
			set { _provinces = value; }
		}
	}
}