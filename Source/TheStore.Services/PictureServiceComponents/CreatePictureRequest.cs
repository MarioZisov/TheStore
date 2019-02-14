namespace TheStore.Services.PictureServiceComponents
{
    using System.IO;
    using TheStore.Core.Common;

    public class CreatePictureRequest
    {
        public Stream InputStream { get; set; }

        public string ContentType { get; set; }

        public string FileExtention { get; set; }

        /// <summary>
        /// <see cref="PictureQuality.Regular"/> by default
        /// </summary>
        public PictureQuality Quality => PictureQuality.Regular;

        /// <summary>
        /// If the value is null keeps the original image size
        /// </summary>
        public int? MaxWidth { get; set; }

        /// <summary>
        /// If the value is null keeps the original image size
        /// </summary>
        public int? MaxHeight { get; set; }

        public string ServerPath { get; set; }

        public string UrlPath { get; set; }
    }
}
