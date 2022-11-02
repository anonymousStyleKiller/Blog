using Blog.Services.Interfaces;
using Blog.Services.Models.Articles;

namespace Blog.Test.Fakes;

public class FakeArticleService : IArticleServices
{
    public async Task<IEnumerable<ArticleListingServiceModel>> GetArticlesAsync(int page)
    {
        var articles = new List<ArticleListingServiceModel>
        {
            new() { Id = 1 },
            new() { Id = 2 },
            new() { Id = 3 }
        };
        return await Task.FromResult<IEnumerable<ArticleListingServiceModel>>(articles);
    }

    public Task<ArticleDetailsServiceModel?> GetDetailsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddAsync(string title, string description, string authorId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> EditAsync(int id, string title, string description)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(int id, string authorId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}