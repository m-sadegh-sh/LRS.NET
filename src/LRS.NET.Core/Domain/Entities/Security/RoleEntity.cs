namespace LRS.NET.Core.Domain.Entities.Security {
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	using LRS.NET.Core.Extensions;

	public class RoleEntity : EntityBase {
		private ICollection<PermissionGroupEntity> _groups;
		private ICollection<PermissionEntity> _permissions;
		private ICollection<UserEntity> _users;

		public virtual string Name { get; set; }

		public virtual ICollection<PermissionGroupEntity> Groups {
			get { return _groups ?? (_groups = new ObservableCollection<PermissionGroupEntity>()); }
			protected set { _groups = value; }
		}

		public virtual ICollection<PermissionEntity> Permissions {
			get { return _permissions ?? (_permissions = new ObservableCollection<PermissionEntity>()); }
			protected set { _permissions = value; }
		}

		public virtual ICollection<UserEntity> Users {
			get { return _users ?? (_users = new ObservableCollection<UserEntity>()); }
			protected set { _users = value; }
		}

		public override string ToString() {
			return Name;
		}

		public override bool Equals(object obj) {
			return Equals(obj as RoleEntity);
		}

		public virtual bool Equals(RoleEntity other) {
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