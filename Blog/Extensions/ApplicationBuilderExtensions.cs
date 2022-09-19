using Blog.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void UseExceptHandler(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment()) return;
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    public static void UseControllerEndpoints(this IApplicationBuilder app)
    {
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );

            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

            endpoints.MapRazorPages();
        });
    }

    public static void SeedData(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        var db = serviceScope.ServiceProvider.GetService<BlogDbContext>();
        db?.Database.Migrate();
    }
}