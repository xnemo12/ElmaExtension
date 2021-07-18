using System;
using System.Text;
// ReSharper disable MemberCanBePrivate.Global

namespace ElmaExtensionMethods
{
    /// <summary>
    /// Extensions for <see cref="Encoding" />.
    /// </summary>
    public static class EncodingExtensions
    {
        /// <summary>
        /// Converts a string to byte array.
        /// </summary>
        public static byte[] GetBytes(this string s, Encoding encoding)
        {
            return encoding.GetBytes(s);
        }

        /// <summary>
        /// Converts a string to byte array using unicode encoding.
        /// </summary>
        public static byte[] GetBytes(this string s) => s.GetBytes(Encoding.Unicode);

        /// <summary>
        /// Converts a byte array to string.
        /// </summary>
        public static string GetString(this byte[] bytes, Encoding encoding)
        {
            return encoding.GetString(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Converts a byte array to string using unicode encoding.
        /// </summary>
        public static string GetString(this byte[] bytes) => bytes.GetString(Encoding.Unicode);

        /// <summary>
        /// Converts a byte array to a base64 string.
        /// </summary>
        public static string ToBase64(this byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Converts a base64 string to a byte array.
        /// </summary>
        public static byte[] FromBase64(this string s)
        {
            return Convert.FromBase64String(s);
        }
    }
}