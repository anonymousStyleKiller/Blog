using AutoMapper;
using Blog.DAL.Models;
using Blog.Services.Models.Articles;

namespace Blog.Services.Infrastructure;

public class ServiceMappingProfile : Profile
{
    public ServiceMappingProfile()
    {
        CreateMap<Article, ArticleListingServiceModel>()
            .ForMember(m=>m.Author,
                       cfg=>cfg.MapFrom(a=>a.Author.UserName));
        
        CreateMap<Article, ArticleDetailsServiceModel>()
            .ForMember(m=>m.Author,
                       cfg=>cfg.MapFrom(a=>a.Author.UserName));
    }
}