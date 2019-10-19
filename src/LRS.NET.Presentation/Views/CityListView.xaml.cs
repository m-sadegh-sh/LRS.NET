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

	[Export(typeof (ICityListView))]
	public partial class CityListView : UserControl, ICityListView {
		private readonly Lazy<CityListViewModel> _viewModel;
		private ICollectionView _cityCollectionView;

		public CityListView() {
			InitializeComponent();

			_viewModel = new Lazy<CityListViewModel>(this.GetViewModel<CityListViewModel>);
			Loaded += OnLoaded;
		}

		private CityListViewModel ViewModel {
			get { return _viewModel.Value; }
		}

		public new void Focus() {
			CityDataGrid.Focus();
			CityDataGrid.CurrentCell = new DataGridCellInfo(CityDataGrid.SelectedItem, CityDataGrid.Columns[0]);
		}

		private void OnLoaded(object sender, RoutedEventArgs e) {
			Loaded -= OnLoaded;

			if (!WafConfiguration.IsInDesignMode) {
				_cityCollectionView = CollectionViewSource.GetDefaultView(ViewModel.Items);
				_cityCollectionView.Filter = Filter;
				ViewModel.ItemCollectionView = _cityCollectionView.Cast<CityDataModel>();

				CityDataGrid.Focus();
				CityDataGrid.CurrentCell = new DataGridCellInfo(ViewModel.Items.FirstOrDefault(), CityDataGrid.Columns[0]);
			}
		}

		private void FilterTextBox_OnTextChanged(object sender, TextChangedEventArgs e) {
			if (CityDataGrid.CommitEdit(DataGridEditingUnit.Row, true))
				_cityCollectionView.Refresh();
		}

		private bool Filter(object obj) {
			return ViewModel.Filter((CityDataModel) obj);
		}

		private void CityDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
			foreach (CityDataModel city in e.RemovedItems)
				ViewModel.RemoveSelectedItem(city);

			foreach (CityDataModel city in e.AddedItems)
				ViewModel.AddSelectedItem(city);
		}
	}
}