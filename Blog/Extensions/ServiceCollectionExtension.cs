using System.Reflection;
using Blog.Services.Common;
using Blog.Services.Implementations;
using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Extensions;

public static class ServiceCollectionExtension
{
    public static void InitServices(this IServiceCollection services)
    {
        services
            .AddTransient<IArticleServices, ArticleServices>()
            .AddTransient<IImageService, ImageService>()
            .AddTransient<IFileSystemService, FileSystemService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }

    public static void AddConventionalServices(this IServiceCollection services)
    {
        var serviceInterfaceType = typeof(IService);
        var scopedServiceInterfaceType = typeof(IScopedService);
        var singletonServiceInterfaceType = typeof(ISingletonService);

        var types = serviceInterfaceType
            .Assembly
            .GetExportedTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .Select(t => new
            {
                Service = t.GetInterface($"I{t.Name}"),
                Implementation = t,
            })
            .Where(t => t.Service != null);

        foreach (var type in types)
        {
            if (serviceInterfaceType.IsAssignableFrom(type.Service))
            {
                services.AddTransient(type.Service, type.Implementation);
            }
            else if (scopedServiceInterfaceType.IsAssignableFrom(type.Service))
            { 
                services.AddSingleton(type.Service, type.Implementation);
            }
            else if (singletonServiceInterfaceType.IsAssignableFrom(type.Service))
            { 
                services.AddScoped(type.Service, type.Implementation);
            }
        }
    }

    public static void AddMvc(this IServiceCollection services)
    {
        services.AddControllersWithViews(opt => opt.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
        services.AddRazorPages();
    }
}