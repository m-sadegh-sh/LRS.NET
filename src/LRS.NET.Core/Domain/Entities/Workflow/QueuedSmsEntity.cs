namespace LRS.NET.Core.Domain.Entities.Workflow {
	using System;

	using LRS.NET.Core.Domain.Components;

	public class QueuedSmsEntity : EntityBase {
		public virtual SmsProviderEntity Provider { get; set; }
		public virtual CellNumberComponent To { get; set; }
		public virtual string Body { get; set; }
		public virtual QueuedSmsImportance Importance { get; set; }
		public virtual int SendTries { get; set; }
		public virtual DateTime? SentDateUtc { get; set; }

		public override string ToString() {
			return string.Format("{0} ({1})", To, Importance);
		}
	}
}