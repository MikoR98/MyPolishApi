using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace MoneyManager.Converters
{
    public class TransactionCategoryConverter : MarkupExtension, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var parameters = new List<string>();

            if (values != null && values.Length == 2)
            {
                if(values[0] != null)
                    parameters.Add(values[0].ToString());

                if (values[1] != null)
                    parameters.Add(values[1].ToString());
            }

            return parameters;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
