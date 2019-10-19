namespace LRS.NET.Presentation.Converters {
	using System;
	using System.Globalization;
	using System.Windows;
	using System.Windows.Data;

	public class StringToUriConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			Uri uri;

			if (Uri.TryCreate(value as string ?? "", UriKind.RelativeOrAbsolute, out uri))
				return uri;

			return DependencyProperty.UnsetValue;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			throw new NotImplementedException();
		}
	}
}