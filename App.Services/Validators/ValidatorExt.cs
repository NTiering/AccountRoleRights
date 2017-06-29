namespace App.Services.Validators
{
    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using System.Linq;

    public static class Validation
    {
        /// <summary>
        /// Combine two lists, unless first is null, and then secont replaces it 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        public static void CombineOrReplace<T>(this List<T> l1, List<T> l2)
        {
            if (l1 == null)
            {
                l1 = l2;
            }
            else
            {
                l1.AddRange(l2);
            }
        }

        /// <summary>
        /// Returns true if value is not default
        /// </summary>
        /// <param name="n"></param>
        /// <Returns></Returns>
        public static bool IsPresent(this float n)
        {
            return n != 0f;
        }

        /// <summary>
        /// Returns true if value is not default
        /// </summary>
        /// <param name="n"></param>
        /// <Returns></Returns>
        public static bool IsPresent(this bool n)
        {
            return n;
        }

        /// <summary>
        /// Returns true if value is not default
        /// </summary>
        /// <param name="n"></param>
        /// <Returns></Returns>
        public static bool IsPresent(this byte[] n)
        {
            return (n != null && n.Count() != 0);
        }

        /// <summary>
        /// Returns true if value is not default
        /// </summary>
        /// <param name="n"></param>
        /// <Returns></Returns>
        public static bool IsPresent(this string n)
        {
            return string.IsNullOrWhiteSpace(n) == false;
        }

        /// <summary>
        /// Returns true if value is not default
        /// </summary>
        /// <param name="n"></param>
        /// <Returns></Returns>
        public static bool IsPresent(this DateTime n)
        {
            return (n != DateTime.MinValue);
        }

        /// <summary>
        /// Returns true if value is not default
        /// </summary>
        /// <param name="n"></param>
        /// <Returns></Returns>
        public static bool IsPresent(this int n)
        {
            return (n != 0);
        }

        /// <summary>
        /// Determines whether [is zero or positive].
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns>
        ///   <c>true</c> if [is zero or positive] [the specified n]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsZeroOrPositive(this decimal n)
        {
            return (n >= 0m);
        }

        /// <summary>
        /// Determines whether /[is zero or negative].
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns>
        ///   <c>true</c> if [is zero or negative] [the specified n]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsZeroOrNegative(this decimal n)
        {
            return (n <= 0m);
        }

        /// <summary>
        /// Returns true if value is not default
        /// </summary>
        /// <param name="n"></param>
        /// <Returns></Returns>
        public static bool IsPresent(this decimal n)
        {
            return (n != 0m);
        }

        /// <summary>
        /// Returns true if value falls on this day
        /// </summary>
        /// <param name="dt"></param>
        /// <Returns></Returns>
        public static bool IsToday(this DateTime dt)
        {
            var now = DateTime.Now;
            return (dt.Year == now.Year && dt.DayOfYear == now.DayOfYear);
        }

        /// <summary>
        /// Returns true if value falls on this day or later
        /// </summary>
        /// <param name="dt"></param>
        /// <Returns></Returns>
        public static bool IsTodayOrFuture(this DateTime dt)
        {
            return (dt.IsToday() || dt.IsFuture());
        }

        /// <summary>
        /// Returns true if value falls on this day or before
        /// </summary>
        /// <param name="dt"></param>
        /// <Returns></Returns>
        public static bool IsTodayOrHistoric(this DateTime dt)
        {
            return (dt.IsToday() || dt.IsHistoric());
        }

        /// <summary>
        /// Returns true if value falls after today
        /// </summary>
        /// <param name="dt"></param>
        /// <Returns></Returns>
        public static bool IsFuture(this DateTime dt)
        {
            return dt > DateTime.Now;
        }

        /// <summary>
        /// Returns true if value falls before today
        /// </summary>
        /// <param name="dt"></param>
        /// <Returns></Returns>
        public static bool IsHistoric(this DateTime dt)
        {
            return dt < DateTime.Now;
        }

        /// <summary>
        /// Returns true is it COULD be a valid email
        /// </summary>
        /// <param name="s"></param>
        /// <Returns></Returns>
        public static bool IsEmail(this string s)
        {
            return Regex.IsMatch(s, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        /// <summary>
        /// Returns the nth most right hand chr
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <Returns></Returns>
        public static string Right(this string str, int length)
        {
            if (str == null)
            {
                return null;
            }
            else if (str.Length >= length)
            {
                return str.Substring(str.Length - length, length);
            }
            else
            {
                return str;
            }

        }

        /// <summary>
        /// Returns true if the int could represnt a 24 hr clock (1201 good 1161 bad)
        /// </summary>
        /// <param name="i"></param>
        /// <Returns></Returns>
        public static bool Is24hour(int i)
        {
            if (i < 1) return false;
            if (i > 2359) return false;
            var mins = int.Parse(i.ToString().Right(2));
            if (mins < 0) return false;
            if (mins > 59) return false;
            return true;
        }

        /// <summary>
        /// return true if is abouve the given value
        /// </summary>
        /// <param name="i"></param>
        /// <param name="bound"></param>
        /// <Returns></Returns>
        public static bool IsAbove(this int i, int bound)
        {
            return i > bound;
        }

        /// <summary>
        /// return true is it is below the given value
        /// </summary>
        /// <param name="i"></param>
        /// <param name="bound"></param>
        /// <Returns></Returns>
        public static bool IsBelow(this int i, int bound)
        {
            return i < bound;
        }

        /// <summary>
        /// Returns true if th value is not between the 2 values 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="upper"></param>
        /// <param name="lower"></param>
        /// <param name="inclusive"></param>
        /// <Returns></Returns>
        public static bool IsNotBetweem(this int i, int upper, int lower, bool inclusive = false)
        {
            if (inclusive && i == upper) return true;
            if (inclusive && i == lower) return true;
            return (i.IsAbove(lower) == false) && (i.IsBelow(upper) == false);
        }
    }

}

