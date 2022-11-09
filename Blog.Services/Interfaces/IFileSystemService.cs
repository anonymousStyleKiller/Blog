namespace Blog.Services.Interfaces;

public interface IFileSystemService
{
    Stream OpenRead(string path);
}