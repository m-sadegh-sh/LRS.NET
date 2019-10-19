namespace LRS.NET.Core.Domain.Entities.Workflow {
	using System;

	using LRS.NET.Core.Extensions;

	public class EmailProviderEntity : EntityBase {
		public virtual string Email { get; set; }
		public virtual string Name { get; set; }
		public virtual string UserName { get; set; }
		public virtual string Password { get; set; }
		public virtual string Host { get; set; }
		public virtual int Port { get; set; }
		public virtual bool SslEnabled { get; set; }
		public virtual bool UseDefaultCredentials { get; set; }
		public virtual bool IsDefault { get; set; }

		public override string ToString() {
			return Email;
		}

		public override bool Equals(object obj) {
			return Equals(obj as EmailProviderEntity);
		}

		public virtual bool Equals(EmailProviderEntity other) {
			if (other == null)
				return false;

			if (base.Equals(other))
				return true;

			return string.Equals(Email, other.Email, StringComparison.InvariantCultureIgnoreCase);
		}

		public override int GetHashCode() {
			return Email.NotNullOrDefault().GetHashCode();
		}
	}
}