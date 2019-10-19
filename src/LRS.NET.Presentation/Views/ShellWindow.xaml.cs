namespace LRS.NET.Presentation.Views {
	using System.ComponentModel.Composition;
	using System.Windows;

	using LRS.NET.View;

	using Window = Elysium.Controls.Window;

	[Export(typeof (IShellView))]
	public partial class ShellWindow : Window, IShellView {
		public ShellWindow() {
			InitializeComponent();
		}

		public bool IsMaximized {
			get { return WindowState == WindowState.Maximized; }
			set {
				if (value)
					WindowState = WindowState.Maximized;
				else if (WindowState == WindowState.Maximized)
					WindowState = WindowState.Normal;
			}
		}
	}
}