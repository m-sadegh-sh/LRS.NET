namespace LRS.NET.Services {
	using System.Collections.ObjectModel;
	using System.ComponentModel.Composition;
	using System.Data.Entity;

	using LRS.NET.Core.Domain.Entities.Globalization;
	using LRS.NET.Data;

	[Export]
	[Export(typeof (IEntityService))]
	public class EntityService : IEntityService {
		private ObservableCollection<CityEntity> _cities;
		private ObservableCollection<ProvinceEntity> _provinces;
		private ObservableCollection<CountryEntity> _countries;

		public AppDbContext DbContext { get; set; }

		public ObservableCollection<CityEntity> Cities {
			get {
				if (_cities == null && DbContext != null) {
					DbContext.Set<CityEntity>().Load();
					_cities = DbContext.Set<CityEntity>().Local;
				}

				return _cities;
			}
		}

		public ObservableCollection<ProvinceEntity> Provinces {
			get {
				if (_provinces == null && DbContext != null) {
					DbContext.Set<ProvinceEntity>().Load();
					_provinces = DbContext.Set<ProvinceEntity>().Local;
				}

				return _provinces;
			}
		}

		public ObservableCollection<CountryEntity> Countries {
			get {
				if (_countries == null && DbContext != null) {
					DbContext.Set<CountryEntity>().Load();
					_countries = DbContext.Set<CountryEntity>().Local;
				}

				return _countries;
			}
		}
	}
}