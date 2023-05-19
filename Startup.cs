public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Add services to the container here
        services.AddControllersWithViews();
        services.AddSpaStaticFiles(cfg => cfg.RootPath = "ClientApp/build");
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the app's request pipeline here
    }
}

