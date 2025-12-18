using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using vendingbackend.Application.Services;
using vendingbackend.Core.Abstractions;
using vendingbackend.Core.Models;
using vendingbackend.Hubs;
using vendingbackend.Infrastructure.DataAccess;
using vendingbackend.Infrastructure.Repositories;
using vendingbackend.Mappings;
using vendingbackend.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Hate niggers
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(opt=> opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ITradeApparatusRepository, TradeApparatusRepository>();
builder.Services.AddScoped<ISalesRepository, SalesRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IServicesService, ServicesService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPasswordHasher<User>,PasswordHasher<User>>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<INotificationSender, NotificationSender>();
builder.Services.AddScoped<ITradeApparatusService, TradeApparatusService>();
builder.Services.AddHealthChecks();
builder.Services.AddMemoryCache();
builder.Services.AddSignalR();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    var key = builder.Configuration["Jwt:Key"]!;
    opt.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
    };
});
builder.Services.AddAuthorization();
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//middlewares
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();

//routing
app.MapHealthChecks("/health");
app.MapAuthEndpoints();
app.MapTradeApparatusEndpoints();
app.MapProductEndpoints();
app.MapServiceEndpoints();
app.MapHub<NotificationHub>("/notifications");

app.UseCors(opt => opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.Run();
