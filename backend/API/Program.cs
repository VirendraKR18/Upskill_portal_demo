using System;
using System.Net;
using System.Security.Authentication;
using API.Middleware;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;
var loggerFactory = LoggerFactory.Create(lb => lb.AddConsole());

// TLS enforcement for Kestrel
builder.WebHost.ConfigureKestrel(options =>
{
    options.ConfigureHttpsDefaults(httpsOptions =>
    {
        httpsOptions.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13;
    });
});

// Configuration validation for JWT secret
var jwtSecret = configuration["JWT:SecretKey"];
if (string.IsNullOrWhiteSpace(jwtSecret))
{
    builder.Logging.LogWarning("JWT:SecretKey is not configured. This must be set via environment variables in production.");
}

// Add services
services.AddSingleton<ILoggerFactory>(loggerFactory);
services.AddScoped<IRoleMappingService, RoleMappingService>();
services.AddScoped<IJwtTokenService, JwtTokenService>();
services.AddScoped<ISSOService, SSOService>();
services.AddScoped<IUserRepository, InMemoryUserRepository>(); // Replace with real implementation in production

// Authentication - JwtBearer
var key = jwtSecret != null ? Encoding.UTF8.GetBytes(jwtSecret) : Array.Empty<byte>();
services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = !string.IsNullOrEmpty(jwtSecret),
        IssuerSigningKey = !string.IsNullOrEmpty(jwtSecret) ? new SymmetricSecurityKey(key) : null,
        ValidateIssuer = !string.IsNullOrEmpty(configuration["JWT:Issuer"]),
        ValidIssuer = configuration["JWT:Issuer"],
        ValidateAudience = !string.IsNullOrEmpty(configuration["JWT:Audience"]),
        ValidAudience = configuration["JWT:Audience"],
        ClockSkew = TimeSpan.FromSeconds(60)
    };
});

// Rate limiting policy - 5 requests per IP per minute for auth endpoints
services.AddRateLimiter(options =>
{
    options.AddPolicy("AuthPolicy", context =>
    {
        // use IP for partition key
        var ip = context.Request.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        return RateLimitPartition.GetFixedWindowLimiter(ip, _ => new FixedWindowRateLimiterOptions
        {
            PermitLimit = 5,
            Window = TimeSpan.FromMinutes(1),
            QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
            QueueLimit = 0
        });
    });
});

// CORS - allow frontend origin (configure in env)
services.AddCors(options =>
{
    options.AddPolicy("DefaultCors", policy =>
    {
        var frontend = configuration["Frontend:Origin"] ?? "http://localhost:3000";
        policy.WithOrigins(frontend).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCors("DefaultCors");
app.UseRateLimiter();

app.UseMiddleware<AuthenticationLoggingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers()
   .RequireRateLimiting("AuthPolicy"); // apply rate limiting; controller routes will be subject

app.Run();