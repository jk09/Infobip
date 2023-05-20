using Infobip.Models;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Add services to the container here
        
        services.AddDbContext<CarpoolDbContext>();
        services.AddControllers();
        services.AddSpaStaticFiles(cfg => cfg.RootPath = "ClientApp/build");
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the app's request pipeline here
        if (env.IsDevelopment())
        {
            // Use developer exception page in development
            app.UseDeveloperExceptionPage();
        }

        app.UseStaticFiles();
        app.UseSpaStaticFiles();
        app.UseRouting();
        app.UseEndpoints(endp => { endp.MapControllers(); });
        app.UseSpa(spa => {

            spa.Options.SourcePath = "ClientApp";
            if (env.IsDevelopment())
            {
                spa.UseReactDevelopmentServer(npmScript: "start");
            }
        });
    }
}

