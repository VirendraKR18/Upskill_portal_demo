using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    // Simple in-memory repository for runtime/testing convenience.
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly ConcurrentDictionary<Guid, UserEntity> _users = new();
        private readonly ConcurrentDictionary<Guid, UserSessionEntity> _sessions = new();
        private readonly ConcurrentBag<AuthLogEntry> _logs = new();

        public InMemoryUserRepository()
        {
            // Seed a sample user for local testing
            var u = new UserEntity
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                EmployeeId = "E12345",
                Email = "jane.doe@contoso.com",
                Role = "Learner",
                IsActive = true,
                Name = "Jane Doe"
            };
            _users.TryAdd(u.Id, u);
        }

        public Task<UserEntity?> GetByEmployeeIdAsync(string employeeId)
        {
            var user = _users.Values.FirstOrDefault(u => string.Equals(u.EmployeeId, employeeId, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(user);
        }

        public Task StoreSessionAsync(UserSessionEntity session)
        {
            _sessions[session.Id] = session;
            return Task.CompletedTask;
        }

        public Task LogAuthEventAsync(AuthLogEntry entry)
        {
            _logs.Add(entry);
            return Task.CompletedTask;
        }

        public Task<UserEntity?> GetByIdAsync(Guid userId)
        {
            _users.TryGetValue(userId, out var u);
            return Task.FromResult(u);
        }
    }
}