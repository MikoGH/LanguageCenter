using LanguageCenter;
using LanguageCenter.Controllers;
using LanguageCenter.Data;
using LanguageCenter.Repositories.Implementations;
using LanguageCenter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<Context>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("LanguageCenterDB"))
);

builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<ILevelRepository, LevelRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "Language Center Swagger",
            Version = "v1"
        });

	//var filePath = Path.Combine(System.AppContext.BaseDirectory, "MyApi.xml");
	//options.IncludeXmlComments(Assembly.GetExecutingAssembly());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = String.Empty;
    options.DocumentTitle = "My Swagger";
});

app.Seed();

app.Run();
