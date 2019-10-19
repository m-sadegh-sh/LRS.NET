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
	public class CountrySelectorViewModel : ViewModel<ICountrySelectorView> {
		private readonly DelegateCommand _confirmCommand;
		private ProvinceEntity _province;
		private IEnumerable<CountryEntity> _countries;
		private CountryEntity _selectedCountry;
		private bool _dialogResult;

		[ImportingConstructor]
		public CountrySelectorViewModel(ICountrySelectorView view) : base(view) {
			_confirmCommand = new DelegateCommand(Confirm_OnExecute);
		}

		public static string Title {
			get { return Controls.Window_Country_Selector; }
		}

		public ICommand ConfirmCommand {
			get { return _confirmCommand; }
		}

		public ProvinceEntity Province {
			get { return _province; }
			set { SetProperty(ref _province, value); }
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
			set { SetProperty(ref _selectedCountry, value); }
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