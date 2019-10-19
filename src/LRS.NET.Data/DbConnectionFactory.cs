namespace LRS.NET.Data {
	using System.Configuration;
	using System.Data.Common;

	public static class DbConnectionFactory {
		public static DbConnection CreateConnection(string connectionName) {
			var connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionName];

			var factory = DbProviderFactories.GetFactory(connectionStringSettings.ProviderName);

			var connection = factory.CreateConnection();

			connection.ConnectionString = connectionStringSettings.ConnectionString;

			return connection;
		}
	}
}