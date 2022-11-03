using Blog.Services.Interfaces;

namespace Blog.Services.Implementations;

public  class ImageService : IImageService
{
    public Task UpdateImage(string imageUrl, string destination, int? width = null, int? height = null)
    {
        throw new NotImplementedException();
    }
}