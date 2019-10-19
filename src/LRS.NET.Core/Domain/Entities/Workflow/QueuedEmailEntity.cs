namespace LRS.NET.Core.Domain.Entities.Workflow {
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	public class QueuedEmailEntity : EntityBase {
		private ICollection<string> _cc;
		private ICollection<string> _bcc;

		public virtual EmailProviderEntity Provider { get; set; }
		public virtual string FromEmail { get; set; }
		public virtual string FromName { get; set; }
		public virtual string ToEmail { get; set; }
		public virtual string ToName { get; set; }

		public virtual ICollection<string> Cc {
			get { return _cc ?? (_cc = new ObservableCollection<string>()); }
			set { _cc = value; }
		}

		public virtual ICollection<string> Bcc {
			get { return _bcc ?? (_bcc = new ObservableCollection<string>()); }
			set { _bcc = value; }
		}

		public virtual string Subject { get; set; }
		public virtual string Body { get; set; }
		public virtual bool IsBodyHtml { get; set; }
		public virtual QueuedEmailImportance Importance { get; set; }
		public virtual int SendTries { get; set; }
		public virtual DateTime? SentDateUtc { get; set; }

		public override string ToString() {
			return string.Format("{0} ({1}), {2} ({3})", FromEmail, FromName, ToEmail, ToName);
		}
	}
}