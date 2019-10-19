namespace LRS.NET.Core.Domain.Entities.Globalization {
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Collections.Specialized;
	using System.ComponentModel.DataAnnotations;

	using LRS.NET.Resources;

	public class ProvinceEntity : EntityBase {
		private CountryEntity _country;
		private string _name;
		private ICollection<CityEntity> _cities;

		[Display(Name = "Label_Province_Country", ResourceType = typeof (Controls))]
		[Required(ErrorMessageResourceName = "Error_Required_Selectable", ErrorMessageResourceType = typeof (Validations))]
		public virtual CountryEntity Country {
			get { return _country; }
			set { SetPropertyAndValidate(ref _country, value); }
		}

		[Display(Name = "Label_Province_Name", ResourceType = typeof (Controls))]
		[Required(ErrorMessageResourceName = "Error_Required", ErrorMessageResourceType = typeof (Validations))]
		[StringLength(60, ErrorMessageResourceName = "Error_InvalidLength", ErrorMessageResourceType = typeof (Validations))]
		public virtual string Name {
			get { return _name; }
			set { SetPropertyAndValidate(ref _name, value); }
		}

		public ProvinceEntity() {
			var x = new ObservableCollection<CityEntity>();
			x.CollectionChanged += x_CollectionChanged;
		}

		public virtual int CitisCount {
			get { return _cities.Count; }
		}

		private void x_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {}

		public virtual ICollection<CityEntity> Cities {
			get { return _cities ?? (_cities = new ObservableCollection<CityEntity>()); }
			set { _cities = value; }
		}
	}
}