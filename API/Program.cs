using API.Extensions;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence.Data;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureCors();
builder.Services.ConfigureRateLimiting();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.AddApplicationServices();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddDbContext<SeguridadContext>(optionsBuilder =>
{
    string connectionString = builder.Configuration.GetConnectionString("MySqlConex");
    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services
    .AddAuthentication()
    .AddBearerToken();  //👈
builder.Services.AddAuthorization();

// builder.Services.AddIdentityApiEndpoints<IdentityUser>()
//     .AddEntityFrameworkStores<SeguridadContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/login", (string username) =>
    {
        var claimsPrincipal = new ClaimsPrincipal(
          new ClaimsIdentity(
            new[] { new Claim(ClaimTypes.Name, username)},
            BearerTokenDefaults.AuthenticationScheme  //👈
          )
        );

        return Results.SignIn(claimsPrincipal);
    });
app.MapGet("/user", (ClaimsPrincipal user) =>
    {
        return Results.Ok($"Welcome {user.Identity.Name}!");
    })
    .RequireAuthorization();

app.UseHttpsRedirection();
app.UseIpRateLimiting();
app.UseAuthorization();

app.UseCors("CorsPolicy");
app.MapControllers();

app.Run();