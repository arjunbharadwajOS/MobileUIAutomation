using System.Globalization;
using System.Text.RegularExpressions;

namespace Facebook.Mobile.Test.Utility
{
    public class Converter
    {
        public string FromDoubleToPrice(double text)
        {
            return string.Format("{0:C}", text);
        }

        public double FromPriceToDouble(string text)
        {
            return double.Parse(text, NumberStyles.Currency);
        }

        public string ExtractPriceValue(string text)
        {
            return Regex.Match(text, @"\d+.").Value;
        }
    }
}
