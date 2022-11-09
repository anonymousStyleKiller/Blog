using AutoMapper;
using Blog.Services.Implementations;
using Blog.Services.Infrastructure;
using Blog.Test.Common;
using Blog.Test.Fakes.Services;

namespace Blog.Test.Services;

public class ArticleServiceTest : TestWithData
{
    [Fact]
    public async Task IsByUserShouldReturnTrueWhenArticleBySpecificUserExists()
    {
        var articleService = await GetArticleService("ArticleDbContextShouldTrue");
        var exists = await articleService.ExistsAsync(1, "1");
        Assert.True(exists);
    }

    [Fact]
    public async Task ChangeVisibilityShouldCorrectPublishedOnDate()
    {
        const int articleId = 1;
        var articleService = await GetArticleService("ChangeVisibility");
        await articleService.ChangeVisibility(1);
        var article = await Database.Articles.FindAsync(articleId);
        Assert.NotNull(article);
        Assert.True(article.IsPublic); 
        Assert.Equal(new DateTime(2022, 11, 9).DayOfWeek, article.PublishedOn.DayOfWeek);
    }
    
    [Fact]
    public async Task IsByUserShouldReturnFalseWhenArticleBySpecificUserExists()
    {
        var articleService = await GetArticleService("ArticleDbContextShouldFalse");
        var exists = await articleService.ExistsAsync(3, "1");
        Assert.False(exists);
    }
    

    private async Task<ArticleServices> GetArticleService(string name)
    {
        await InitDb(name);
        var mapper = new Mapper(new MapperConfiguration(config =>
        {
            config.AddProfile<ServiceMappingProfile>();
        }));
        
        return new ArticleServices(Database, mapper, new FakeDateTimeService());
    }
}