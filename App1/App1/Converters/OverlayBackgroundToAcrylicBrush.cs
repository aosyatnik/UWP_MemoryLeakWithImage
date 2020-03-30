using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace App1.Converters
{
    public class OverlayBackgroundToAcrylicBrush : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {

            if (value is OverlayBackground)
            {
                var background = (OverlayBackground)value;

                if (background == OverlayBackground.fx)
                {
                    AcrylicBrush color = new AcrylicBrush
                    {
                        TintColor = Windows.UI.Colors.Transparent,
                        Opacity = 20
                    };
                    return color;
                }

                return null;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
