using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FileSystem = System.IO.File;

namespace Blog.Contollers;

public class UsersController  : Controller
{
    private const string UserImageDestination = @"Images\Users\{0}";
    private const string ImageContentType = "image/jpeg";
    private readonly IImageService _imageService;


    public UsersController(IImageService imageService)
    {
        _imageService = imageService;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetProfilePicture()
    {
        var userImageDestination = string.Format($"{UserImageDestination}_optimized.jpg", User.Identity.Name);
        await using var file = FileSystem.OpenRead(userImageDestination);
        return File(file, ImageContentType);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> ChangeProfilePicture(string pictureUrl)
    {
        if (string.IsNullOrWhiteSpace(pictureUrl)) return BadRequest("Image url cannot be empty");

        var userImageDestination = string.Format(UserImageDestination, User.Identity.Name);
        await _imageService.UpdateImage(pictureUrl, userImageDestination);
        return Ok();
    }
}