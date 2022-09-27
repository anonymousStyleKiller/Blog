using Blog.DAL;
using Blog.Data.Models;
using Blog.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Services.Implementations;

public class ArticleServices : IArticleServices
{
    private const int ArticlePageSize = 10;
    private readonly BlogDbContext _dbContext;

    public ArticleServices(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Article>> GetArticles(int page)
    {
        return await _dbContext
                   .Articles
                   .Skip((page - 1) * ArticlePageSize)
                   .Take(ArticlePageSize)
                   .ToListAsync();
    }
}