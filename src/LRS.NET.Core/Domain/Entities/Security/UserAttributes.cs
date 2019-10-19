namespace LRS.NET.Core.Domain.Entities.Security {
	public enum UserAttribute : byte {
		FirstName = 0,
		LastName = 1,
		NickName = 2,
		CultureCode = 4,
		TimeZoneId = 8,
		Theme = 16
	}
}