using Blog.Extensions;
using Blog.Services.Implementations;
using Blog.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.InitServices();
builder.Services.AddConventionalServices();

var app = builder.Build();
app.UseExceptHandler(builder.Environment);
app.UseControllerEndpoints();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.SeedData();
app.Run();