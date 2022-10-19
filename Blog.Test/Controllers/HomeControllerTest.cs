using Blog.Contollers;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Test.Controllers;

public class HomeControllerTest
{
    [Fact]
    public void ShouldReturnViewResult()
    {
        // Arrange
        var homeController = new HomeController();
        // Act
        var result = homeController.Index();
        // Assert
        Assert.IsType<ViewResult>(result);
    }
}