namespace Blog.Services.Interfaces;

public interface IImageService
{
    Task UpdateImage(string imageUrl, string destination, int? width = null, int? height = null);
}