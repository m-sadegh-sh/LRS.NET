namespace LRS.NET.Presentation.Views {
	using System.ComponentModel.Composition;

	using Elysium.Controls;

	using LRS.NET.View.Globalization;

	[Export(typeof (ICountrySelectorView))]
	[PartCreationPolicy(CreationPolicy.NonShared)]
	public partial class CountrySelectorView : Window, ICountrySelectorView {
		public CountrySelectorView() {
			InitializeComponent();
		}

		public void ShowDialog(object owner) {
			Owner = owner as System.Windows.Window;

			ShowDialog();
		}
	}
}