using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace ASRR
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {

        #region Public Properties

        /// <summary>
        /// statyczna instancja tworzonego konwertera
        /// </summary>
        public static T Converter { get; set; } = null;

        #endregion

        #region Markup Extension

        /// <summary>
        /// dostarcza statyczna instancje konwertera
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Converter ?? (Converter = new T());
        }

        #endregion

        #region Methods

        /// <summary>
        /// konwersja typu zrodlowego na docelowy
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);


        /// <summary>
        /// konwersja typu docelowego na zrodlowy
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion
    }
}
