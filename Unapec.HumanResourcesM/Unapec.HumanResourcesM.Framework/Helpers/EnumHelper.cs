using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Unapec.HumanResourcesM.Resources;

namespace Unapec.HumanResourcesM.Framework.Helpers
{
    public class EnumHelper
    {


        public static string Translate(Enum param)
        {
            return Strings.ResourceManager.GetString(param.ToString(), CultureInfo.CurrentCulture);
        }

        public static IEnumerable<KeyValuePair<int, string>> ToList(Type type, bool translate = true)
        {
            return Enum.GetValues(type).Cast<Enum>().Select(p => new KeyValuePair<int, string>(Convert.ToInt32(p), (translate) ? Translate(p) : p.ToString())).ToList();
        }

        public static T GetEnum<T>(string value)
        {
            var names = Enum.GetNames(typeof(T));
            return (T)Enum.Parse(typeof(T), value);
        }


    }
}
