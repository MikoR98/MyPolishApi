using MyPolishApi.Entity.Enum;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace MoneyManager.Converters
{
    public class MultiValueConverter : MarkupExtension, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            switch (values[1])
            {
                case TransactionCategoryEnum.CREDIT:
                    return $"{values[0]} PLN";
                case TransactionCategoryEnum.DEBIT:
                    return $"-{values[0]} PLN";
                default:
                    return string.Empty;
            }
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
