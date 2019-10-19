namespace LRS.NET.Core.Domain.Entities.Payment {
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	using LRS.NET.Core.Domain.Entities.Foundation;

	public class OrderEntity : EntityBase {
		private ICollection<TransferLogEntity> _transfers;

		public virtual LoanRequestEntity Request { get; set; }
		public virtual DateTime OrderDateUtc { get; set; }
		public virtual int TotalAmount { get; set; }

		public ICollection<TransferLogEntity> Transfers {
			get { return _transfers ?? (_transfers = new ObservableCollection<TransferLogEntity>()); }
			set { _transfers = value; }
		}
	}
}