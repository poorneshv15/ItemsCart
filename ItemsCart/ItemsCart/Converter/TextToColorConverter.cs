using System;
using System.Globalization;
using Xamarin.Forms;

namespace ItemsCart.Converter
{
	public class TextToColorConverter : IValueConverter
	{


		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return null;
			}
			var item = value as Models.MenuItem;
			if (item.Name is string)
			{
				switch (item.Name.ToUpper())
				{
					case "APPLE":
						return Color.FromHex("FF0000");
					case "GRAPES":
						return Color.FromHex("00A2ED");
					case "Banana":
						return Color.FromHex("FDB900");
					case "TEA":
					case "COFFEE":
						return Color.FromHex("C4A484");
					case "ORANGE":
						return Color.FromHex("F25022");
					default:
						return Color.Default;
				}
			}
			else
				return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}


	}
}
