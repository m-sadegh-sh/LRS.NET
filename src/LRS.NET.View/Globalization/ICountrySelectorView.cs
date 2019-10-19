namespace LRS.NET.View.Globalization {
	using System.Waf.Applications;

	public interface ICountrySelectorView : IView {
		void ShowDialog(object owner);
		void Close();
	}
}