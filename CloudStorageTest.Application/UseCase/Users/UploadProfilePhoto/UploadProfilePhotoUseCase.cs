
using CloudStorageTest.Domain.Entities;
using CloudStorageTest.Domain.Storage;
using FileTypeChecker.Extensions;
using FileTypeChecker.Types;
using Microsoft.AspNetCore.Http;

namespace CloudStorageTest.Application.UseCase.Users.UploadProfilePhoto;

public class UploadProfilePhotoUseCase : IUploadProfilePhotoUseCase
{
    private readonly IStorageService _storageService;
    public UploadProfilePhotoUseCase(IStorageService storageService)
    {
        _storageService = storageService;
    }
    public void Execute(IFormFile file)
    {
        var fileStream = file.OpenReadStream();
        var isImage = fileStream.Is<JointPhotographicExpertsGroup>();

        if (isImage == false)
        {
            throw new Exception("The file is not an image.");
        }
        var user = GetFromDatabase();
        _storageService.Upload(file, user);
    }

    private User GetFromDatabase()
    {
        return new User
        {
            Id = 1,
            Name = "Leonardo",
            Email = "engenharia.leonardoferreira@gmail.com",
            RefreshToken = "1//04mFj3_moI28gCgYIARAAGAQSNwF-L9IrqoFMJLHR20EuGQb9aCuVtcd2PnDBJcLznvB20_kWCol3yoXSrXrIEJVnbg0KPAzbKBQ",
            AccessToken = "ya29.a0Ad52N3_MQYzVI7Kh6G3ExWDVgSLfJxQykNUoKBIDQztjzJwg7PAz9nXeg04fMzzXPZ1UPBjD8WKMxik_iyHddf1Mqz0bui6hnyfOqHSRqpIS24sIs9qNmjIw9CLBFnidkR-Qtgt92k6RotRm0zkthx-zLXWB75q8Yy2saCgYKAQQSARISFQHGX2Mi7SSIVuY0YON94ONmbHze0w0171"
        };
    }
}
