namespace LRS.NET.Services {
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.ComponentModel.Composition;
	using System.Waf.Foundation;

	using LRS.NET.Resources;
	using LRS.NET.View;
	using LRS.NET.View.Globalization;

	[Export]
	[Export(typeof (IViewService))]
	public class ViewService : Model, IViewService {
		private IShellView _shellView;
		private ICityListView _cityListView;
		private ICityView _cityView;
		private IProvinceListView _provinceListView;
		private IProvinceView _provinceView;
		private ICountryListView _countryListView;
		private ICountryView _countryView;

		public IShellView ShellView {
			get { return _shellView; }
			set { SetProperty(ref _shellView, value); }
		}

		public ICollection<ViewContent> Contents {
			get {
				var contents = new ObservableCollection<ViewContent> {
					new ViewContent(Controls.Window_City, CityListView, CityView),
					new ViewContent(Controls.Window_Province, ProvinceListView, ProvinceView),
					new ViewContent(Controls.Window_Country, CountryListView, CountryView)
				};

				return contents;
			}
		}

		public ICityListView CityListView {
			get { return _cityListView; }
			set { SetProperty(ref _cityListView, value); }
		}

		public ICityView CityView {
			get { return _cityView; }
			set { SetProperty(ref _cityView, value); }
		}

		public IProvinceListView ProvinceListView {
			get { return _provinceListView; }
			set { SetProperty(ref _provinceListView, value); }
		}

		public IProvinceView ProvinceView {
			get { return _provinceView; }
			set { SetProperty(ref _provinceView, value); }
		}

		public ICountryListView CountryListView {
			get { return _countryListView; }
			set { SetProperty(ref _countryListView, value); }
		}

		public ICountryView CountryView {
			get { return _countryView; }
			set { SetProperty(ref _countryView, value); }
		}
	}
}