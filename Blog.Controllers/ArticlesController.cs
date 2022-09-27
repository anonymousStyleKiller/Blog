using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

public class ArticlesController : Controller
{
    private readonly IArticleServices _articleServices;

    public ArticlesController(IArticleServices articleServices)
    {
        _articleServices = articleServices;
    }

    public async Task<IActionResult> Index()
    {
        return Ok(await _articleServices.GetArticles(1));
    }
}