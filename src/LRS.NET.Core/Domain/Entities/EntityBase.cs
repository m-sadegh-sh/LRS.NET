namespace LRS.NET.Core.Domain.Entities {
	using System.Globalization;
	using System.Waf.Foundation;

	public abstract class EntityBase : ValidatableModel, IEntity {
		private long _id;
		private int _version;
		private int _displayOrder;
		private bool _isEnabled;

		public virtual long Id {
			get { return _id; }
			set { SetPropertyAndValidate(ref _id, value); }
		}

		public virtual int Version {
			get { return _version; }
			set { SetPropertyAndValidate(ref _version, value); }
		}

		public virtual int DisplayOrder {
			get { return _displayOrder; }
			set { SetPropertyAndValidate(ref _displayOrder, value); }
		}

		public virtual bool IsEnabled {
			get { return _isEnabled; }
			set { SetPropertyAndValidate(ref _isEnabled, value); }
		}

		public virtual bool IsTransient() {
			return IsTransient(this);
		}

		public virtual string IdString {
			get { return Id.ToString(CultureInfo.InvariantCulture); }
		}

		private static bool IsTransient(EntityBase obj) {
			return obj != null && Equals(obj.Id, default(long));
		}

		public override string ToString() {
			return Id.ToString(CultureInfo.InvariantCulture);
		}

		public override bool Equals(object obj) {
			return Equals(obj as EntityBase);
		}

		protected virtual bool Equals(EntityBase other) {
			if (other == null)
				return false;

			if (ReferenceEquals(this, other))
				return true;

			if (!IsTransient(this) && !IsTransient(other) && Equals(Id, other.Id)) {
				var otherType = other.GetType();
				var thisType = GetType();
				return thisType.IsAssignableFrom(otherType) || otherType.IsAssignableFrom(thisType);
			}

			return false;
		}

		public override int GetHashCode() {
			return Id.GetHashCode();
		}

		public static bool operator ==(EntityBase x, EntityBase y) {
			return Equals(x, y);
		}

		public static bool operator !=(EntityBase x, EntityBase y) {
			return !Equals(x, y);
		}
	}
}