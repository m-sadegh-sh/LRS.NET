namespace LRS.NET.Controllers {
	using System;
	using System.ComponentModel;
	using System.ComponentModel.Composition;
	using System.Waf.Applications;
	using System.Waf.Applications.Services;

	using LRS.NET.Controllers.Globalization;
	using LRS.NET.Resources;
	using LRS.NET.Services;
	using LRS.NET.Settings;
	using LRS.NET.View;
	using LRS.NET.ViewModels;

	[Export]
	[Export(typeof (IModuleController))]
	public class ShellController : IModuleController {
		private readonly IMessageService _messageService;
		private readonly IEntityController _entityController;
		private readonly CountryController _countryController;
		private readonly ProvinceController _provinceController;
		private readonly CityController _cityController;
		private readonly IViewService _viewService;
		private readonly Lazy<ShellViewModel> _shellViewModel;
		private readonly DelegateCommand _exitCommand;

		[ImportingConstructor]
		public ShellController(IMessageService messageService, IPresentationService presentationService, IEntityController entityController, CountryController countryController, ProvinceController provinceController, CityController cityController,
				IViewService viewService, Lazy<ShellViewModel> shellViewModel) {
			presentationService.InitializeCultures();

			_messageService = messageService;
			_entityController = entityController;
			_countryController = countryController;
			_provinceController = provinceController;
			_cityController = cityController;
			_viewService = viewService;
			_shellViewModel = shellViewModel;
			_exitCommand = new DelegateCommand(Close);
		}

		private ShellViewModel ShellViewModel {
			get { return _shellViewModel.Value; }
		}

		public void Initialize() {
			_viewService.ShellView = (IShellView) ShellViewModel.View;
			ShellViewModel.ExitCommand = _exitCommand;
			ShellViewModel.Closing += ShellViewModel_OnClosing;

			_entityController.Initialize();
			_countryController.Initialize();
			_provinceController.Initialize();
			_cityController.Initialize();
		}

		public void Run() {
			ShellViewModel.Show();
		}

		public void Shutdown() {
			_entityController.Shutdown();

			AppSettings.Default.Save();
		}

		private void ShellViewModel_OnClosing(object sender, CancelEventArgs e) {
			if (_entityController.HasChanges) {
				if (_entityController.CanSave()) {
					var result = _messageService.ShowQuestion(_viewService.ShellView, Messages.SaveChangesQuestion);
					if (result == true) {
						if (!_entityController.Save())
							e.Cancel = true;
					} else if (result == null)
						e.Cancel = true;
				} else
					e.Cancel = !_messageService.ShowYesNoQuestion(_viewService.ShellView, Messages.LoseChangesQuestion);
			}
		}

		private void Close() {
			ShellViewModel.Close();
		}
	}
}