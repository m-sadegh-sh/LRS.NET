namespace LRS.NET.Data.Mapping.Globalization {
	using LRS.NET.Core.Domain.Entities.Globalization;

	internal class ProvinceMapping : EntityMappingBase<ProvinceEntity> {
		public ProvinceMapping() {
			ToTable("Provinces", "Globalization");

			HasRequired(p => p.Country).WithMany().Map(p => p.MapKey("CountryId"));
			Property(p => p.Name).HasMaxLength(60).IsRequired();
			HasMany(p => p.Cities).WithRequired(c => c.Province).WillCascadeOnDelete(false);
		}
	}
}