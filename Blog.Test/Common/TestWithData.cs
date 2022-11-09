using Blog.DAL;
using Blog.DAL.Models;
using Blog.Test.Fakes.DbContext;

namespace Blog.Test.Common;

public abstract class TestWithData
{
    protected async Task InitDb(string name)
    {
        var fakeDb = new FakeBlogDbContext(name);
        await AddFakeArticles(fakeDb);
        Database = fakeDb.Data;
    }

    protected BlogDbContext Database { get; set; }

    private static async Task AddFakeArticles(FakeBlogDbContext dbContext)
        => await dbContext.AddAsync(new Article
        {
            Id = 1,
            AuthorId = "1",
            Title = "Test article"
        });
}