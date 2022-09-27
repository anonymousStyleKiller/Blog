using Blog.DAL;
using Blog.Data.Models;
using Blog.Services.Interfaces;
using Blog.Services.Models.Articles;
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

    
    public async Task<IEnumerable<ArticleListingServiceModel>> GetArticles(int page)
    {
        return await _dbContext
                   .Articles
                   .Skip((page - 1) * ArticlePageSize)
                   .Take(ArticlePageSize)
                   .Select(a => new ArticleListingServiceModel
                   {
                       Id = a.Id,
                       Title = a.Title,
                       Author = a.Author.UserName
                   })
                   .ToListAsync();
    }

    public async Task<int> AddAsync(string title, string description, string authorId)
    {
        var article = new Article
        {
            Title = title,
            Description = description,
            AuthorId = authorId
        };

        _dbContext.Add(article);

        await _dbContext.SaveChangesAsync();
        return article.Id;
    }
}