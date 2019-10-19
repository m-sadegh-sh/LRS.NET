namespace LRS.NET.Core.Domain.Entities.Foundation {
	public class BorrowerEntity : PeopleEntityBase {
		public virtual string NationalId { get; set; }
		public virtual string NationalCode { get; set; }
		public virtual string FatherName { get; set; }
		public virtual string PostalCode { get; set; }
	}
}