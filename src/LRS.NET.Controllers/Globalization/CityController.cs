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
	public class CityController {
		private readonly IViewService _viewService;
		private readonly IEntityService _entityService;
		private readonly CityListViewModel _cityListViewModel;
		private readonly CityViewModel _cityViewModel;
		private readonly ExportFactory<ProvinceSelectorViewModel> _provinceSelectorViewModelFactory;
		private readonly DelegateCommand _addNewCommand;
		private readonly DelegateCommand _removeCommand;
		private readonly DelegateCommand _selectProvinceCommand;
		private SynchronizingCollection<CityDataModel, CityEntity> _cityDataModels;

		[ImportingConstructor]
		public CityController(IViewService viewService, IEntityService entityService, CityListViewModel cityListViewModel, CityViewModel cityViewModel, ExportFactory<ProvinceSelectorViewModel> provinceSelectorViewModelFactory) {
			_viewService = viewService;
			_entityService = entityService;
			_cityListViewModel = cityListViewModel;
			_cityViewModel = cityViewModel;
			_provinceSelectorViewModelFactory = provinceSelectorViewModelFactory;
			_addNewCommand = new DelegateCommand(AddNewCity_OnExecute, AddNewCity_OnCanExecute);
			_removeCommand = new DelegateCommand(RemoveCity_OnExecute, RemoveCity_OnCanExecute);
			_selectProvinceCommand = new DelegateCommand(c => SelectProvince_OnExecute((CityEntity) c));
		}

		public void Initialize() {
			_cityViewModel.SelectProvinceCommand = _selectProvinceCommand;
			PropertyChangedEventManager.AddHandler(_cityViewModel, CityViewModel_OnPropertyChanged, "");

			_cityDataModels = new SynchronizingCollection<CityDataModel, CityEntity>(_entityService.Cities, c => new CityDataModel(c, _selectProvinceCommand));
			_cityListViewModel.Items = _cityDataModels;
			_cityListViewModel.AddCommand = _addNewCommand;
			_cityListViewModel.RemoveCommand = _removeCommand;
			PropertyChangedEventManager.AddHandler(_cityListViewModel, CityListViewModel_OnPropertyChanged, "");

			_viewService.CityListView = (ICityListView) _cityListViewModel.View;
			_viewService.CityView = (ICityView) _cityViewModel.View;

			_cityListViewModel.SelectedItem = _cityListViewModel.Items.FirstOrDefault();
		}

		private void CityListViewModel_OnPropertyChanged(object sender, PropertyChangedEventArgs e) {
			if (e.PropertyName == "SelectedItem") {
				_cityViewModel.Entity = _cityListViewModel.SelectedItem != null ? _cityListViewModel.SelectedItem.Entity : null;
				UpdateCommands();
			} else if (e.PropertyName == "IsValid")
				UpdateCommands();
		}

		private void CityViewModel_OnPropertyChanged(object sender, PropertyChangedEventArgs e) {
			if (e.PropertyName == "IsValid")
				UpdateCommands();
		}

		private bool AddNewCity_OnCanExecute() {
			return _cityListViewModel.IsValid && _cityViewModel.IsValid;
		}

		private void AddNewCity_OnExecute() {
			var city = new CityEntity();
			city.Validate();
			_entityService.Cities.Add(city);

			_cityListViewModel.SelectedItem = _cityDataModels.Single(c => c.Entity == city);
			_cityListViewModel.Focus();
		}

		private bool RemoveCity_OnCanExecute() {
			return _cityListViewModel.SelectedItem != null && _cityListViewModel.IsValid && _cityViewModel.IsValid;
		}

		private void RemoveCity_OnExecute() {
			var citysToExclude = _cityListViewModel.SelectedItems.Except(new[] {
				_cityListViewModel.SelectedItem
			});

			var nextCity = CollectionHelper.GetNextElementOrDefault(_cityListViewModel.ItemCollectionView.Except(citysToExclude), _cityListViewModel.SelectedItem);

			foreach (var city in _cityListViewModel.SelectedItems.ToArray())
				_entityService.Cities.Remove(city.Entity);

			_cityListViewModel.SelectedItem = nextCity ?? _cityListViewModel.ItemCollectionView.LastOrDefault();
			_cityListViewModel.Focus();
		}

		private void SelectProvince_OnExecute(CityEntity city) {
			var provinceSelectorViewModel = _provinceSelectorViewModelFactory.CreateExport().Value;
			provinceSelectorViewModel.City = city;
			provinceSelectorViewModel.Countries = _entityService.Countries;

			if (provinceSelectorViewModel.ShowDialog(_viewService.ShellView))
				city.Province = provinceSelectorViewModel.SelectedProvince;
		}

		private void UpdateCommands() {
			_addNewCommand.RaiseCanExecuteChanged();
			_removeCommand.RaiseCanExecuteChanged();
			_selectProvinceCommand.RaiseCanExecuteChanged();
		}
	}
}