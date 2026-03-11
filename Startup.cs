using EPiServer.Cms.Shell;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using VIVEcms.Services;

namespace VIVEcms;

public class Startup
{
    private readonly IWebHostEnvironment _webHostingEnvironment;

    public Startup(IWebHostEnvironment webHostingEnvironment)
    {
        _webHostingEnvironment = webHostingEnvironment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        if (_webHostingEnvironment.IsDevelopment())
        {
            AppDomain.CurrentDomain.SetData(
                "DataDirectory",
                Path.Combine(_webHostingEnvironment.ContentRootPath, "App_Data")
            );

            services.Configure<SchedulerOptions>(options => options.Enabled = false);
        }

        services
            .AddCmsAspNetIdentity<ApplicationUser>()
            .AddCms()
            .AddAdminUserRegistration()
            .AddEmbeddedLocalization<Startup>();

        // =============================================
        // CUSTOM APPLICATION SERVICES
        // =============================================

        // Image Service - handles alt text retrieval from ImageFile assets
        services.AddScoped<IImageService, ImageService>();

        // Layout Service - fetches global Navbar and Footer data from SiteSettingsPage
        services.AddScoped<ILayoutService, LayoutService>();

        // =============================================
        // CONTENT DELIVERY API (Headless / Next.js)
        // =============================================

        // Registers all required API services (fixes IOutputCacheProvider error)
        // Exposes CMS content via REST API at /api/episerver/v3.0/...
        services.AddContentDeliveryApi();

        // =============================================
        // CORS — Allow Next.js frontend to call the API
        // =============================================

        services.AddCors(options =>
        {
            options.AddPolicy(
                "NextJsPolicy",
                builder =>
                {
                    builder
                        .WithOrigins(
                            "http://localhost:3000", // Next.js dev server
                            "https://your-nextjs-domain.com"
                        ) // update before production
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                }
            );
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStaticFiles();
        app.UseRouting();

        // ← Must be placed BEFORE UseAuthentication
        // Allows Next.js on port 3000 to call the API
        app.UseCors("NextJsPolicy");

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapContent();
        });
    }
}
