namespace LRS.NET.Data {
	using System.Data.Entity;

	public sealed class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext> {}
}