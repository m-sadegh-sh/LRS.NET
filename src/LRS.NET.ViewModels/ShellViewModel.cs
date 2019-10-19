namespace LRS.NET.ViewModels {
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.ComponentModel.Composition;
	using System.Waf.Applications;
	using System.Waf.Applications.Services;
	using System.Windows.Input;

	using LRS.NET.Resources;
	using LRS.NET.Services;
	using LRS.NET.Settings;
	using LRS.NET.View;

	[Export]
	public class ShellViewModel : ViewModel<IShellView> {
		private readonly IMessageService _messageService;
		private readonly IViewService _viewService;
		private readonly DelegateCommand _aboutCommand;
		private ICommand _saveCommand;
		private ICommand _exitCommand;
		private bool _isValid = true;
		private bool _isBusy;

		[ImportingConstructor]
		public ShellViewModel(IShellView shellView, IMessageService messageService, IPresentationService presentationService, IViewService viewService) : base(shellView) {
			_messageService = messageService;
			_viewService = viewService;
			_aboutCommand = new DelegateCommand(About_OnExecute);
			shellView.Closing += OnViewClosing;
			shellView.Closed += OnViewClosed;

			if (AppSettings.Default.Left >= 0 && AppSettings.Default.Top >= 0 && AppSettings.Default.Width > 0 && AppSettings.Default.Height > 0 && AppSettings.Default.Left + AppSettings.Default.Width <= presentationService.VirtualScreenWidth &&
			    AppSettings.Default.Top + AppSettings.Default.Height <= presentationService.VirtualScreenHeight) {
				ViewCore.Left = AppSettings.Default.Left;
				ViewCore.Top = AppSettings.Default.Top;
				ViewCore.Height = AppSettings.Default.Height;
				ViewCore.Width = AppSettings.Default.Width;
			}

			ViewCore.IsMaximized = AppSettings.Default.IsMaximized;
		}

		public string Title {
			get { return Controls.App_Title; }
		}

		public IViewService ViewService {
			get { return _viewService; }
		}

		public ICollection<ViewContent> Contents {
			get { return ViewService.Contents; }
		}

		public ICommand AboutCommand {
			get { return _aboutCommand; }
		}

		public ICommand SaveCommand {
			get { return _saveCommand; }
			set { SetProperty(ref _saveCommand, value); }
		}

		public ICommand ExitCommand {
			get { return _exitCommand; }
			set { SetProperty(ref _exitCommand, value); }
		}

		public bool IsValid {
			get { return _isValid; }
			set { SetProperty(ref _isValid, value); }
		}

		public bool IsBusy {
			get { return _isBusy; }
			set { SetProperty(ref _isBusy, value); }
		}

		public event CancelEventHandler Closing;

		public void Show() {
			ViewCore.Show();
		}

		public void Close() {
			ViewCore.Close();
		}

		protected virtual void OnClosing(CancelEventArgs e) {
			if (Closing != null)
				Closing(this, e);
		}

		private void OnViewClosing(object sender, CancelEventArgs e) {
			OnClosing(e);
		}

		private void OnViewClosed(object sender, EventArgs e) {
			AppSettings.Default.Left = ViewCore.Left;
			AppSettings.Default.Top = ViewCore.Top;
			AppSettings.Default.Height = ViewCore.Height;
			AppSettings.Default.Width = ViewCore.Width;
			AppSettings.Default.IsMaximized = ViewCore.IsMaximized;
		}

		private void About_OnExecute() {
			_messageService.ShowMessage(View, string.Format(Messages.AboutText, ApplicationInfo.ProductName, ApplicationInfo.Version, Controls.App_Title));
		}
	}
}