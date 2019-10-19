namespace LRS.NET.Data.Mapping {
	using System.Data.Entity.ModelConfiguration;

	using LRS.NET.Core.Domain.Entities;

	internal abstract class EntityMappingBase<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : EntityBase {
		protected EntityMappingBase() {
			HasKey(e => e.Id);

			Property(e => e.Version).IsRequired();
			Property(e => e.DisplayOrder).IsRequired();
			Property(e => e.IsEnabled).IsRequired();
		}
	}
}