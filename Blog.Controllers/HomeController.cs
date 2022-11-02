using Blog.Contollers.Models;
using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Contollers;

public class HomeController : Controller
{
    private readonly IArticleServices _articleServices;
    public HomeController(IArticleServices articleServices) => _articleServices = articleServices;

    public async Task<IActionResult> Index()
    {
        var articles = await _articleServices.GetArticlesAsync(page: 3);
        return View(articles);
    }

    public IActionResult About() => View();

    [Authorize]
    public IActionResult Privacy() => View(new PrivacyViewModel
    {
        UserName = User.Identity.Name
    });
}