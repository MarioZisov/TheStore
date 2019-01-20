namespace TheStore.Site
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public static class DateTimeExtentions
    {
        public static string ToTimeStampString(this DateTime date)
        {
            return date.ToString("yyyyMMddHHmmssffff");
        }
    }
}