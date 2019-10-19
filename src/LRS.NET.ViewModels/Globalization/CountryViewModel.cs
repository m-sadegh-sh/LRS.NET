namespace LRS.NET.ViewModels.Globalization {
	using System.ComponentModel.Composition;

	using LRS.NET.Core.Domain.Entities.Globalization;
	using LRS.NET.View.Globalization;

	[Export]
	public class CountryViewModel : ViewModelBase<ICountryView, CountryEntity> {
		[ImportingConstructor]
		public CountryViewModel(ICountryView view) : base(view) {}
	}
}