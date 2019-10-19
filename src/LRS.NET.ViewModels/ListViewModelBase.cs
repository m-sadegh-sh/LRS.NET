namespace LRS.NET.ViewModels {
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Waf.Applications;
	using System.Windows.Input;

	using LRS.NET.Core.Domain.Entities;
	using LRS.NET.DataModels;

	public abstract class ListViewModelBase<TView, TDataModel, TEntity> : ViewModel<TView> where TView : class, IView where TDataModel : DataModelBase<TEntity> where TEntity : EntityBase {
		private IEnumerable<TDataModel> _items;
		private readonly ObservableCollection<TDataModel> _selectedItems;
		private TDataModel _selectedItem;
		private bool _isValid = true;
		private string _filterText = "";
		private ICommand _addCommand;
		private ICommand _removeCommand;

		protected ListViewModelBase(TView view) : base(view) {
			_selectedItems = new ObservableCollection<TDataModel>();
		}

		public IEnumerable<TDataModel> Items {
			get { return _items; }
			set { SetProperty(ref _items, value); }
		}

		public IEnumerable<TDataModel> ItemCollectionView { get; set; }

		public IEnumerable<TDataModel> SelectedItems {
			get { return _selectedItems; }
		}

		public void AddSelectedItem(TDataModel dataModel) {
			_selectedItems.Add(dataModel);
		}

		public void RemoveSelectedItem(TDataModel dataModel) {
			_selectedItems.Remove(dataModel);
		}

		public TDataModel SelectedItem {
			get { return _selectedItem; }
			set { SetProperty(ref _selectedItem, value); }
		}

		public ICommand AddCommand {
			get { return _addCommand; }
			set { SetProperty(ref _addCommand, value); }
		}

		public ICommand RemoveCommand {
			get { return _removeCommand; }
			set { SetProperty(ref _removeCommand, value); }
		}

		public bool IsValid {
			get { return _isValid; }
			set { SetProperty(ref _isValid, value); }
		}

		public string FilterText {
			get { return _filterText; }
			set { SetProperty(ref _filterText, value); }
		}

		public bool Filter(TDataModel dataModel) {
			if (string.IsNullOrEmpty(_filterText))
				return true;

			return FilterCore(dataModel.Entity);
		}

		protected abstract bool FilterCore(TEntity entity);
	}
}