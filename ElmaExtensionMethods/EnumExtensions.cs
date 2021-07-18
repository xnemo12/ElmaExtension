using System;

namespace ElmaExtensionMethods
{
    /// <summary>
    /// Extensions for <see cref="Enum" />.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Parses an enum value of a given type from a string.
        /// </summary>
        public static TEnum ParseEnum<TEnum>(this string value, bool ignoreCase = true) where TEnum : struct, Enum
        {
            return (TEnum) Enum.Parse(typeof(TEnum), value, ignoreCase);
        }

        /// <summary>
        /// Parses an enum value of a given type from a string or returns default value if unsuccessful.
        /// </summary>
        public static TEnum ParseEnumOrDefault<TEnum>(this string str, bool ignoreCase = true) where TEnum : struct, Enum
        {
            return Enum.TryParse(str, ignoreCase, out TEnum result) ? result : default;
        }
    }
}