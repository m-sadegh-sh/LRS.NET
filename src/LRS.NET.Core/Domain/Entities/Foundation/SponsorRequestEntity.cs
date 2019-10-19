namespace LRS.NET.Core.Domain.Entities.Foundation {
	public class SponsorRequestEntity : EntityBase {
		public virtual SponsorTypeEntity Type { get; set; }
		public virtual int Count { get; set; }
	}
}