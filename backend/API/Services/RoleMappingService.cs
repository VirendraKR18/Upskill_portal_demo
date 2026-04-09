using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace API.Services
{
    public interface IRoleMappingService
    {
        string MapSSORoleToAppRole(IEnumerable<string>? ssoRoles, string email);
    }

    public class RoleMappingService : IRoleMappingService
    {
        private readonly ILogger<RoleMappingService> _logger;
        private static readonly Dictionary<string, string> RoleMap = new(StringComparer.OrdinalIgnoreCase)
        {
            ["AAD_Group_Leadership"] = "Leadership",
            ["AAD_Group_AI_Admins"] = "Admin",
            ["AAD_Group_Managers"] = "Manager"
        };

        // privilege order: Leadership > Admin > Manager > Learner
        private static readonly List<string> PrivilegeOrder = new() { "Leadership", "Admin", "Manager", "Learner" };

        public RoleMappingService(ILogger<RoleMappingService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public string MapSSORoleToAppRole(IEnumerable<string>? ssoRoles, string email)
        {
            if (ssoRoles == null)
            {
                _logger.LogDebug("No roles provided by SSO for user {Email}. Defaulting to Learner.", email);
                return "Learner";
            }

            var mappedRoles = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var r in ssoRoles)
            {
                if (string.IsNullOrWhiteSpace(r)) continue;
                if (RoleMap.TryGetValue(r.Trim(), out var mapped))
                {
                    mappedRoles.Add(mapped);
                }
                else
                {
                    _logger.LogWarning("Unrecognized SSO role '{SSORole}' for user {Email}. Defaulting may apply.", r, email);
                }
            }

            // If none mapped, fallback to Learner
            if (mappedRoles.Count == 0)
            {
                return "Learner";
            }

            // Apply privilege order
            foreach (var p in PrivilegeOrder)
            {
                if (mappedRoles.Contains(p))
                {
                    return p;
                }
            }

            // Shouldn't reach here, but default safe role
            return "Learner";
        }
    }
}