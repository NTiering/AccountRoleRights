using App.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace App.Mvc
{
    public static class ExtMethods
    {
        /// <summary>
        /// Returns empty enumeration if null.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> DefaultIfNull<TSource>(this IEnumerable<TSource> source)
        {
            return source ?? Enumerable.Empty<TSource>();
        }

        /// <summary>
        /// Determines whether this instance is debug.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <returns>
        ///   <c>true</c> if the specified HTML helper is debug; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDebug(this HtmlHelper htmlHelper)
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }
}