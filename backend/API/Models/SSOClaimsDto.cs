using System.Collections.Generic;

namespace API.Models
{
    public class SSOClaimsDto
    {
        public string Subject { get; set; } = string.Empty; // sub
        public string Issuer { get; set; } = string.Empty; // iss
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? EmployeeId { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
        public IDictionary<string, object>? RawClaims { get; set; }
    }
}