namespace LRS.NET.Presentation.Views {
	using System;
	using System.ComponentModel;
	using System.ComponentModel.Composition;
	using System.Linq;
	using System.Waf;
	using System.Waf.Applications;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Data;

	using LRS.NET.DataModels.Globalization;
	using LRS.NET.View.Globalization;
	using LRS.NET.ViewModels.Globalization;

	[Export(typeof (ICountryListView))]
	public partial class CountryListView : UserControl, ICountryListView {
		private readonly Lazy<CountryListViewModel> _viewModel;
		private ICollectionView _countryCollectionView;

		public CountryListView() {
			InitializeComponent();

			_viewModel = new Lazy<CountryListViewModel>(this.GetViewModel<CountryListViewModel>);
			Loaded += OnLoaded;
		}

		private CountryListViewModel ViewModel {
			get { return _viewModel.Value; }
		}

		public new void Focus() {
			CountryDataGrid.Focus();
			CountryDataGrid.CurrentCell = new DataGridCellInfo(CountryDataGrid.SelectedItem, CountryDataGrid.Columns[0]);
		}

		private void OnLoaded(object sender, RoutedEventArgs e) {
			Loaded -= OnLoaded;

			if (!WafConfiguration.IsInDesignMode) {
				_countryCollectionView = CollectionViewSource.GetDefaultView(ViewModel.Items);
				_countryCollectionView.Filter = Filter;
				ViewModel.ItemCollectionView = _countryCollectionView.Cast<CountryDataModel>();

				CountryDataGrid.Focus();
				CountryDataGrid.CurrentCell = new DataGridCellInfo(ViewModel.Items.FirstOrDefault(), CountryDataGrid.Columns[0]);
			}
		}

		private void FilterTextBox_OnTextChanged(object sender, TextChangedEventArgs e) {
			if (CountryDataGrid.CommitEdit(DataGridEditingUnit.Row, true))
				_countryCollectionView.Refresh();
		}

		private bool Filter(object obj) {
			return ViewModel.Filter((CountryDataModel) obj);
		}

		private void CountryDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
			foreach (CountryDataModel country in e.RemovedItems)
				ViewModel.RemoveSelectedItem(country);

			foreach (CountryDataModel country in e.AddedItems)
				ViewModel.AddSelectedItem(country);
		}
	}
}