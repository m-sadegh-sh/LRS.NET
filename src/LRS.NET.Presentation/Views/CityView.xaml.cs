namespace LRS.NET.Presentation.Views {
	using System.ComponentModel.Composition;
	using System.Windows.Controls;

	using LRS.NET.View.Globalization;

	[Export(typeof (ICityView))]
	public partial class CityView : UserControl, ICityView {
		public CityView() {
			InitializeComponent();
		}
	}
}