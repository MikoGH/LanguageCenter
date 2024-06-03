using LanguageCenter.Data;
using LanguageCenter.Modules;
using LanguageCenter.Modules.Jwt;
using LanguageCenter.Modules.MappingProfiles;
using LanguageCenter.Modules.PasswordHasher;
using LanguageCenter.Repositories.Implementations;
using LanguageCenter.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
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
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

			services.AddDbContext<Context>(
				o => o.UseNpgsql(configuration.GetConnectionString("LanguageCenterDB"))
			);

			services.AddAutoMapper(typeof(LanguageMappingProfile));
			services.AddAutoMapper(typeof(LevelMappingProfile));
			services.AddAutoMapper(typeof(CourseMappingProfile));
			services.AddAutoMapper(typeof(PersonMappingProfile));
			services.AddAutoMapper(typeof(GroupMappingProfile));
			services.AddAutoMapper(typeof(AddressMappingProfile));
			services.AddAutoMapper(typeof(ClassroomMappingProfile));
			services.AddAutoMapper(typeof(ScheduleMappingProfile));

			services.AddScoped<ILanguageRepository, LanguageRepository>();
			services.AddScoped<ILevelRepository, LevelRepository>();
			services.AddScoped<ICourseRepository, CourseRepository>();
			services.AddScoped<IPersonRepository, PersonRepository>();
			services.AddScoped<IGroupRepository, GroupRepository>();
			services.AddScoped<IAddressRepository, AddressRepository>();
			services.AddScoped<IClassroomRepository, ClassroomRepository>();
			services.AddScoped<IScheduleRepository, ScheduleRepository>();
			services.AddScoped<IGroupClientRepository, GroupClientRepository>();
			services.AddScoped<ICourseTutorRepository, CourseTutorRepository>();

			services.AddScoped<IPasswordHasher, PasswordHasher>();
			services.AddScoped<IJwtProvider, JwtProvider>();

			services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

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
