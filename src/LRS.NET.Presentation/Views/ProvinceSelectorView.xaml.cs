namespace LRS.NET.Presentation.Views {
	using System.ComponentModel.Composition;

	using Elysium.Controls;

	using LRS.NET.View.Globalization;

	[Export(typeof (IProvinceSelectorView))]
	[PartCreationPolicy(CreationPolicy.NonShared)]
	public partial class ProvinceSelectorView : Window, IProvinceSelectorView {
		public ProvinceSelectorView() {
			InitializeComponent();
		}

		public void ShowDialog(object owner) {
			Owner = owner as System.Windows.Window;

			ShowDialog();
		}
	}
}