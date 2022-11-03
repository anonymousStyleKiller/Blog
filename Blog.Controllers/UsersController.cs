using Blog.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Contollers;

public class UsersController  : Controller
{
    private const string UserImageDestination = @"Images\Users\{0}";
    private const string ImageContentType = "image/jpeg";
    
    
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> ChangeProfilePicture(string pictureUrl)
    {
        if (string.IsNullOrWhiteSpace(pictureUrl)) return BadRequest("Image url cannot be empty");

        var userImageDestination = string.Format(UserImageDestination, User.Identity.Name);
        await ImageService.UpdateImage(pictureUrl, userImageDestination);
        return Ok();
    }
}