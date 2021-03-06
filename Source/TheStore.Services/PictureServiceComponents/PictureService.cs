﻿namespace TheStore.Services.PictureServiceComponents
{
    using System;
    using TheStore.Core.Common;
    using TheStore.Core.Domain;
    using TheStore.Data;
    using TheStore.Services.Interfaces;

    public class PictureService : IPictureService
    {
        private readonly IRepository<Picture> PictureRepository;

        public PictureService(IRepository<Picture> pictureRepository)
        {
            this.PictureRepository = pictureRepository ?? throw new ArgumentNullException(nameof(pictureRepository));
        }

        public Picture GetById(int id)
        {
            return this.PictureRepository.GetById(id);
        }

        public CreatePictureResponse Create(CreatePictureRequest request)
        {
            var response = new CreatePictureResponse();

            bool isPicture = FileHelper.IsPicture(request.ContentType, request.FileExtention);
            if (isPicture == false)
            {
                response.Result = CreatePictureResult.InvalidFormat;
                return response;
            }

            bool isValidFileSize = FileHelper.IsValidImageSize(request.InputStream.Length);
            if (isValidFileSize == false)
            {
                response.Result = CreatePictureResult.TooLarge;
                return response;
            }

            string picName = FileHelper.GeneratePictureName(request.FileExtention);
            string fullPath = $"{request.ServerPath}{picName}";

            if (request.MaxHeight.HasValue && request.MaxWidth.HasValue)
                PictureProcessor.SaveJpeg(fullPath, request.InputStream, request.Quality, request.MaxWidth.Value, request.MaxHeight.Value);
            else
                PictureProcessor.SaveJpeg(fullPath, request.InputStream, request.Quality);

            string urlPath = $"{request.UrlPath}{picName}";

            Picture picture = new Picture
            {
                FullPath = fullPath,
                Url = urlPath,
                UploadDate = DateTime.Now,
            };

            this.PictureRepository.Insert(picture);

            response.Picture = picture;
            response.Result = CreatePictureResult.Success;

            return response;
        }

        public Picture Delete(int id)
        {
            var picture = this.PictureRepository.GetById(id);
            if (picture != null)
            {
                picture.Deleted = true;
                picture.DeletedDate = DateTime.Now;
                this.PictureRepository.Update(picture);

                return picture;
            }

            return null;
        }
    }    
}