using Blog.Contollers;
using Blog.Services.Implementations;
using Blog.Test.Constants;
using Blog.Test.Extensions;
using Blog.Test.Fakes;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Test.Controllers;

public class UsersControllerTest
{
    [Fact]
    public async  Task ChangeProfilePictureWithNullPictureUrlShouldReturnBadRequest()
    {
        var userController = new UsersController(null);
        var result = await userController.ChangeProfilePicture(null);
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Image url cannot be empty", badRequestResult.Value);
    }

    [Fact]
    public async Task ChangeProfilePictureWithNonNullPictureUrlShouldReturnOk()
    {
        const string pictureUrl = "TestPictureUrl";
        var imageService = new FakeImageService();
        var usersController = new UsersController(imageService).WithTestUser();
        var result = await usersController.ChangeProfilePicture(pictureUrl);
        Assert.Equal(pictureUrl, imageService.ImageUrl);
        Assert.Equal(@$"Images\Users\{TestConstants.TesUsername}", imageService.Destination);
        Assert.IsType<OkResult>(result);
    }
}