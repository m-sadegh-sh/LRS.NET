namespace LRS.NET.ViewModels {
	using System.Waf.Applications;

	using LRS.NET.Core.Domain.Entities;

	public abstract class ViewModelBase<TView, TEntity> : ViewModel<TView> where TView : class, IView where TEntity : EntityBase {
		private bool _isValid = true;
		private TEntity _entity;

		protected ViewModelBase(TView view) : base(view) {}

		public TEntity Entity {
			get { return _entity; }
			set {
				if (SetProperty(ref _entity, value))
					RaisePropertyChanged("IsEnabled");
			}
		}

		public bool IsEnabled {
			get { return _entity != null; }
		}

		public bool IsValid {
			get { return _isValid; }
			set { SetProperty(ref _isValid, value); }
		}
	}
}