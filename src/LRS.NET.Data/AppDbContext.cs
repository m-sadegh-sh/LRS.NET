namespace LRS.NET.Data {
	using System.Data.Common;
	using System.Data.Entity;
	using System.Data.Entity.Core.Objects;
	using System.Data.Entity.Infrastructure;
	using System.Linq;

	using LRS.NET.Data.Mapping.Globalization;

	public class AppDbContext : DbContext {
		public AppDbContext(DbConnection dbConnection) : base(dbConnection, false) {
			Database.SetInitializer(new AppDbInitializer());
		}

		public bool HasChanges {
			get {
				ChangeTracker.DetectChanges();

				return ObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added).Any() || ObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Modified).Any() ||
				       ObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Deleted).Any();
			}
		}

		private ObjectContext ObjectContext {
			get { return ((IObjectContextAdapter) this).ObjectContext; }
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);
			modelBuilder.Configurations.Add(new CountryMapping());
			modelBuilder.Configurations.Add(new ProvinceMapping());
			modelBuilder.Configurations.Add(new CityMapping());
		}
	}
}