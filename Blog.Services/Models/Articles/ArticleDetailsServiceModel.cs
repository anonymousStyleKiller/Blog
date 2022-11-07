using Blog.Common.Mapping;
using Blog.DAL.Models;

namespace Blog.Services.Models.Articles;

public class ArticleDetailsServiceModel  : IMapFrom<Article>, IMapExplicitly
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedOn { get; set; }
    public string? Author { get; set; }
}