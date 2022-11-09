using System.Text;
using Blog.Services.Interfaces;

namespace Blog.Test.Fakes.Services;

public class FakeFileSystemService : IFileSystemService
{
    public Stream OpenRead(string path) => new MemoryStream(Encoding.UTF8.GetBytes(path));
}