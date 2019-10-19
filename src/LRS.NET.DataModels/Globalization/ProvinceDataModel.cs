namespace LRS.NET.DataModels.Globalization {
	using System;
	using System.Windows.Input;

	using LRS.NET.Core.Domain.Entities.Globalization;

	public class ProvinceDataModel : DataModelBase<ProvinceEntity> {
		private readonly ICommand _selectCountryCommand;

		public ProvinceDataModel(ProvinceEntity province, ICommand selectCountryCommand) : base(province) {
			if (selectCountryCommand == null)
				throw new ArgumentNullException("selectCountryCommand");

			_selectCountryCommand = selectCountryCommand;
		}

		public ICommand SelectCountryCommand {
			get { return _selectCountryCommand; }
		}
	}
}