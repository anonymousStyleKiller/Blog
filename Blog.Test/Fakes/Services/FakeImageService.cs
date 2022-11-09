using Blog.Services.Interfaces;

namespace Blog.Test.Fakes.Services;

public class FakeImageService : IImageService
{
    public string? ImageUrl { get; private set; }
    public string? Destination { get; private set; }

    public Task UpdateImage(string imageUrl, string destination, int? width = null, int? height = null)
    {
        ImageUrl = imageUrl;
        Destination = destination;
        return Task.CompletedTask;
    }
}