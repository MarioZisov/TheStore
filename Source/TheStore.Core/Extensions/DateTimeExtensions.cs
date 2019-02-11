namespace TheStore.Core.Extensions
{
    using System;

    public static class DateTimeExtensions
    {
        public static string ToTimeStampString(this DateTime date)
        {
            return date.ToString("yyyyMMddHHmmssffff");
        }
    }
}