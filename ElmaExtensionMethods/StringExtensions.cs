using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// ReSharper disable CognitiveComplexity
// ReSharper disable NotAccessedVariable

// ReSharper disable MemberCanBePrivate.Global

namespace ElmaExtensionMethods
{
    /// <summary>
    /// Extensions for <see cref="string" />.
    /// </summary>
    public static class StringExtensions
    {
        /*/// <summary>
        /// Indicates whether a string is null or empty.
        /// </summary>
        public static bool IsNullOrEmpty(this string s) => string.IsNullOrEmpty(s);*/

        /*/// <summary>
        /// Indicates whether a string is either null, empty, or whitespace.
        /// </summary>
        public static bool IsNullOrWhiteSpace(this string s) => string.IsNullOrWhiteSpace(s);*/
        
        /*/// <summary>
        /// Returns a string formed by repeating the given string given number of times.
        /// </summary>
        public static string Repeat(this string s, int count)
        {
            // If count is 0 - return empty string
            if (count == 0)
                return string.Empty;

            // Concat a new string
            var sb = new StringBuilder(s.Length * count);
            for (var i = 0; i < count; i++)
                sb.Append(s);

            return sb.ToString();
        }*/

        /// <summary>
        /// Returns an empty string if given a null string, otherwise returns given string.
        /// </summary>
        public static string EmptyIfNull(this string s) => s ?? string.Empty;

        /// <summary>
        /// Determines whether the string only consists of digits.
        /// </summary>
        public static bool IsNumeric(this string s)
        {
            return s.ToCharArray().All(char.IsDigit);
        }

        /// <summary>
        /// Determines whether the string only consists of letters.
        /// </summary>
        public static bool IsAlphabetic(this string s)
        {
            return s.ToCharArray().All(char.IsLetter);
        }

        /// <summary>
        /// Determines whether the string only consists of letters and/or digits.
        /// </summary>
        public static bool IsAlphanumeric(this string s)
        {
            return s.ToCharArray().All(char.IsLetterOrDigit);
        }

        /// <summary>
        /// Removes all leading occurrences of a substring in the given string.
        /// </summary>
        public static string TrimStart(this string s, string sub,
            StringComparison comparison = StringComparison.Ordinal)
        {
            while (s.StartsWith(sub, comparison))
                s = s.Substring(sub.Length);

            return s;
        }

        /// <summary>
        /// Removes all trailing occurrences of a substring in the given string.
        /// </summary>
        public static string TrimEnd(this string s, string sub,
            StringComparison comparison = StringComparison.Ordinal)
        {
            while (s.EndsWith(sub, comparison))
                s = s.Substring(0, s.Length - sub.Length);

            return s;
        }

        /// <summary>
        /// Removes all leading and trailing occurrences of a substring in the given string.
        /// </summary>
        public static string Trim(this string s, string sub,
            StringComparison comparison = StringComparison.Ordinal)
        {
            return s.TrimStart(sub, comparison).TrimEnd(sub, comparison);
        }

        /// <summary>
        /// Reverses order of characters in a string.
        /// </summary>
        public static string Reverse(this string s)
        {
            // If length is 1 char or less - return same string
            if (s.Length <= 1)
                return s;

            // Concat a new string
            var sb = new StringBuilder(s.Length);
            for (var i = s.Length - 1; i >= 0; i--)
                sb.Append(s[i]);

            return sb.ToString();
        }

        /// <summary>
        /// Returns a string formed by repeating the given character given number of times.
        /// </summary>
        public static string Repeat(this char c, int count)
        {
            // If count is 0 - return empty string
            if (count == 0)
                return string.Empty;

            return new string(c, count);
        }

        /// <summary>
        /// Returns a new string in which all occurrences of a specified string in the current instance are replaced with another specified string.
        /// </summary>
        public static string Replace(this string s, string oldValue, string newValue,
            StringComparison comparison = StringComparison.Ordinal)
        {
            var sb = new StringBuilder();

            var offset = 0;
            while (true)
            {
                // Find the next occurence of old value
                var index = s.IndexOf(oldValue, offset, comparison);

                // If not found - append the rest of the string and return
                if (index < 0)
                {
                    sb.Append(s, offset, s.Length - offset);
                    return sb.ToString();
                }

                // Append a portion of the string since last occurence until this one
                sb.Append(s, offset, index - offset);

                // Append new value
                sb.Append(newValue);

                // Advance offset
                offset = index + oldValue.Length;
            }
        }

        /// <summary>
        /// Retrieves a substring that ends at the position of first occurrence of the given other string.
        /// </summary>
        public static string SubstringUntil(this string s, string sub,
            StringComparison comparison = StringComparison.Ordinal)
        {
            // Find substring
            var index = s.IndexOf(sub, comparison);

            // If not found - return whole string
            if (index < 0)
                return s;

            // Otherwise - return portion of the string until index
            return s.Substring(0, index);
        }

        /// <summary>
        /// Retrieves a substring that starts at the position of first occurrence of the given other string.
        /// </summary>
        public static string SubstringAfter(this string s, string sub,
            StringComparison comparison = StringComparison.Ordinal)
        {
            // Find substring
            var index = s.IndexOf(sub, comparison);

            // If not found - return empty string
            if (index < 0)
                return string.Empty;

            // Otherwise - return portion of the string after index
            return s.Substring(index + sub.Length, s.Length - index - sub.Length);
        }

        /// <summary>
        /// Retrieves a substring that ends at the position of last occurrence of the given other string.
        /// </summary>
        public static string SubstringUntilLast(this string s, string sub,
            StringComparison comparsion = StringComparison.Ordinal)
        {
            // Find substring
            var index = s.LastIndexOf(sub, comparsion);

            // If not found - return whole string
            if (index < 0)
                return s;

            // Otherwise - return portion of the string until index
            return s.Substring(0, index);
        }

        /// <summary>
        /// Retrieves a substring that starts at the position of last occurrence of the given other string.
        /// </summary>
        public static string SubstringAfterLast(this string s, string sub,
            StringComparison comparsion = StringComparison.Ordinal)
        {
            // Find substring
            var index = s.LastIndexOf(sub, comparsion);

            // If not found - return empty string
            if (index < 0)
                return string.Empty;

            // Otherwise - return portion of the string after index
            return s.Substring(index + sub.Length, s.Length - index - sub.Length);
        }

        /// <summary>
        /// Discards null, empty and whitespace strings from a sequence.
        /// </summary>
        public static IEnumerable<string> ExceptNullOrWhiteSpace(this IEnumerable<string> source)
        {
            return source.Where(s => !string.IsNullOrWhiteSpace(s));
        }

        /// <summary>
        /// Splits string using given separators, discarding empty entries.
        /// </summary>
        public static string[] Split(this string s, params string[] separators)
        {
            return s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Splits string using given separators, discarding empty entries.
        /// </summary>
        public static string[] Split(this string s, params char[] separators)
        {
            return s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Returns a string formed by joining elements of a sequence using the given separator.
        /// </summary>
        public static string JoinToString<T>(this IEnumerable<T> source, string separator)
        {
            return string.Join(separator, source);
        }
        
        /// <summary>
		/// Formats string as string.Format() but the parameter index is optional and parameter meta is allowed.
		/// </summary>
		/// <example>"{} is a {1}".format("this", "test")</example>
		public static string Format(this string format, params object[] args)
		{
			var buffer = new StringBuilder(format);
			var i = 0;
			var param = 0;
			var paramMetaToIndexMap = new Dictionary<string, string>();
			while (i < buffer.Length)
			{
				// close curly before open curly
				if (buffer[i] == '}')
				{
					// skip escaped curly "}}", else break
					if (i + 1 < buffer.Length && buffer[i + 1] == '}')
					{
						i += 2;
						continue;
					}

					break;
				}
				// stop at '{'
				if (buffer[i] != '{')
				{
					i++;
					continue;
				}
				// skip escaped curly "{{"
				if (i + 1 < buffer.Length && buffer[i + 1] == '{')
				{
					i += 2;
					continue;
				}
				var start = i;
				while (i < buffer.Length && buffer[i] != '}')
				{
					i++;
				}
				// open curly is not matched, break
				if (i == buffer.Length)
				{
					break;
				}
				var end = i;
				//// at this point buffer[start..end] has format field
				//// insert parameter index only if not present
				////     so insert for:
				////     se  s  e  s            e  s    e  s      e  s                e
				////     {}  {:2}  {,10:#,##0.00}  {test}  {test:2}  {test,10:#,##0.00}
				////     and do not insert for:
				////     s e  s   e  s             e
				////     {0}  {0:2}  {0,10:#,##0.00}
				// find the meta substring
				var metastart = start + 1;
				var metaend = metastart;
				while (buffer[metaend] != '}' && buffer[metaend] != ':' && buffer[metaend] != ',')
				{
					metaend++;
				}
				var paramMeta = buffer.ToString(metastart, metaend - metastart).Trim();
				// insert param only if meta is not int
				int ignore;
				if (!int.TryParse(paramMeta, out ignore))
				{
					string paramIndex;
					// do not insert "" into meta->index map
					if (paramMeta == "")
					{
						paramIndex = param.ToString();
						param++;
					}
					else
					{
						// remove meta
						buffer.Remove(metastart, paramMeta.Length);
						// insert param index into meta->index map if not exists
						if (!paramMetaToIndexMap.ContainsKey(paramMeta))
						{
							paramMetaToIndexMap[paramMeta] = param.ToString();
							param++;
						}
						// do not increment param as param index is reused
						paramIndex = paramMetaToIndexMap[paramMeta];
					}
					// insert index
					buffer.Insert(metastart, paramIndex);
					// adjust end as buffer is removed from and inserted into
					end += -paramMeta.Length + paramIndex.Length;
				}
				else
				{
					param++;
				}
				i = end + 1; // i++ does not work
			}
			var formatConverted = buffer.ToString();
			return string.Format(formatConverted, args);
		}

        /// <summary>
        /// Default string.Format()
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string DefaultFormat(this string format, params object[] args)
	        => string.Format(format, args);
    }
}