namespace LRS.NET.Core.Domain.Entities.Security {
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	using LRS.NET.Core.Extensions;

	public class UserEntity : EntityBase {
		private ICollection<RoleEntity> _roles;

		public virtual string Email { get; set; }
		public virtual string Password { get; set; }
		public virtual DateTime CreateDateUtc { get; set; }
		public virtual DateTime? LastActivityDateUtc { get; set; }
		public virtual DateTime? LastLoginDateUtc { get; set; }
		public virtual DateTime? LastPasswordChangeDateUtc { get; set; }
		public virtual DateTime? LastPasswordFailureDateUtc { get; set; }
		public virtual DateTime? LastLockoutDateUtc { get; set; }
		public virtual bool IsLocked { get; set; }

		public virtual ICollection<RoleEntity> Roles {
			get { return _roles ?? (_roles = new ObservableCollection<RoleEntity>()); }
			protected set { _roles = value; }
		}

		public override string ToString() {
			return string.Format("{0}", Email);
		}

		public override bool Equals(object obj) {
			return Equals(obj as UserEntity);
		}

		public virtual bool Equals(UserEntity other) {
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