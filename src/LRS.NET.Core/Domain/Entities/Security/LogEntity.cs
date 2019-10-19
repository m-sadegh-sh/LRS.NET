namespace LRS.NET.Core.Domain.Entities.Security {
	using System;

	public class LogEntity : EntityBase {
		public virtual LogSeverity Severity { get; set; }
		public virtual DateTime LogDateUtc { get; set; }
		public virtual string FullMessage { get; set; }
		public virtual string StackTrace { get; set; }
		public virtual UserEntity Invoker { get; set; }

		public override string ToString() {
			return string.Format("[{0}] {1} ({2})", LogDateUtc, FullMessage, Severity);
		}
	}
}