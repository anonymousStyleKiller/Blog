using Blog.Contollers;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Test.Controllers;

public class UsersControllerTest
{
    [Fact]
    public async  Task NullPictureUrlShouldReturnBadRequest()
    {
        var userController = new UsersController();
        var result = await userController.ChangeProfilePicture(null);
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Image url cannot be empty", badRequestResult.Value);
    }
}