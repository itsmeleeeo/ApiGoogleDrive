using Microsoft.AspNetCore.Http;

namespace CloudStorageTest.Application.UseCase.Users.UploadProfilePhoto
{
    public interface IUploadProfilePhotoUseCase
    {
        public void Execute(IFormFile file);
    }
}
