using Blog.Contollers;
using Blog.Contollers.Models;
using Blog.Services.Models.Articles;
using Blog.Test.Extensions;
using Blog.Test.Fakes.Services;
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
    var model = Assert.IsAssignableFrom<IEnumerable<ArticleListingServiceModel>>(viewResult.Model);
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
    var homeController = new HomeController(null).WithTestUser();
    var result = homeController.Privacy();
    var viewResult = Assert.IsType<ViewResult>(result);
    var model = Assert.IsType<PrivacyViewModel>(viewResult.Model);

    Assert.Equal(userName, model.UserName);

  }
}