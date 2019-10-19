namespace LRS.NET.Core.Domain.Entities.Workflow {
	public enum QueuedSmsImportance : byte {
		Low = 0,
		Normal = 1,
		High = 2,
		Critical = 4
	}
}