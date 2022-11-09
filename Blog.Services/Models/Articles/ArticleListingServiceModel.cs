using AutoMapper;
using Blog.Common.Mapping;
using Blog.DAL.Models;

namespace Blog.Services.Models.Articles;

public class ArticleListingServiceModel : IMapFrom<Article>, IMapExplicitly
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }

    public void RegisterMapping(IProfileExpression profile)
    {
        profile.CreateMap<Article, ArticleListingServiceModel>()
            .ForMember(destinationMember => destinationMember.Author,
                cfg => cfg.MapFrom(a=>a.Author.UserName));

    }
}