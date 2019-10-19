namespace LRS.NET.Core.Domain.Entities.Security {
	using LRS.NET.Core.Extensions;

	public class UserAttributeEntity : AttributeEntityBase<UserAttribute> {
		public virtual UserEntity User { get; set; }

		public override string ToString() {
			return string.Format("{0} ({1}: {2})", User, Key, Value);
		}

		public override bool Equals(object obj) {
			return Equals(obj as UserAttributeEntity);
		}

		public virtual bool Equals(UserAttributeEntity other) {
			if (other == null)
				return false;

			if (base.Equals(other))
				return true;

			return Equals(User, other.User) && Equals(Key, other.Key);
		}

		public override int GetHashCode() {
			return User.GetHashCode() + Key.ToStringOrDefault().GetHashCode();
		}
	}
}