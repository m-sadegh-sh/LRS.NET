namespace LRS.NET.DataModels {
	using System;
	using System.Waf.Foundation;

	using LRS.NET.Core.Domain.Entities;

	public abstract class DataModelBase<TEntity> : Model where TEntity : EntityBase {
		private readonly TEntity _entity;

		protected DataModelBase(TEntity entity) {
			if (entity == null)
				throw new ArgumentNullException("entity");

			_entity = entity;
		}

		public TEntity Entity {
			get { return _entity; }
		}
	}
}