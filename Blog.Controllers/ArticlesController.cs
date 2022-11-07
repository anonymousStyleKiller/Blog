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
        return Ok(await _articleServices.GetArticlesAsync(1));
    }

  [HttpGet]
  [Authorize]
  public IActionResult Create() => View();


  [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ArticleFormModel model)
    {
        if (!ModelState.IsValid) return View(model);
        var articleId =  await _articleServices.AddAsync(model.Title, model.Description, User.GetUserId());
        return RedirectToAction("Details", new {articleId, });
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Edit(int id)
    {
        if (await _articleServices.ExistsAsync(id, User.GetUserId())) return NotFound();
        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Edit(int id, ArticleFormModel model)
    {
        if (await _articleServices.ExistsAsync(id, User.GetUserId())) return NotFound();
        if (!ModelState.IsValid) return View(model);
        await _articleServices.EditAsync(id, model.Title, model.Description);
        return RedirectToAction(nameof(Details), new {id, });
    }

    public async Task<IActionResult> Details(int id)
    {
       var article = await _articleServices.GetDetailsAsync(id);
       if (article == null)
       {
           return NotFound();
       }
       return View(article);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        if (!await _articleServices.ExistsAsync(id, User.GetUserId())) return NotFound();
        return View();
    }

    [HttpPost]
    [Authorize]

    public async Task<IActionResult> ConfirmDelete(int id)
    {
        if (!await _articleServices.ExistsAsync(id, User.GetUserId())) return NotFound();
        await _articleServices.DeleteAsync(id);
        return RedirectToAction(nameof(GetAll));
    }
    
}