namespace LRS.NET.Core.Domain.Entities.Payment {
	using System;

	public class TransferLogEntity : EntityBase {
		public virtual OrderEntity Order { get; set; }
		public virtual TransferTarget Target { get; set; }
		public virtual DateTime TransferDateUtc { get; set; }
		public virtual int Amount { get; set; }
		public virtual string Comment { get; set; }
	}
}