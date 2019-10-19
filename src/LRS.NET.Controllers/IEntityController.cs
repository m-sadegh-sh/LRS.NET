namespace LRS.NET.Controllers {
	public interface IEntityController {
		bool HasChanges { get; }
		void Initialize();
		bool CanSave();
		bool Save();
		void Shutdown();
	}
}