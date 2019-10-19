namespace LRS.NET.DataModels.Globalization {
	using LRS.NET.Core.Domain.Entities.Globalization;

	public class CountryDataModel : DataModelBase<CountryEntity> {
		public CountryDataModel(CountryEntity country) : base(country) {}
	}
}