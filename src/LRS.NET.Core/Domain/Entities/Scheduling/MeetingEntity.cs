namespace LRS.NET.Core.Domain.Entities.Scheduling {
	using System;

	using LRS.NET.Core.Domain.Entities.Foundation;

	public class MeetingEntity : WorkingTimeEntityBase {
		public virtual string Title { get; set; }
		public virtual string Description { get; set; }
		public virtual DateTime DueDateUtc { get; set; }
	}
}