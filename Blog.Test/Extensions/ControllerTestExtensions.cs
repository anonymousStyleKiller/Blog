using System.Security.Claims;
using Blog.Common.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Test.Extensions;

public static class ControllerTestExtensions
{
    public static TController WithTestUser<TController>(this TController controller)
        where TController : Controller
    {
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, TestConstants.TesUsername)
                }))
            }
        };
        return controller;
    }
}