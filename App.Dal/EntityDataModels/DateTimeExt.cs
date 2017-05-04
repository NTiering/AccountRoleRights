using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Dal.EntityDataModels
{
    static class DateTimeExt
    {
        /// <summary>
        /// returns the host value , or the min value , whichever is larger
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <returns></returns>
        public static DateTime Or(this DateTime dt, DateTime minValue)
        {
            return (dt < minValue) ? minValue : dt; 
        }
    }
}
