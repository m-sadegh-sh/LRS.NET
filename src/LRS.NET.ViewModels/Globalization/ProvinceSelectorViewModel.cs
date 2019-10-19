namespace LRS.NET.ViewModels.Globalization {
	using System.Collections.Generic;
	using System.ComponentModel.Composition;
	using System.Linq;
	using System.Waf.Applications;
	using System.Windows.Input;

	using LRS.NET.Core.Domain.Entities.Globalization;
	using LRS.NET.Resources;
	using LRS.NET.View.Globalization;

	[Export]
	[PartCreationPolicy(CreationPolicy.NonShared)]
	public class ProvinceSelectorViewModel : ViewModel<IProvinceSelectorView> {
		private readonly DelegateCommand _confirmCommand;
		private CityEntity _city;
		private IEnumerable<CountryEntity> _countries;
		private CountryEntity _selectedCountry;
		private IEnumerable<ProvinceEntity> _provinces;
		private ProvinceEntity _selectedProvince;
		private bool _dialogResult;

		[ImportingConstructor]
		public ProvinceSelectorViewModel(IProvinceSelectorView view) : base(view) {
			_confirmCommand = new DelegateCommand(Confirm_OnExecute);
		}

		public static string Title {
			get { return Controls.Window_Province_Selector; }
		}

		public ICommand ConfirmCommand {
			get { return _confirmCommand; }
		}

		public CityEntity City {
			get { return _city; }
			set { SetProperty(ref _city, value); }
		}

		public IEnumerable<CountryEntity> Countries {
			get { return _countries; }
			set {
				if (SetProperty(ref _countries, value))
					SelectedCountry = _countries.FirstOrDefault();
			}
		}

		public CountryEntity SelectedCountry {
			get { return _selectedCountry; }
			set {
				if (SetProperty(ref _selectedCountry, value))
					Provinces = _selectedCountry.Provinces;
			}
		}

		public IEnumerable<ProvinceEntity> Provinces {
			get { return _provinces; }
			set {
				if (SetProperty(ref _provinces, value))
					SelectedProvince = _provinces.FirstOrDefault();
			}
		}

		public ProvinceEntity SelectedProvince {
			get { return _selectedProvince; }
			set {
				if (SetProperty(ref _selectedProvince, value))
					SelectedCountry = _selectedProvince.Country;
			}
		}

		public bool ShowDialog(object owner) {
			ViewCore.ShowDialog(owner);

			return _dialogResult;
		}

		private void Confirm_OnExecute() {
			_dialogResult = true;

			ViewCore.Close();
		}
	}
}