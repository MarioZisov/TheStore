namespace TheStore.Services.PictureServiceComponents
{
    using System.Collections.Generic;
    using TheStore.Core.Common;
    using TheStore.Core.Domain;
    using TheStore.Core.Resources;

    public class CreatePictureResponse
    {
        private readonly Dictionary<CreatePictureResult, string> Messages = new Dictionary<CreatePictureResult, string>
        {
            { CreatePictureResult.Success, ValidationMessages.SuccsessfulImageSave },
            { CreatePictureResult.TooLarge, string.Format(ValidationMessages.TooLargeImage, FileHelper.IMAGE_BYTES_LIMIT) },
            { CreatePictureResult.InvalidFormat, ValidationMessages.InvalidImageFormat },
        };

        public Picture Picture { get; internal set; }

        public CreatePictureResult Result { get; internal set; }

        public string Message { get => this.Messages[this.Result]; }

    }

    public enum CreatePictureResult
    {
        Success = 0,
        TooLarge = 10,
        InvalidFormat = 11,
    }
}