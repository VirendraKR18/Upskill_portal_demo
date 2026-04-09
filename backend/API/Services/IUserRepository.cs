using System;
using System.Threading.Tasks;
using API.Models;

namespace API.Services
{
    public class UserEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string EmployeeId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "Learner";
        public bool IsActive { get; set; } = true;
        public string? Name { get; set; }
        public string? AvatarUrl { get; set; }
    }

    public class UserSessionEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public string TokenId { get; set; } = string.Empty;
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
    }

    public class AuthLogEntry
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? UserId { get; set; }
        public string? EmployeeId { get; set; }
        public string IpAddress { get; set; } = string.Empty;
        public DateTime TimestampUtc { get; set; }
        public string EventType { get; set; } = string.Empty;
        public string Severity { get; set; } = "Info";
        public string? Details { get; set; }
    }

    public interface IUserRepository
    {
        Task<UserEntity?> GetByEmployeeIdAsync(string employeeId);
        Task StoreSessionAsync(UserSessionEntity session);
        Task LogAuthEventAsync(AuthLogEntry entry);
        Task<UserEntity?> GetByIdAsync(Guid userId);
    }
}