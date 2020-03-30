using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace App1.Converters
{
    public class OverlayBackgroundToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is OverlayBackground)
            {

                SolidColorBrush solidColorBrush = new SolidColorBrush();
                switch ((OverlayBackground)value)
                {
                    case OverlayBackground.black:
                    case OverlayBackground.fx:
                        solidColorBrush = new SolidColorBrush(Colors.Black);
                        break;
                    case OverlayBackground.grey:
                        solidColorBrush = new SolidColorBrush(Colors.Gray);
                        break;
                    case OverlayBackground.transparent:
                        solidColorBrush = new SolidColorBrush(Colors.Transparent);
                        break;
                }
                return solidColorBrush;

            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
