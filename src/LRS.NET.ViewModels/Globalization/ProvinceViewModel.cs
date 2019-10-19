namespace LRS.NET.ViewModels.Globalization {
	using System.ComponentModel.Composition;
	using System.Windows.Input;

	using LRS.NET.Core.Domain.Entities.Globalization;
	using LRS.NET.View.Globalization;

	[Export]
	public class ProvinceViewModel : ViewModelBase<IProvinceView, ProvinceEntity> {
		private ICommand _selectCountryCommand;

		[ImportingConstructor]
		public ProvinceViewModel(IProvinceView view) : base(view) {}

		public ICommand SelectCountryCommand {
			get { return _selectCountryCommand; }
			set { SetProperty(ref _selectCountryCommand, value); }
		}
	}
}