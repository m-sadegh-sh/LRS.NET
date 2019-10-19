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

	[Export(typeof (IProvinceListView))]
	public partial class ProvinceListView : UserControl, IProvinceListView {
		private readonly Lazy<ProvinceListViewModel> _viewModel;
		private ICollectionView _provinceCollectionView;

		public ProvinceListView() {
			InitializeComponent();

			_viewModel = new Lazy<ProvinceListViewModel>(this.GetViewModel<ProvinceListViewModel>);
			Loaded += OnLoaded;
		}

		private ProvinceListViewModel ViewModel {
			get { return _viewModel.Value; }
		}

		public new void Focus() {
			ProvinceDataGrid.Focus();
			ProvinceDataGrid.CurrentCell = new DataGridCellInfo(ProvinceDataGrid.SelectedItem, ProvinceDataGrid.Columns[0]);
		}

		private void OnLoaded(object sender, RoutedEventArgs e) {
			Loaded -= OnLoaded;

			if (!WafConfiguration.IsInDesignMode) {
				_provinceCollectionView = CollectionViewSource.GetDefaultView(ViewModel.Items);
				_provinceCollectionView.Filter = Filter;
				ViewModel.ItemCollectionView = _provinceCollectionView.Cast<ProvinceDataModel>();

				ProvinceDataGrid.Focus();
				ProvinceDataGrid.CurrentCell = new DataGridCellInfo(ViewModel.Items.FirstOrDefault(), ProvinceDataGrid.Columns[0]);
			}
		}

		private void FilterTextBox_OnTextChanged(object sender, TextChangedEventArgs e) {
			if (ProvinceDataGrid.CommitEdit(DataGridEditingUnit.Row, true))
				_provinceCollectionView.Refresh();
		}

		private bool Filter(object obj) {
			return ViewModel.Filter((ProvinceDataModel) obj);
		}

		private void ProvinceDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
			foreach (ProvinceDataModel province in e.RemovedItems)
				ViewModel.RemoveSelectedItem(province);

			foreach (ProvinceDataModel province in e.AddedItems)
				ViewModel.AddSelectedItem(province);
		}
	}
}