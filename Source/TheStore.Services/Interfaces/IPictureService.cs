namespace TheStore.Services.Interfaces
{
    using TheStore.Core.Domain;
    using TheStore.Services.PictureServiceComponents;

    public interface IPictureService
    {
        CreatePictureResponse Create(CreatePictureRequest request);
    }
}