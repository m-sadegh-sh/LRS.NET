namespace LRS.NET.Core.Domain.Entities.Security {
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	using LRS.NET.Core.Extensions;

	public class PermissionGroupEntity : EntityBase {
		private ICollection<PermissionEntity> _permissions;
		private ICollection<RoleEntity> _roles;

		public virtual string Name { get; set; }

		public virtual ICollection<PermissionEntity> Permissions {
			get { return _permissions ?? (_permissions = new ObservableCollection<PermissionEntity>()); }
			protected set { _permissions = value; }
		}

		public virtual ICollection<RoleEntity> Roles {
			get { return _roles ?? (_roles = new ObservableCollection<RoleEntity>()); }
			protected set { _roles = value; }
		}

		public override string ToString() {
			return Name;
		}

		public override bool Equals(object obj) {
			return Equals(obj as PermissionGroupEntity);
		}

		public virtual bool Equals(PermissionGroupEntity other) {
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