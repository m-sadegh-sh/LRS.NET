namespace LRS.NET.Core.Domain.Entities.Security {
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	using LRS.NET.Core.Extensions;

	public class PermissionEntity : EntityBase {
		private ICollection<RoleEntity> _roles;

		public virtual string Name { get; set; }

		public virtual PermissionGroupEntity Group { get; set; }

		public virtual ICollection<RoleEntity> Roles {
			get { return _roles ?? (_roles = new ObservableCollection<RoleEntity>()); }
			protected set { _roles = value; }
		}

		public override string ToString() {
			return string.Format("{0} ({1})", Name, Group);
		}

		public override bool Equals(object obj) {
			return Equals(obj as PermissionEntity);
		}

		public virtual bool Equals(PermissionEntity other) {
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