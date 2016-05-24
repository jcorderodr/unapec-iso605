using System;
using System.Globalization;

namespace Unapec.HumanResourcesM.Framework.Helpers
{
    public class FormatHelper
    {

        public const String APP_CULTURE = "es-DO";

        public const String DATE_FULL_FORMAT = "dd MMMM yyyy";

        public const String DATE_TIME_FULL_FORMAT = "D";

        public const String MONEY_CURRENCY_LETTER = "C2";

        public static String GetCurrency(double value)
        {
            return value.ToString(MONEY_CURRENCY_LETTER, new CultureInfo(APP_CULTURE));
        }

        /// <summary>
        /// Cleans and reach a DateTime to his lowest hour.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime CleanTimeFromDate(DateTime date)
        {
            return date.AddHours(-date.Hour).AddMinutes(-date.Minute).AddSeconds(-date.Second).AddMilliseconds(-date.Millisecond);
        }


    }
}
