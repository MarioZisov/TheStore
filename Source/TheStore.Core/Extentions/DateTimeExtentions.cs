namespace TheStore.Core.Extentions
{
    using System;

    public static class DateTimeExtentions
    {
        public static string ToTimeStampString(this DateTime date)
        {
            return date.ToString("yyyyMMddHHmmssffff");
        }
    }
}