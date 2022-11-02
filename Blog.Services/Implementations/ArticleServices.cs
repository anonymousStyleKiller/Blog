using AutoMapper;
using AutoMapper.QueryableExtensions;
using Blog.DAL;
using Blog.DAL.Models;
using Blog.Services.Interfaces;
using Blog.Services.Models.Articles;
using Microsoft.EntityFrameworkCore;

namespace Blog.Services.Implementations;

public class ArticleServices : IArticleServices
{
    private const int ArticlePageSize = 10;
    private readonly BlogDbContext _dbContext;
    private readonly IMapper _mapper;

    public ArticleServices(BlogDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    
    public async Task<IEnumerable<ArticleListingServiceModel>> GetArticlesAsync(int page)
    {
        return await _dbContext
                   .Articles
                   .Skip((page - 1) * ArticlePageSize)
                   .Take(ArticlePageSize)
                   .ProjectTo<ArticleListingServiceModel>(_mapper.ConfigurationProvider)
                   .ToListAsync();
    }

    public async Task<ArticleDetailsServiceModel> GetDetailsAsync(int id) =>
        await _dbContext.Articles
            .Where(a => a.Id == id)
            .ProjectTo<ArticleDetailsServiceModel>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    

    public async Task<int> AddAsync(string title, string description, string authorId)
    {
        var article = new Article
        {
            Title = title,
            Description = description,
            AuthorId = authorId,
        };

        _dbContext.Add(article);
        await _dbContext.SaveChangesAsync();
        return article.Id;
    }
    
    public async Task<bool> EditAsync(int id, string title, string description)
    {
        var article = await _dbContext.Articles.FindAsync(id);
        if (article == null) return false;
        article.Title = title;
        article.Description = description;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id, string authorId) => 
        await _dbContext.Articles.AnyAsync(a=>a.Id == id && a.AuthorId == authorId);

    public async Task<bool> DeleteAsync(int id)
    {
        var article = await _dbContext.Articles.FindAsync(id);
        if (article == null) return false;
        _dbContext.Articles.Remove(article);
        await _dbContext.SaveChangesAsync();
        return true;
    }
    
    
}