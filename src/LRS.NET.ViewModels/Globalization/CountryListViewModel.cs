namespace LRS.NET.ViewModels.Globalization {
	using System.ComponentModel.Composition;

	using LRS.NET.Core.Domain.Entities.Globalization;
	using LRS.NET.DataModels.Globalization;
	using LRS.NET.View.Globalization;

	[Export]
	public class CountryListViewModel : ListViewModelBase<ICountryListView, CountryDataModel, CountryEntity> {
		[ImportingConstructor]
		public CountryListViewModel(ICountryListView view) : base(view) {}

		protected override bool FilterCore(CountryEntity country) {
			return string.IsNullOrEmpty(country.Name) || country.Name.Contains(FilterText);
		}

		public void Focus() {
			ViewCore.Focus();
		}
	}
}