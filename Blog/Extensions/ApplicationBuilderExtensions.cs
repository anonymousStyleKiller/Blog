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
}