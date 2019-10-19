namespace LRS.NET.Services {
	using System.Collections.ObjectModel;

	using LRS.NET.Core.Domain.Entities.Globalization;
	using LRS.NET.Data;

	public interface IEntityService {
		AppDbContext DbContext { get; set; }
		ObservableCollection<CityEntity> Cities { get; }
		ObservableCollection<ProvinceEntity> Provinces { get; }
		ObservableCollection<CountryEntity> Countries { get; }
	}
}