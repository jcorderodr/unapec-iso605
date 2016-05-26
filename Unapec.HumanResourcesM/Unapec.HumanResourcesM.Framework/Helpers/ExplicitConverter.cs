using System;

namespace Unapec.HumanResourcesM.Framework.Helpers
{
    public static class ExplicitConverter
    {

        public static T As<T>(this object value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }

    }
}
