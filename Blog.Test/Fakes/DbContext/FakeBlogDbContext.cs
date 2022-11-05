using Blog.DAL;
using Microsoft.EntityFrameworkCore;

namespace Blog.Test.Fakes.DbContext;

public class FakeBlogDbContext
{

    public FakeBlogDbContext(string nameDb)
    {
        var options = new DbContextOptionsBuilder<BlogDbContext>()
            .UseInMemoryDatabase(nameDb).Options;
        Data = new BlogDbContext(options);
    }

    public async Task AddAsync(params object[] data)
    {
        await Data.AddRangeAsync(data);
        await Data.SaveChangesAsync();
    } 

    public BlogDbContext Data { get; set; }
    
}