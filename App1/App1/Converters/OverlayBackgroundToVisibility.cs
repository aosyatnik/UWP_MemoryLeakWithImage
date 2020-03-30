using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace App1.Converters
{
    public class OverlayBackgroundToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is OverlayBackground)
            {
                var background = (OverlayBackground)value;

                if (background == OverlayBackground.black ||
                    background == OverlayBackground.grey ||
                    background == OverlayBackground.none ||
                    background == OverlayBackground.transparent)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
