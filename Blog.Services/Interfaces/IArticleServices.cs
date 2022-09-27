using Blog.Data.Models;

namespace Blog.Services.Interfaces;

public interface IArticleServices
{
    public Task<IEnumerable<Article>> GetArticles(int page);
}