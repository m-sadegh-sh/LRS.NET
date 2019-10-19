namespace LRS.NET.Controllers {
	using System;
	using System.ComponentModel;
	using System.ComponentModel.Composition;
	using System.Data.Common;
	using System.Globalization;
	using System.Linq;
	using System.Waf.Applications;
	using System.Waf.Applications.Services;

	using LRS.NET.Data;
	using LRS.NET.Resources;
	using LRS.NET.Services;
	using LRS.NET.ViewModels;

	[Export(typeof (IEntityController))]
	public class EntityController : IEntityController {
		private readonly IEntityService _entityService;
		private readonly IMessageService _messageService;
		private readonly IViewService _viewService;
		private readonly Lazy<ShellViewModel> _shellViewModel;
		private readonly DelegateCommand _saveCommand;
		private DbConnection _connection;
		private AppDbContext _dbContext;

		[ImportingConstructor]
		public EntityController(IEntityService entityService, IMessageService messageService, IViewService viewService, Lazy<ShellViewModel> shellViewModel) {
			_entityService = entityService;
			_messageService = messageService;
			_viewService = viewService;
			_shellViewModel = shellViewModel;
			_saveCommand = new DelegateCommand(() => Save(), CanSave);
		}

		public bool HasChanges {
			get { return _dbContext != null && _dbContext.HasChanges; }
		}

		private ShellViewModel ShellViewModel {
			get { return _shellViewModel.Value; }
		}

		public void Initialize() {
			_connection = DbConnectionFactory.CreateConnection("AppDbContext");

			_dbContext = new AppDbContext(_connection);
			_entityService.DbContext = _dbContext;

			PropertyChangedEventManager.AddHandler(ShellViewModel, ShellViewModelPropertyChanged, "");
			ShellViewModel.SaveCommand = _saveCommand;
		}

		public void Shutdown() {
			_dbContext.Dispose();
			_connection.Dispose();
		}

		public bool CanSave() {
			return ShellViewModel.IsValid;
		}

		public bool Save() {
			if (!CanSave())
				throw new InvalidOperationException("You must not call Save when CanSave returns false.");

			var errors = _dbContext.GetValidationErrors();
			if (errors.Any()) {
				var errorMessages = errors.Select(x => string.Format(CultureInfo.CurrentCulture, Messages.EntityInvalid, EntityToString(x.Entry.Entity), string.Join(Environment.NewLine, x.ValidationErrors.Select(y => y.ErrorMessage))));
				_messageService.ShowError(_viewService.ShellView, string.Format(CultureInfo.CurrentCulture, Messages.SaveErrorInvalidEntities, string.Join(Environment.NewLine, errorMessages)));
				return false;
			}

			_dbContext.SaveChanges();
			return true;
		}

		private void ShellViewModelPropertyChanged(object sender, PropertyChangedEventArgs e) {
			if (e.PropertyName == "IsValid")
				_saveCommand.RaiseCanExecuteChanged();
		}

		internal static string EntityToString(object entity) {
			var formattableEntity = entity as IFormattable;
			if (formattableEntity != null)
				return formattableEntity.ToString(null, CultureInfo.CurrentCulture);
			return entity.ToString();
		}
	}
}