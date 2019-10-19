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
	public class ProvinceController {
		private readonly IViewService _viewService;
		private readonly IEntityService _entityService;
		private readonly ProvinceListViewModel _provinceListViewModel;
		private readonly ProvinceViewModel _provinceViewModel;
		private readonly ExportFactory<CountrySelectorViewModel> _countrySelectorViewModelFactory;
		private readonly DelegateCommand _addNewCommand;
		private readonly DelegateCommand _removeCommand;
		private readonly DelegateCommand _selectCountryCommand;
		private SynchronizingCollection<ProvinceDataModel, ProvinceEntity> _provinceDataModels;

		[ImportingConstructor]
		public ProvinceController(IViewService viewService, IEntityService entityService, ProvinceListViewModel provinceListViewModel, ProvinceViewModel provinceViewModel, ExportFactory<CountrySelectorViewModel> countrySelectorViewModelFactory) {
			_viewService = viewService;
			_entityService = entityService;
			_provinceListViewModel = provinceListViewModel;
			_provinceViewModel = provinceViewModel;
			_countrySelectorViewModelFactory = countrySelectorViewModelFactory;
			_addNewCommand = new DelegateCommand(AddNewProvince_OnExecute, AddNewProvince_OnCanExecute);
			_removeCommand = new DelegateCommand(RemoveProvince_OnExecute, RemoveProvince_OnCanExecute);
			_selectCountryCommand = new DelegateCommand(p => SelectCountry_OnExecute((ProvinceEntity) p));
		}

		public void Initialize() {
			_provinceViewModel.SelectCountryCommand = _selectCountryCommand;
			PropertyChangedEventManager.AddHandler(_provinceViewModel, ProvinceViewModel_OnPropertyChanged, "");

			_provinceDataModels = new SynchronizingCollection<ProvinceDataModel, ProvinceEntity>(_entityService.Provinces, c => new ProvinceDataModel(c, _selectCountryCommand));
			_provinceListViewModel.Items = _provinceDataModels;
			_provinceListViewModel.AddCommand = _addNewCommand;
			_provinceListViewModel.RemoveCommand = _removeCommand;
			PropertyChangedEventManager.AddHandler(_provinceListViewModel, ProvinceListViewModel_OnPropertyChanged, "");

			_viewService.ProvinceListView = (IProvinceListView) _provinceListViewModel.View;
			_viewService.ProvinceView = (IProvinceView) _provinceViewModel.View;

			_provinceListViewModel.SelectedItem = _provinceListViewModel.Items.FirstOrDefault();
		}

		private void ProvinceListViewModel_OnPropertyChanged(object sender, PropertyChangedEventArgs e) {
			if (e.PropertyName == "SelectedItem") {
				_provinceViewModel.Entity = _provinceListViewModel.SelectedItem != null ? _provinceListViewModel.SelectedItem.Entity : null;
				UpdateCommands();
			} else if (e.PropertyName == "IsValid")
				UpdateCommands();
		}

		private void ProvinceViewModel_OnPropertyChanged(object sender, PropertyChangedEventArgs e) {
			if (e.PropertyName == "IsValid")
				UpdateCommands();
		}

		private bool AddNewProvince_OnCanExecute() {
			return _provinceListViewModel.IsValid && _provinceViewModel.IsValid;
		}

		private void AddNewProvince_OnExecute() {
			var province = new ProvinceEntity();
			province.Validate();
			_entityService.Provinces.Add(province);

			_provinceListViewModel.SelectedItem = _provinceDataModels.Single(p => p.Entity == province);
			_provinceListViewModel.Focus();
		}

		private bool RemoveProvince_OnCanExecute() {
			return _provinceListViewModel.SelectedItem != null && _provinceListViewModel.IsValid && _provinceViewModel.IsValid;
		}

		private void RemoveProvince_OnExecute() {
			var provincesToExclude = _provinceListViewModel.SelectedItems.Except(new[] {
				_provinceListViewModel.SelectedItem
			});

			var nextProvince = CollectionHelper.GetNextElementOrDefault(_provinceListViewModel.ItemCollectionView.Except(provincesToExclude), _provinceListViewModel.SelectedItem);

			foreach (var province in _provinceListViewModel.SelectedItems.ToArray())
				_entityService.Provinces.Remove(province.Entity);

			_provinceListViewModel.SelectedItem = nextProvince ?? _provinceListViewModel.ItemCollectionView.LastOrDefault();
			_provinceListViewModel.Focus();
		}

		private void SelectCountry_OnExecute(ProvinceEntity province) {
			var countrySelectorViewModel = _countrySelectorViewModelFactory.CreateExport().Value;
			countrySelectorViewModel.Province = province;
			countrySelectorViewModel.Countries = _entityService.Countries;

			if (countrySelectorViewModel.ShowDialog(_viewService.ShellView))
				province.Country = countrySelectorViewModel.SelectedCountry;
		}

		private void UpdateCommands() {
			_addNewCommand.RaiseCanExecuteChanged();
			_removeCommand.RaiseCanExecuteChanged();
			_selectCountryCommand.RaiseCanExecuteChanged();
		}
	}
}