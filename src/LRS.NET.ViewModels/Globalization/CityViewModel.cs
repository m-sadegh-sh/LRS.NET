namespace LRS.NET.ViewModels.Globalization {
	using System.ComponentModel.Composition;
	using System.Windows.Input;

	using LRS.NET.Core.Domain.Entities.Globalization;
	using LRS.NET.View.Globalization;

	[Export]
	public class CityViewModel : ViewModelBase<ICityView, CityEntity> {
		private ICommand _selectProvinceCommand;

		[ImportingConstructor]
		public CityViewModel(ICityView view) : base(view) {}

		public ICommand SelectProvinceCommand {
			get { return _selectProvinceCommand; }
			set { SetProperty(ref _selectProvinceCommand, value); }
		}
	}
}