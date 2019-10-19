namespace LRS.NET.Controllers.Globalization {
	using System.ComponentModel;
	using System.ComponentModel.Composition;
	using System.Linq;
	using System.Waf.Applications;
	using System.Waf.Foundation;

	using LRS.NET.Core.Domain.Entities.Globalization;
	using LRS.NET.DataModels.Globalization;
	using LRS.NET.Services;
	using LRS.NET.View.Globalization;
	using LRS.NET.ViewModels.Globalization;

	[Export]
	public class CountryController {
		private readonly IViewService _viewService;
		private readonly IEntityService _entityService;
		private readonly CountryListViewModel _countryListViewModel;
		private readonly CountryViewModel _countryViewModel;
		private readonly DelegateCommand _addNewCommand;
		private readonly DelegateCommand _removeCommand;
		private SynchronizingCollection<CountryDataModel, CountryEntity> _countryDataModels;

		[ImportingConstructor]
		public CountryController(IViewService viewService, IEntityService entityService, CountryListViewModel countryListViewModel, CountryViewModel countryViewModel) {
			_viewService = viewService;
			_entityService = entityService;
			_countryListViewModel = countryListViewModel;
			_countryViewModel = countryViewModel;
			_addNewCommand = new DelegateCommand(AddNewCountry_OnExecute, AddNewCountry_OnCanExecute);
			_removeCommand = new DelegateCommand(RemoveCountry_OnExecute, RemoveCountry_OnCanExecute);
		}

		public void Initialize() {
			PropertyChangedEventManager.AddHandler(_countryViewModel, CountryViewModel_OnPropertyChanged, "");

			_countryDataModels = new SynchronizingCollection<CountryDataModel, CountryEntity>(_entityService.Countries, c => new CountryDataModel(c));
			_countryListViewModel.Items = _countryDataModels;
			_countryListViewModel.AddCommand = _addNewCommand;
			_countryListViewModel.RemoveCommand = _removeCommand;
			PropertyChangedEventManager.AddHandler(_countryListViewModel, CountryListViewModel_OnPropertyChanged, "");

			_viewService.CountryListView = (ICountryListView) _countryListViewModel.View;
			_viewService.CountryView = (ICountryView) _countryViewModel.View;

			_countryListViewModel.SelectedItem = _countryListViewModel.Items.FirstOrDefault();
		}

		private void CountryListViewModel_OnPropertyChanged(object sender, PropertyChangedEventArgs e) {
			if (e.PropertyName == "SelectedItem") {
				_countryViewModel.Entity = _countryListViewModel.SelectedItem != null ? _countryListViewModel.SelectedItem.Entity : null;
				UpdateCommands();
			} else if (e.PropertyName == "IsValid")
				UpdateCommands();
		}

		private void CountryViewModel_OnPropertyChanged(object sender, PropertyChangedEventArgs e) {
			if (e.PropertyName == "IsValid")
				UpdateCommands();
		}

		private bool AddNewCountry_OnCanExecute() {
			return _countryListViewModel.IsValid && _countryViewModel.IsValid;
		}

		private void AddNewCountry_OnExecute() {
			var country = new CountryEntity();
			country.Validate();
			_entityService.Countries.Add(country);

			_countryListViewModel.SelectedItem = _countryDataModels.Single(c => c.Entity == country);
			_countryListViewModel.Focus();
		}

		private bool RemoveCountry_OnCanExecute() {
			return _countryListViewModel.SelectedItem != null && _countryListViewModel.IsValid && _countryViewModel.IsValid;
		}

		private void RemoveCountry_OnExecute() {
			var countriesToExclude = _countryListViewModel.SelectedItems.Except(new[] {
				_countryListViewModel.SelectedItem
			});

			var nextCountry = CollectionHelper.GetNextElementOrDefault(_countryListViewModel.ItemCollectionView.Except(countriesToExclude), _countryListViewModel.SelectedItem);

			foreach (var country in _countryListViewModel.SelectedItems.ToArray())
				_entityService.Countries.Remove(country.Entity);

			_countryListViewModel.SelectedItem = nextCountry ?? _countryListViewModel.ItemCollectionView.LastOrDefault();
			_countryListViewModel.Focus();
		}

		private void UpdateCommands() {
			_addNewCommand.RaiseCanExecuteChanged();
			_removeCommand.RaiseCanExecuteChanged();
		}
	}
}