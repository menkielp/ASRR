using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace ASRR
{
    abstract class BaseMultiValueConverter<T> : MarkupExtension, IMultiValueConverter
        where T : class, new()
    {
        #region Public Properties

        /// <summary>
        /// statyczna instancja tworzonego multiconvertera
        /// </summary>
        public static T MultiConverter { get; set; } = null;

        #endregion

        #region Markup Extension

        /// <summary>
        /// dostarcza konwerter do znacznikow w xaml
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return MultiConverter ?? (MultiConverter = new T());
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// konwersja wartosci zrodlowej na docelowa
        /// </summary>
        /// <param name="values"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// konwersja wartosci docelowej na zrodlowa
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetTypes"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture);

        #endregion
    }
}
