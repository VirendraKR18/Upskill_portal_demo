# Epic Specification Document

## Document Control

| Attribute | Value |
|-----------|-------|
| **Project** | AI-Powered Credit-Based Learning Platform |
| **Document Type** | Epic Specification |
| **Version** | 1.1 |
| **Status** | Final |
| **Created** | April 8, 2026 |
| **Last Updated** | April 9, 2026 |
| **Author** | Product Team |
| **Stakeholders** | Engineering, Product, Leadership |

---

## Table of Contents

1. [Epic Overview](#epic-overview)
2. [Epic Summary Table](#epic-summary-table)
3. [EP-TECH: Technical Foundation & Infrastructure](#ep-tech-technical-foundation--infrastructure)
4. [EP-DATA: Data Layer & Persistence](#ep-data-data-layer--persistence)
5. [EP-001: Authentication & User Management](#ep-001-authentication--user-management)
6. [EP-002: Learning System Core](#ep-002-learning-system-core)
7. [EP-003: Credit & Verification System](#ep-003-credit--verification-system)
8. [EP-004: Gamification & Achievements](#ep-004-gamification--achievements)
9. [EP-005: Certification Workflow](#ep-005-certification-workflow)
10. [EP-006: Career Advancement & Workday Sync](#ep-006-career-advancement--workday-sync)
11. [EP-007: Analytics & Role-Based Dashboards](#ep-007-analytics--role-based-dashboards)
12. [EP-008: Admin Operations & Compliance](#ep-008-admin-operations--compliance)
13. [EP-009: User Experience & Accessibility](#ep-009-user-experience--accessibility)
14. [Backlog Refinement Required](#backlog-refinement-required)

---

## Epic Overview

This document defines the complete epic decomposition for the AI-Powered Credit-Based Learning Platform, a greenfield web application designed to systematically upskill organizational resources in AI technologies through a credit-based system with gamification elements.

**Project Type:** Greenfield (New Development)  
**Total Epics:** 11 (9 feature epics + EP-TECH + EP-DATA)  
**Total Requirements Mapped:** 110 requirements (FR: 38, UC: 8, NFR: 15, TR: 15, DR: 10, UXR: 24)  
**Priority Approach:** Business value first, then technical dependencies  
**Development Strategy:** Foundation → Core Features → Advanced Features

**Key Success Metrics:**
- Zero orphaned requirements (100% traceability)
- All epics sized appropriately (5-12 requirements each)
- Clear priority ordering for phased delivery
- Complete dependency mapping

---

## Epic Summary Table

| Epic ID | Epic Title | Mapped Requirement IDs | Priority | Est. Story Points |
|---------|------------|------------------------|----------|-------------------|
| EP-TECH | Technical Foundation & Infrastructure | TR-001, TR-002, TR-003, TR-004, TR-005, TR-006, TR-007, TR-008, TR-009, TR-010, TR-011, TR-012, TR-014, TR-015, NFR-007, NFR-008, NFR-011 | P0 (Critical) | 55 |
| EP-DATA | Data Layer & Persistence | DR-001, DR-002, DR-003, DR-004, DR-005, DR-006, DR-007, DR-008, DR-009, DR-010 | P0 (Critical) | 34 |
| EP-001 | Authentication & User Management | FR-001, FR-002, FR-003, FR-004, NFR-004, NFR-005, NFR-006, UC-007 | P0 (Critical) | 21 |
| EP-002 | Learning System Core | FR-005, FR-006, FR-007, FR-008, NFR-003, UC-001, UC-002 | P0 (Critical) | 34 |
| EP-003 | Credit & Verification System | FR-010, FR-011, FR-012, FR-013, FR-014, NFR-012, UC-002, UC-008 | P0 (Critical) | 34 |
| EP-004 | Gamification & Achievements | FR-015, FR-016, FR-017, FR-018, FR-019, NFR-015 | P1 (High) | 21 |
| EP-005 | Certification Workflow | FR-020, FR-021, FR-022, FR-023, FR-024, NFR-014, UC-004 | P1 (High) | 29 |
| EP-006 | Career Advancement & Workday Sync | FR-025, FR-026, FR-027, FR-028, NFR-009, NFR-013 | P2 (Medium) | 21 |
| EP-007 | Analytics & Role-Based Dashboards | FR-029, FR-030, FR-031, FR-033, FR-034, NFR-001, NFR-002, UC-003, UC-006 | P1 (High) | 34 |
| EP-008 | Admin Operations & Compliance | FR-035, FR-036, FR-037, FR-038, NFR-010, UC-005 | P1 (High) | 21 |
| EP-009 | User Experience & Accessibility | UXR-001, UXR-002, UXR-003, UXR-101, UXR-102, UXR-103, UXR-104, UXR-105, UXR-201, UXR-202, UXR-203, UXR-204, UXR-301, UXR-302, UXR-303, UXR-401, UXR-402, UXR-403, UXR-404, UXR-501, UXR-502, UXR-503, UXR-504 | P0 (Critical) | 34 |

**Notes:**
1. EP-TECH must be completed first to establish the technical foundation (infrastructure, CI/CD, base architecture)
2. EP-DATA follows EP-TECH to set up all database entities and relationships
3. No requirements tagged with [UNCLEAR] in source documents; all requirements mapped
4. FR-009 (AI recommendations) and FR-032 (skill gap analysis) deferred to Phase 2 (not in MVP scope)
5. TR-013 (ML Platform) deferred to Phase 2 with AI features
7. EP-009 (UX/Accessibility) applies to all screens as cross-cutting concerns; implemented alongside UI epics
8. Total estimated story points: 338 (approximately 22-26 sprints at 13 points/sprint)

---

## Epic Descriptions

### EP-TECH: Technical Foundation & Infrastructure

**Business Value**: Establishes the complete technical foundation required for all subsequent development, including project scaffolding, CI/CD pipeline, cloud infrastructure, microservices architecture, containerization, and observability. Without this epic, no feature development can proceed.

**Description**: 
Build the complete technical infrastructure for a greenfield enterprise learning platform. This epic encompasses project initialization, technology stack setup, cloud deployment configuration, containerization, API gateway, caching layer, message queue, CI/CD pipeline with automated testing and security scanning, and comprehensive monitoring/observability.

This is the foundational epic that enables all future development. It includes:
- **Backend API**: ASP.NET Core 8.0 with RESTful API design, OpenAPI documentation, async/await patterns
- **Frontend SPA**: React 18 with TypeScript, modern build tooling (Vite), code splitting
- **Database**: PostgreSQL 14+ setup with connection pooling and migration framework
- **Cloud Infrastructure**: Azure deployment (AKS, Azure Database for PostgreSQL, Azure Cache for Redis, Application Insights)
- **Containerization**: Docker multi-stage builds, security scanning, registry setup
- **Microservices Architecture**: Service boundaries defined, API Gateway configured
- **Caching**: Redis 7.x for performance (leaderboards, dashboard data)
- **Message Queue**: RabbitMQ for event-driven architecture
- **CI/CD Pipeline**: Azure DevOps with automated builds, unit tests (>80% coverage), integration tests, security scans, blue-green deployments
- **Observability**: Application Insights with distributed tracing, custom metrics, log aggregation, alerting
- **File Storage**: Azure Blob Storage configuration

**UI Impact**: No (infrastructure only)

**Screen References**: N/A

**Key Deliverables**:
- Project structure with clean architecture (API, Core, Infrastructure layers)
- Development environment setup documentation
- Docker containers for all services (API, Frontend, ML service placeholder)
- Kubernetes manifests for AKS deployment
- CI/CD pipeline with automated quality gates
- Azure infrastructure provisioned via IaC (Terraform or Bicep)
- API Gateway configured with rate limiting
- Redis cache cluster operational
- RabbitMQ message queue configured
- Application Insights dashboards and alerts
- Initial API documentation (Swagger/OpenAPI)
- Code quality gates enforced (80% test coverage, static analysis)
- Security scanning integrated (SAST/DAST)

**Dependent EPICs**: None (foundation epic)

**Technical Notes**:
- Follow ASP.NET Core clean architecture principles
- Use repository pattern for data access
- Implement CQRS where appropriate for complex queries
- Set up health check endpoints for Kubernetes probes
- Configure auto-scaling policies for AKS
- Implement circuit breaker pattern (Polly library)
- Set up distributed tracing correlation IDs

---

### EP-DATA: Data Layer & Persistence

**Business Value**: Creates the complete data model with all entities, relationships, and constraints required for credit management, learning tracking, user profiles, certifications, gamification, and audit compliance. Enables verifiable, tamper-proof credit operations and comprehensive audit trails.

**Description**:
Implement the full relational database schema with 10 core entities, referential integrity constraints, database triggers for credit validation, materialized views for leaderboard performance, and comprehensive audit logging with 7-year retention.

This epic builds upon EP-TECH foundation and creates:
- **User Entity** (DR-001): User profiles with Workday employee ID as unique identifier
- **Learning Path Entity** (DR-002): Structured learning progressions (Beginner→Intermediate→Advanced)
- **Course Entity** (DR-003): Course metadata, content types, difficulty levels, credit values
- **Credit Transaction Entity** (DR-004): Tamper-proof credit records with SHA-256 hashing
- **Badge/Achievement Entity** (DR-005): Achievement criteria and tracking
- **Certification Entity** (DR-006): External certification records with proof storage
- **Audit Log Entity** (DR-007): Immutable audit trail with 7-year retention
- **Leaderboard Views** (DR-008): Materialized views for sub-2s query performance
- **Referential Integrity** (DR-009): Foreign key constraints for all relationships
- **Backup & Recovery** (DR-010): Point-in-time recovery with 30-day retention

**UI Impact**: No (data layer only)

**Screen References**: N/A

**Key Deliverables**:
- Entity Relationship Diagram (ERD) documented
- Database migration scripts (Entity Framework migrations or SQL scripts)
- All 10 core entities created with proper indexing
- Foreign key constraints ensuring referential integrity
- Database triggers for credit transaction validation
- Materialized views for leaderboards (global, team)
- Seed data scripts for testing (users, courses, learning paths)
- Mock data generator for development environments
- Database backup strategy implemented (daily full + continuous log backups)
- Point-in-time recovery tested and documented
- Performance benchmarks for critical queries (<100ms for user queries, <2s for dashboards)
- Audit log archival strategy (7-year retention compliance)

**Dependent EPICs**: EP-TECH (database infrastructure must exist)

**Technical Notes**:
- Use Entity Framework Core Code-First approach
- Implement audit columns (CreatedAt, CreatedBy, UpdatedAt, UpdatedBy) on all entities
- Credit transactions table must have IMMUTABLE constraint (delete/update prohibited)
- Materialize views refreshed via RabbitMQ events (decoupled from transactions)
- Implement database connection pooling (min 10, max 100 connections)
- Use PostgreSQL JSONB columns for flexible metadata storage where appropriate
- Implement optimistic concurrency control (row versioning)

---

### EP-001: Authentication & User Management

**Business Value**: Enables secure access to the platform through Organization SSO, maintains user profiles synchronized with Workday HR system, and enforces role-based access control for 4 distinct user roles (Learner, Manager, Admin, Leadership).

**Description**:
Implement complete authentication and user management system with SSO integration, Workday employee data synchronization (every 4 hours), role-based access control (RBAC), and user profile management capabilities. This epic enables secure platform access and ensures user data accuracy through bidirectional Workday sync.

**Functional Capabilities**:
- OAuth 2.0/SAML 2.0 SSO authentication with Organization identity provider
- Automated user provisioning from Workday (employee ID, name, email, department, manager, role, employment status)
- RBAC with 4 roles: Learner, Manager, Admin, Leadership (permissions enforced at API level)
- User profile CRUD operations (bio, skills, interests, notification preferences)
- Inactive employee auto-disable based on Workday employment status
- Session management with timeout and token refresh
- Encryption at rest (AES-256) and in transit (TLS 1.2+)

**UI Impact**: Yes

**Screen References**: SCR-001 (Login), SCR-004 (User Profile), SCR-023 (Notification Settings)

**Key Deliverables**:
- SSO integration with Organization OAuth/SAML provider
- Workday API integration for employee data sync (scheduled job every 4 hours)
- User authentication middleware with JWT token validation
- Authorization policies for 4 roles with granular permissions
- User profile API endpoints (GET, PUT)
- Profile update validation (mandatory fields, format checks)
- Change history tracking for profile updates
- Failed authentication attempt logging
- Session timeout configuration (30 minutes idle)
- Login/logout audit logs
- Encryption configuration (at-rest: AES-256, in-transit: TLS 1.2+)

**Dependent EPICs**: EP-TECH (infrastructure, API), EP-DATA (User entity)

**Acceptance Criteria**:
- Users can authenticate via corporate SSO without platform-specific credentials  
- Workday sync runs every 4 hours with data consistency validation  
- Unauthorized access attempts are blocked and logged  
- Profile updates reflect immediately and maintain change history  
- Inactive employees are automatically disabled within 4 hours of Workday status change  

---

### EP-002: Learning System Core

**Business Value**: Provides the core learning functionality including structured learning paths (Beginner→Intermediate→Advanced AI), course enrollment with progress tracking, support for 4 content types (Courses, Labs, Assessments, Projects), and automatic progress persistence every 5 minutes to prevent data loss.

**Description**:
Build the foundational learning management capabilities that allow learners to browse and enroll in structured AI learning paths, track progress through courses with multiple content types, and resume learning sessions from the last accessed position. This epic creates the primary value delivery mechanism of the platform.

**Functional Capabilities**:
- Structured learning paths with 3 difficulty levels (Beginner, Intermediate, Advanced)
- Learning path prerequisites enforcement (must complete Beginner before Intermediate)
- Course enrollment with status tracking (enrolled, in-progress, completed, dropped)
- Concurrent enrollment limit (max 5 courses)
- Support for 4 content types: Courses (video lectures), Labs (hands-on exercises), Assessments (quizzes), Projects (capstone submissions)
- Progress tracking: completion percentage, time spent, last accessed date
- Auto-save every 5 minutes during active sessions
- Resume from last position (bookmark functionality)
- Completion criteria: 100% of mandatory sections required

**UI Impact**: Yes

**Screen References**: SCR-002 (Individual Dashboard), SCR-005 (Learning Path Browser), SCR-018 (Learning Path Detail), SCR-019 (Course Detail), SCR-010 (Course Player), SCR-020 (Assessment), SCR-021 (Project Submission)

**Key Deliverables**:
- Learning path CRUD API (admin creates, learners browse/enroll)
- Course catalog API with filtering (difficulty, duration, content type)
- Enrollment API with validation (prerequisites, concurrent limit)
- Progress tracking service with auto-save (5-minute interval)
- Content player components for each content type (video, lab, assessment, project)
- Video playback with bookmark support (resume from last position)
- Assessment engine with scoring and validation
- Project submission interface with file upload (Azure Blob Storage)
- Progress calculation algorithm (weighted by mandatory vs optional sections)
- Enrollment status state machine (enrolled→in-progress→completed/dropped)

**Dependent EPICs**: EP-TECH (infrastructure), EP-DATA (LearningPath, Course entities), EP-001 (authenticated users)

**Acceptance Criteria**:
- Learners can browse and enroll in learning paths with defined prerequisites  
- Path sequence is enforced (cannot skip difficulty levels without prerequisites)  
- Progress auto-saves every 5 minutes during active sessions  
- Learners can resume from last accessed position  
- Completion requires 100% of mandatory sections  
- Maximum 5 concurrent enrollments enforced  

---

### EP-003: Credit & Verification System

**Business Value**: Implements the core value proposition of the platform—verifiable, tamper-proof credit tracking with comprehensive audit trails. Enables credit-based progression, ensures credit integrity through cryptographic hashing (SHA-256), and provides provable certificates for career advancement and promotions.

**Description**:
Build the credit calculation engine, assignment rules based on difficulty levels, verification system with downloadable certificates, comprehensive audit logging, and tamper detection mechanisms. This epic is critical for platform credibility and organizational trust in the learning metrics.

**Functional Capabilities**:
- Credit calculation engine: course completion (weighted by difficulty), assessment scores (performance-based bonus), project submissions (quality-assessed)
- Credit assignment rules: Beginner (10-20), Intermediate (30-50), Advanced (60-100), Certifications (150-300)
- Bonus credits for high assessment scores (>90% earns +10% bonus)
- Verifiable certificates with completion date, credit amount, validation hash (SHA-256), unique verification code
- Comprehensive audit logging: timestamp, user ID, credit amount, source, validator, transaction hash
- Credit transfer prevention (no buying, selling, or transferring credits)
- Anomaly detection: unusual credit spikes, impossible completion times, pattern violations
- Admin alerts for suspicious activities

**UI Impact**: Yes

**Screen References**: SCR-002 (Individual Dashboard - credits earned), SCR-003 (Global Leaderboard), SCR-014 (Credit Audit - admin), SCR-015 (Anomaly Detection - admin), SCR-030 (Transaction Detail)

**Key Deliverables**:
- Credit calculation service with documented formula
- Credit assignment API with validation rules
- Certificate generation service (PDF with QR code for verification)
- Verification API (third-party can validate certificates via API)
- Audit log immutability enforcement (database trigger prevents delete/update)
- Credit transaction SHA-256 hashing on commit
- Anomaly detection algorithm (statistical analysis of credit patterns)
- Admin alert system for flagged transactions
- Credit transaction export (CSV for compliance audits)
- Audit log retention policy (7 years)

**Dependent EPICs**: EP-TECH (infrastructure, message queue for events), EP-DATA (CreditTransaction, AuditLog entities), EP-002 (course completions trigger credit awards)

**Acceptance Criteria**:
- Credit calculation is reproducible and auditable  
- Certificates are downloadable as PDF with unique verification codes  
- All credit transactions are logged with immutable audit trail  
- Credit transfer attempts are blocked with alerts sent to admins  
- Anomaly detection flags suspicious patterns within 15 minutes  
- Third-party verification API responds within 500ms  

---

### EP-004: Gamification & Achievements

**Business Value**: Drives learner engagement and motivation through gamification elements including badges, achievements, ranking tiers (Bronze→Silver→Gold→Platinum→Diamond), and real-time leaderboards (global and team-based). Increases platform adoption and learning velocity through competitive and recognition mechanisms.

**Description**:
Implement the complete gamification system with automatic badge assignment, achievement tracking, ranking tier progression, global leaderboard, and team leaderboards. This epic transforms learning into an engaging, competitive experience that encourages continuous skill development.

**Functional Capabilities**:
- Badge system: automatic assignment when predefined criteria met (skill milestones, credit thresholds, time-based)
- Achievement types: skill-based ("ML Beginner", "NLP Expert") and milestone-based ("100 Credits", "10 Courses Completed")
- Achievement progress visibility with notifications on unlock
- Global leaderboard: top 100 learners ranked by total credits, real-time updates (<5 minutes)
- Team leaderboards: department/team rankings based on average credits per member (minimum 3 members)
- Ranking tiers: Bronze (0-100), Silver (101-300), Gold (301-600), Platinum (601-1000), Diamond (1001+)
- Tier-up notifications and tier benefits display
- Leaderboard filtering (week, month, all-time)
- User position visibility (even if not in top 100)

**UI Impact**: Yes

**Screen References**: SCR-002 (Individual Dashboard - badges), SCR-003 (Global Leaderboard), SCR-004 (User Profile - badge showcase), SCR-022 (Team Leaderboard)

**Key Deliverables**:
- Badge definition engine (criteria specification DSL or JSON schema)
- Badge assignment service (event-driven via RabbitMQ)
- Achievement tracking service with progress calculation
- Badge notification system (real-time via SignalR or WebSocket)
- Leaderboard calculation service using Redis sorted sets
- Global leaderboard API with pagination (top 100 + user position)
- Team leaderboard aggregation (average credits per team)
- Leaderboard materialized view refresh (triggered by credit events)
- Ranking tier calculation and tier-up notifications
- Badge image storage (Azure Blob Storage)
- Retroactive badge assignment for existing progress

**Dependent EPICs**: EP-TECH (Redis cache, message queue), EP-DATA (Badge, LeaderboardView entities), EP-003 (credit transactions trigger leaderboard updates)

**Acceptance Criteria**:
- Badges are assigned within 1 minute of criteria being met  
- Leaderboard updates within 5 minutes of credit award  
- Top 100 users displayed on global leaderboard with real-time ranks  
- Users can see their own rank even if not in top 100  
- Team leaderboards show average credits per team member  
- Tier progression notifications sent immediately on tier-up  

---

### EP-005: Certification Workflow

**Business Value**: Enables learners to apply for external certifications from approved training providers (Coursera, Udacity, Pluralsight), routes applications through manager approval workflow, validates certification completion with proof verification, and allocates predefined credits (150-300) upon successful validation. Supports career advancement through recognized industry certifications.

**Description**:
Build the multi-stage certification workflow including application submission, manager approval process, certification validation with proof verification (PDF upload + optional provider API verification), and credit allocation upon successful validation. This epic connects internal learning with external certification providers and organizational approval processes.

**Functional Capabilities**:
- Certification application form (course name, provider, cost, business justification)
- Draft application save/resume capability
- Manager approval workflow (approve, reject, request-more-info)
- Manager notifications within 1 hour of submission
- Approval SLA tracking (5 business days)
- Rejection reason requirement
- Certification proof upload (PDF/image, multiple formats supported)
- Provider API integration for automatic verification (Coursera, Udacity, Pluralsight)
- Admin manual verification fallback
- Verification status tracking (pending, verified, rejected)
- Credit allocation (150-300 based on certification level) within 24 hours of validation
- Certification records with proof storage (Azure Blob Storage)
- Certification catalog sync from provider APIs (weekly)

**UI Impact**: Yes

**Screen References**: SCR-006 (Certification Application), SCR-012 (Certification Approval Queue - manager), SCR-024 (Certification Status), SCR-025 (Certification Review - manager), SCR-036 (Certification Records - admin)

**Key Deliverables**:
- Certification application API (POST, GET, PUT for drafts)
- Manager approval workflow engine (state machine: pending→approved/rejected/info-requested)
- Manager notification service (email + in-app)
- SLA tracking and escalation (>5 days → alert manager's manager)
- Provider API integration service (Coursera, Udacity, Pluralsight)
- Weekly catalog sync scheduled job
- Certification proof upload service (Azure Blob Storage)
- Verification service (API-based or manual admin verification)
- Credit allocation service (triggered on verification approval)
- Certification record CRUD API with search/filter
- Certificate PDF storage and retrieval
- Webhook integration for provider completion events (if supported)

**Dependent EPICs**: EP-TECH (Azure Blob Storage, message queue), EP-DATA (Certification entity), EP-001 (authenticated users, manager role), EP-003 (credit allocation)

**Acceptance Criteria**:
- Learners can submit certification applications with required fields validated  
- Manager receives notification within 1 hour of submission  
- Approval decisions are logged with timestamps and reasons  
- Verification accepts PDF/image proof with multiple formats  
- API integration validates completions automatically for supported providers  
- Credits are allocated within 24 hours of successful verification  
- SLA breaches (>5 days) trigger escalation alerts  

---

### EP-006: Career Advancement & Workday Sync

**Business Value**: Maps learner credits to skill levels (Basic, Intermediate, Advanced, Expert), recommends role transitions and promotion opportunities based on skill profiles and career goals, and syncs career advancement data bidirectionally with Workday HR system. Connects learning achievements to career progression and organizational talent management.

**Description**: Implement the career advancement recommendation system and Workday bidirectional synchronization for career data (promotions, role changes, skill certifications). This epic creates the bridge between learning achievements and career outcomes in the HR system of record.

**Functional Capabilities**:
- Skill level mapping: Basic (0-200 credits), Intermediate (201-500), Advanced (501-1000), Expert (1001+)
- Role transition recommendations based on accumulated skills
- Promotion eligibility analysis (compare current skills vs role requirements)
- Career goal tracking (user sets goals, system recommends paths)
- Monthly recommendation generation
- Manager review workflow for promotion submissions
- Workday sync (every 4 hours): employee data IN, career advancement OUT
- Bidirectional sync: promotions, role changes, skill certifications
- Sync latency <5 minutes for critical updates (via webhook)
- Data consistency validation and conflict resolution

**UI Impact**: Yes

**Screen References**: SCR-002 (Individual Dashboard - career recommendations), SCR-004 (User Profile - career goals), SCR-007 (Manager Dashboard - team member skills)

**Key Deliverables**:
- Skill level calculation service
- Role mapping engine (skills → eligible roles)
- Career advancement recommendation algorithm
- Promotion eligibility scoring (rules-based + ML-enhanced in Phase 2)
- Workday outbound API integration (POST career advancement events)
- Workday inbound API integration (enhanced from EP-001 to include career data)
- Sync orchestration service (scheduled + webhook-triggered)
- Conflict resolution rules (Workday wins for HR data, platform wins for skills)
- Sync monitoring dashboard (success/failure rates, data quality metrics)
- Career goal CRUD API

**Dependent EPICs**: EP-DATA (User entity with career fields), EP-001 (Workday integration foundation), EP-003 (credit accumulation triggers eligibility changes)

**Acceptance Criteria**:
- Skill levels are accurately calculated based on credit thresholds  
- Role recommendations surface when learner reaches eligibility criteria  
- Promotion eligibility analysis is transparent (criteria documented)  
- Workday sync runs every 4 hours without platform performance impact  
- Critical updates (promotions) sync within 5 minutes via webhooks  
- Sync failures are logged and retried with exponential backoff  

---

### EP-007: Analytics & Role-Based Dashboards

**Business Value**: Provides real-time visibility into learning progress, team performance, and organizational AI readiness through role-specific dashboards (Individual, Manager, Leadership). Enables data-driven decision making with sub-2-second dashboard response times and comprehensive analytics including learning velocity trends, skill gap identification, and adoption metrics.

**Description**:
Build three distinct, role-optimized dashboards with rich analytics, caching for performance (sub-2s load times), and real-time or near-real-time data updates. This epic transforms raw learning data into actionable insights for learners, managers, and executives.

**Functional Capabilities**:
- **Individual Learner Dashboard**: total credits, current rank, badges, courses in progress, upcoming certifications, personalized recommendations, learning velocity trends
- **Manager Dashboard**: team roster, individual team member progress, team average credits, team ranking, skill gap heatmap, at-risk learner identification (no activity in 14 days), engagement metrics
- **Leadership Dashboard**: organizational AI readiness score, adoption metrics (enrollment rate, active users, avg credits/user, completion rates), department comparison, trending skills, ROI analysis, certification completion rates
- Dashboard data caching (Redis) for sub-2s response times
- Real-time updates via SignalR or polling (leaderboard, progress)
- Export capabilities (CSV, PDF)
- Customizable widgets (drag-and-drop for manager/leadership)
- Date range filtering (week, month, quarter, year)

**UI Impact**: Yes

**Screen References**: SCR-002 (Individual Dashboard), SCR-007 (Manager Dashboard), SCR-009 (Leadership Dashboard), SCR-011 (Team Member Detail), SCR-016 (Executive Reports), SCR-026 (Skill Gap Analysis), SCR-032 (Report Export)

**Key Deliverables**:
- Individual dashboard API with caching (Redis)
- Manager dashboard API with team aggregations
- Leadership dashboard API with org-level metrics
- Skill gap analysis algorithm (team skills vs target profiles)
- At-risk learner detection service (14-day inactivity threshold)
- Learning velocity calculation (credits/week trend analysis)
- AI readiness score algorithm (proprietary formula based on credits, certifications, course diversity)
- Team performance heatmap (members × skill categories)
- Dashboard widget framework (customizable layouts)
- Real-time update service (SignalR hubs)
- Report generation service (PDF/CSV exports)
- Dashboard materialized views (refresh triggered by data changes)

**Dependent EPICs**: EP-TECH (Redis cache, Application Insights), EP-DATA (LeaderboardView, analytics aggregations), EP-001 (authenticated users), EP-002 (course progress), EP-003 (credit data), EP-004 (leaderboard data)

**Acceptance Criteria**:
- Dashboards load within 2 seconds at 95th percentile  
- Individual dashboard shows total credits, rank, badges, courses in progress  
- Manager dashboard displays team roster with individual progress  
- Leadership dashboard shows organizational AI readiness score  
- At-risk learners are flagged when no activity for 14 days  
- Skill gap heatmap visualizes team strengths and weaknesses  
- Reports can be exported to PDF and CSV  

---

### EP-008: Admin Operations & Compliance

**Business Value**: Empowers administrators to manage platform content (learning paths, courses), audit credit transactions for compliance, monitor user activity, detect and respond to tamper attempts, and maintain certification records. Ensures platform integrity, regulatory compliance (7-year audit retention), and operational excellence.

**Description**:
Build the complete administrative suite including content management (CRUD operations for learning paths and courses), comprehensive audit reporting, user activity monitoring, anomaly detection with admin alerts, and certification record management. This epic provides the operational and compliance capabilities required for enterprise platform management.

**Functional Capabilities**:
- **Content Management**: Admin CRUD operations for learning paths, courses, course materials
- Course material upload (videos, PDFs, labs) to Azure Blob Storage
- Learning path sequencing (drag-and-drop course ordering)
- Draft/Published workflow (content not visible until published)
- Content versioning (track changes to courses)
- **Credit Audit Reports**: All credit transactions with verification records, anomaly detections, compliance status
- Date range filtering, user filtering, export to CSV/Excel
- Transaction detail drill-down (hash verification, before/after state)
- **User Activity Monitoring**: Login/logout tracking, course access logs, assessment attempts, credit transactions, admin actions
- Activity timeline visualization per user
- **Tamper Detection**: Anomaly detection alerts (unusual credit spikes, impossible completion times, pattern violations)
- Admin investigation interface with evidence timeline
- Credit adjustment workflow (revoke credits, suspend user, apply penalties)
- **Certification Records**: Admin view of all certifications with validation status, proof documents, credit allocations
- Manual verification workflow (approve/reject certification proof)

**UI Impact**: Yes

**Screen References**: SCR-008 (Admin Console), SCR-013 (Content Management), SCR-027 (Create/Edit Learning Path), SCR-028 (Create/Edit Course), SCR-029 (Course Materials Upload), SCR-014 (Credit Audit), SCR-030 (Transaction Detail), SCR-015 (Anomaly Detection), SCR-031 (Anomaly Investigation), SCR-035 (Admin Reports)

**Key Deliverables**:
- Content Management API (learning path/course CRUD with admin authorization)
- Course material upload service (Azure Blob Storage with CDN)
- Draft/publish workflow (status field + visibility rules)
- Content versioning service (track changes, rollback capability)
- Credit audit report generation service
- Transaction detail API with hash verification
- User activity logging service (comprehensive event tracking)
- Anomaly detection algorithm (statistical + rule-based)
- Admin alert service (email + in-app notifications)
- Anomaly investigation UI with evidence presentation
- Credit adjustment API (revoke credits with reason, audit logged)
- User suspension workflow (temporary or permanent)
- Certification manual verification UI (approve/reject with comments)

**Dependent EPICs**: EP-TECH (Azure Blob Storage, message queue), EP-DATA (AuditLog, all entities), EP-001 (admin role), EP-002 (content entities), EP-003 (credit transactions), EP-005 (certification management)

**Acceptance Criteria**:
- Admins can create, edit, and publish learning paths and courses  
- Course materials can be uploaded (videos, PDFs, labs) with progress tracking  
- Credit audit reports show all transactions with verification records  
- Audit logs are immutable and retained for 7 years  
- User activity is logged for all critical operations (login, credit award, course completion)  
- Anomaly detection flags suspicious patterns and alerts admins  
- Admins can investigate flagged transactions with full evidence timeline  
- Credit adjustments are logged with reason and executor  

---

### EP-009: User Experience & Accessibility

**Business Value**: Ensures the platform delivers a consistent, accessible, and high-quality user experience across all devices and for all users, including those with disabilities. Compliance with WCAG 2.2 AA standards is mandatory for organizational accessibility requirements and legal compliance. Enhances user adoption, reduces support costs, and ensures all employees can participate in AI upskilling regardless of ability or device.

**Description**:
Implement comprehensive cross-cutting UX requirements that apply to all screens throughout the platform. This epic establishes the user experience foundation including usability standards (max 3 clicks to any feature, clear visual hierarchy, inline help), full WCAG 2.2 AA accessibility compliance (keyboard navigation, screen reader support, contrast ratios, focus indicators), responsive design for all viewport sizes (mobile 320px+, tablet 768px+, desktop 1024px+), consistent visual design using design tokens from designsystem.md, interaction patterns (loading feedback, transitions, progress indicators), and comprehensive error handling with recovery paths.

**Functional Capabilities**:
- **Usability Standards** (UXR-001 to UXR-003):
  - Maximum 3 clicks to reach any primary feature from entry point
  - Clear visual hierarchy with semantic HTML headings (H1-H6) and proper content grouping
  - Contextual help via tooltips, help icons, and inline guidance for complex features (>80% coverage)

- **Accessibility Compliance** (UXR-101 to UXR-105):
  - WCAG 2.2 AA compliance with zero critical accessibility errors
  - Full keyboard navigation with logical tab order and skip links
  - ARIA labels, roles, and live regions for screen reader compatibility (NVDA, JAWS, VoiceOver)
  - Minimum contrast ratio 4.5:1 for normal text, 3:1 for large text (18pt+)
  - Visible focus indicators with minimum 2px outline on all focusable elements

- **Responsiveness** (UXR-201 to UXR-204):
  - Mobile viewport (320px-767px): stacked navigation, touch-optimized controls, no horizontal scrolling
  - Tablet viewport (768px-1023px): hybrid navigation suitable for touch and pointer
  - Desktop viewport (1024px+): full sidebar navigation, multi-column layouts, optimized information density
  - Touch-friendly tap targets: minimum 44x44px hit area with 8px spacing between targets

- **Visual Design Consistency** (UXR-301 to UXR-303):
  - Consistent design tokens (colors, typography, spacing, radius, shadows) from designsystem.md across all screens (>95% coverage)
  - Brand identity maintenance: organizational logo, color palette, typography hierarchy
  - Immediate visual feedback for all user actions (button states, form submissions, navigation)

- **Interaction Patterns** (UXR-401 to UXR-404):
  - Loading feedback within 200ms of user action (skeleton screens or spinners)
  - Success confirmations for all state-changing actions via toasts or modals (3-5 second duration)
  - Smooth transitions and animations with maximum 300ms duration (respects prefers-reduced-motion)
  - Progress indicators for operations exceeding 2 seconds (leaderboard updates, report generation)

- **Error Handling** (UXR-501 to UXR-504):
  - Inline validation with specific, actionable error messages for all form inputs
  - Clear recovery paths for all error states with retry buttons or alternative actions
  - Non-blocking error messages (toasts/banners) for non-critical errors; modals only for critical errors
  - 5 required states for every screen (Default, Loading, Empty, Error, Validation)

**UI Impact**: Yes (applies to ALL screens)

**Screen References**: All screens (SCR-001 through SCR-036) - cross-cutting requirements

**Key Deliverables**:
- WCAG 2.2 AA compliance audit report (automated via axe-core, manual via NVDA/JAWS testing)
- Responsive design implementation (mobile-first approach, breakpoints at 768px and 1024px)
- Design system integration (design tokens consumed from designsystem.md, no hard-coded values)
- Keyboard navigation testing suite (automated via Playwright)
- Screen reader compatibility testing across 3 tools (NVDA, JAWS, VoiceOver)
- Color contrast validation (all text meets 4.5:1 ratio, automated checks in Storybook)
- Touch target size validation (all interactive elements ≥44x44px)
- Focus indicator visibility testing (2px outline on all focusable elements)
- Loading state implementation (skeleton screens for async data, spinners for actions)
- Error state implementation for all forms with inline validation
- Toast notification system (success/error/info with 3-5s duration, dismissible)
- Help tooltip component (reusable across all complex features)
- Animation framework (300ms max, respects prefers-reduced-motion CSS media query)
- State documentation for all screens (Default, Loading, Empty, Error, Validation states designed)

**Dependent EPICs**: EP-TECH (React 18 frontend framework), EP-DATA (no direct dependency, but screens display data), All UI Epics (EP-001, EP-002, EP-005, EP-007, EP-008)

**Acceptance Criteria**:
- All screens achieve WCAG 2.2 AA compliance with zero automated errors (axe-core, WAVE)  
- Keyboard-only testing passes: tab order logical, all features accessible, skip links functional  
- Screen reader testing passes on 3 tools: NVDA (Windows), JAWS (Windows), VoiceOver (macOS/iOS)  
- Color contrast audit passes: minimum 4.5:1 for normal text, 3:1 for large text (18pt+)  
- Responsive design verified on 3 viewport sizes: mobile (375px), tablet (768px), desktop (1440px)  
- Touch target audit passes: all interactive elements ≥44x44px with 8px spacing  
- Design token coverage >95%: no hard-coded colors/spacing/typography  
- Loading feedback appears within 200ms of user action  
- Success/error confirmations display for all state-changing actions  
- All forms have inline validation with specific error messages  
- All screens implement 5 required states (Default, Loading, Empty, Error, Validation)  
- Animations respect prefers-reduced-motion preference  
- Maximum 3 clicks to reach any primary feature (navigation audit passes)  

**Implementation Notes**:
- Use React Aria or Radix UI for accessible component primitives (headless components with ARIA support)
- Integrate axe-core into Playwright E2E tests for automated accessibility testing
- Use Storybook with a11y addon for component-level accessibility validation
- Implement design token consumption via CSS custom properties or styled-components theme
- Create reusable accessibility hooks: useKeyboardNavigation, useFocusTrap, useAnnouncer (for screen readers)
- Document all keyboard shortcuts in Help documentation
- Provide accessibility statement page with VPAT (Voluntary Product Accessibility Template) if required

---

## Backlog Refinement Required

**No requirements tagged with [UNCLEAR] in source documents.** All 110 requirements (FR: 38, UC: 8, NFR: 15, TR: 15, DR: 10, UXR: 24) have been successfully mapped to epics.

**Deferred to Phase 2 (Out of MVP Scope):**
- **FR-009**: Personalized Content Recommendations (AI-CANDIDATE)  
  - *Reason*: AI features require ML infrastructure (TR-013) and historical data for training. Deferred to Phase 2 after MVP launch establishes baseline data.
  
- **FR-032**: Skill Gap Analysis with AI (AI-CANDIDATE)  
  - *Reason*: Advanced ML-based skill gap analysis deferred to Phase 2. Basic skill gap visualization included in EP-007.
  
- **TR-013**: ML Platform (Python ML service with FastAPI)  
  - *Reason*: ML infrastructure not required for MVP. Deferred to Phase 2 with AI features (FR-009, FR-032).

**Clarifications Needed:** None at this time. All requirements are clearly specified in source documents.

---

## Epic Dependency Graph

```
EP-TECH (Foundation)
  ↓
EP-DATA (Data Layer)
  ↓
EP-001 (Auth) ←──────┐
  ↓                   │
EP-002 (Learning) ←───┤
  ↓                   │
EP-003 (Credits) ←────┤
  ↓                   │
EP-004 (Gamification)←┤
EP-005 (Certification)←┤
EP-006 (Career) ←─────┤
EP-007 (Dashboards) ←─┤
EP-008 (Admin) ←──────┤
EP-009 (UX/Access.) ←─┘ (parallel to all UI epics)
```

**Suggested Implementation Order:**
1. **Sprint 1-3**: EP-TECH (Foundation setup)
2. **Sprint 4-5**: EP-DATA (Database schema and entities)
3. **Sprint 6**: EP-009 Phase 1 (Design system setup, accessibility framework, base components)
4. **Sprint 7-8**: EP-001 (Authentication & User Management)
5. **Sprint 9-11**: EP-002 (Learning System Core) + EP-009 Phase 2 (screen-specific UX)
6. **Sprint 12-14**: EP-003 (Credit & Verification System) + EP-009 Phase 3 (UX refinement)
7. **Sprint 15-16**: EP-004 (Gamification & Achievements)
8. **Sprint 17-18**: EP-005 (Certification Workflow)
9. **Sprint 19-21**: EP-007 (Analytics & Dashboards) + EP-009 Phase 4 (dashboard UX)
10. **Sprint 22-23**: EP-008 (Admin Operations & Compliance) + EP-009 Phase 5 (admin UX)
11. **Sprint 24-25**: EP-006 (Career Advancement & Workday Sync)
12. **Sprint 26**: EP-009 Final (Cross-browser testing, accessibility audit, UX polish)

---

## Notes on Requirements Traceability

**Coverage Statistics:**
- **Functional Requirements (FR)**: 36/38 mapped to MVP epics (95% coverage)
  - FR-009, FR-032 deferred to Phase 2
- **Use Cases (UC)**: 8/8 mapped to epics (100% coverage)
- **Non-Functional Requirements (NFR)**: 15/15 mapped to epics (100% coverage)
- **Technical Requirements (TR)**: 14/15 mapped to MVP epics (93% coverage)
  - TR-013 deferred to Phase 2
- **Data Requirements (DR)**: 10/10 mapped to epics (100% coverage)
- **UX Requirements (UXR)**: 24/24 mapped to EP-009 (100% coverage)

**Total MVP Coverage**: 107/110 requirements (97.3%)

**Orphaned Requirements**: None

**Duplicate Mappings**: 
- FR-002 appears in both EP-001 (Workday employee sync) and EP-006 (Workday career sync) – This is intentional as EP-001 establishes the integration foundation and EP-006 extends it for career data.

---

**Document Version History:**

| Version | Date | Author | Changes |
|---------|------|--------|---------|
| 1.0 | April 8, 2026 | Product Team | Initial epic specification for MVP |
| 1.1 | April 9, 2026 | Product Team | Added EP-009 (UX/Accessibility), mapped all UXR-001 to UXR-504 requirements, updated coverage statistics to 97.3% |

---

**End of Epic Specification Document**
