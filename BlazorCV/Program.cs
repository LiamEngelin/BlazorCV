using BlazorCV.Components;
using BlazorCV.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorCV;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://blazorcv-api:8080/") });
        builder.Services.AddScoped<ProjectService>();
        builder.Services.AddScoped<SkillService>();
        builder.WebHost.CaptureStartupErrors(true);

        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
