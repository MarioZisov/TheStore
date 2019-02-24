namespace TheStore.Services.Interfaces
{
    using TheStore.Core.Domain;
    using TheStore.Services.PictureServiceComponents;

    public interface IPictureService
    {
        Picture GetById(int id);

        CreatePictureResponse Create(CreatePictureRequest request);

        Picture Delete(int id);
    }
}