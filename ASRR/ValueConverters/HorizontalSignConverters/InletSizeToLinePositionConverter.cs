using System;
using System.Globalization;
using System.Windows.Data;

namespace ASRR
{
    /// <summary>
    /// konwerter do okreslenia pozycji linii na wlocie
    /// </summary>
    class InletSizeToLinePositionConverter : BaseValueConverter<InletSizeToLinePositionConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double middleLinePosition = (double)value;
            int offset = int.Parse((string)parameter);
            
            if(offset > -3 && offset < 3)
                return middleLinePosition + (offset * 44);
            else
            {
                if(offset > 2)
                {
                    offset += -2;
                    return middleLinePosition + (offset * 22);
                }
                else
                {
                    offset += 2;
                    return middleLinePosition + (offset * 22);
                }
            }


        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
