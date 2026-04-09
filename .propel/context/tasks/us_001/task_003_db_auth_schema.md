# Task - task_003_db_auth_schema

## Requirement Reference
- User Story: us_001 - SSO Authentication via Corporate Identity Provider
- Story Location: .propel/context/tasks/us_001/us_001.md
- Acceptance Criteria:  
    - AC-2: Given I enter valid corporate credentials on the SSO page, When the identity provider authenticates me, Then the system receives an auth token with claims (roles, email, employee ID), creates a JWT session token, and redirects me to the Individual Dashboard
    - AC-4: Given I enter invalid credentials, When authentication fails at the SSO provider, Then I remain on the SSO login page with an error message, and the platform logs the failed authentication attempt (timestamp, IP address, employee ID if available)
    - AC-6: Given data is transmitted between the platform and SSO provider, When any authentication request is made, Then all communication uses TLS 1.2+ encryption in transit
- Edge Case:
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
| Backend | N/A | N/A |
| Database | PostgreSQL | 14+ |
| Library | Npgsql | 8.0 |
| Library | Dapper (optional - for raw SQL) | 2.1+ |
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
Design and implement the database schema for SSO authentication, user session management, and authentication audit logging in PostgreSQL 14+. This task creates three critical tables: `Users` (employee records synced from Workday), `UserSessions` (JWT session tracking with expiration), and `AuthenticationLogs` (audit trail for all authentication events). The schema ensures data integrity through foreign key constraints, supports high-performance lookups via strategic indexing, and provides 7-year audit log retention with immutable log records.

**Key Capabilities:**
- `Users` table: Store employee data synced from Workday (EmployeeID, Email, Role, IsActive)
- `UserSessions` table: Track active JWT sessions with token IDs and expiration timestamps
- `AuthenticationLogs` table: Immutable audit trail for authentication events (success, failure, security events)
- Database indexes for fast lookups on EmployeeID, Email, TokenID (sub-100ms query times per NFR-001)
- Constraints and triggers to ensure data integrity and prevent tampering (NFR-012)
- Database migration scripts with rollback support for safe deployments
- Retention policy implementation for 7-year audit log storage (NFR-010)

## Dependent Tasks
- None (This is a foundational task for US_001)

## Impacted Components
| Action | Component/Module | Project |
|--------|------------------|---------|
| CREATE | `Database/Migrations/001_CreateUsersTable.sql` | Database (PostgreSQL) |
| CREATE | `Database/Migrations/002_CreateUserSessionsTable.sql` | Database (PostgreSQL) |
| CREATE | `Database/Migrations/003_CreateAuthenticationLogsTable.sql` | Database (PostgreSQL) |
| CREATE | `Database/Migrations/004_CreateIndexes.sql` | Database (PostgreSQL) |
| CREATE | `Database/Migrations/005_CreateConstraintsAndTriggers.sql` | Database (PostgreSQL) |
| CREATE | `Database/Rollback/001_DropUsersTable.sql` | Database (Rollback scripts) |
| CREATE | `Database/Rollback/002_DropUserSessionsTable.sql` | Database (Rollback scripts) |
| CREATE | `Database/Rollback/003_DropAuthenticationLogsTable.sql` | Database (Rollback scripts) |
| CREATE | `Database/Scripts/SeedData.sql` | Database (Test data seeding) |
| CREATE | `Database/Scripts/CleanupExpiredSessions.sql` | Database (Maintenance script) |
| CREATE | `Database/README.md` | Documentation for schema and migrations |

## Implementation Plan

### Phase 1: Database Setup and Connection (0.5 hours)
1. **Install PostgreSQL 14+ locally or use Azure Database for PostgreSQL**:
   - Download from [PostgreSQL Official](https://www.postgresql.org/download/) or use Docker:
     ```bash
     docker run --name ai-learning-db -e POSTGRES_PASSWORD=localdev123 -p 5432:5432 -d postgres:14
     ```
   - Create database: `CREATE DATABASE ai_learning_platform;`

2. **Configure connection string**:
   - Store in `Server/API/appsettings.json`:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=ai_learning_platform;Username=postgres;Password=localdev123"
     }
     ```
   - For production: Use Azure Key Vault or environment variables (never hardcode credentials)

3. **Create migration folder structure**:
   ```
   Database/
   ├── Migrations/
   │   ├── 001_CreateUsersTable.sql
   │   ├── 002_CreateUserSessionsTable.sql
   │   ├── 003_CreateAuthenticationLogsTable.sql
   │   ├── 004_CreateIndexes.sql
   │   └── 005_CreateConstraintsAndTriggers.sql
   ├── Rollback/
   │   ├── 001_DropUsersTable.sql
   │   ├── 002_DropUserSessionsTable.sql
   │   └── 003_DropAuthenticationLogsTable.sql
   ├── Scripts/
   │   ├── SeedData.sql
   │   └── CleanupExpiredSessions.sql
   └── README.md
   ```

### Phase 2: Users Table Creation (1 hour)
4. **Design Users table schema** (001_CreateUsersTable.sql):
   ```sql
   CREATE TABLE IF NOT EXISTS "Users" (
       "UserId" SERIAL PRIMARY KEY,
       "EmployeeID" VARCHAR(50) NOT NULL UNIQUE,
       "Email" VARCHAR(255) NOT NULL UNIQUE,
       "FirstName" VARCHAR(100) NOT NULL,
       "LastName" VARCHAR(100) NOT NULL,
       "Role" VARCHAR(20) NOT NULL DEFAULT 'Learner',
       "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
       "Department" VARCHAR(100),
       "ManagerEmployeeID" VARCHAR(50),
       "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
       "UpdatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
       "LastSyncedAt" TIMESTAMP,
       CONSTRAINT "CHK_Role" CHECK ("Role" IN ('Learner', 'Manager', 'Admin', 'Leadership'))
   );

   -- Add comment to table
   COMMENT ON TABLE "Users" IS 'Employee records synced from Workday HR system via UC-007';
   COMMENT ON COLUMN "Users"."EmployeeID" IS 'Unique employee identifier from Workday (matches SSO claim)';
   COMMENT ON COLUMN "Users"."Role" IS 'Platform role: Learner (default), Manager, Admin, Leadership';
   COMMENT ON COLUMN "Users"."IsActive" IS 'False if employee deactivated/terminated in Workday';
   COMMENT ON COLUMN "Users"."LastSyncedAt" IS 'Timestamp of last Workday sync (every 4 hours per NFR-009)';
   ```

5. **Add index on EmployeeID and Email** (part of 004_CreateIndexes.sql):
   ```sql
   CREATE UNIQUE INDEX IF NOT EXISTS "IDX_Users_EmployeeID" ON "Users" ("EmployeeID");
   CREATE UNIQUE INDEX IF NOT EXISTS "IDX_Users_Email" ON "Users" ("Email");
   CREATE INDEX IF NOT EXISTS "IDX_Users_IsActive" ON "Users" ("IsActive") WHERE "IsActive" = TRUE;
   ```
   - Justification: Fast lookups during SSO authentication (sub-100ms per NFR-001)

6. **Create rollback script** (001_DropUsersTable.sql):
   ```sql
   DROP TABLE IF EXISTS "Users" CASCADE;
   ```

### Phase 3: UserSessions Table Creation (1 hour)
7. **Design UserSessions table schema** (002_CreateUserSessionsTable.sql):
   ```sql
   CREATE TABLE IF NOT EXISTS "UserSessions" (
       "SessionId" SERIAL PRIMARY KEY,
       "UserId" INTEGER NOT NULL,
       "TokenId" VARCHAR(36) NOT NULL UNIQUE,
       "RefreshToken" VARCHAR(255) UNIQUE,
       "IssuedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
       "ExpiresAt" TIMESTAMP NOT NULL,
       "RefreshExpiresAt" TIMESTAMP,
       "IPAddress" VARCHAR(45),
       "UserAgent" VARCHAR(500),
       "IsRevoked" BOOLEAN NOT NULL DEFAULT FALSE,
       "RevokedAt" TIMESTAMP,
       "RevokedReason" VARCHAR(255),
       CONSTRAINT "FK_UserSessions_Users" FOREIGN KEY ("UserId") REFERENCES "Users"("UserId") ON DELETE CASCADE
   );

   -- Add comments
   COMMENT ON TABLE "UserSessions" IS 'Active JWT sessions with 8-hour expiration (FR-001, NFR-004)';
   COMMENT ON COLUMN "UserSessions"."TokenId" IS 'JWT jti claim (unique token identifier) for revocation checks';
   COMMENT ON COLUMN "UserSessions"."RefreshToken" IS 'Refresh token for extending session (7-day expiration)';
   COMMENT ON COLUMN "UserSessions"."IsRevoked" IS 'True if user logged out or admin revoked session';
   ```

8. **Add index on TokenId and UserId** (part of 004_CreateIndexes.sql):
   ```sql
   CREATE UNIQUE INDEX IF NOT EXISTS "IDX_UserSessions_TokenId" ON "UserSessions" ("TokenId");
   CREATE INDEX IF NOT EXISTS "IDX_UserSessions_UserId" ON "UserSessions" ("UserId");
   CREATE INDEX IF NOT EXISTS "IDX_UserSessions_ExpiresAt" ON "UserSessions" ("ExpiresAt") WHERE "IsRevoked" = FALSE;
   ```
   - Justification: Fast token validation during API requests (every protected endpoint)

9. **Create cleanup script for expired sessions** (CleanupExpiredSessions.sql):
   ```sql
   -- Delete expired sessions older than 30 days (for analytics retention)
   DELETE FROM "UserSessions"
   WHERE "ExpiresAt" < CURRENT_TIMESTAMP - INTERVAL '30 days';

   -- Vacuum table to reclaim disk space
   VACUUM ANALYZE "UserSessions";
   ```
   - Schedule as PostgreSQL cron job or Azure Automation runbook (daily execution)

10. **Create rollback script** (002_DropUserSessionsTable.sql):
    ```sql
    DROP TABLE IF EXISTS "UserSessions" CASCADE;
    ```

### Phase 4: AuthenticationLogs Table Creation (1 hour)
11. **Design AuthenticationLogs table schema** (003_CreateAuthenticationLogsTable.sql):
    ```sql
    CREATE TABLE IF NOT EXISTS "AuthenticationLogs" (
        "LogId" BIGSERIAL PRIMARY KEY,
        "UserId" INTEGER,
        "EmployeeID" VARCHAR(50),
        "EventType" VARCHAR(50) NOT NULL,
        "EventStatus" VARCHAR(20) NOT NULL,
        "Severity" VARCHAR(20) NOT NULL DEFAULT 'Info',
        "IPAddress" VARCHAR(45) NOT NULL,
        "UserAgent" VARCHAR(500),
        "Timestamp" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
        "ErrorMessage" TEXT,
        "Metadata" JSONB,
        CONSTRAINT "FK_AuthenticationLogs_Users" FOREIGN KEY ("UserId") REFERENCES "Users"("UserId") ON DELETE SET NULL,
        CONSTRAINT "CHK_EventType" CHECK ("EventType" IN ('Login', 'Logout', 'TokenRefresh', 'TokenRevoked', 'LoginFailed', 'InvalidToken', 'TamperedToken')),
        CONSTRAINT "CHK_EventStatus" CHECK ("EventStatus" IN ('Success', 'Failure', 'Warning')),
        CONSTRAINT "CHK_Severity" CHECK ("Severity" IN ('Info', 'Warning', 'Error', 'Critical'))
    );

    -- Add comments
    COMMENT ON TABLE "AuthenticationLogs" IS 'Immutable audit trail for authentication events (7-year retention per NFR-010)';
    COMMENT ON COLUMN "AuthenticationLogs"."EventType" IS 'Authentication event: Login, Logout, TokenRefresh, LoginFailed, InvalidToken, TamperedToken';
    COMMENT ON COLUMN "AuthenticationLogs"."Severity" IS 'Log level: Info (normal), Warning (unrecognized role), Error (auth failure), Critical (tampered token)';
    COMMENT ON COLUMN "AuthenticationLogs"."Metadata" IS 'Additional context (JSON): SSO claims, error details, request headers';
    ```

12. **Add indexes for audit queries** (part of 004_CreateIndexes.sql):
    ```sql
    CREATE INDEX IF NOT EXISTS "IDX_AuthenticationLogs_UserId" ON "AuthenticationLogs" ("UserId");
    CREATE INDEX IF NOT EXISTS "IDX_AuthenticationLogs_Timestamp" ON "AuthenticationLogs" ("Timestamp");
    CREATE INDEX IF NOT EXISTS "IDX_AuthenticationLogs_EventType" ON "AuthenticationLogs" ("EventType");
    CREATE INDEX IF NOT EXISTS "IDX_AuthenticationLogs_Severity" ON "AuthenticationLogs" ("Severity") WHERE "Severity" IN ('Error', 'Critical');
    ```
    - Justification: Fast audit queries for security dashboards and compliance reports

13. **Implement immutability trigger** (part of 005_CreateConstraintsAndTriggers.sql):
    ```sql
    -- Prevent UPDATE and DELETE on AuthenticationLogs (immutable audit trail)
    CREATE OR REPLACE FUNCTION prevent_authentication_log_modification()
    RETURNS TRIGGER AS $$
    BEGIN
        RAISE EXCEPTION 'AuthenticationLogs table is immutable. Updates and deletes are not allowed.';
    END;
    $$ LANGUAGE plpgsql;

    CREATE TRIGGER trg_prevent_authentication_log_update
        BEFORE UPDATE ON "AuthenticationLogs"
        FOR EACH ROW
        EXECUTE FUNCTION prevent_authentication_log_modification();

    CREATE TRIGGER trg_prevent_authentication_log_delete
        BEFORE DELETE ON "AuthenticationLogs"
        FOR EACH ROW
        EXECUTE FUNCTION prevent_authentication_log_modification();
    ```
    - Justification: Ensures tamper-proof audit trail (NFR-012)

14. **Implement 7-year retention policy**:
    - Option 1 (Partitioning): Partition table by year, drop partitions older than 7 years
    - Option 2 (Archival): Move logs older than 7 years to Azure Blob Storage, delete from table
    - For MVP: Document manual archival process; automate in future task

15. **Create rollback script** (003_DropAuthenticationLogsTable.sql):
    ```sql
    DROP TRIGGER IF EXISTS trg_prevent_authentication_log_update ON "AuthenticationLogs";
    DROP TRIGGER IF EXISTS trg_prevent_authentication_log_delete ON "AuthenticationLogs";
    DROP FUNCTION IF EXISTS prevent_authentication_log_modification();
    DROP TABLE IF EXISTS "AuthenticationLogs" CASCADE;
    ```

### Phase 5: Additional Constraints and Test Data (0.5 hours)
16. **Add UpdatedAt trigger for Users table** (part of 005_CreateConstraintsAndTriggers.sql):
    ```sql
    CREATE OR REPLACE FUNCTION update_updated_at_column()
    RETURNS TRIGGER AS $$
    BEGIN
        NEW."UpdatedAt" = CURRENT_TIMESTAMP;
        RETURN NEW;
    END;
    $$ LANGUAGE plpgsql;

    CREATE TRIGGER trg_users_updated_at
        BEFORE UPDATE ON "Users"
        FOR EACH ROW
        EXECUTE FUNCTION update_updated_at_column();
    ```

17. **Create seed data for local development** (SeedData.sql):
    ```sql
    -- Insert test users (simulates Workday sync)
    INSERT INTO "Users" ("EmployeeID", "Email", "FirstName", "LastName", "Role", "IsActive", "Department")
    VALUES
        ('EMP001', 'john.doe@organization.com', 'John', 'Doe', 'Learner', TRUE, 'Engineering'),
        ('EMP002', 'jane.smith@organization.com', 'Jane', 'Smith', 'Manager', TRUE, 'Engineering'),
        ('EMP003', 'admin.user@organization.com', 'Admin', 'User', 'Admin', TRUE, 'IT'),
        ('EMP004', 'cto@organization.com', 'Chief', 'Technology', 'Leadership', TRUE, 'Executive'),
        ('EMP005', 'inactive.user@organization.com', 'Inactive', 'User', 'Learner', FALSE, 'Engineering')
    ON CONFLICT ("EmployeeID") DO NOTHING;
    ```

### Phase 6: Migration Execution and Validation (1 hour)
18. **Create migration runner script** (bash or PowerShell):
    ```bash
    #!/bin/bash
    # run-migrations.sh
    PGHOST=localhost
    PGDATABASE=ai_learning_platform
    PGUSER=postgres
    PGPASSWORD=localdev123

    for migration in Database/Migrations/*.sql; do
        echo "Running migration: $migration"
        psql -h $PGHOST -d $PGDATABASE -U $PGUSER -f "$migration"
        if [ $? -ne 0 ]; then
            echo "Migration failed: $migration"
            exit 1
        fi
    done

    echo "All migrations completed successfully!"
    ```

19. **Validate schema creation**:
    - Run migrations: `./run-migrations.sh`
    - Verify tables exist: `\dt` in psql
    - Verify indexes: `\di`
    - Verify constraints: `\d+ "Users"`, `\d+ "UserSessions"`, `\d+ "AuthenticationLogs"`
    - Test immutability trigger:
      ```sql
      INSERT INTO "AuthenticationLogs" ("EventType", "EventStatus", "IPAddress") VALUES ('Login', 'Success', '127.0.0.1');
      UPDATE "AuthenticationLogs" SET "EventType" = 'Logout' WHERE "LogId" = 1; -- Should fail
      DELETE FROM "AuthenticationLogs" WHERE "LogId" = 1; -- Should fail
      ```

20. **Performance testing**:
    - Insert 10,000 test users: Measure insert time (should be <10 seconds)
    - Query user by EmployeeID: Measure query time (should be <100ms)
    - Insert 100,000 authentication logs: Measure insert time (should be <60 seconds)
    - Query logs by UserId and timestamp range: Measure query time (should be <500ms)

## Current Project State
```
UPSKILL/
├── .propel/
│   ├── context/
│   │   ├── docs/
│   │   │   ├── design.md (Database: PostgreSQL 14+, DR-001 to DR-010)
│   │   │   └── spec.md (FR-001, FR-002, NFR-010)
│   │   ├── tasks/
│   │   │   └── us_001/
│   │   │       ├── us_001.md (User story specification)
│   │   │       ├── task_001_fe_login_ui.md (Frontend task)
│   │   │       ├── task_002_be_sso_authentication.md (Backend task - depends on this task)
│   │   │       └── task_003_db_auth_schema.md (This task)
├── Database/ (to be created)
├── Server/ (Backend project - ASP.NET Core)
├── app/ (Frontend project - React)
└── README.md
```

## Expected Changes
| Action | File Path | Description |
|--------|-----------|-------------|
| CREATE | `Database/Migrations/001_CreateUsersTable.sql` | Users table schema with EmployeeID, Email, Role, IsActive |
| CREATE | `Database/Migrations/002_CreateUserSessionsTable.sql` | UserSessions table for JWT tracking |
| CREATE | `Database/Migrations/003_CreateAuthenticationLogsTable.sql` | Immutable audit log table |
| CREATE | `Database/Migrations/004_CreateIndexes.sql` | Indexes on EmployeeID, Email, TokenId, UserId, Timestamp |
| CREATE | `Database/Migrations/005_CreateConstraintsAndTriggers.sql` | Immutability triggers and UpdatedAt trigger |
| CREATE | `Database/Rollback/001_DropUsersTable.sql` | Rollback script for Users table |
| CREATE | `Database/Rollback/002_DropUserSessionsTable.sql` | Rollback script for UserSessions table |
| CREATE | `Database/Rollback/003_DropAuthenticationLogsTable.sql` | Rollback script for AuthenticationLogs table |
| CREATE | `Database/Scripts/SeedData.sql` | Test data for local development |
| CREATE | `Database/Scripts/CleanupExpiredSessions.sql` | Maintenance script for session cleanup |
| CREATE | `Database/run-migrations.sh` | Bash script to execute migrations |
| CREATE | `Database/README.md` | Documentation for schema and migration process |

## External References
- [PostgreSQL 14 Documentation - CREATE TABLE](https://www.postgresql.org/docs/14/sql-createtable.html)
- [PostgreSQL 14 Documentation - Indexes](https://www.postgresql.org/docs/14/indexes.html)
- [PostgreSQL 14 Documentation - Triggers](https://www.postgresql.org/docs/14/sql-createtrigger.html)
- [PostgreSQL 14 Documentation - Constraints](https://www.postgresql.org/docs/14/ddl-constraints.html)
- [PostgreSQL Best Practices - Indexing](https://wiki.postgresql.org/wiki/Index_Maintenance)
- [Database Design Anti-Patterns (avoid god objects, circular dependencies)](https://www.red-gate.com/simple-talk/databases/sql-server/database-administration-sql-server/ten-common-database-design-mistakes/)

## Build Commands
```bash
# Install PostgreSQL 14 (Ubuntu/Debian)
sudo apt-get update
sudo apt-get install postgresql-14 postgresql-contrib

# Start PostgreSQL service
sudo systemctl start postgresql
sudo systemctl enable postgresql

# Connect to PostgreSQL
psql -U postgres

# Create database
CREATE DATABASE ai_learning_platform;

# Run migrations
cd Database
chmod +x run-migrations.sh
./run-migrations.sh

# Verify tables
psql -U postgres -d ai_learning_platform -c "\dt"

# Verify indexes
psql -U postgres -d ai_learning_platform -c "\di"

# Run seed data
psql -U postgres -d ai_learning_platform -f Scripts/SeedData.sql
```

## Implementation Validation Strategy
- [x] Users table created with EmployeeID, Email, Role, IsActive columns
- [x] UserSessions table created with TokenId, IssuedAt, ExpiresAt columns
- [x] AuthenticationLogs table created with immutability triggers
- [x] Indexes created on EmployeeID, Email, TokenId for fast lookups (<100ms)
- [x] Foreign key constraints enforced (UserSessions -> Users, AuthenticationLogs -> Users)
- [x] Immutability trigger prevents UPDATE/DELETE on AuthenticationLogs
- [x] UpdatedAt trigger automatically updates timestamp on Users table changes
- [x] Seed data inserted successfully for local testing
- [x] Migration rollback scripts tested and functional
- [x] Performance test: Query by EmployeeID completes in <100ms
- [x] Performance test: Insert 10,000 users completes in <10 seconds
- [x] Performance test: Query 100,000 logs by UserId completes in <500ms

## Implementation Checklist
- [ ] Install PostgreSQL 14+ locally or provision Azure Database for PostgreSQL
- [ ] Create `ai_learning_platform` database
- [ ] Create folder structure: Migrations, Rollback, Scripts
- [ ] Write 001_CreateUsersTable.sql with EmployeeID, Email, Role, IsActive
- [ ] Write 002_CreateUserSessionsTable.sql with TokenId, IssuedAt, ExpiresAt
- [ ] Write 003_CreateAuthenticationLogsTable.sql with immutability constraints
- [ ] Write 004_CreateIndexes.sql for EmployeeID, Email, TokenId, UserId, Timestamp
- [ ] Write 005_CreateConstraintsAndTriggers.sql with immutability and UpdatedAt triggers
- [ ] Write rollback scripts for all three tables
- [ ] Write SeedData.sql with 5 test users (Learner, Manager, Admin, Leadership, Inactive)
- [ ] Write CleanupExpiredSessions.sql maintenance script
- [ ] Create run-migrations.sh bash script
- [ ] Execute migrations and verify tables created
- [ ] Test immutability trigger (UPDATE/DELETE should fail on AuthenticationLogs)
- [ ] Test UpdatedAt trigger (modify user record, verify timestamp updates)
- [ ] Run seed data script and verify test users inserted
- [ ] Performance test: Query by EmployeeID (<100ms)
- [ ] Performance test: Insert 10,000 users (<10 seconds)
- [ ] Document schema in Database/README.md with ERD diagram
