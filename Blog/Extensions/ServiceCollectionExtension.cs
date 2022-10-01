using System.Reflection;
using Blog.Services.Implementations;
using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Extensions;

public static class ServiceCollectionExtension
{
    public static void InitServices(this IServiceCollection services)
    {
        services.AddScoped<IArticleServices, ArticleServices>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }

    public static void AddMvc(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllersWithViews(opt=>opt.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
        serviceCollection.AddRazorPages();
    }
    
}