using Blog.DAL;
using Blog.DAL.Models;
using Blog.Services.Implementations;
using Microsoft.EntityFrameworkCore;

namespace Blog.Test.Services;

public class ArticleServiceTest
{
    [Fact]
    public async Task IsByUserShouldReturnTrueWhenArticleBySpecificUserExists()
    {
        var options = new DbContextOptionsBuilder<BlogDbContext>()
            .UseInMemoryDatabase("ArticlesIsByUser").Options;
        await using (var initialDbContext = new BlogDbContext(options))
        {
            initialDbContext.Articles.Add(new Article
            {
                Id = 1,
                AuthorId = "1",
                Title = "Test article"
            });
            await initialDbContext.SaveChangesAsync();
        }
        
        await using var dbContext = new BlogDbContext(options);
        var articleService = new ArticleServices(dbContext);
        var exists = await articleService.ExistsAsync(1, "1");
        Assert.True(exists);
    }
}