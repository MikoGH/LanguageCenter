using LanguageCenter.Data;
using LanguageCenter.Modules;
using LanguageCenter.Repositories.Implementations;
using LanguageCenter.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace LanguageCenter
{
	public static class ServicesExtension
	{
		public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddRazorPages();

			services.AddDbContext<Context>(
				o => o.UseNpgsql(configuration.GetConnectionString("LanguageCenterDB"))
			);

			services.AddScoped<ILanguageRepository, LanguageRepository>();
			services.AddScoped<ILevelRepository, LevelRepository>();
			services.AddScoped<ICourseRepository, CourseRepository>();
			services.AddScoped<IPersonRepository, PersonRepository>();

			services.AddScoped<IPasswordHasher, PasswordHasher>();
			services.AddScoped<IJwtProvider, JwtProvider>();

			services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
			services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromMinutes(60);
				options.Cookie.HttpOnly = true;
				options.Cookie.IsEssential = true;
			});
			services.AddAuthorization();
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
				.AddJwtBearer(options =>
				{
					options.SaveToken = true;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection(nameof(JwtOptions))["SecretKey"])),
						ValidateIssuer = false,
						ValidateAudience = false,
						ValidateLifetime = true
					};
					options.Events = new JwtBearerEvents
					{
						OnMessageReceived = context =>
						{
							context.Token = context.Request.Cookies["cookie"];
							return Task.CompletedTask;
						}
					};
				});

			services.AddHttpContextAccessor();

			//services.AddMediatR(Assembly.GetExecutingAssembly());

			services.AddControllers();

			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1",
					new Microsoft.OpenApi.Models.OpenApiInfo
					{
						Title = "Language Center Swagger",
						Version = "v1"
					});
				options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
				{
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header
				});
				options.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							}
						}, Array.Empty<string>()
					}
				});
			});

			return services;
		}
	}
}
