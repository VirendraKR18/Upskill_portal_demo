# Task - task_002_be_sso_authentication

## Requirement Reference
- User Story: us_001 - SSO Authentication via Corporate Identity Provider
- Story Location: .propel/context/tasks/us_001/us_001.md
- Acceptance Criteria:  
    - AC-2: Given I enter valid corporate credentials on the SSO page, When the identity provider authenticates me, Then the system receives an auth token with claims (roles, email, employee ID), creates a JWT session token, and redirects me to the Individual Dashboard
    - AC-3: Given I am authenticated, When the system processes my SSO claims, Then my role (Learner, Manager, Admin, or Leadership) is mapped from SSO claims and stored in the JWT for subsequent authorization checks
    - AC-4: Given I enter invalid credentials, When authentication fails at the SSO provider, Then I remain on the SSO login page with an error message, and the platform logs the failed authentication attempt (timestamp, IP address, employee ID if available)
    - AC-5: Given the SSO provider is temporarily unavailable, When I attempt to log in, Then the system displays a user-friendly error message and does not expose internal error details
    - AC-6: Given data is transmitted between the platform and SSO provider, When any authentication request is made, Then all communication uses TLS 1.2+ encryption in transit
- Edge Case:
    - What happens when the SSO token is tampered with? (JWT signature validation rejects tampered tokens; request blocked and logged as security event)
    - How does the system handle SSO token with unrecognized role claims? (Default to Learner role; log warning for admin review; do not block access)
    - What happens if the user's EmployeeID from SSO claims does not exist in the User table? (Block access; return "Account not provisioned" message; user must wait for next Workday sync cycle)

## Design References (Frontend Tasks Only)
| Reference Type | Value |
|----------------|-------|
| **UI Impact** | No |
| **Figma URL** | N/A |
| **Wireframe Status** | N/A |
| **Wireframe Type** | N/A |
| **Wireframe Path/URL** | N/A |
| **Screen Spec** | N/A |
| **UXR Requirements** | N/A |
| **Design Tokens** | N/A |

> If UI Impact = No, all design references should be N/A

## Applicable Technology Stack
| Layer | Technology | Version |
|-------|------------|---------|
| Frontend | N/A | N/A |
| Backend | ASP.NET Core | 8.0 |
| Database | PostgreSQL | 14+ |
| Library | Microsoft.AspNetCore.Authentication.JwtBearer | 8.0 |
| Library | Microsoft.AspNetCore.Authentication.OpenIdConnect | 8.0 |
| Library | Npgsql.EntityFrameworkCore.PostgreSQL | 8.0 |
| Library | System.IdentityModel.Tokens.Jwt | 7.0+ |
| AI/ML | N/A | N/A |
| Vector Store | N/A | N/A |
| AI Gateway | N/A | N/A |

**Note**: All code, and libraries, MUST be compatible with versions above.

## AI References (AI Tasks Only)
| Reference Type | Value |
|----------------|-------|
| **AI Impact** | No |
| **AIR Requirements** | N/A |
| **AI Pattern** | N/A |
| **Prompt Template Path** | N/A |
| **Guardrails Config** | N/A |
| **Model Provider** | N/A |

> If AI Impact = No, all AI references should be N/A

## Task Overview
Implement SSO authentication backend for the AI Learning Platform using OAuth 2.0/SAML 2.0 protocols with Organization SSO (Azure AD). This task handles the SSO callback after user authentication at the identity provider, validates the incoming token, extracts user claims (email, employee ID, roles), maps roles to platform roles (Learner, Manager, Admin, Leadership), generates a JWT session token with role-based claims, and returns it to the frontend for subsequent API authorization.

**Key Capabilities:**
- SSO callback endpoint (`POST /api/auth/callback`) to receive OAuth 2.0/SAML 2.0 tokens
- Token validation with signature verification to prevent tampering (NFR-004, NFR-005)
- Role mapping from SSO claims to platform roles with default fallback
- JWT generation with 8-hour expiration and refresh token support
- Authentication event logging (success, failure, security events) with audit trail (NFR-010)
- User provisioning check against Workday-synced user records (UC-007)
- Error handling with secure, non-revealing error messages (OWASP A05)
- TLS 1.2+ enforcement for all SSO communication (AC-6)

## Dependent Tasks
- task_003_db_auth_schema - User sessions table and authentication logs table must exist

## Impacted Components
| Action | Component/Module | Project |
|--------|------------------|---------|
| CREATE | `Server/API/Controllers/AuthController.cs` | Backend (ASP.NET Core) |
| CREATE | `Server/API/Services/SSOService.cs` | Backend (SSO integration service) |
| CREATE | `Server/API/Services/JwtTokenService.cs` | Backend (JWT generation service) |
| CREATE | `Server/API/Services/RoleMappingService.cs` | Backend (Role mapping logic) |
| CREATE | `Server/API/Middleware/AuthenticationLoggingMiddleware.cs` | Backend (Audit logging) |
| CREATE | `Server/API/Models/AuthResponseDto.cs` | Backend (API response model) |
| CREATE | `Server/API/Models/SSOClaimsDto.cs` | Backend (SSO claims model) |
| MODIFY | `Server/API/Program.cs` | Add authentication middleware and services |
| MODIFY | `Server/API/appsettings.json` | Add SSO provider configuration |
| CREATE | `Server/Tests/AuthControllerTests.cs` | Backend (Unit tests) |
| CREATE | `Server/Tests/SSOServiceTests.cs` | Backend (Unit tests) |

## Implementation Plan

### Phase 1: SSO Configuration and Setup (1.5 hours)
1. **Configure SSO provider in appsettings.json**:
   - Add `Authentication:AzureAd` section with:
     - `Instance`: Azure AD endpoint (e.g., `https://login.microsoftonline.com/`)
     - `Domain`: Organization domain (e.g., `contoso.com`)
     - `TenantId`: Azure AD tenant ID (from environment variable)
     - `ClientId`: Application ID (from environment variable)
     - `ClientSecret`: Application secret (from Azure Key Vault, never hardcode)
     - `CallbackPath`: `/api/auth/callback`
   - Add `JWT:SecretKey`, `JWT:Issuer`, `JWT:Audience`, `JWT:ExpirationMinutes` (480 for 8 hours)

2. **Install NuGet packages**:
   ```bash
   dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.0
   dotnet add package Microsoft.AspNetCore.Authentication.OpenIdConnect --version 8.0.0
   dotnet add package System.IdentityModel.Tokens.Jwt --version 7.0.0
   dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 8.0.0
   ```

3. **Register authentication services in Program.cs**:
   - Configure OpenIdConnect authentication for SSO
   - Configure JwtBearer authentication for API requests
   - Add CORS policy for frontend origin
   - Register custom services: `SSOService`, `JwtTokenService`, `RoleMappingService`
   - Add `AuthenticationLoggingMiddleware` to pipeline

### Phase 2: SSO Service Implementation (2.5 hours)
4. **Implement SSOService.cs**:
   - `ValidateSSOToken(string token)` method:
     - Validate JWT signature using Azure AD public keys (JWKS endpoint)
     - Verify `iss` (issuer), `aud` (audience), `exp` (expiration) claims
     - Extract user claims: `sub`, `email`, `name`, `roles`, `employeeId` (custom claim)
     - Return `SSOClaimsDto` object or throw `UnauthorizedAccessException`
     - Reference: [Microsoft Identity Platform - Validate tokens](https://learn.microsoft.com/en-us/azure/active-directory/develop/access-tokens#validate-tokens)

5. **Implement RoleMappingService.cs**:
   - `MapSSORoleToAppRole(string[] ssoRoles, string email)` method:
     - Role mapping rules:
       - `AAD_Group_AI_Admins` → `Admin`
       - `AAD_Group_Managers` → `Manager`
       - `AAD_Group_Leadership` → `Leadership`
       - Default (no matching groups) → `Learner`
     - Log warning if unrecognized role encountered (use ILogger)
     - Return platform role as string
     - Handle multiple roles: Select highest privilege (Leadership > Admin > Manager > Learner)

6. **Implement JwtTokenService.cs**:
   - `GenerateJwtToken(SSOClaimsDto claims, string platformRole)` method:
     - Create JWT with claims: `userId` (EmployeeID), `email`, `name`, `role`, `jti` (unique token ID)
     - Set expiration: 8 hours (480 minutes) from issue time
     - Sign with HMAC-SHA256 using secret key from appsettings (or Azure Key Vault)
     - Return JWT as string
     - Reference: [ASP.NET Core JWT Bearer Authentication](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/jwt?view=aspnetcore-8.0)

7. **Implement refresh token generation** (future-proofing):
   - `GenerateRefreshToken()` method:
     - Generate cryptographically secure random token (32 bytes, Base64 encoded)
     - Store in `UserSessions` table with expiration (7 days)
     - Return refresh token string

### Phase 3: Authentication Controller Implementation (2 hours)
8. **Implement AuthController.cs**:
   - `POST /api/auth/callback` endpoint:
     - Parameter: `[FromBody] SSOCallbackRequest request` (contains `code`, `state`, `nonce`)
     - Exchange authorization code for access token (OAuth 2.0 Authorization Code Flow)
     - Call `SSOService.ValidateSSOToken(accessToken)`
     - Extract `EmployeeID` from claims
     - **User provisioning check**: Query `Users` table where `EmployeeID = claims.EmployeeID`
       - If user NOT found: Return `401 Unauthorized` with message: "Account not provisioned. Your employee record will be synced from Workday within 4 hours. Please try again later."
       - If user found but `IsActive = false`: Return `401 Unauthorized` with message: "Account deactivated. Please contact IT support."
     - Call `RoleMappingService.MapSSORoleToAppRole(claims.Roles, claims.Email)`
     - Call `JwtTokenService.GenerateJwtToken(claims, platformRole)`
     - Store session in `UserSessions` table (user ID, token ID, issue time, expiration)
     - Log successful authentication to `AuthenticationLogs` table
     - Return `AuthResponseDto` with JWT, refresh token, role, and redirect URL

9. **Implement error handling and logging**:
   - Try-catch blocks for SSO provider failures:
     - Network timeouts: Return `503 Service Unavailable` with message: "Authentication service temporarily unavailable. Please try again in a few minutes."
     - Invalid token: Return `401 Unauthorized` with message: "Authentication failed. Please try again."
     - Token tampering detected: Return `401 Unauthorized`, log as security event with high severity
   - Use structured logging (Serilog or Microsoft.Extensions.Logging):
     - Log success: `"User {EmployeeID} authenticated successfully with role {Role}"`
     - Log failure: `"Authentication failed for IP {IPAddress}, Reason: {Reason}"`
     - Log security event: `"Security: Tampered token detected from IP {IPAddress}, EmployeeID: {EmployeeID}"`

10. **Implement GET /api/auth/user endpoint** (for frontend user info):
    - Requires `[Authorize]` attribute (JWT bearer token)
    - Extract user ID from JWT claims
    - Query `Users` table and return user profile (name, email, role, avatar URL)
    - Return `404 Not Found` if user not in database

### Phase 4: Middleware and Cross-Cutting Concerns (1.5 hours)
11. **Implement AuthenticationLoggingMiddleware.cs**:
    - Intercept all requests to `/api/auth/*` endpoints
    - Log request metadata: Timestamp, IP address, User-Agent, endpoint path
    - Log response metadata: Status code, response time
    - Store logs in `AuthenticationLogs` table with retention policy (7 years per NFR-010)
    - Use `HttpContext.Connection.RemoteIpAddress` for IP extraction
    - Reference: [ASP.NET Core Middleware](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-8.0)

12. **Configure TLS 1.2+ enforcement in Program.cs**:
    ```csharp
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ConfigureHttpsDefaults(httpsOptions =>
        {
            httpsOptions.SslProtocols = System.Security.Authentication.SslProtocols.Tls12 | System.Security.Authentication.SslProtocols.Tls13;
        });
    });
    ```
    - Enforce HTTPS redirection: `app.UseHttpsRedirection();`
    - Set HSTS header: `app.UseHsts();` (production only)

13. **Implement rate limiting for auth endpoints** (security best practice):
    - Limit `/api/auth/callback` to 5 requests per IP per minute (prevent brute force)
    - Use ASP.NET Core Rate Limiting middleware or custom implementation
    - Return `429 Too Many Requests` if limit exceeded
    - Reference: [Rate limiting middleware in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/performance/rate-limit?view=aspnetcore-8.0)

### Phase 5: Testing and Validation (1.5 hours)
14. **Write unit tests (AuthControllerTests.cs)**:
    - Test valid SSO token flow: Returns 200 with JWT and redirect URL
    - Test invalid token: Returns 401 with error message
    - Test tampered token: Returns 401 and logs security event
    - Test user not provisioned: Returns 401 with "Account not provisioned" message
    - Test deactivated user: Returns 401 with "Account deactivated" message
    - Test unrecognized role claim: Maps to Learner role and logs warning
    - Mock `SSOService`, `JwtTokenService`, `RoleMappingService` using Moq
    - Minimum 80% code coverage (per NFR-011)

15. **Write integration tests**:
    - Test full OAuth 2.0 flow with Azure AD test tenant (if available)
    - Test JWT validation on protected endpoints
    - Test refresh token flow
    - Verify authentication logs written to database
    - Test rate limiting enforcement

16. **Manual testing checklist**:
    - [ ] SSO callback receives token from Azure AD successfully
    - [ ] JWT token generated with correct claims structure
    - [ ] Role mapping works for all 4 roles (Learner, Manager, Admin, Leadership)
    - [ ] User provisioning check blocks access for non-existent users
    - [ ] Authentication logs written to database with correct metadata
    - [ ] Tampered token rejected and logged as security event
    - [ ] TLS 1.2+ enforced (verify with SSL Labs test)
    - [ ] Rate limiting blocks excessive requests

## Current Project State
```
UPSKILL/
├── .propel/
│   ├── context/
│   │   ├── docs/
│   │   │   ├── design.md (Tech stack: ASP.NET Core 8.0, PostgreSQL 14+)
│   │   │   ├── spec.md (FR-001, NFR-004, NFR-005, NFR-006)
│   │   │   └── models.md (UC-007 sequence diagram)
│   │   ├── tasks/
│   │   │   └── us_001/
│   │   │       ├── us_001.md (User story specification)
│   │   │       ├── task_001_fe_login_ui.md (Frontend task - completed dependency)
│   │   │       └── task_003_db_auth_schema.md (Database task - pending dependency)
├── Server/ (Backend project - ASP.NET Core - to be created)
├── app/ (Frontend project - React - created by task_001)
└── README.md
```

**Expected after task_003_db_auth_schema completion:**
- `Users` table exists with `EmployeeID`, `Email`, `Role`, `IsActive` columns
- `UserSessions` table exists with `UserId`, `TokenId`, `IssuedAt`, `ExpiresAt` columns
- `AuthenticationLogs` table exists with `UserId`, `IPAddress`, `Timestamp`, `EventType`, `Severity` columns

## Expected Changes
| Action | File Path | Description |
|--------|-----------|-------------|
| CREATE | `Server/API/Controllers/AuthController.cs` | SSO callback and user info endpoints |
| CREATE | `Server/API/Services/SSOService.cs` | SSO token validation and claims extraction |
| CREATE | `Server/API/Services/JwtTokenService.cs` | JWT and refresh token generation |
| CREATE | `Server/API/Services/RoleMappingService.cs` | Map SSO roles to platform roles |
| CREATE | `Server/API/Middleware/AuthenticationLoggingMiddleware.cs` | Audit logging middleware |
| CREATE | `Server/API/Models/AuthResponseDto.cs` | API response model for auth endpoints |
| CREATE | `Server/API/Models/SSOClaimsDto.cs` | SSO claims data transfer object |
| CREATE | `Server/API/Models/SSOCallbackRequest.cs` | Request model for callback endpoint |
| MODIFY | `Server/API/Program.cs` | Register auth services, middleware, TLS config |
| MODIFY | `Server/API/appsettings.json` | Add SSO and JWT configuration |
| CREATE | `Server/Tests/AuthControllerTests.cs` | Unit tests for AuthController |
| CREATE | `Server/Tests/SSOServiceTests.cs` | Unit tests for SSOService |
| CREATE | `Server/Tests/JwtTokenServiceTests.cs` | Unit tests for JwtTokenService |
| CREATE | `Server/Tests/RoleMappingServiceTests.cs` | Unit tests for RoleMappingService |

## External References
- [Microsoft Identity Platform - OAuth 2.0 authorization code flow](https://learn.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-auth-code-flow)
- [ASP.NET Core 8.0 - JWT Bearer Authentication](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/jwt?view=aspnetcore-8.0)
- [ASP.NET Core 8.0 - OpenID Connect Authentication](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/social/microsoft-logins?view=aspnetcore-8.0)
- [JWT.io - Token Debugger and Specification](https://jwt.io/)
- [OWASP - Authentication Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Authentication_Cheat_Sheet.html)
- [IETF RFC 7519 - JSON Web Token (JWT)](https://datatracker.ietf.org/doc/html/rfc7519)
- [ASP.NET Core 8.0 - Rate Limiting Middleware](https://learn.microsoft.com/en-us/aspnet/core/performance/rate-limit?view=aspnetcore-8.0)

## Build Commands
```bash
# Navigate to backend project
cd Server/API

# Restore NuGet packages
dotnet restore

# Build project
dotnet build --configuration Release

# Run unit tests
dotnet test --configuration Release --collect:"XPlat Code Coverage"

# Run project locally (development)
dotnet run --environment Development

# Publish for production
dotnet publish --configuration Release --output ./publish
```

## Implementation Validation Strategy
- [x] Unit tests pass (minimum 80% coverage per NFR-011)
- [x] Integration tests pass (OAuth 2.0 flow, JWT validation)
- [x] SSO token validation correctly rejects tampered tokens
- [x] Role mapping defaults to Learner for unrecognized roles
- [x] User provisioning check blocks non-existent users
- [x] Authentication logs written to database with 7-year retention
- [x] TLS 1.2+ enforced (verify with SSL Labs scan)
- [x] Rate limiting functional (5 requests/IP/minute)
- [x] Error messages do not expose internal details (OWASP A05 compliance)
- [x] JWT tokens contain correct claims structure (userId, email, name, role, jti, exp)

## Implementation Checklist
- [ ] Configure SSO provider settings in appsettings.json with environment variables
- [ ] Install required NuGet packages (JwtBearer, OpenIdConnect, EntityFrameworkCore)
- [ ] Implement SSOService with token validation and claims extraction
- [ ] Implement RoleMappingService with default fallback to Learner
- [ ] Implement JwtTokenService with 8-hour expiration and HMAC-SHA256 signing
- [ ] Implement AuthController with SSO callback endpoint
- [ ] Add user provisioning check against Users table (EmployeeID lookup)
- [ ] Implement error handling with user-friendly, non-revealing messages
- [ ] Create AuthenticationLoggingMiddleware for audit trail
- [ ] Configure TLS 1.2+ enforcement in Program.cs
- [ ] Implement rate limiting (5 requests/IP/minute) for auth endpoints
- [ ] Write unit tests for all services and controller (>80% coverage)
- [ ] Write integration tests for OAuth 2.0 flow
- [ ] Test tampered token rejection and security event logging
- [ ] Test unrecognized role defaults to Learner with warning log
- [ ] Verify authentication logs stored with 7-year retention policy
- [ ] Manual testing: SSO flow end-to-end with Azure AD test account
- [ ] Verify TLS configuration with SSL Labs scan
