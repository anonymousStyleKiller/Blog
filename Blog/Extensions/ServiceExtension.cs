using Blog.Services.Implementations;
using Blog.Services.Interfaces;

namespace Blog.Extensions;

public static class ServiceExtension
{
    public static void InitServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IArticleServices, ArticleServices>();
    }
}