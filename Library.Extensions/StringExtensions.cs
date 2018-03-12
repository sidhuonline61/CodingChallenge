using System.Collections.Generic;
using System.IO;

namespace System
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        public static bool IsNotNullOrWhiteSpace(this string s)
        {
            return !s.IsNullOrWhiteSpace();
        }

        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static bool IsNotNullOrEmpty(this string s)
        {
            return s != null ? s.Trim().IsNullOrEmpty() ? false : true : false;
        }

        public static string TrimNullSafe(this string s)
        {
            return s != null ? s.Trim() : s;
        }

        public static string ReplaceNullSafe(this string s, string oldValue, string newValue)
        {
            return s != null ? s.Replace(oldValue, newValue) : s;
        }

        public static string FormatNullSafe(this string s, params object[] args)
        {
            return s.IsNullOrWhiteSpace() ? s : string.Format(s, args);
        }

        public static string TrimLengthNullSafe(this string s, int length)
        {
            if (s.IsNotNull() && s.Length > length)
            {
                return s.Substring(0, length);
            }

            return s;
        }

        public static Guid? ToGuidNullSafe(this string s)
        {
            return s.IsNotNullOrWhiteSpace() ? (Guid?)Guid.Parse(s) : null;
        }

        public static string ToNullIfEmpty(this string s)
        {
            return s.IsNotNullOrWhiteSpace() ? s : null;
        }

        public static MemoryStream ToMemoryStream(this string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static bool EqualsIgnoreCase(this string s1, string s2)
        {
            if (s1 == null && s2 == null)
            {
                return true;
            }
            else if (s1 == null || s2 == null)
            {
                return false;
            }

            return s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool ContainsIgnoreCase(this string source, string toCheck, StringComparison comp)
        {
            return source != null && toCheck != null && source.IndexOf(toCheck, comp) >= 0;
        }

        public static string TrimAndUpperNullSafe(this string s)
        {
            return s != null ? s.Trim().ToUpper() : s;
        }

        public static List<string> ConvertToListNullSafe(this string inputString)
        {
            var _List = new List<string>();

            if (inputString.IsNotNull())
                _List.Add(inputString);
            return _List;
        }
    }
}
