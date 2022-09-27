using Blog.Services.Models.Articles;

namespace Blog.Services.Interfaces;

public interface IArticleServices
{
    public Task<IEnumerable<ArticleListingServiceModel>> GetArticles(int page);

    public Task<int> AddAsync(string title, string description, string authorId);
}