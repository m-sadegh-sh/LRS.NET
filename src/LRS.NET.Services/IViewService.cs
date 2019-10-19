namespace LRS.NET.Services {
	using System.Collections.Generic;
	using System.ComponentModel;

	using LRS.NET.View;
	using LRS.NET.View.Globalization;

	public interface IViewService : INotifyPropertyChanged {
		IShellView ShellView { get; set; }
		ICityListView CityListView { get; set; }
		ICityView CityView { get; set; }
		IProvinceListView ProvinceListView { get; set; }
		IProvinceView ProvinceView { get; set; }
		ICountryListView CountryListView { get; set; }
		ICountryView CountryView { get; set; }
		ICollection<ViewContent> Contents { get; }
	}
}