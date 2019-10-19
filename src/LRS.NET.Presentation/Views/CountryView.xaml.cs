namespace LRS.NET.Presentation.Views {
	using System.ComponentModel.Composition;
	using System.Windows.Controls;

	using LRS.NET.View.Globalization;

	[Export(typeof (ICountryView))]
	public partial class CountryView : UserControl, ICountryView {
		public CountryView() {
			InitializeComponent();
		}
	}
}