using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Shine.Models;
using Xamarin.Forms;

namespace Shine.Converters
{
    public class WeatherIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Weather weather)
            {
                switch (weather.Id)
                {
                    case long n when (n >= 200 && n < 300):
                        return "tstorm.png";
                    case long n when (n >= 300 && n < 400) || (n >= 500 && n < 600):
                        return "rain.png";
                    case long n when (n >= 600 && n < 700):
                        return "snow.png";
                    case long n when (n >= 700 && n < 800):
                        return "atmosphere.png";
                    case long n when (n == 800):
                        return "clear.png";
                    case long n when (n > 800 && n < 900):
                        return "cloudy.png";
                    default:
                        return "unknown.png";
                }
            }

            return "unknown.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
