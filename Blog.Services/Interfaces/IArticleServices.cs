using Blog.Services.Common;
using Blog.Services.Models.Articles;

namespace Blog.Services.Interfaces;

public interface IArticleServices : IService
{
    public Task<IEnumerable<ArticleListingServiceModel>> GetArticlesAsync(int page);
    public Task<ArticleDetailsServiceModel?> GetDetailsAsync(int id);

    public Task<int> AddAsync(string? title, string? description, string authorId);

    Task<bool> EditAsync(int id, string? title, string? description);

    Task<bool> ExistsAsync(int id, string authorId);

    Task<bool> DeleteAsync(int id);
}