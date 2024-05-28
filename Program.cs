using LanguageCenter;
using LanguageCenter.Controllers;
using LanguageCenter.Data;
using LanguageCenter.Modules;
using LanguageCenter.Repositories.Implementations;
using LanguageCenter.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();
app.ConfigureApp();
app.Run();
