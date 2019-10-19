namespace LRS.NET.Core.Domain.Entities.Workflow {
	using System;

	using LRS.NET.Core.Extensions;

	public class SmsProviderEntity : EntityBase {
		public virtual string Name { get; set; }
		public virtual string UserName { get; set; }
		public virtual string Password { get; set; }
		public virtual string InvocationUrl { get; set; }
		public virtual bool UseDefaultCredentials { get; set; }
		public virtual bool IsDefault { get; set; }
		public virtual Type ProviderType { get; set; }

		public override string ToString() {
			return Name;
		}

		public override bool Equals(object obj) {
			return Equals(obj as EmailProviderEntity);
		}

		public virtual bool Equals(SmsProviderEntity other) {
			if (other == null)
				return false;

			if (base.Equals(other))
				return true;

			return string.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase);
		}

		public override int GetHashCode() {
			return Name.NotNullOrDefault().GetHashCode();
		}
	}
}