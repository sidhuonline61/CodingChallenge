using System.Collections.Generic;
using System.Linq;

namespace System
{
    public static class ArgumentExtensions
    {
        public static void AssertArgumentIsNotNull(this object o, string paramName = null, string message = null)
        {
            if (o.IsNull())
            {
                throw new ArgumentNullException(message, paramName);
            }
        }
        public static void AssertArgumentIsNotNullOrWhiteSpace(this string o, string paramName = null, string message = null)
        {
            if (o.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException(message, paramName);
            }
        }

        public static void AssertArgumentIsNotEmpty(this DateTime o, string paramName = null, string message = null)
        {
            if (o == DateTime.MinValue)
            {
                throw new ArgumentNullException(message, paramName);
            }
        }

        public static void AssertArgumentIsNotZero(this decimal o, string paramName = null, string message = null)
        {
            if (o == 0)
            {
                throw new ArgumentNullException(message, paramName);
            }
        }

        public static void AssertArgumentIsNotNegative(this decimal o, string paramName = null, string message = null)
        {
            if (o < 0)
            {
                throw new ArgumentNullException(message, paramName);
            }
        }

        public static void AssertArgumentIsListOfDates(this string s, string dateFormat, char seperator, string paramName)
        {
            if (s.IsNotNullOrWhiteSpace())
            {
                var split = s.Split(seperator);

                foreach (var sDate in split)
                {
                    DateTime date;
                    var success = DateTime.TryParseExact(sDate, dateFormat, null, Globalization.DateTimeStyles.None, out date);
                    if (!success)
                    {
                        throw new ArgumentException(s + " is not a list of dates in the format " + dateFormat + seperator + dateFormat, paramName);
                    }
                }
            }
        }

        public static void AssertArgumentHasNonNullItems<T>(this IList<T> o, string paramName = null, string message = null) where T : class
        {
            if (o.IsNull())
            {
                throw new ArgumentNullException(message, paramName);
            }

            if (!o.Any())
            {
                throw new ArgumentException(message, paramName);
            }

            if (o.Where(x => x == null).Any())
            {
                throw new ArgumentException(message, paramName);
            }
        }

        public static void AssertArgumentHasItemCountLessThanEqual<T>(this IList<T> o, int count, string paramName = null, string message = null) where T : class
        {
            if (o.IsNull())
            {
                throw new ArgumentNullException(message, paramName);
            }

            if (!o.Any())
            {
                throw new ArgumentException(message, paramName);
            }

            if (o.Count() > count)
            {
                throw new ArgumentException("The count of items in the list is greater than " + count, paramName);
            }
        }
    }
}
