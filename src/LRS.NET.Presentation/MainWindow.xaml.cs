namespace Elysium.Test {
	using System;
	using System.Diagnostics;
	using System.IO;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Media;
	using System.Windows.Shapes;

	public sealed partial class MainWindow {
		public MainWindow() {
			InitializeComponent();
		}

		private static readonly string Windows = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
		private static readonly string SegoeUI = Windows + @"\Fonts\SegoeUI.ttf";
		private static readonly string Verdana = Windows + @"\Fonts\Verdana.ttf";

		private void ThemeGlyphInitialized(object sender, EventArgs e) {
			ThemeGlyph.FontUri = new Uri(File.Exists(SegoeUI) ? SegoeUI : Verdana);
		}

		private void AccentGlyphInitialized(object sender, EventArgs e) {
			AccentGlyph.FontUri = new Uri(File.Exists(SegoeUI) ? SegoeUI : Verdana);
		}

		private void ContrastGlyphInitialized(object sender, EventArgs e) {
			ContrastGlyph.FontUri = new Uri(File.Exists(SegoeUI) ? SegoeUI : Verdana);
		}

		private void LightClick(object sender, RoutedEventArgs e) {
			Application.Current.Apply(Theme.Light);
		}

		private void DarkClick(object sender, RoutedEventArgs e) {
			Application.Current.Apply(Theme.Dark);
		}

		private void AccentClick(object sender, RoutedEventArgs e) {
			var item = e.Source as MenuItem;
			if (item != null) {
				var accentBrush = (SolidColorBrush) ((Rectangle) item.Icon).Fill;
				Application.Current.Apply(accentBrush, null);
			}
		}

		private void WhiteClick(object sender, RoutedEventArgs e) {
			Application.Current.Apply(null, Brushes.White);
		}

		private void BlackClick(object sender, RoutedEventArgs e) {
			Application.Current.Apply(null, Brushes.Black);
		}

		private async void NotificationClick(object sender, RoutedEventArgs e) {
			//await NotificationManager.TryPushAsync("Message", "The quick brown fox jumps over the lazy dog");
		}

		private void DonateClick(object sender, RoutedEventArgs e) {
			Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=KNYYZ7RM6LBCG");
		}

		private void LicenseClick(object sender, RoutedEventArgs e) {
			Process.Start("http://elysium.asvishnyakov.com/License.cshtml#header");
		}

		private void AuthorsClick(object sender, RoutedEventArgs e) {
			Process.Start("http://elysium.codeplex.com/team/view");
		}

		private void HelpClick(object sender, RoutedEventArgs e) {
			Process.Start("http://elysium.asvishnyakov.com/Documentation.cshtml#header");
		}
	}
}