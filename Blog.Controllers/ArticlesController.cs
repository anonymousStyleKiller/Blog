using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Contollers;

public class ArticlesController : Controller
{
    private readonly IArticleServices _articleServices;

    public ArticlesController(IArticleServices articleServices)
    {
        _articleServices = articleServices;
    }

    public async Task<IActionResult> GetAll()
    {
        return Ok(await _articleServices.GetArticles(1));
    }
}