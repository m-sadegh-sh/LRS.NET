namespace LRS.NET.Core {
	using System.Globalization;

	using LRS.NET.Core.Domain.Entities.Foundation;
	using LRS.NET.Core.Domain.Entities.Security;

	public interface IWorkContext {
		UserEntity CurrentUser { get; }
		ShiftEntity CurrentShift { get; }
		CultureInfo CurrentCulture { get; }
	}
}