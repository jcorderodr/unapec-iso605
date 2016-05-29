using System;

namespace Unapec.HumanResourcesM.Framework.Helpers
{
    public static class ExplicitConverter
    {

        public static T As<T>(this string value)
        {
            return As<T>((object)value);
        }

        public static T As<T>(this int value)
        {
            return As<T>((object)value);
        }

        public static T As<T>(this decimal value)
        {
            return As<T>((object)value);
        }

        private static T As<T>(this object value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }

    }
}
