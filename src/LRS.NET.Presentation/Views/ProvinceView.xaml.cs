namespace LRS.NET.Presentation.Views {
	using System.ComponentModel.Composition;
	using System.Windows.Controls;

	using LRS.NET.View.Globalization;

	[Export(typeof (IProvinceView))]
	public partial class ProvinceView : UserControl, IProvinceView {
		public ProvinceView() {
			InitializeComponent();
		}
	}
}