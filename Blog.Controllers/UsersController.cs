using Blog.Common.Constants;
using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Contollers;

public class UsersController  : Controller
{
    private readonly IImageService _imageService;
    private readonly IFileSystemService _fileSystemService;
    
    public UsersController(IImageService imageService, IFileSystemService fileSystemService)
    {
        _imageService = imageService;
        _fileSystemService = fileSystemService;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetProfilePicture()
    {
        var userImageDestination = $"{ControllerConstants.UserImageDestination}{User.Identity?.Name}_optimized.jpg";
        await using var file = _fileSystemService.OpenRead(userImageDestination);
        return File(file, ControllerConstants.ImageContentType);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> ChangeProfilePicture(string pictureUrl)
    {
        if (string.IsNullOrWhiteSpace(pictureUrl)) return BadRequest("Image url cannot be empty");
        var userImageDestination = string.Format(ControllerConstants.UserImageDestination, User.Identity?.Name);
        await _imageService.UpdateImage(pictureUrl, userImageDestination);
        return Ok();
    }
}