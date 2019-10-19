namespace LRS.NET.Core.Domain.Components {
	public class CellNumberComponent : IComponent {
		public string CountryCode { get; set; }
		public string RegionalCode { get; set; }
		public string Number { get; set; }
		public string Internal { get; set; }
	}
}