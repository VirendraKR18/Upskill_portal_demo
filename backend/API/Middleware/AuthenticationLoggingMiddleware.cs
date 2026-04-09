using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace API.Middleware
{
    using API.Services;

    public class AuthenticationLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AuthenticationLoggingMiddleware> _logger;
        private readonly IUserRepository _userRepo;

        public AuthenticationLoggingMiddleware(RequestDelegate next, ILogger<AuthenticationLoggingMiddleware> logger, IUserRepository userRepo)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userRepo = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value ?? string.Empty;
            // Only log /api/auth/* endpoints
            if (!path.StartsWith("/api/auth/", StringComparison.OrdinalIgnoreCase))
            {
                await _next(context);
                return;
            }

            var sw = Stopwatch.StartNew();
            var timestamp = DateTime.UtcNow;
            var ip = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var userAgent = context.Request.Headers["User-Agent"].ToString();

            _logger.LogInformation("Auth request started {Method} {Path} from IP {IP}", context.Request.Method, context.Request.Path, ip);

            await _next(context);

            sw.Stop();
            var statusCode = context.Response.StatusCode;

            // Persist auth log entry (non-blocking)
            var entry = new AuthLogEntry
            {
                EmployeeId = context.Request.Headers["X-Employee-Id"].ToString(),
                IpAddress = ip,
                TimestampUtc = timestamp,
                EventType = $"Request:{context.Request.Method}:{path}",
                Severity = statusCode >= 500 ? "High" : statusCode >= 400 ? "Medium" : "Info",
                Details = $"Status:{statusCode};UA:{userAgent};DurationMs:{sw.ElapsedMilliseconds}"
            };

            try
            {
                await _userRepo.LogAuthEventAsync(entry);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to persist authentication log entry");
            }

            _logger.LogInformation("Auth request completed {Path} Status {Status} DurationMs {Ms}", path, statusCode, sw.ElapsedMilliseconds);
        }
    }
}