using System.Security.Claims;
using Blog.Contollers;
using Blog.Contollers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Test.Controllers;

public class HomeControllerTest
{
    [Fact]
    public void ShouldReturnViewResult()
    {
        var homeController = new HomeController();
      
        var result = homeController.About();
        
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public void PrivacyShouldReturnViewResultWithCorrectUsername()
    {
        const string userName = "Test";
        
        var homeController = new HomeController();
        homeController.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>{new(ClaimTypes.Name, userName)}))
            }
        };
        var result = homeController.Privacy();
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<PrivacyViewModel>(viewResult.Model);
        
        Assert.Equal(userName, model.UserName);
        
    }
}