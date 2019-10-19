namespace LRS.NET.ViewModels.Globalization {
	using System.ComponentModel.Composition;

	using LRS.NET.Core.Domain.Entities.Globalization;
	using LRS.NET.DataModels.Globalization;
	using LRS.NET.View.Globalization;

	[Export]
	public class ProvinceListViewModel : ListViewModelBase<IProvinceListView, ProvinceDataModel, ProvinceEntity> {
		[ImportingConstructor]
		public ProvinceListViewModel(IProvinceListView view) : base(view) {}

		protected override bool FilterCore(ProvinceEntity province) {
			return string.IsNullOrEmpty(province.Name) || province.Name.Contains(FilterText);
		}

		public void Focus() {
			ViewCore.Focus();
		}
	}
}