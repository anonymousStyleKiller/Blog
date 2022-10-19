using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Blog.Contollers;

public class HomeController : Controller
{
    public HomeController() { }

    public ViewResult Index()
    {
        return View();
    }
    
}