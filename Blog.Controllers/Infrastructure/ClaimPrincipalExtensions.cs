using System.Security.Claims;

namespace Blog.Contollers.Infrastructure;

public static class ClaimPrincipalExtensions
{
    public static string GetUserId(this ClaimsPrincipal claimsPrincipal) =>
        claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
}