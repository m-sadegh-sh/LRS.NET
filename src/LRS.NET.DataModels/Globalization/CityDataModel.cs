namespace LRS.NET.DataModels.Globalization {
	using System;
	using System.Windows.Input;

	using LRS.NET.Core.Domain.Entities.Globalization;

	public class CityDataModel : DataModelBase<CityEntity> {
		private readonly ICommand _selectProvinceCommand;

		public CityDataModel(CityEntity city, ICommand selectProvinceCommand) : base(city) {
			if (selectProvinceCommand == null)
				throw new ArgumentNullException("selectProvinceCommand");

			_selectProvinceCommand = selectProvinceCommand;
		}

		public ICommand SelectProvinceCommand {
			get { return _selectProvinceCommand; }
		}
	}
}