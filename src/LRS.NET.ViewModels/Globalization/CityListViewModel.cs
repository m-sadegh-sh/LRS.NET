namespace LRS.NET.ViewModels.Globalization {
	using System.ComponentModel.Composition;

	using LRS.NET.Core.Domain.Entities.Globalization;
	using LRS.NET.DataModels.Globalization;
	using LRS.NET.View.Globalization;

	[Export]
	public class CityListViewModel : ListViewModelBase<ICityListView, CityDataModel, CityEntity> {
		[ImportingConstructor]
		public CityListViewModel(ICityListView view) : base(view) {}

		protected override bool FilterCore(CityEntity city) {
			return string.IsNullOrEmpty(city.Name) || city.Name.Contains(FilterText);
		}

		public void Focus() {
			ViewCore.Focus();
		}
	}
}