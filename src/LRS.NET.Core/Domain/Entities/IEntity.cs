namespace LRS.NET.Core.Domain.Entities {
	public interface IEntity {
		long Id { get; set; }
		string IdString { get; }
		int Version { get; set; }
		int DisplayOrder { get; set; }
		bool IsEnabled { get; set; }
		bool IsTransient();
	}
}