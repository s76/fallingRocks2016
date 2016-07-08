
using System;

namespace s76ToolBox.GeneralUse.Extensions
{
    public static class StringExtensions 
    {
        public static bool IsNullOrEmpty (this string s)
        {
            return string.IsNullOrEmpty(s);
        }
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }

}

