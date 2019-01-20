namespace TheStore.Core.Common
{
    using System;
    using System.Linq;
    using Extentions;

    public static class FileHelper
    {
        private static readonly int IMAGE_SIZE_LIMIT = 1000;
        private static readonly string[] IMAGE_FORMATS = new string[] { ".jpg", ".png", ".jpeg" };

        public static bool IsValidImageSize(int size)
        {
            return size <= IMAGE_SIZE_LIMIT;
        }

        public static bool IsPicture(string contentType, string fileExtention)
        {
            if (contentType == null)
                return false;

            if (contentType.StartsWith("image/"))
            {
                
                bool formatMatch = IMAGE_FORMATS.Any(format => fileExtention.Equals(format, StringComparison.OrdinalIgnoreCase));

                return formatMatch;
            }

            return false;
        }

        public static string GeneratePictureName(string fileExtention)
        {
            return $"img_{DateTime.Now.ToTimeStampString()}{fileExtention}";
        }
    }
}