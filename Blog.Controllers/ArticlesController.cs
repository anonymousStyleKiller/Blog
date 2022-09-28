using Blog.Contollers.Infrastructure;
using Blog.Contollers.Models.Articles;
using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Create() => View();

    
    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateArticleFormModel model)
    {
        if (!ModelState.IsValid) return View(model);
        var articleId =  await _articleServices.AddAsync(model.Title, model.Description, User.GetUserId());
        return RedirectToAction("Details", new {articleId,});

    }

}