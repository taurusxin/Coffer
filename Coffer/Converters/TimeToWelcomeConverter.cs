using System;
using System.Globalization;
using Xamarin.Forms;

namespace Coffer.Converters
{
    public class TimeToWelcomeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var time = DateTime.Now.Hour;
            if (time < 7)
            {
                return "Morning exercise!";
            }
            if (time > 7 && time < 11)
            {
                return "Good morning!";
            } else if (time < 13)
            {
                return "Lunch time!";
            } else if (time < 18)
            {
                return "Good afternoon!";
            } else if (time < 23)
            {
                return "Good evening!";
            }
            else
            {
                return "Go to the bed!";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Empty;
        }
    }
}