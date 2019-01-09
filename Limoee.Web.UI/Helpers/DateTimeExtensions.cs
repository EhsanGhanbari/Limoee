using System;

namespace Limoee.Web.UI.Helpers
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt)
        {
            DayOfWeek dayOfWeek = dt.DayOfWeek;
            
            return dt.AddDays(dayOfWeek - DayOfWeek.Friday).Date;
        }

        //public static DateTime EndOfWeek(this DateTime dt)
        //{
        //    DayOfWeek diff = dt.DayOfWeek;
        //    if (diff < 0)
        //    {
        //        diff += 7;
        //    }

        //    return dt.AddDays(-1 * diff).Date;
        //}
    }
}