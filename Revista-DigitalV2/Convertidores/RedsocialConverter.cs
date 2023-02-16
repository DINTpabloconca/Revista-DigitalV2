using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Revista_DigitalV2.Convertidores
{
    class RedsocialConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imagen = "";
            switch (value.ToString())
            {
                case "Facebook":
                    imagen = "/Recursos/facebook_logo.png";
                    break;
                case "Twitter":
                    imagen = "/Recursos/twitter_logo.png";
                    break;
                case "Instagram":
                    imagen = "/Recursos/instagram_logo.png";
                    break;
            }
            return imagen;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
