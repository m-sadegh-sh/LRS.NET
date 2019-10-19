namespace LRS.NET.Data.Mapping.Globalization {
	using LRS.NET.Core.Domain.Entities.Globalization;

	internal class CountryMapping : EntityMappingBase<CountryEntity> {
		public CountryMapping() {
			ToTable("Countries", "Globalization");

			Property(c => c.Name).HasMaxLength(60);
			HasMany(c => c.Provinces).WithRequired(p => p.Country).WillCascadeOnDelete(false);
		}
	}
}