namespace LRS.NET.Data.Mapping.Globalization {
	using LRS.NET.Core.Domain.Entities.Globalization;

	internal class CityMapping : EntityMappingBase<CityEntity> {
		public CityMapping() {
			ToTable("Cities", "Globalization");

			HasRequired(c => c.Province).WithMany().Map(c => c.MapKey("ProvinceId"));
			Property(c => c.Name).HasMaxLength(60).IsRequired();
			Ignore(c => c.Branches);
			//HasMany(c => c.Branches).WithRequired(b => b.City).WillCascadeOnDelete(false);
		}
	}
}