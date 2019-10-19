namespace LRS.NET.Core.Domain.Entities.Foundation {
	using LRS.NET.Core.Domain.Components;

	public class BankEntity : EntityBase {
		public virtual string Name { get; set; }
		public virtual LoanLimitationsComponent Limitations { get; set; }
	}
}