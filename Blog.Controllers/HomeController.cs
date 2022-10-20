using AutoMapper;
using Blog.Contollers.Models;
using Blog.DAL;
using Blog.Services.Implementations;
using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Blog.Contollers;

public class HomeController : Controller
{
    private readonly IArticleServices _articleServices;
    private readonly BlogDbContext _context;
    private readonly IMapper _mapper;
    public HomeController()
    {
    }

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