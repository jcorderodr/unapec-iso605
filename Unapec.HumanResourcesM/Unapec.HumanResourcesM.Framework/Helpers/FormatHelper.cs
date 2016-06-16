using System;
using System.Globalization;

namespace Unapec.HumanResourcesM.Framework.Helpers
{
    public class FormatHelper
    {

        public const String APP_CULTURE = "es-DO";

        public const String DATE_FULL_FORMAT = "dd MMMM yyyy";

        public const String DATE_TIME_FULL_FORMAT = "dddd dd MMMM yyyy, hh:mm";

        public const String MONEY_CURRENCY_LETTER = "C2";
        
        public static string GetValidCurrencyWithPadding(decimal value)
        {
            return string.Format("{0:000000.00}", value);
        }

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

        public static bool IsInvalidIdentification(string identifier)
        {
            int vnTotal = 0;
            string vcCedula = identifier.Replace("-", "");
            int pLongCed = vcCedula.Trim().Length;
            int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

            if (pLongCed < 11 || pLongCed > 11)
                return true;

            for (int vDig = 1; vDig <= pLongCed; vDig++)
            {
                int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                if (vCalculo < 10)
                    vnTotal += vCalculo;
                else
                    vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) + Int32.Parse(vCalculo.ToString().Substring(1, 1));
            }

            return vnTotal % 10 == 0 ? false : true;
        }


    }
}
