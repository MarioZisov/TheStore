namespace TheStore.Core.Common
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;

    public static class PictureProcessor
    {
        /// <summary> 
        /// Saves an image as a jpeg image, with the given quality and size (keeps original ratio)
        /// </summary> 
        /// <param name="path"> Path to which the image would be saved. </param> 
        /// <param name="quality"> An Enumeration based on 0 to 100, with 100 being the highest quality. </param> 
        public static void SaveJpeg(string path, IntPtr hBitmap, PictureQuality quality, int maxWidth, int maxHeight)
        {
            Image img = Image.FromHbitmap(hBitmap);
            SaveJpeg(path, img, quality, maxWidth, maxHeight);
        }

        /// <summary> 
        /// Saves an image as a jpeg image, with the given quality and size (keeps original ratio)
        /// </summary> 
        /// <param name="path"> Path to which the image would be saved. </param> 
        /// <param name="quality"> An Enumeration based on 0 to 100, with 100 being the highest quality. </param> 
        public static void SaveJpeg(string path, Stream stream, PictureQuality quality, int maxWidth, int maxHeight)
        {
            Image img = Image.FromStream(stream);
            SaveJpeg(path, img, quality, maxWidth, maxHeight);
        }

        /// <summary> 
        /// Saves an image as a jpeg image, with the given quality and size (keeps original ratio)
        /// </summary> 
        /// <param name="path"> Path to which the image would be saved. </param> 
        /// <param name="quality"> An Enumeration based on 0 to 100, with 100 being the highest quality. </param>
        public static void SaveJpeg(string path, Image img, PictureQuality quality, int maxWidth, int maxHeight)
        {
            double ratio = CalculateImageRatio(img, maxWidth, maxHeight);

            int newWidth = (int)(img.Width * ratio);
            int newHeight = (int)(img.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(img, 0, 0, newWidth, newHeight);
            }

            SaveJpeg(path, newImage, quality);
        }

        /// <summary> 
        /// Saves an image as a jpeg image, with the given quality 
        /// </summary> 
        /// <param name="path"> Path to which the image would be saved. </param> 
        /// <param name="quality"> An Enumeration based on 0 to 100, with 100 being the highest quality. </param>
        public static void SaveJpeg(string path, IntPtr hBitmap, PictureQuality quality)
        {
            Image img = Image.FromHbitmap(hBitmap);
            SaveJpeg(path, img, quality);
        }

        /// <summary> 
        /// Saves an image as a jpeg image, with the given quality 
        /// </summary> 
        /// <param name="path"> Path to which the image would be saved. </param> 
        /// <param name="quality"> An Enumeration based on 0 to 100, with 100 being the highest quality. </param> 
        public static void SaveJpeg(string path, Stream stream, PictureQuality quality)
        {
            Image img = Image.FromStream(stream);
            SaveJpeg(path, img, quality);
        }

        /// <summary> 
        /// Saves an image as a jpeg image, with the given quality 
        /// </summary> 
        /// <param name="path"> Path to which the image would be saved. </param> 
        /// <param name="quality"> An Enumeration based on 0 to 100, with 100 being the highest quality. </param> 
        public static void SaveJpeg(string path, Image img, PictureQuality quality)
        {
            // Encoder parameter for image quality 
            EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, (int)quality);
            // JPEG image codec 
            ImageCodecInfo jpgCodec = GetEncoderInfo("image/jpeg");
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            img.Save(path, jpgCodec, encoderParams);
        }

        /// <summary> 
        /// Returns the image codec with the given mime type 
        /// </summary> 
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats 
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec 
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];

            return null;
        }

        /// <summary>
        /// Calculates the image ratio based on the given width and height
        /// </summary>
        /// <returns>Image size ratio</returns>
        private static double CalculateImageRatio(Image img, int maxWidth, int maxHeight)
        {
            if (maxWidth <= 0 || maxWidth > img.Width)
                maxWidth = img.Width;

            if (maxHeight <= 0 || maxHeight > img.Height)
                maxHeight = img.Height;

            // Get the image's original width and height
            int originalWidth = img.Width;
            int originalHeight = img.Height;

            // To preserve the aspect ratio
            double ratioX = (double)maxWidth / (double)originalWidth;
            double ratioY = (double)maxHeight / (double)originalHeight;
            double ratio = Math.Min(ratioX, ratioY);

            return ratio;
        }

        
    }
}