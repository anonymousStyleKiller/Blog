using Blog.DAL.Models;
using Blog.Services.Implementations;
using Blog.Test.Fakes.DbContext;


namespace Blog.Test.Services;

public class ArticleServiceTest
{
    [Fact]
    public async Task IsByUserShouldReturnTrueWhenArticleBySpecificUserExists()
    {
        var articleService = await GetArticleService("ArticleDbContextShouldTrue");
        var exists = await articleService.ExistsAsync(1, "1");
        Assert.True(exists);
    }
    
    [Fact]
    public async Task IsByUserShouldReturnFalseWhenArticleBySpecificUserExists()
    {
        var articleService = await GetArticleService("ArticleDbContextShouldFalse");
        var exists = await articleService.ExistsAsync(3, "1");
        Assert.False(exists);
    }

    private async Task AddFakeArticles(FakeBlogDbContext dbContext)
        => await dbContext.AddAsync(new Article
        {
            Id = 1,
            AuthorId = "1",
            Title = "Test article"
        });

    private async Task<ArticleServices> GetArticleService(string name)
    {
        var dbContext = new FakeBlogDbContext(name);
        await AddFakeArticles(dbContext);
        return new ArticleServices(dbContext.Data);
    }
}