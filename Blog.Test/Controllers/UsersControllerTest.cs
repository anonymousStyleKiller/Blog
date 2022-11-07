using System.Text;
using Blog.Common.Constants;
using Blog.Contollers;
using Blog.Test.Extensions;
using Blog.Test.Fakes.Services;
using Microsoft.AspNetCore.Mvc;
using static Blog.Common.Constants.ControllerConstants;


namespace Blog.Test.Controllers;

public class UsersControllerTest
{
    [Fact]
    public async  Task ChangeProfilePictureWithNullPictureUrlShouldReturnBadRequest()
    {
        var userController = new UsersController(null, null);
        var result = await userController.ChangeProfilePicture(null);
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Image url cannot be empty", badRequestResult.Value);
    }

    [Fact]
    public async Task ChangeProfilePictureWithNonNullPictureUrlShouldReturnOk()
    {
        const string pictureUrl = "TestPictureUrl";
        var imageService = new FakeImageService();
        var usersController = new UsersController(imageService, null).WithTestUser();
        var result = await usersController.ChangeProfilePicture(pictureUrl);
        Assert.Equal(pictureUrl, imageService.ImageUrl);
        Assert.Equal(@$"Images\Users\{TestConstants.TesUsername}", imageService.Destination);
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task GetProfilePictureShouldReturnCorrectFileStreamResult()
    {
        var usersController = new UsersController(null,new FakeFileSystemService())
            .WithTestUser();
        var result = await usersController.GetProfilePicture();
        var fileStreamResult = Assert.IsType<FileStreamResult>(result);
        var memoryStream = Assert.IsType<MemoryStream>(fileStreamResult.FileStream);
        var memoryStreamData = memoryStream.ToArray();
        var memoryStreamDataAsText = Encoding.UTF8.GetString(memoryStreamData.ToArray());
        var expectedProfilePicturePath = @$"{UserImageDestination}{TestConstants.TesUsername}_optimized.jpg";
            Assert.Equal(expectedProfilePicturePath, memoryStreamDataAsText);
        Assert.Equal(ImageContentType, fileStreamResult.ContentType);
    }
}