using Blog.Services.Interfaces;

namespace Blog.Services.Implementations;

public class FileSystemService : IFileSystemService
{
    public Stream OpenRead(string path) => File.OpenRead(path);
}