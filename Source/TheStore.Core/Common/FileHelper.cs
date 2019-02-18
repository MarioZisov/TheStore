namespace TheStore.Core.Common
{
    using System;
    using System.IO;
    using System.Linq;
    using Extensions;

    public static class FileHelper
    {
        public static readonly long IMAGE_BYTES_LIMIT = 5242880;
        private static readonly string[] IMAGE_FORMATS = new string[] { ".jpg", ".png", ".jpeg" };

        public static bool IsValidImageSize(long size)
        {
            return size <= IMAGE_BYTES_LIMIT;
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

        public static bool FileCompare(Stream file1, Stream file2)
        {
            if (file1.Length != file2.Length)
                return false;
            int file1Byte;
            int file2Byte;
            do
            {
                file1Byte = file1.ReadByte();
                file2Byte = file2.ReadByte();
            } while (file1Byte == file2Byte && file1Byte != -1);

            return ((file1Byte - file2Byte) == 0);
        }
    }
}