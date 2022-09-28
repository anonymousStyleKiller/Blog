using Blog.Services.Implementations;
using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Extensions;

public static class ServiceCollectionExtension
{
    public static void InitServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IArticleServices, ArticleServices>();
    }

    public static void AddMvc(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllersWithViews(opt=>opt.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
        serviceCollection.AddRazorPages();
    }
    
}