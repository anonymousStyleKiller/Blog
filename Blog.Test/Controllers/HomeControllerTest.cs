using System.Security.Claims;
using Blog.Contollers;
using Blog.Contollers.Models;
using Blog.Services.Models.Articles;
using Blog.Test.Fakes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Test.Controllers;

public class HomeControllerTest
{
    [Fact]
    public async Task IndexShouldReturnViewResultWithCorrectArticleModelAsync()
    {
        var homeController = new HomeController(new FakeArticleService());
        var result = await homeController.Index();
        var viewResult = Assert.IsType<ViewResult>(result);
        var model  = Assert.IsAssignableFrom<IEnumerable<ArticleListingServiceModel>>(viewResult.Model);
        Assert.Equal(3, model.Count());
    }
    
    [Fact]
    public void ShouldReturnViewResult()
    {
        var homeController = new HomeController(null);
      
        var result = homeController.About();
        
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public void PrivacyShouldReturnViewResultWithCorrectUsername()
    {
        const string userName = "Test";
        var homeController = new HomeController(null);
        
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