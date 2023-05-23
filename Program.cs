using AutoMapper;
using Infobip.Controllers;
using Infobip.Models;
using Infobip.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(opt => {
        opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        opt.AllowInputFormatterExceptionMessages = true;
    });

//builder.Services.AddDbContext<CarpoolDbContext>();
builder.Services.AddSingleton<IMapper>(svc =>
{
    var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
    var mapper = config.CreateMapper();
    return mapper;
});


builder.Services.AddScoped<ICarpoolRepository, CarpoolRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
