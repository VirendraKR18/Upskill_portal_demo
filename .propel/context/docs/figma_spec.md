# Figma Design Specification - AI-Powered Credit-Based Learning Platform

## 1. Figma Specification
**Platform**: Responsive Web (Desktop, Tablet, Mobile)
**Framework**: React 18 with TypeScript
**Target Browsers**: Modern browsers (Chrome, Firefox, Safari, Edge - latest 2 versions)

---

## 2. Source References

### Primary Source
| Document | Path | Purpose |
|----------|------|---------|
| Requirements Specification | [spec.md](.propel/context/docs/spec.md) | Personas, use cases (UC-001 to UC-008), functional requirements (FR-001 to FR-038) |
| Architecture Design | [design.md](.propel/context/docs/design.md) | Technical context, NFR, TR, DR requirements |

### Optional Sources
| Document | Path | Purpose |
|----------|------|---------|
| Wireframes | `.propel/context/wireframes/` | Not available - screens derived from use cases |
| Design Assets | `.propel/context/Design/` | Not available - design system to be created |

### Related Documents
| Document | Path | Purpose |
|----------|------|---------|
| Design System | [designsystem.md](.propel/context/docs/designsystem.md) | Tokens, branding, component specifications |
| UML Models | [models.md](.propel/context/docs/models.md) | Sequence diagrams showing UI interactions |

---

## 3. UX Requirements (UXR-XXX)

*Generated based on use cases with UI impact. These requirements apply to screen implementations and are derived from UC-001 through UC-008.*

### UXR Requirements Summary

Before detailing each UXR, here's the complete list of UX requirements to be generated:

| UXR-ID | Category | Summary | Rationale |
|--------|----------|---------|-----------|
| UXR-001 | Usability | Max 3 clicks to any feature | Discoverability requirement from NFR-001 (dashboard <2s) |
| UXR-002 | Usability | Clear visual hierarchy | Derived from FR-029, FR-030, FR-033 (dashboard requirements) |
| UXR-003 | Usability | Inline help and tooltips | Reduces learning curve for AI learning platform |
| UXR-101 | Accessibility | WCAG 2.2 AA compliance | Legal baseline for organizational platform |
| UXR-102 | Accessibility | Keyboard navigation support | Essential for all interactive elements (FR-001 to FR-038) |
| UXR-103 | Accessibility | Screen reader compatibility | ARIA labels for assistive technology users |
| UXR-104 | Accessibility | Minimum contrast ratio 4.5:1 | WCAG 2.2 AA visual accessibility requirement |
| UXR-105 | Accessibility | Focus indicators visible | Keyboard navigation visibility standard |
| UXR-201 | Responsiveness | Mobile viewport support (320px+) | Platform must work on mobile devices per spec.md |
| UXR-202 | Responsiveness | Tablet viewport support (768px+) | Responsive design requirement from FR-029 (mobile-responsive) |
| UXR-203 | Responsiveness | Desktop viewport support (1024px+) | Primary platform target |
| UXR-204 | Responsiveness | Touch-friendly targets (44x44px min) | Mobile usability standard |
| UXR-301 | Visual Design | Consistent design system | Design token adherence from designsystem.md |
| UXR-302 | Visual Design | Brand consistency | Organizational branding alignment |
| UXR-303 | Visual Design | Visual feedback for all actions | User confidence and transparency |
| UXR-401 | Interaction | Loading feedback within 200ms | Perceived performance from NFR-001 |
| UXR-402 | Interaction | Success confirmations | Completion feedback for user actions |
| UXR-403 | Interaction | Smooth transitions (300ms max) | Professional polish without lag |
| UXR-404 | Interaction | Progress indication for long operations | Transparency for operations >2s |
| UXR-501 | Error Handling | Inline validation with clear messages | Prevent user errors from FR-020 (form validation) |
| UXR-502 | Error Handling | Recovery paths for all errors | User empowerment per UC-XXX alternative flows |
| UXR-503 | Error Handling | Non-blocking error messages | User can continue working when possible |
| UXR-504 | Error Handling | Error state documentation | All screens require error state per spec |

### UXR Detailed Specifications

#### Usability Requirements (UXR-001 to UXR-003)

| UXR-ID | Category | Requirement | Acceptance Criteria | Screens Affected | Derived From |
|--------|----------|-------------|---------------------|------------------|--------------|
| UXR-001 | Usability | System MUST provide navigation to any primary feature in maximum 3 clicks from entry point | Click depth audit passes; user testing confirms <3 clicks; navigation paths documented | All screens | NFR-001 (dashboard <2s), FR-029/030/033 (dashboard requirements) |
| UXR-002 | Usability | System MUST implement clear visual hierarchy with distinct heading levels (H1-H6) and content grouping | Visual hierarchy audit passes; heading structure follows semantic HTML; user testing confirms content scannability | All screens | FR-029 (customizable widgets), design best practices |
| UXR-003 | Usability | System MUST provide contextual help via tooltips, help icons, and inline guidance for non-obvious features | Help coverage >80% of complex features; user testing confirms reduced support requests | SCR-002 (Dashboard), SCR-005 (Learning Path Browser), SCR-010 (Admin Console) | UC-001 (learner guidance), UC-005 (admin complexity) |

#### Accessibility Requirements (UXR-101 to UXR-105)

| UXR-ID | Category | Requirement | Acceptance Criteria | Screens Affected | Derived From |
|--------|----------|-------------|---------------------|------------------|--------------|
| UXR-101 | Accessibility | System MUST comply with WCAG 2.2 AA standards for all UI elements | WAVE/axe accessibility audit passes with 0 critical errors; automated testing in CI/CD | All screens | Legal requirement, organizational compliance |
| UXR-102 | Accessibility | System MUST support full keyboard navigation with logical tab order and skip links | Keyboard-only testing passes; tab order follows visual flow; skip to main content available | All screens | WCAG 2.2 AA requirement 2.1.1 (Keyboard) |
| UXR-103 | Accessibility | System MUST provide ARIA labels, roles, and live regions for screen reader compatibility | Screen reader testing (NVDA, JAWS, VoiceOver) passes; dynamic content announced; form labels present | All screens | WCAG 2.2 AA requirement 4.1.2 (Name, Role, Value) |
| UXR-104 | Accessibility | System MUST maintain minimum contrast ratio of 4.5:1 for normal text and 3:1 for large text (18pt+) | Color contrast audit passes; automated checks in design system; brand colors validated | All screens | WCAG 2.2 AA requirement 1.4.3 (Contrast Minimum) |
| UXR-105 | Accessibility | System MUST display visible focus indicators with minimum 2px outline on all focusable elements | Focus indicator audit passes; keyboard navigation visibility confirmed; custom focus styles implemented | All screens | WCAG 2.2 AA requirement 2.4.7 (Focus Visible) |

#### Responsiveness Requirements (UXR-201 to UXR-204)

| UXR-ID | Category | Requirement | Acceptance Criteria | Screens Affected | Derived From |
|--------|----------|-------------|---------------------|------------------|--------------|
| UXR-201 | Responsiveness | System MUST adapt layout for mobile viewports (320px - 767px) with stacked navigation and touch-optimized controls | Mobile viewport testing passes; all features accessible; no horizontal scrolling; touch targets ≥44px | All screens | FR-029 (mobile-responsive dashboards) |
| UXR-202 | Responsiveness | System MUST adapt layout for tablet viewports (768px - 1023px) with optimized sidebar and hybrid navigation | Tablet viewport testing passes; navigation patterns suitable for touch and pointer; content readable without zoom | All screens | Responsive design best practices |
| UXR-203 | Responsiveness | System MUST optimize layout for desktop viewports (1024px+) with full sidebar navigation and multi-column layouts | Desktop viewport testing passes; information density appropriate; whitespace balanced; no wasted screen space | All screens | Primary platform target from design.md (React 18 SPA) |
| UXR-204 | Responsiveness | System MUST provide touch-friendly tap targets with minimum 44x44px hit area and 8px spacing between targets | Touch target audit passes; mobile usability testing confirms easy tapping; accidental taps minimized | All screens (mobile/tablet) | iOS HIG and Material Design touch target guidelines |

#### Visual Design Requirements (UXR-301 to UXR-303)

| UXR-ID | Category | Requirement | Acceptance Criteria | Screens Affected | Derived From |
|--------|----------|-------------|---------------------|------------------|--------------|
| UXR-301 | Visual Design | System MUST apply consistent design tokens (colors, typography, spacing, radius, shadows) from designsystem.md across all screens | Design token audit passes; no hard-coded values; design system coverage >95%; visual regression testing passes | All screens | Design system requirement from designsystem.md |
| UXR-302 | Visual Design | System MUST maintain consistent brand identity with organizational logo, color palette, and typography | Brand guideline compliance audit passes; brand colors used correctly; logo placement consistent; typography hierarchy correct | All screens | Organizational branding requirement |
| UXR-303 | Visual Design | System MUST provide immediate visual feedback for all user actions (button presses, form submissions, navigation) | Interaction feedback audit passes; all buttons show hover/active states; loading spinners present; success/error states visible | All screens | UX best practices, user confidence requirement |

#### Interaction Requirements (UXR-401 to UXR-404)

| UXR-ID | Category | Requirement | Acceptance Criteria | Screens Affected | Derived From |
|--------|----------|-------------|---------------------|------------------|--------------|
| UXR-401 | Interaction | System MUST provide loading feedback within 200ms of user action to maintain perceived performance | Performance testing confirms <200ms feedback; skeleton screens or spinners appear promptly; no perceived lag | All screens with async operations | NFR-001 (dashboard <2s), perceived performance research |
| UXR-402 | Interaction | System MUST display success confirmations for all state-changing actions (save, delete, submit) via toasts or modals | Success feedback audit passes; all CRUD operations show confirmation; toast messages dismissible; duration 3-5 seconds | All screens with forms/actions | UX best practices, user confidence |
| UXR-403 | Interaction | System MUST implement smooth transitions and animations with maximum 300ms duration to avoid perceived lag | Animation performance audit passes; transitions feel snappy; no jank (60 FPS); reduced motion preference respected | All screens | Web animation best practices, accessibility (prefers-reduced-motion) |
| UXR-404 | Interaction | System MUST show progress indicators for operations exceeding 2 seconds (leaderboard updates, report generation, sync) | Progress indication audit passes; long operations show % complete or spinner; user can cancel if applicable | SCR-003 (Leaderboard), SCR-007 (Manager Dashboard), SCR-009 (Leadership Dashboard) | NFR-015 (leaderboard <5 min), UX best practices |

#### Error Handling Requirements (UXR-501 to UXR-504)

| UXR-ID | Category | Requirement | Acceptance Criteria | Screens Affected | Derived From |
|--------|----------|-------------|---------------------|------------------|--------------|
| UXR-501 | Error Handling | System MUST provide inline validation with specific, actionable error messages for all form inputs | Form validation audit passes; error messages appear below fields; red borders on invalid fields; no generic "error" messages | SCR-001 (Login), SCR-004 (Profile), SCR-006 (Certification Application), SCR-010 (Admin - Course Creation) | FR-020 (form validation), UC-001/UC-004 form requirements |
| UXR-502 | Error Handling | System MUST provide clear recovery paths for all error states with retry buttons or alternative actions | Error recovery testing passes; no dead ends; users can retry or navigate away; error messages explain next steps | All screens | UC-XXX alternative flows, UX best practices |
| UXR-503 | Error Handling | System MUST display non-blocking error messages (toasts/banners) for non-critical errors to allow continued work | Non-blocking error audit passes; critical errors use modals (block); non-critical errors use toasts (dismissible); user workflow not interrupted unnecessarily | All screens | UX best practices, user productivity |
| UXR-504 | Error Handling | System MUST document and implement 5 required states (Default, Loading, Empty, Error, Validation) for every screen | Screen state coverage audit passes; all 5 states designed and implemented; state transitions tested; edge cases covered | All screens | Figma spec requirement, comprehensive UX |

### UXR Derivation Logic Documentation

**Usability UXR (001-003):**
- **UXR-001** derived from NFR-001 (dashboard performance <2s) → implies efficient navigation preventing deep menu diving
- **UXR-002** derived from FR-029/030/033 (dashboard complexity) → requires clear visual hierarchy to scan data quickly
- **UXR-003** derived from UC-001 (learner onboarding) + UC-005 (admin complexity) → tooltips reduce learning curve

**Accessibility UXR (101-105):**
- **UXR-101 to 105** derived from WCAG 2.2 AA legal baseline + organizational compliance requirements
- Applied to ALL screens as universal accessibility mandate

**Responsiveness UXR (201-204):**
- **UXR-201 to 203** derived from FR-029 "mobile-responsive" requirement + React 18 technology choice (responsive framework)
- **UXR-204** derived from mobile usability standards (iOS HIG, Material Design)

**Visual Design UXR (301-303):**
- **UXR-301** derived from designsystem.md requirement for consistent tokens
- **UXR-302** derived from organizational branding requirement
- **UXR-303** derived from UX best practices for user confidence

**Interaction UXR (401-404):**
- **UXR-401** derived from NFR-001 (perceived performance) + 200ms feedback threshold research
- **UXR-402 & 403** derived from UX best practices for professional web applications
- **UXR-404** derived from NFR-015 (leaderboard <5 min) + long-running operation requirements

**Error Handling UXR (501-504):**
- **UXR-501** derived from FR-020 (certification application validation) + form validation requirements
- **UXR-502** derived from UC-XXX alternative/exception flow paths in all use cases
- **UXR-503** derived from UX best practices (don't block user unnecessarily)
- **UXR-504** derived from Figma workflow mandate for 5 screen states

### UXR to Screen Mapping Matrix

| Screen ID | Screen Name | UXR Coverage | Notes |
|-----------|-------------|--------------|-------|
| SCR-001 | Login | UXR-001, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-404, UXR-501-504 | All baseline UXR + form validation |
| SCR-002 | Individual Dashboard | UXR-001-003, UXR-101-105, UXR-201-204, UXR-301-304, UXR-401-404 | High complexity, needs inline help |
| SCR-003 | Global Leaderboard | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401, UXR-404 | Progress indicator for updates |
| SCR-004 | User Profile | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-402, UXR-501-504 | Form validation required |
| SCR-005 | Learning Path Browser | UXR-001-003, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-404 | Needs inline help for recommendations |
| SCR-006 | Certification Application | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-402, UXR-501-504 | Multi-step form with validation |
| SCR-007 | Manager Dashboard | UXR-001-003, UXR-101-105, UXR-201-204, UXR-301-304, UXR-401, UXR-404 | Complex analytics, needs help |
| SCR-008 | Admin Console | UXR-001-003, UXR-101-105, UXR-201-204, UXR-301-304, UXR-401-404, UXR-501-504 | Highest complexity, extensive help needed |
| SCR-009 | Leadership Dashboard | UXR-001-003, UXR-101-105, UXR-201-204, UXR-301-304, UXR-401, UXR-404 | Executive-level analytics |
| SCR-010 | Course Player | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401, UXR-404 | Video playback, progress tracking |

*All screens inherit baseline UXR (101-105 accessibility, 201-204 responsiveness, 301-303 visual design).*

---

## 4. Personas Summary

*Derived from [spec.md - Actors & System Boundary](.propel/context/docs/spec.md#actors--system-boundary)*

| Persona | Role | Primary Goals | Key Screens | Pain Points |
|---------|------|---------------|-------------|-------------|
| **Learner** | Engineering Team Member | • Upskill in AI technologies<br/>• Earn verifiable credits<br/>• Track progress toward certifications<br/>• Get personalized learning recommendations | SCR-001 (Login)<br/>SCR-002 (Dashboard)<br/>SCR-005 (Learning Path Browser)<br/>SCR-010 (Course Player)<br/>SCR-004 (Profile)<br/>SCR-006 (Certification Application)<br/>SCR-003 (Leaderboard) | • Unclear learning path progression<br/>• Difficulty finding relevant courses<br/>• Progress not visible<br/>• No motivation/gamification |
| **Manager** | Team Lead/Dept Manager | • Monitor team skill development<br/>• Approve certification requests<br/>• Identify skill gaps<br/>• Recommend learning paths | SCR-001 (Login)<br/>SCR-007 (Manager Dashboard)<br/>SCR-011 (Team Member Detail)<br/>SCR-012 (Certification Approval Queue) | • No visibility into team progress<br/>• Cannot identify at-risk learners<br/>• Skill gaps not quantified<br/>• Manual certification approval workflow |
| **Admin** | Platform Administrator | • Manage content and courses<br/>• Configure credit rules<br/>• Monitor credit integrity<br/>• Ensure audit compliance | SCR-001 (Login)<br/>SCR-008 (Admin Console)<br/>SCR-013 (Content Management)<br/>SCR-014 (Credit Audit)<br/>SCR-015 (Anomaly Detection) | • Complex content management<br/>• Credit fraud detection manual<br/>• Compliance reporting time-consuming<br/>• Provider integration gaps |
| **Leadership** | C-Level Executives | • View AI readiness metrics<br/>• Make strategic training decisions<br/>• Allocate training budgets<br/>• Track ROI of learning initiatives | SCR-001 (Login)<br/>SCR-009 (Leadership Dashboard)<br/>SCR-016 (Executive Reports) | • No data-driven AI readiness visibility<br/>• Cannot quantify training ROI<br/>• Department comparison difficult<br/>• Strategic planning data-poor |

### Persona to Use Case Mapping

| Persona | Primary Use Cases | Screen Coverage |
|---------|------------------|-----------------|
| Learner | UC-001 (Enroll in Path), UC-002 (Complete Course), UC-004 (Apply for Certification) | 7 screens (SCR-001 to SCR-006, SCR-010) |
| Manager | UC-003 (Monitor Team Progress) | 4 screens (SCR-001, SCR-007, SCR-011, SCR-012) |
| Admin | UC-005 (Manage Content), UC-008 (Detect Tampering - admin view) | 5 screens (SCR-001, SCR-008, SCR-013 to SCR-015) |
| Leadership | UC-006 (View AI Readiness) | 3 screens (SCR-001, SCR-009, SCR-016) |

---

## 5. Information Architecture

### Site Map

```
AI Learning Platform (Root)
│
├── Public (No Auth Required)
│   ├── SCR-001: Login
│   └── SCR-017: Forgot Password (Optional)
│
├── Learner Portal (Role: Learner)
│   ├── SCR-002: Individual Dashboard
│   ├── SCR-005: Learning Path Browser
│   │   ├── SCR-018: Learning Path Detail
│   │   └── SCR-019: Course Detail
│   ├── SCR-010: Course Player
│   │   ├── SCR-020: Assessment
│   │   └── SCR-021: Project Submission
│   ├── SCR-003: Global Leaderboard
│   │   └── SCR-022: Team Leaderboard
│   ├── SCR-004: User Profile
│   │   └── SCR-023: Notification Settings
│   └── SCR-006: Certification Application
│       └── SCR-024: Certification Status
│
├── Manager Portal (Role: Manager)
│   ├── SCR-007: Manager Dashboard
│   ├── SCR-011: Team Member Detail
│   ├── SCR-012: Certification Approval Queue
│   │   └── SCR-025: Certification Review
│   └── SCR-026: Skill Gap Analysis (Dedicated Screen)
│
├── Admin Portal (Role: Admin)
│   ├── SCR-008: Admin Console
│   ├── SCR-013: Content Management
│   │   ├── SCR-027: Create/Edit Learning Path
│   │   ├── SCR-028: Create/Edit Course
│   │   └── SCR-029: Course Materials Upload
│   ├── SCR-014: Credit Audit
│   │   └── SCR-030: Transaction Detail
│   └── SCR-015: Anomaly Detection
│       └── SCR-031: Anomaly Investigation
│
├── Leadership Portal (Role: Leadership)
│   ├── SCR-009: Leadership Dashboard
│   └── SCR-016: Executive Reports
│       └── SCR-032: Report Export
│
└── Shared Components (All Roles)
    ├── Header Navigation
    ├── Sidebar Navigation
    ├── User Menu
    ├── Notifications Panel
    └── Help/Support

```

### Navigation Patterns

| Pattern | Type | Platform Behavior | Applicable Roles |
|---------|------|-------------------|------------------|
| **Primary Navigation** | Persistent Sidebar | **Desktop:** Left sidebar (250px) with collapsible menu<br/>**Tablet:** Collapsible sidebar (overlay on toggle)<br/>**Mobile:** Bottom navigation bar (5 primary items max) | All authenticated users |
| **Secondary Navigation** | Tabs | **Desktop/Tablet/Mobile:** Horizontal tabs within content area<br/>Example: Dashboard tabs (Overview, Progress, Recommendations) | Context-specific |
| **Utility Navigation** | Header Icons | **Desktop:** Right-aligned header icons (Notifications, Profile, Help)<br/>**Tablet/Mobile:** Hamburger menu for utility items | All authenticated users |
| **Breadcrumbs** | Path Navigation | **Desktop/Tablet:** Below header, shows current location path<br/>**Mobile:** Hidden on small screens (use back button) | Deep navigation screens (Course Player, Content Management) |
| **Quick Actions** | FAB (Floating Action Button) | **Mobile Only:** Bottom-right FAB for primary action per screen<br/>Example: Dashboard → "Browse Courses" | Mobile responsive screens |

### Navigation Hierarchy by Role

**Learner:**
1. Dashboard (Home)
2. Browse Learning Paths
3. My Courses (Active)
4. Leaderboard
5. Profile

**Manager:**
1. Team Dashboard (Home)
2. Team Members
3. Certification Approvals
4. Reports

**Admin:**
1. Admin Console (Home)
2. Content Management
3. Credit Audit
4. System Health

**Leadership:**
1. AI Readiness Dashboard (Home)
2. Reports
3. Department Analytics

---

## 6. Screen Inventory

*Screens derived from use cases UC-001 through UC-008. Every use case maps to one or more screens.*

### Screen Derivation Summary

| Screen ID | Screen Name | Derived From UC | UXR-XXX Mapped | Personas Covered | Priority | States Required | Parent Epic (if exists) |
|-----------|-------------|-----------------|----------------|------------------|----------|-----------------|------------------------|
| **SCR-001** | Login | UC-001 (entry point) | UXR-001, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-404, UXR-501-504 | All | P0 | 5 | - |
| **SCR-002** | Individual Dashboard | UC-001 (post-enrollment), UC-002 (progress display) | UXR-001-003, UXR-101-105, UXR-201-204, UXR-301-304, UXR-401-404 | Learner | P0 | 5 | - |
| **SCR-003** | Global Leaderboard | UC-002 (credit ranking) | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401, UXR-404 | Learner | P0 | 5 | - |
| **SCR-004** | User Profile | UC-001 (profile setup), UC-002 (badge display) | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-402, UXR-501-504 | Learner, Manager, Admin, Leadership | P1 | 5 | - |
| **SCR-005** | Learning Path Browser | UC-001 (view paths, enroll) | UXR-001-003, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-404 | Learner | P0 | 5 | - |
| **SCR-006** | Certification Application | UC-004 (apply for cert) | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-402, UXR-501-504 | Learner | P1 | 5 | - |
| **SCR-007** | Manager Dashboard | UC-003 (team monitoring) | UXR-001-003, UXR-101-105, UXR-201-204, UXR-301-304, UXR-401, UXR-404 | Manager | P0 | 5 | - |
| **SCR-008** | Admin Console | UC-005 (content management), UC-008 (anomaly alerts) | UXR-001-003, UXR-101-105, UXR-201-204, UXR-301-304, UXR-401-404, UXR-501-504 | Admin | P0 | 5 | - |
| **SCR-009** | Leadership Dashboard | UC-006 (AI readiness) | UXR-001-003, UXR-101-105, UXR-201-204, UXR-301-304, UXR-401, UXR-404 | Leadership | P0 | 5 | - |
| **SCR-010** | Course Player | UC-002 (course content, progress) | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401, UXR-404 | Learner | P0 | 5 | - |
| **SCR-011** | Team Member Detail | UC-003 (drill-down view) | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-404 | Manager | P1 | 5 | - |
| **SCR-012** | Certification Approval Queue | UC-004 (manager approval workflow) | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-402, UXR-501-504 | Manager | P1 | 5 | - |
| **SCR-013** | Content Management | UC-005 (create/edit courses) | UXR-001-003, UXR-101-105, UXR-201-204, UXR-301-304, UXR-401-404, UXR-501-504 | Admin | P0 | 5 | - |
| **SCR-014** | Credit Audit | UC-005 (audit logs), UC-008 (compliance) | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401, UXR-404 | Admin | P1 | 5 | - |
| **SCR-015** | Anomaly Detection | UC-008 (tampering alerts) | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-402, UXR-501-504 | Admin | P1 | 5 | - |
| **SCR-016** | Executive Reports | UC-006 (export reports) | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-402 | Leadership | P1 | 5 | - |
| **SCR-017** | Forgot Password | UC-001 (alternative auth flow) | UXR-001, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-402, UXR-501-504 | All | P2 | 5 | - |
| **SCR-018** | Learning Path Detail | UC-001 (view path details before enrolling) | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-404 | Learner | P1 | 5 | - |
| **SCR-019** | Course Detail | UC-001 (view course before enrolling) | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-404 | Learner | P1 | 5 | - |
| **SCR-020** | Assessment | UC-002 (take assessment) | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-402, UXR-501-504 | Learner | P0 | 5 | - |
| **SCR-021** | Project Submission | UC-002 (submit project) | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-402, UXR-501-504 | Learner | P1 | 5 | - |
| **SCR-022** | Team Leaderboard | UC-002 (team ranking) | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401, UXR-404 | Learner, Manager | P1 | 5 | - |
| **SCR-023** | Notification Settings | UC-001 (configure preferences) | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-402, UXR-501-504 | All | P2 | 5 | - |
| **SCR-024** | Certification Status | UC-004 (track cert application) | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-404 | Learner | P1 | 5 | - |
| **SCR-025** | Certification Review | UC-004 (manager review detail) | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-402, UXR-501-504 | Manager | P1 | 5 | - |
| **SCR-026** | Skill Gap Analysis | UC-003 (dedicated skill gap view) | UXR-001-003, UXR-101-105, UXR-201-204, UXR-301-304, UXR-401, UXR-404 | Manager | P1 | 5 | - |
| **SCR-027** | Create/Edit Learning Path | UC-005 (path management) | UXR-001-003, UXR-101-105, UXR-201-204, UXR-301-304, UXR-401-404, UXR-501-504 | Admin | P0 | 5 | - |
| **SCR-028** | Create/Edit Course | UC-005 (course management) | UXR-001-003, UXR-101-105, UXR-201-204, UXR-301-304, UXR-401-404, UXR-501-504 | Admin | P0 | 5 | - |
| **SCR-029** | Course Materials Upload | UC-005 (upload content) | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-402, UXR-501-504 | Admin | P0 | 5 | - |
| **SCR-030** | Transaction Detail | UC-005 (audit drill-down) | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-404 | Admin | P2 | 5 | - |
| **SCR-031** | Anomaly Investigation | UC-008 (investigate flagged anomaly) | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-402, UXR-501-504 | Admin | P1 | 5 | - |
| **SCR-032** | Report Export | UC-006 (export exec report) | UXR-001-002, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-402 | Leadership | P2 | 5 | - |

**Priority Legend:**
- **P0**: Critical - MVP launch blocker (16 screens)
- **P1**: High - Important for complete user experience (13 screens)
- **P2**: Medium - Nice-to-have, can be phased (3 screens)

**Total Screens:** 32 screens (comprehensive coverage of all 8 use cases)

### Use Case to Screen Coverage Matrix

| Use Case | Screens Covering This UC | Coverage Complete? |
|----------|-------------------------|-------------------|
| UC-001: Learner Enrolls in Learning Path | SCR-001, SCR-002, SCR-005, SCR-018 | ✅ Yes |
| UC-002: Learner Completes Course and Earns Credits | SCR-002, SCR-003, SCR-010, SCR-020, SCR-021, SCR-022 | ✅ Yes |
| UC-003: Manager Monitors Team Progress | SCR-007, SCR-011, SCR-022, SCR-026 | ✅ Yes |
| UC-004: Learner Applies for External Certification | SCR-006, SCR-012, SCR-024, SCR-025 | ✅ Yes |
| UC-005: Admin Manages Content and Credits | SCR-008, SCR-013, SCR-014, SCR-027, SCR-028, SCR-029, SCR-030 | ✅ Yes |
| UC-006: Leadership Views AI Readiness Metrics | SCR-009, SCR-016, SCR-032 | ✅ Yes |
| UC-007: System Syncs Employee Data from Workday | (Backend process - no dedicated UI screen, status shown in SCR-008 Admin Console) | ✅ Yes |
| UC-008: System Detects and Prevents Credit Tampering | SCR-008, SCR-014, SCR-015, SCR-031 | ✅ Yes |

**Coverage Validation:** All 8 use cases have dedicated screen coverage. ✅

---

## 7. Content & Tone

### Voice & Tone Guidelines

**Brand Voice:**
- **Professional yet Approachable**: Corporate learning platform with friendly, encouraging tone
- **Clear and Concise**: Avoid jargon; explain AI concepts in accessible language
- **Motivational**: Celebrate achievements; encourage continuous learning
- **Transparent**: Credit rules and progression paths clearly explained

**Tone by Context:**
| Context | Tone | Example |
|---------|------|---------|
| **Success Messages** | Celebratory, Encouraging | "Congratulations! You've earned 50 credits and unlocked the 'ML Beginner' badge!" |
| **Error Messages** | Helpful, Solution-Oriented | "We couldn't process your enrollment. Please check that you've completed the prerequisite course 'Intro to AI'." |
| **Instructional Content** | Clear, Step-by-Step | "To enroll in a learning path: 1) Browse available paths, 2) Review prerequisites, 3) Click 'Enroll Now'." |
| **Dashboard Insights** | Data-Driven, Actionable | "Your team has completed 45% of NLP courses. Focus on 'Advanced NLP' to close the skill gap." |
| **Gamification** | Fun, Competitive | "You're rank #45 globally! Earn 20 more credits to reach rank #40." |

### Microcopy Standards

**Buttons:**
- Primary Actions: Verb-first, specific (e.g., "Enroll in Path", "Submit Application", "Approve Certification")
- Secondary Actions: Supporting verbs (e.g., "Cancel", "Go Back", "View Details")
- Destructive Actions: Warning labels (e.g., "Delete Course" → show confirmation "Are you sure?")

**Form Labels:**
- Clear, specific (e.g., "Business Justification for Certification" not just "Justification")
- Include helper text for non-obvious fields
- Mark required fields with asterisk (*) and "(Required)" label

**Empty States:**
- Explain why content is empty
- Provide actionable next step
- Example: "No courses in progress yet. Browse our learning paths to get started!"

**Loading States:**
- Specific to action (e.g., "Calculating your rank...", "Generating AI readiness report...")
- Avoid generic "Loading..." when possible

---

## 8. Data & Edge Cases

### Data Scenarios by Screen

#### SCR-002: Individual Dashboard
**Data Scenarios:**
- **New User (0 courses)**: Empty state with onboarding prompt
- **Active Learner (1-5 courses)**: Standard dashboard with progress widgets
- **Power User (10+ courses)**: Paginated or scrollable course list
- **No Recommendations Available**: Show "Check back soon" message

**Edge Cases:**
- User with 0 credits but badges (awarded by admin exception)
- Leaderboard rank tie-breaking (timestamp-based)
- Progress percentage exactly 100% but course marked incomplete (assessment pending)

#### SCR-003: Global Leaderboard
**Data Scenarios:**
- **Top 100 Users**: Standard leaderboard display
- **User Not in Top 100**: Show user's position separately (e.g., "You are rank #145")
- **Multiple Users Tied**: Display all tied users with same rank

**Edge Cases:**
- Leaderboard update lag (show "Last updated: 3 minutes ago")
- User with identical credit count (tie-breaking logic visible)
- Anonymous mode request (organizational setting - TBD)

#### SCR-007: Manager Dashboard
**Data Scenarios:**
- **Small Team (1-5 members)**: Full roster visible
- **Large Team (20+ members)**: Pagination or scrollable list
- **Team with 0 Progress**: Empty state with "Encourage your team to enroll" message

**Edge Cases:**
- Team member transferred (no longer reports to manager - show historical data?)
- At-risk learner with recent activity spike (flag false positive)
- Skill gap analysis with insufficient data (minimum 30 days enrollment)

#### SCR-010: Course Player
**Data Scenarios:**
- **Video Content**: Standard video player with playback controls
- **Lab/Interactive Content**: Embedded iframe or external link
- **Assessment**: Question-answer interface with timer
- **Project Submission**: File upload interface

**Edge Cases:**
- Video playback error (codec issue, network timeout)
- Progress autosave failure (offline mode - queue for retry)
- Course content updated while user in progress (show "New version available")

### Global Edge Cases

**Network Errors:**
- **Offline Mode**: Show offline banner; queue actions for retry
- **Slow Network**: Progressive loading with skeleton screens
- **Timeout Errors**: Retry button with exponential backoff

**Permissions:**
- **Unauthorized Access**: Redirect to login or show 403 error
- **Role Change Mid-Session**: Refresh session and redirect to appropriate dashboard
- **Feature Flag Disabled**: Hide feature gracefully with "Coming Soon" message

**Data Integrity:**
- **Stale Data**: Show "Last synced: X minutes ago" timestamp
- **Concurrent Edits**: Conflict resolution (last write wins with notification)
- **Credit Calculation Error**: Flag transaction for admin review

---

## 9. Branding / Visual Direction

### Organizational Branding

**Brand Identity:**
- **Company Name**: [To Be Defined]
- **Tagline**: "Transform into an AI-Native Enterprise"
- **Brand Attributes**: Innovative, Trustworthy, Empowering, Professional

### Visual Style

**Design Philosophy:**
- **Modern and Clean**: Minimalist interfaces with ample whitespace
- **Data-Driven**: Emphasis on charts, metrics, and progress visualization
- **Gamified**: Playful elements (badges, leaderboards) balanced with professional tone
- **Accessible**: High contrast, large touch targets, clear typography

**Color Palette (Conceptual - to be finalized in designsystem.md):**
- **Primary Color**: Blue (Trust, Professionalism, Technology) - suggested #0078D4 (Azure Blue)
- **Secondary Color**: Green (Growth, Achievement, Success) - suggested #10B981 (Emerald)
- **Accent Color**: Purple (AI, Innovation) - suggested #8B5CF6 (Violet)
- **Semantic Colors**:
  - Success: Green #10B981
  - Warning: Amber #F59E0B
  - Error: Red #EF4444
  - Info: Blue #3B82F6
- **Neutral Palette**: Gray scale (50-900) for backgrounds, text, borders

**Typography (Conceptual):**
- **Heading Font**: Sans-serif, modern (e.g., Inter, Roboto, SF Pro)
- **Body Font**: Same as heading for consistency
- **Monospace Font**: For code snippets or technical content (e.g., Fira Code, Consolas)

**Imagery Style:**
- **Illustrations**: Flat, geometric style for empty states and onboarding
- **Icons**: Outlined style for consistency (e.g., Heroicons, Lucide Icons)
- **Photos**: Authentic, diverse team photos (avoid stock photo clichés)
- **Data Visualizations**: Chart.js or D3.js styled charts with brand colors

### Inspiration References

**Design System Inspiration:**
- **Material Design 3** (Google): Component patterns, responsive behavior
- **Ant Design** (Alibaba): Enterprise dashboard patterns, data tables
- **Fluent UI** (Microsoft): Professional enterprise aesthetics
- **Tailwind UI**: Clean, modern component styling

**Dashboard Inspiration:**
- Duolingo (gamification and progress visualization)
- LinkedIn Learning (course player and progress tracking)
- Khan Academy (personalized recommendations and learning paths)
- Coursera (certification workflows)

---

## 10. Components / Design System Constraints

### Design System Source

Reference the comprehensive design system specification in [designsystem.md](.propel/context/docs/designsystem.md) for detailed token values, component specifications, and usage guidelines.

### Core Component Inventory

*Derived from screen requirements. Components organized by atomic design methodology.*

#### Atoms (Foundational Elements)

| Component | Variants | Required States | Usage | Screens |
|-----------|----------|-----------------|--------|---------|
| **Button** | Primary, Secondary, Tertiary, Outline, Ghost, Danger | Default, Hover, Active, Disabled, Loading | CTAs, form submissions, actions | All |
| **Input Field** | Text, Email, Password, Number, TextArea | Default, Focused, Filled, Error, Disabled, Read-Only | Form inputs | SCR-001, SCR-004, SCR-006, SCR-013, SCR-027, SCR-028 |
| **Checkbox** | Standard, Indeterminate | Unchecked, Checked, Disabled | Multi-select, agreements | SCR-004, SCR-013, SCR-023 |
| **Radio Button** | Standard | Unselected, Selected, Disabled | Single choice selection | SCR-006, SCR-020 |
| **Toggle Switch** | Standard | Off, On, Disabled | Boolean settings | SCR-004, SCR-023 |
| **Link** | Standard, Underlined | Default, Hover, Visited, Active | Navigation, external links | All |
| **Label** | Standard, Required | Default | Form field labels | All forms |
| **Icon** | 100+ icons | Default, Hover (if interactive) | Visual indicators, actions | All |
| **Badge** | Skill, Milestone, Tier, Count | Default | Achievement display, counts | SCR-002, SCR-003, SCR-004 |
| **Avatar** | Small (32px), Medium (48px), Large (64px) | Default, Placeholder (initials) | User identification | SCR-004, SCR-007, SCR-011 |
| **Spinner** | Small, Medium, Large | Rotating | Loading indication | All |

#### Molecules (Component Combinations)

| Component | Description | Required States | Usage | Screens |
|-----------|-------------|-----------------|--------|---------|
| **Search Bar** | Input + Icon + Clear Button | Empty, Focused, Filled, Loading | Content search | SCR-005, SCR-007, SCR-013, SCR-014 |
| **Dropdown/Select** | Trigger + Menu + Options | Closed, Open, Disabled | Selection from list | SCR-004, SCR-006, SCR-013, SCR-027 |
| **Card** | Container with Border/Shadow | Default, Hover, Selected | Content grouping | SCR-002, SCR-005, SCR-007, SCR-009 |
| **Toast Notification** | Icon + Message + Close | Success, Error, Warning, Info | Feedback messages | All |
| **Progress Bar** | Bar + Label + Percentage | 0-100% | Progress indication | SCR-002, SCR-010 |
| **Breadcrumb** | Links + Separators | Default | Navigation path | SCR-010, SCR-013, SCR-027, SCR-028 |
| **Pagination** | Page Numbers + Prev/Next | Default, Disabled | List navigation | SCR-003, SCR-007, SCR-014 |
| **Tab Group** | Tab Buttons + Panel | Selected, Unselected, Disabled | Content organization | SCR-002, SCR-007, SCR-008, SCR-009 |
| **Stat Card** | Metric + Label + Trend Icon | Default, Loading | KPI display | SCR-002, SCR-007, SCR-009 |
| **Empty State** | Icon + Message + CTA | Default | No data scenario | All |
| **File Upload** | Dropzone + File List + Progress | Empty, Dragging, Uploading, Complete, Error | File uploads | SCR-021, SCR-024, SCR-029 |

#### Organisms (Complex Components)

| Component | Description | Nested Components | Usage | Screens |
|-----------|-------------|-------------------|--------|---------|
| **Header Navigation** | Logo + Nav Links + User Menu | Links, Dropdown, Avatar, Badge (notifications) | Global navigation | All authenticated |
| **Sidebar Navigation** | Menu Items + Collapse Toggle | Links, Icons, Badge (counts) | Primary navigation | All authenticated (desktop) |
| **Bottom Navigation** | Menu Items (Mobile) | Links, Icons, Badge | Mobile navigation | All authenticated (mobile) |
| **Data Table** | Headers + Rows + Actions + Sort + Filter + Pagination | Checkbox, Sort Icons, Dropdown, Pagination | Data display | SCR-007, SCR-011, SCR-014, SCR-015 |
| **Modal Dialog** | Overlay + Header + Content + Footer | Heading, Button, Close Icon | Overlays, confirmations | All (contextual) |
| **Drawer/Sidebar Panel** | Slide-in Panel + Close | Heading, Content Area, Button | Contextual details | SCR-011, SCR-031 |
| **Form** | Fields + Labels + Validation + Submit | Input, Checkbox, Dropdown, Button | Data entry | SCR-004, SCR-006, SCR-013, SCR-027, SCR-028 |
| **Chart** | Bar/Line/Pie/Doughnut Chart | Legend, Axes, Tooltips | Data visualization | SCR-002, SCR-007, SCR-009 |
| **Leaderboard List** | Ranked Items with Avatars + Stats | Avatar, Badge, Stat Label | Ranking display | SCR-003, SCR-022 |
| **Course Card** | Thumbnail + Title + Metadata + CTA | Image, Heading, Labels, Button, Progress Bar | Course display | SCR-005, SCR-018 |
| **Video Player** | Controls + Timeline + Quality Selector | Button, Slider, Dropdown | Video playback | SCR-010 |
| **Skill Gap Heatmap** | Grid + Color Scale + Tooltips | Table cells, Color legend | Skill visualization | SCR-007, SCR-026 |

### Component Library Constraints

**Framework Integration:**
- Build with **React 18** and **TypeScript**
- Use **Tailwind CSS** for utility-first styling (aligns with design tokens)
- Consider **shadcn/ui** or **Ant Design** as base component library (customizable)
- Accessibility: All components WCAG 2.2 AA compliant out-of-box

**Component Architecture:**
- **Atomic Design** methodology for organization
- **Compound Components** pattern for flexibility (e.g., Modal.Header, Modal.Content)
- **Controlled Components** for form inputs with validation
- **Composition over Configuration** for customization

**State Management:**
- Component-level state with **React Hooks** (useState, useReducer)
- Global state with **Redux Toolkit** or **Zustand** (for dashboard data, user session)
- Form state with **React Hook Form** (performance, validation)

---

## 11. Prototype Flows

*Flows organized by flow name (not by persona). Each flow notes which personas are covered.*

### Flow Overview

| Flow ID | Flow Name | Derived From UC | Personas Covered | Screens Involved | Priority |
|---------|-----------|-----------------|------------------|------------------|----------|
| FL-001 | Authentication Flow | UC-001 | All | SCR-001, SCR-017 | P0 |
| FL-002 | Learning Path Enrollment Flow | UC-001 | Learner | SCR-002, SCR-005, SCR-018, SCR-019 | P0 |
| FL-003 | Course Completion Flow | UC-002 | Learner | SCR-010, SCR-020, SCR-021, SCR-002, SCR-003 | P0 |
| FL-004 | Certification Application Flow | UC-004 | Learner, Manager | SCR-006, SCR-024, SCR-012, SCR-025 | P1 |
| FL-005 | Team Monitoring Flow | UC-003 | Manager | SCR-007, SCR-011, SCR-026 | P0 |
| FL-006 | Content Management Flow | UC-005 | Admin | SCR-008, SCR-013, SCR-027, SCR-028, SCR-029 | P0 |
| FL-007 | Credit Audit Flow | UC-005, UC-008 | Admin | SCR-008, SCR-014, SCR-030, SCR-015, SCR-031 | P1 |
| FL-008 | Executive Reporting Flow | UC-006 | Leadership | SCR-009, SCR-016, SCR-032 | P1 |

---

### FL-001: Authentication Flow
**Flow ID:** FL-001  
**Derived From:** UC-001 (entry point for all use cases)  
**Personas Covered:** All (Learner, Manager, Admin, Leadership)  
**Description:** User authentication via Organization SSO with role-based redirect

**Flow Sequence:**
1. **Entry**: SCR-001 (Login) / **Default State**
   - Trigger: User navigates to platform URL
   - Action: SSO button displayed ("Sign in with Organization Account")

2. **Step**: SCR-001 (Login) / **Loading State**
   - Trigger: User clicks "Sign in with Organization Account"
   - Action: Redirect to SSO provider (OAuth 2.0/SAML)
   
3. **Decision Point (External - SSO Provider)**:
   - Success (credentials valid) → Continue to Step 4
   - Error (credentials invalid) → SCR-001 (Login) / **Error State** (show error banner)

4. **Step**: SCR-001 (Login) / **Loading State**
   - Trigger: SSO provider returns success token
   - Action: Platform validates token, extracts user claims (role, email, name)

5. **Decision Point (Role-Based Routing)**:
   - Role = Learner → SCR-002 (Individual Dashboard) / **Default State**
   - Role = Manager → SCR-007 (Manager Dashboard) / **Default State**
   - Role = Admin → SCR-008 (Admin Console) / **Default State**
   - Role = Leadership → SCR-009 (Leadership Dashboard) / **Default State**

6. **Exit**: Dashboard (Role-Specific) / **Default State**

**Required Interactions:**
- SSO button with hover state
- Loading spinner during SSO redirect
- Error message display for failed authentication
- Forgot password link (optional) → SCR-017

**Alternative Flows:**
- Forgot Password: SCR-001 → SCR-017 (Forgot Password) → Email sent confirmation → SCR-001
- Session Expired: Dashboard → SCR-001 (Login) with banner "Session expired, please login again"

---

### FL-002: Learning Path Enrollment Flow
**Flow ID:** FL-002  
**Derived From:** UC-001 (Learner Enrolls in Learning Path)  
**Personas Covered:** Learner  
**Description:** Learner discovers, evaluates, and enrolls in an AI learning path

**Flow Sequence:**
1. **Entry**: SCR-002 (Individual Dashboard) / **Default State**
   - Trigger: Learner clicks "Browse Learning Paths" button or FAB (mobile)

2. **Step**: SCR-005 (Learning Path Browser) / **Default State**
   - Action: Display available learning paths (Beginner, Intermediate, Advanced)
   - Filters: Difficulty level, duration, credits
   - Recommendations: "Recommended for You" section (FR-009)

3. **Step**: SCR-018 (Learning Path Detail) / **Default State**
   -  Trigger: Learner clicks on learning path card
   - Action: Show full path details (courses, prerequisites, duration, total credits)

4. **Decision Point (Prerequisites Check)**:
   - Prerequisites met OR no prerequisites → Continue to Step 5
   - Prerequisites NOT met → SCR-018 / **Error State** (show prerequisite requirements, disable "Enroll" button)

5. **Step**: SCR-018 (Learning Path Detail) / **Default State**
   - Trigger: Learner clicks "Enroll Now" button
   - Action: Show enrollment confirmation modal

6. **Decision Point (Enrollment Limit Check)**:
   - Active enrollments < 5 (limit) → Continue to Step 7
   - Active enrollments ≥ 5 → SCR-018 / **Error State** (show "Max 5 concurrent enrollments" message)

7. **Step**: SCR-018 / **Loading State**
   - Action: Submit enrollment request to API

8. **Decision Point (Enrollment Success)**:
   - Success → SCR-002 (Individual Dashboard) / **Default State** with success toast "Enrolled in 'Beginner AI' path!"
   - Error → SCR-018 / **Error State** (show error message with retry button)

9. **Exit**: SCR-002 (Individual Dashboard) / **Default State**
   - Outcome: New learning path appears in "My Learning Paths" widget
   - First course in path displayed in "Recommended Next Steps"

**Required Interactions:**
- Path cards with hover effect showing quick stats
- Filter dropdowns with multi-select (difficulty, duration)
- Search bar for path/course name
- Enrollment confirmation modal with path summary
- Success toast notification (auto-dismiss after 5 seconds)
- Back navigation (breadcrumb or back button)

**Alternative Flows:**
- View Course Detail First: SCR-005 → SCR-019 (Course Detail) → Back to SCR-018 via breadcrumb
- No Paths Available (Empty State): SCR-005 / **Empty State** ("No learning paths match your filters. Reset filters?")

---

### FL-003: Course Completion Flow
**Flow ID:** FL-003  
**Derived From:** UC-002 (Learner Completes Course and Earns Credits)  
**Personas Covered:** Learner  
**Description:** Learner progresses through course content, takes assessment, and earns credits with leaderboard updates

**Flow Sequence:**
1. **Entry**: SCR-002 (Individual Dashboard) / **Default State**
   - Trigger: Learner clicks on course in "Courses in Progress" or "Recommended Next Steps"

2. **Step**: SCR-010 (Course Player) / **Default State**
   - Action: Display course content (video, text, lab, etc.)
   - Progress bar shows % completion
   - Auto-save progress every 5 minutes (background)

3. **Step**: SCR-010 (Course Player) / **Default State**
   - Trigger: Learner completes all mandatory sections (100% progress)
   - Action: "Take Final Assessment" button becomes enabled

4. **Step**: SCR-020 (Assessment) / **Default State**
   - Trigger: Learner clicks "Take Final Assessment"
   - Action: Display assessment questions (multiple choice, coding, etc.)
   - Timer countdown (if timed assessment)
   - Submit button

5. **Step**: SCR-020 (Assessment) / **Loading State**
   - Trigger: Learner clicks "Submit Assessment"
   - Action: Grading in progress (API call)

6. **Decision Point (Assessment Score)**:
   - Score ≥ 70% (passing) → Continue to Step 7
   - Score < 70% AND attempts < 3 → SCR-020 / **Error State** (show failed score, retry available in 24h)
   - Score < 70% AND attempts ≥ 3 → SCR-020 / **Error State** (show "Must retake course" message)

7. **Step**: SCR-010 (Course Player) / **Loading State**
   - Action: Calculate credits (base + bonus if score ≥90%)
   - Award credits to learner account
   - Generate completion certificate

8. **Step**: SCR-002 (Individual Dashboard) / **Default State**
   - Trigger: Automatic redirect after credit award
   - Action: Success modal appears:
     - "Congratulations! You've earned 50 credits!" (animated celebration)
     - Badge unlock notification (if criteria met)
     - Certificate download link
   - Updated widgets: Total credits, current rank, new badge (if unlocked)

9. **Step**: SCR-003 (Global Leaderboard) / **Loading State** (optional - user may navigate)
   - Trigger: User clicks "View Leaderboard" from success  modal
   - Action: Leaderboard recalculates rank (updates within 5 min per NFR-015)

10. **Exit**: SCR-002 (Individual Dashboard) / **Default State** OR SCR-003 (Leaderboard)
    - Outcome: Course marked complete, credits awarded, leaderboard updated, certificate available

**Required Interactions:**
- Video player controls (play, pause, volume, speed, quality, fullscreen)
- Progress auto-save indicator (small checkmark icon)
- Assessment submission confirmation ("Are you sure? You cannot retake immediately.")
- Success modal with animated confetti effect (celebrate achievement)
- Certificate download button (PDF generation)
- Badge unlock animation (slide-in badge icon)

**Alternative Flows:**
- Project Submission: SCR-010 → SCR-021 (Project Submission) → Upload file → Submit → Admin review → Credits awarded (async)
- Assessment Retry: SCR-020 (Failed) → Wait 24h → SCR-020 (Retry) → Submit
- Network Error During Submission: SCR-020 / **Error State** (retry button, queued for retry if offline)

---

### FL-004: Certification Application Flow
**Flow ID:** FL-004  
**Derived From:** UC-004 (Learner Applies for External Certification)  
**Personas Covered:** Learner (applicant), Manager (approver)  
**Description:** Multi-actor flow from learner application through manager approval and tracking

**Flow Sequence (Learner Perspective):**
1. **Entry**: SCR-002 (Individual Dashboard) or SCR-005 / **Default State**
   - Trigger: Learner clicks "Apply for Certification" button

2. **Step**: SCR-006 (Certification Application) / **Default State**
   - Action: Display application form
   - Fields: Provider (dropdown), Course Name (searchable), Cost, Business Justification (textarea)
   - Provider catalog synced from APIs

3. **Step**: SCR-006 / **Validation State**
   - Trigger: Learner submits incomplete form
   - Action: Inline validation errors appear (required fields, cost format)

4. **Step**: SCR-006 / **Loading State**
   - Trigger: Learner submits valid form
   - Action: Submit application to API, route to manager queue

5. **Step**: SCR-024 (Certification Status) / **Default State**
   - Trigger: Automatic redirect after submission
   - Action: Success message "Application submitted to your manager for approval"
   - Status tracking: "Pending Manager Approval" with estimated SLA (5 business days)

6. **Exit (Learner - Wait State)**: SCR-024 / **Default State**
   - Outcome: Application visible in "My Certifications" with status badge

**Flow Sequence (Manager Perspective - Parallel Flow):**
7. **Entry**: SCR-007 (Manager Dashboard) / **Default State**
   - Trigger: Notification badge on "Certification Approvals" sidebar item
   - Manager receives email notification

8. **Step**: SCR-012 (Certification Approval Queue) / **Default State**
   - Action: Display pending approvals in table (applicant, course, cost, submitted date, SLA remaining)
   - Sort/filter options

9. **Step**: SCR-025 (Certification Review) / **Default State**
   - Trigger: Manager clicks on application row
   - Action: Drawer/modal opens with full application details and business justification

10. **Decision Point (Manager Decision)**:
    - Approve → Continue to Step 11
    - Reject → SCR-025 with "Rejection Reason" textarea → Submit rejection → SCR-024 (Learner) updates to "Rejected"
    - Request More Info → SCR-025 → Send message to learner → Learner updates application → Back to Step 9

11. **Step**: SCR-025 / **Loading State**
    - Trigger: Manager clicks "Approve"
    - Action: Update application status to "Approved"

12. **Step**: SCR-024 (Learner view) / **Default State**
    - Trigger: Learner receives notification of approval
    - Action: Status updates to "Approved - Enroll and Upload Proof"
    - CTA button: "Upload Completion Certificate"

**Flow Sequence (Post-Completion):**
13. **Step**: SCR-024 / **Default State**
    - Trigger: Learner completes external certification, clicks "Upload Proof"
    - Action: File upload interface (drag & drop or browse)

14. **Step**: SCR-024 / **Loading State**
    - Action: Upload certificate PDF to blob storage

15. **Step**: SCR-024 / **Default State**
    - Outcome: Status updates to "Pending Admin Validation"
    - Admin receives notification

16. **Step** (Admin Validation - separate flow): SCR-015 (Admin) validates → Awards credits → SCR-024 (Learner) updates to "Validated - Credits Awarded"

17. **Exit**: SCR-024 / **Default State** with success banner "300 credits awarded!"

**Required Interactions:**
- Provider dropdown with search (typeahead)
- Course catalog search (autocomplete from provider API)
- Cost input with currency formatting
- Business justification textarea (character count: 500 max)
- Manager approval modal with approve/reject/request-more-info buttons
- File upload drag-and-drop zone (PDF only, max 10MB)
- Status badge color-coded (Pending=Yellow, Approved=Green, Rejected=Red, Validated=Blue)

**Alternative Flows:**
- Draft Application: SCR-006 → Save as draft → Exit → Return later → Resume from draft
- Approval SLA Breach: >5 days pending → Escalation notification to manager's manager
- Validation Failure: Admin rejects proof → SCR-024 / **Error State** → Learner re-uploads alternate proof

---

### FL-005: Team Monitoring Flow
**Flow ID:** FL-005  
**Derived From:** UC-003 (Manager Monitors Team Progress)  
**Personas Covered:** Manager  
**Description:** Manager reviews team performance, identifies at-risk learners, and analyzes skill gaps

**Flow Sequence:**
1. **Entry**: SCR-007 (Manager Dashboard) / **Default State**
   - Trigger: Manager logs in (default landing page for Manager role)
   - Action: Display team performance overview (KPI cards, charts, team roster)

2. **Step**: SCR-007 / **Default State**
   - Action: Manager scans KPI cards:
     - Team Average Credits
     - Team Rank (out of N teams)
     - Completion Rate (%)
     - At-Risk Learners (count with alert icon)
   - Charts: Learning velocity trends, skill distribution heatmap

3. **Step**: SCR-007 / **Default State**
   - Trigger: Manager clicks on "At-Risk Learners" section (highlighted in red)
   - Action: Data table filters to show only at-risk team members (no activity in 14 days)

4. **Step**: SCR-011 (Team Member Detail) / **Default State**
   - Trigger: Manager clicks on at-risk learner's name
   - Action: Drawer/modal opens with detailed progress:
     - Courses in progress (with last accessed date)
     - Total credits earned
     - Engagement score trend chart
     - Recommended actions (send reminder, assign course, 1-on-1 meeting)

5. **Decision Point (Manager Action)**:
   - Send Reminder → Notification sent to learner → SCR-011 closes
   - Assign Recommend Course → Course assignment workflow → SCR-011 closes
   - No Action → Close drawer → Return to SCR-007

6. **Step**: SCR-026 (Skill Gap Analysis) / **Default State**
   - Trigger: Manager clicks "Skill Gap Analysis" tab on SCR-007 or dedicated sidebar link
   - Action: Display skill gap heatmap (team members rows vs. AI skill categories columns)
   - Color scale: Green (proficient) → Yellow (developing) → Red (critical gap)

7. **Step**: SCR-026 / **Default State**
   - Action: Manager reviews AI-generated insights:
     - "Critical Gap: NLP skills (60% of team below target)"
     - "Recommended Action: Enroll team in 'NLP Intermediate Path'"
   - CTA: "Assign Path to Team" button

8. **Step**: SCR-026 / **Loading State**
   - Trigger: Manager clicks "Assign Path to  Team"
   - Action: Bulk assignment modal opens → Select team members (checkboxes) → Confirm

9. **Exit**: SCR-007 (Manager Dashboard) / **Default State** with success toast
   - Outcome: "5 team members assigned to 'NLP Intermediate Path'"
   - Team members receive notification

**Required Interactions:**
- KPI cards with drill-down click (expand to detail view)
- At-risk learner table with sorting/filtering (by days inactive, credits, completion rate)
- Team member detail drawer (slide-in from right)
- Send reminder button (opens message composer)
- Skill gap heatmap with tooltips (hover shows specific skill level and gap)
- Bulk assignment modal with team member multi-select
- Export team report button (generates Excel/PDF download)

**Alternative Flows:**
- Large Team (>20 members): Pagination in team roster table
- No At-Risk Learners: SCR-007 shows green "All team members active!" message
- Skill Gap Insufficient Data: SCR-026 / **Empty State** ("Minimum 30 days enrollment required for analysis")

---

### FL-006: Content Management Flow
**Flow ID:** FL-006  
**Derived From:** UC-005 (Admin Manages Content and Credits)  
**Personas Covered:** Admin  
**Description:** Admin creates and publishes learning paths and courses with credit configuration

**Flow Sequence:**
1. **Entry**: SCR-008 (Admin Console) / **Default State**
   - Trigger: Admin clicks "Content Management" sidebar link

2. **Step**: SCR-013 (Content Management) / **Default State**
   - Action: Display content library (learning paths and courses in tabs)
   - Actions: Create New, Edit, Delete, Publish/Unpublish

3. **Step**: SCR-027 (Create/Edit Learning Path) / **Default State**
   - Trigger: Admin clicks "Create New Learning Path"
   - Action: Form appears:
     - Name, Description, Difficulty Level (dropdown), Prerequisites (multi-select existing paths)
     - Course Sequence (drag & drop courses to reorder)
     - Estimated Duration, Total Credits (calculated)

4. **Step**: SCR-027 / **Validation State**
   - Trigger: Admin submits incomplete form
   - Action: Inline validation errors (name required, at least 1 course, etc.)

5. **Step**: SCR-027 / **Loading State**
   - Trigger: Admin submits valid form
   - Action: Save learning path (draft mode)

6. **Step**: SCR-028 (Create/Edit Course) / **Default State**
   - Trigger: Admin clicks "Add New Course" from SCR-027 or directly from SCR-013
   - Action: Multi-step form:
     - **Step 1**: Basic Info (Title, Description, Content Type, Difficulty, Duration)
     - **Step 2**: Credit Rules (Base Credits, Bonus Threshold %)
     - **Step 3**: Prerequisites (select courses)
     - **Step 4**: Course Materials Upload

7. **Step**: SCR-029 (Course Materials Upload) / **Default State**
   - Trigger: Admin advances to Step 4 of course creation
   - Action: File upload interface:
     - Video files (MP4, max 500MB per file)
     - Documents (PDF, max 50MB)
     - Lab files (ZIP, max 100MB)
   - Drag-and-drop zone with progress bars

8. **Step**: SCR-029 / **Loading State**
   - Action: Upload files to Azure Blob Storage, generate thumbnails for videos

9. **Decision Point (Upload Success)**:
   - Success → SCR-028 / **Default State** (materials listed, preview buttons)
   - Error → SCR-029 / **Error State** (show upload error, retry button)

10. **Step**: SCR-028 / **Default State**
    - Trigger: Admin completes all steps, clicks "Save Draft"
    - Action: Course saved in draft mode (not visible to learners)

11. **Step**: SCR-013 (Content Management) / **Default State**
    - Action: Course appears in course library with "Draft" badge

12. **Step**: SCR-013 / **Loading State**
    - Trigger: Admin clicks "Publish" on course or learning path
    - Action: Validation checks run (all required fields, materials uploaded, prerequisites valid)

13. **Decision Point (Validation)**:
    - Pass → SCR-013 / **Default State** (course/path published, visible to learners)
    - Fail → SCR-013 / **Error State** (validation errors listed, fix and retry)

14. **Exit**: SCR-013 / **Default State** with success toast "Course 'CNN Fundamentals' published!"
    - Outcome: Course/path live, learners can enroll

**Required Interactions:**
- Content library data table with search, filter (status: draft/published, difficulty)
- Create button with dropdown (Learning Path vs. Course)
- Multi-step form with progress indicator (Step 1 of 4)
- Drag-and-drop course sequencing (reorder courses in path)
- File upload with multiple files, progress bars per file
- Preview buttons for uploaded materials (opens in modal/new tab)
- Publish button with confirmation modal ("Are you sure? This will make content live.")
- Validation error list with clickable items (jump to error field)

**Alternative Flows:**
- Edit Existing Content: SCR-013 → Click Edit icon → SCR-027/028 pre-filled → Update → Save
- Bulk Actions: SCR-013 → Select multiple (checkboxes) → Bulk Publish/Unpublish
- Content Template: SCR-028 → "Use Template" button → Pre-fill common credit rules

---

### FL-007: Credit Audit Flow
**Flow ID:** FL-007  
**Derived From:** UC-005 (Admin Audit), UC-008 (Detect Tampering)  
**Personas Covered:** Admin  
**Description:** Admin reviews credit transactions, investigates anomalies, and takes corrective action

**Flow Sequence:**
1. **Entry**: SCR-008 (Admin  Console) / **Default State**
   - Trigger: Admin clicks "Credit Audit" or "Anomaly Detection" sidebar link
   - Notification badge if anomalies flagged

2. **Step**: SCR-014 (Credit Audit) / **Default State**
   - Action: Display credit transactions table (all or filtered)
   - Columns: User, Amount, Source (Course/Cert), Timestamp, Validator, Hash, Status
   - Filters: Date range, user, source, flagged anomalies only

3. **Step**: SCR-014 / **Default State**
   - Action: Admin applies filter "Flagged Anomalies Only"
   - Table shows only suspicious transactions (highlighted in red)

4. **Step**: SCR-015 (Anomaly Detection) / **Default State**
   - Trigger: Admin clicks "View Anomalies" or dedicated sidebar link
   - Action: Anomaly alert dashboard:
     - Critical alerts (red) - immediate action required
     - Medium (yellow) - review needed
     - Low (blue) - informational
   - Anomaly examples: "User X completed 3 courses in 2 hours", "Credit spike: 90 credits in 1 day"

5. **Step**: SCR-031 (Anomaly Investigation) / **Default State**
   - Trigger: Admin clicks on critical anomaly
   - Action: Drawer/modal opens with evidence:
     - User activity timeline
     - Transaction details (timestamps, course completion times)
     - IP address and location logs
     - API access logs (detect direct API manipulation)

6. **Decision Point (Admin Assessment)**:
   - False Positive (legitimate) → SCR-031 → "Clear Flag" button → Anomaly marked resolved
   - Confirmed Tampering → Continue to Step 7

7. **Step**: SCR-031 / **Default State**
   - Trigger: Admin clicks "Confirm Tampering"
   - Action: Credit adjustment form appears:
     - Revoke Credits: Input negative amount (-90 credits)
     - Reason: Textarea (required for audit trail)
     - Account Action: Dropdown (Warning, Suspend 30 days, Permanent Ban)

8. **Decision Point (Adjustment Amount)**:
   - Amount ≤ 50 credits → Admin approves directly → Continue to Step 9
   - Amount > 50 credits → SCR-031 / **Validation State** ("Requires second admin approval for >50 credits") → Request sent to second admin

9. **Step**: SCR-031 / **Loading State**
   - Action: Submit credit adjustment, apply account suspension
   - Update user record with violation flag

10. **Step**: SCR-030 (Transaction Detail) / **Default State** (optional drill-down)
    - Trigger: Admin clicks on transaction row ID
    - Action: Modal shows full transaction details (hash verification, before/after state)

11. **Exit**: SCR-014 (Credit Audit) / **Default State** with success toast
    - Outcome: "90 credits revoked, user suspended for 30 days"
    - Manager and HR notified

**Required Interactions:**
- Data table with advanced filters (date range picker, multi-select dropdowns)
- Anomaly severity badges (color-coded: red/yellow/blue)
- Anomaly evidence timeline (visual timeline with events)
- Credit adjustment form with validation (amount, reason required)
- Second admin approval workflow (pending approval queue)
- Hash verification indicator (checkmark if hash valid, X if tampered)
- Export button (download audit report as Excel/PDF)

**Alternative Flows:**
- No Anomalies: SCR-015 / **Empty State** ("No anomalies detected. System integrity maintained!")
- Second Admin Approves: Pending approval notification → Second admin reviews → Approves → Credits adjusted
- Second Admin Rejects: Revocation request denied → First admin notified

---

### FL-008: Executive Reporting Flow
**Flow ID:** FL-008  
**Derived From:** UC-006 (Leadership Views AI Readiness Metrics)  
**Personas Covered:** Leadership  
**Description:** C-level executives view AI readiness, analyze trends, and export reports for board presentations

**Flow Sequence:**
1. **Entry**: SCR-009 (Leadership Dashboard) / **Default State**
   - Trigger: Leadership user logs in (default landing for Leadership role)
   - Action: Display executive-level KPIs:
     - AI Readiness Score (0-100 gauge with trend)
     - Enrollment Penetration (%)
     - Certification Completion Rate
     - Department Comparison (bar chart)

2. **Step**: SCR-009 / **Default State**
   - Action: Leadership reviews AI-generated insights panel:
     - "Critical NLP skill gap across 60% of teams"
     - "CV skills increasing 15% QoQ (positive trend)"
     - "Teams with 250+ avg credits show 30% higher project success rate"
   - Click on insight for drill-down

3. **Step**: SCR-009 / **Default State**
   - Trigger: Leadership clicks "Department Breakdown" tab
   - Action: Data table shows department metrics:
     - Engineering: 85% enrollment, 68 AI readiness
     - Marketing: 45% enrollment, 42 AI readiness
     - Product: 68% enrollment, 55 AI readiness
   - Sort by score (ascending/descending)

4. **Step**: SCR-009 / **Default State**
   - Trigger: Leadership clicks on specific skill domain (e.g., "NLP Skills")
   - Action: Drill-down to skill heatmap (teams vs. skill proficiency)
   - Color-coded cells (green=proficient, red=gap)

5. **Step**: SCR-009 / **Default State**
   - Action: Leadership reviews ROI analysis panel:
     - Total investment: $150K (certifications + platform)
     - Projected productivity gain: $500K
     - ROI: 233%
     - Project success rate correlation chart (skill level vs. success %)

6. **Step**: SCR-016 (Executive Reports) / **Default State**
   - Trigger: Leadership clicks "Generate Report" button
   - Action: Report configuration modal:
     - Report Type: Dropdown (AI Readiness, Department Comparison, ROI Analysis, Custom)
     - Date Range: Picker (last quarter, last year, custom)
     - Format: PowerPoint (default) or Excel

7. **Step**: SCR-016 / **Loading State**
   - Trigger: Leadership clicks "Generate and Download"
   - Action: Server generates report with charts, graphs, executive summary
   - Progress indicator shows "Generating report... 45%"

8. **Step**: SCR-032 (Report Export) / **Loading State**
   - Action: Report file generated, uploaded to blob storage

9. **Decision Point (Generation Success)**:
   - Success → SCR-016 / **Default State** (download link appears, expires in 7 days)
   - Error → SCR-016 / **Error State** ("Report generation failed. Retry?")

10. **Exit**: SCR-016 / **Default State** with success message
    - Outcome: "Report downloaded: executive-ai-readiness-Q1-2026.pptx"
    - Leadership can share report with board

**Required Interactions:**
- AI Readiness gauge with tooltip (methodology explanation)
- Interactive charts (click to drill-down, hover for details)
- Department table with sorting and filtering
- Insight cards with "Learn More" expansion
- Report configuration modal with preview option (optional)
- Progress bar for report generation (real-time updates via WebSocket)
- Download link with expiration countdown

**Alternative Flows:**
- Custom Report: SCR-016 → Select "Custom" → Multi-select widgets to include → Generate
- Scheduled Reports: SCR-016 → "Schedule Monthly Report" → Email delivery setup
- No Data Available: SCR-009 / **Empty State** ("Minimum 30 days of data required for AI readiness analysis")

---

## 12. Screen State Specifications

*Every screen requires 5 states: Default, Loading, Empty, Error, Validation. States documented per screen below.*

### State Documentation Format

For each screen, the following template is used:

#### SCR-XXX: [Screen Name]

**Default State:**
- Visual description
- Available actions
- Data display

**Loading State:**
- Trigger condition
- Loading indicator type (skeleton screen, spinner, progress bar)
- Disabled interactions

**Empty State:**
- Trigger condition (no data scenario)
- Empty state illustration/icon
- Message copy
- Call-to-action

**Error State:**
- Trigger conditions (network error, validation failure, etc.)
- Error message display (banner, toast, inline)
- Recovery actions (retry, cancel, contact support)

**Validation State** (if applicable - forms only):
- Inline validation triggers
- Error message placement
- Visual indicators (red border, error icon)

---

### SCR-001: Login

**Default State:**
- SSO button prominently displayed: "Sign in with Organization Account"
- Organization logo and platform name at top
- Optional "Forgot Password?" link below button
- Background: Branded gradient or subtle pattern
- No form fields (SSO-only authentication)

**Loading State:**
- Trigger: User clicks SSO button
- SSO button shows spinner, text changes to "Redirecting to SSO..."
- Button disabled (grayed out)
- Overlay dimmed slightly

**Empty State:**
- N/A (login has no empty data scenario)

**Error State:**
- Trigger: SSO authentication fails (invalid credentials, network error, timeout)
- Error banner appears above SSO button:
  - Red background, white text
  - Icon: Alert circle
  - Message: "Authentication failed. Please try again or contact IT support."
- Retry button available (clears error and returns to default)
- SSO button re-enabled

**Validation State:**
- N/A (no form validation, SSO handles credentials)

---

### SCR-002: Individual Dashboard

**Default State:**
- Header: "Welcome back, [User Name]!"
- KPI cards in grid (2x2 on desktop, stacked on mobile):
  - Total Credits Earned
  - Current Global Rank
  - Badges Earned (count)
  - Courses in Progress (count)
- Tabs: Overview, Progress, Recommendations
- **Overview Tab**:  
  - "Courses in Progress" section (card grid, max 6 shown, "View All" link)
  - "Recommended Next Steps" (AI-powered, 3-5 course suggestions)
  - "Recent Achievements" (latest badge, tier-up notification)
  - Quick action FAB (mobile): "Browse Courses"
- Progress visualization (chart showing credit accumulation trend)

**Loading State:**
- Trigger: Page load, data fetching
- Skeleton screens for KPI cards (pulsing gray rectangles)
- Skeleton screens for course cards
- Progress chart shows loading spinner
- "Fetching your dashboard..." message below header

**Empty State:**
- Trigger: New user with 0 courses enrolled, 0 credits
- KPI cards show "0" with gentle gray background
- "Courses in Progress" section:
  - Illustration: Empty folder or learning icon
  - Message: "No courses in progress yet. Let's get started on your AI learning journey!"
  - CTA: "Browse Learning Paths" button (primary, large)
- "Recommended Next Steps" shows 3 beginner courses (system defaults)

**Error State:**
- Trigger: API failure, network timeout
- Error banner at top of dashboard:
  - Red/orange background
  - Icon: Warning triangle
  - Message: "We couldn't load your dashboard. Please refresh or try again later."
  - Retry button

**Validation State:**
- N/A (dashboard is read-only, no forms)

---

### SCR-003: Global Leaderboard

**Default State:**
- Header: "Global Leaderboard" with filter dropdown (This Week, This Month, All-Time)
- Data table:
  - Columns: Rank, User (avatar + name), Total Credits, Tier Badge, Trend (↑ up, ↓ down, — same)
  - Top 3 highlighted with gold/silver/bronze badges
  - Top 100 displayed, paginated (50 per page)
- Current user's rank highlighted if within top 100
- If user not in top 100: Sticky banner below header: "You are rank #145 (+3 from last week)"
- Pagination controls at bottom

**Loading State:**
- Trigger: Page load, filter change, leaderboard update
- Skeleton table rows (pulsing gray bars)
- "Updating leaderboard..." message
- Filter dropdown disabled

**Empty State:**
- Trigger: No users have earned credits yet (unlikely in prod, but possible in fresh deployment)
- Illustration: Trophy icon
- Message: "Leaderboard empty. Be the first to earn credits!"
- CTA: "Start Learning" button

**Error State:**
- Trigger: API failure, network error
- Error banner above table:
  - Message: "Failed to load leaderboard. Please refresh."
  - Retry button
- Table shows placeholder skeleton rows (gray)

**Validation State:**
- N/A (leaderboard is read-only)

---

### SCR-004: User Profile

**Default State:**
- Header: User avatar (large, 128px), name, role, department
- Tabs: Profile Info, Badges, Notification Settings
- **Profile Info Tab**:
  - Form fields (editable): Bio (textarea), Skills (tags input), Interests (tags input), Email (read-only)
  - "Save Changes" button (primary, bottom-right)
  - "Cancel" button (secondary)
- **Badges Tab**: Grid of earned badges (with unlock dates), grayed-out locked badges
- **Notification Settings Tab**: Toggle switches for email/in-app notifications

**Loading State:**
- Trigger: Page load, save changes
- Skeleton screens for form fields
- "Loading your profile..." message

**Empty State:**
- **Badges Tab**: No badges earned yet
  - Illustration: Locked badge icon
  - Message: "You haven't earned any badges yet. Complete courses to unlock achievements!"
  - CTA: "Browse Courses"

**Error State:**
- Trigger: Save failure (network error, validation error from backend)
- Error banner above form:
  - Message: "Failed to save changes. Please try again."
  - Retry button
- Form fields retain user edits (don't clear)

**Validation State:**
- Trigger: User submits form with invalid data
- Inline errors below fields:
  - Bio: Max 500 characters (show character count, red if exceeded)
  - Skills: Max 10 tags (error message if attempting to add more)
- Invalid fields highlighted with red border
- "Save Changes" button disabled until errors cleared

---

### SCR-005: Learning Path Browser

**Default State:**
- Header: "Learning Paths" with search bar
- Filters sidebar (desktop) or drawer (mobile): Difficulty (Beginner/Intermediate/Advanced), Duration (<1 month, 1-3 months, >3 months)
- Path cards in grid (3 columns desktop, 2 tablet, 1 mobile):
  - Card: Thumbnail, Title, Difficulty badge, Duration, Total Credits, Course count, "View Details" button
- "Recommended for You" section at top (AI-powered, 3 paths)
- Pagination if paths > 12

**Loading State:**
- Trigger: Page load, filter change, search
- Skeleton cards (pulsing gray rectangles)
- "Finding learning paths for you..." message

**Empty State:**
- Trigger: No paths match search/filters
- Illustration: Magnifying glass or empty folder
- Message: "No learning paths found. Try adjusting your filters or search terms."
- CTA: "Reset Filters" button

**Error State:**
- Trigger: API failure
- Error banner:
  - Message: "Failed to load learning paths. Please refresh."
  - Retry button

**Validation State:**
- N/A (browser is read-only)

---

### SCR-006: Certification Application

**Default State:**
- Multi-step form (Progress indicator: Step 1 of 3)
- **Step 1 - Select Provider**:
  - Provider dropdown (Coursera, Udacity, Pluralsight)
  - "Next" button
- **Step 2 - Course Details**:
  - Course Name (searchable dropdown from provider catalog)
  - Cost (currency input with $ prefix)
  - "Back" and "Next" buttons
- **Step 3 - Justification**:
  - Business Justification (textarea, 500 char max)
  - "Submit Application" button (primary)

**Loading State:**
- Trigger: Provider catalog loading, form submission
- Loading spinner on provider dropdown ("Fetching courses...")
- Submit button shows spinner, text: "Submitting..."

**Empty State:**
- Trigger: Provider API down, no courses available
- Empty dropdown message: "No courses available from this provider."
- Fallback: "Enter course name manually" text input

**Error State:**
- Trigger: Submission failure (network error, backend validation)
- Error banner above form:
  - Message: "Submission failed. Please check your details and try again."
  - Retry button
- Form retains user input

**Validation State:**
- Trigger: Required fields empty, invalid cost format
- Inline errors:
  - Provider: "Please select a provider"
  - Course Name: "Please select or enter a course"
  - Cost: "Please enter a valid amount (e.g., 299.99)"
  - Justification: "Required (min 50 characters, max 500)"
- Red borders on invalid fields
- Submit button disabled until valid

---

### SCR-007: Manager Dashboard

**Default State:**
- Header: "Team Dashboard" with team name
- KPI cards (4 across desktop):
  - Team Average Credits
  - Team Rank (out of N teams)
  - Completion Rate (%)
  - At-Risk Learners (count, red if >0)
- Tabs: Overview, Team Members, Skill Gaps
- **Overview Tab**:
  - Learning Velocity chart (line chart, credits over time)
  - Skill Distribution chart (radar or bar chart)
  - At-Risk Learners table (if any, click to view detail)
- **Team Members Tab**: Data table (member name, credits, rank, status)
- **Skill Gaps Tab**: Link to SCR-026 (Skill Gap Analysis)

**Loading State:**
- Trigger: Page load, data refresh
- Skeleton KPI cards
- Skeleton charts
- "Loading team data..." message

**Empty State:**
- Trigger: Manager has no team members assigned (rare edge case)
- Illustration: Group icon
- Message: "No team members assigned. Contact HR to update team structure."

**Error State:**
- Trigger: API failure
- Error banner:
  - Message: "Failed to load team dashboard. Refresh to retry."
  - Retry button

**Validation State:**
- N/A (dashboard is read-only)

---

### SCR-010: Course Player

**Default State:**
- Content area: Video player OR text/lab content OR embedded iframe
- Left sidebar (desktop) or drawer (mobile): Course outline (sections, lessons with progress checkmarks)
- Progress bar at top showing % completion
- Navigation: "Previous" and "Next" lesson buttons
- "Take Final Assessment" button (disabled until 100% progress, enabled when ready)
- Auto-save indicator: Small checkmark icon "Progress saved" (appears every 5 min)

**Loading State:**
- Trigger: Page load, video buffering, content fetch
- Video player shows loading spinner
- Content area skeleton screen
- "Loading course content..." message

**Empty State:**
- Trigger: Course has no published materials (admin error)
- Illustration: Empty file icon
- Message: "Course content not available. Please contact support."

**Error State:**
- Trigger: Video playback error, network timeout, API failure
- Error overlay on video player or error banner:
  - Message: "Playback error. Please refresh or try again later."
  - Retry button
- Auto-save failure: Toast notification "Progress auto-save failed. Your progress will be saved when you reconnect."

**Validation State:**
- N/A (player is mostly read-only, except assessment submission via SCR-020)

---

### SCR-020: Assessment

**Default State:**
- Header: "Final Assessment - [Course Name]"
- Timer (if timed): Countdown clock, top-right
- Question area:
  - Question number and total (e.g., "Question 3 of 10")
  - Question text
  - Answer options (multiple choice, code editor, or text input depending on type)
  - "Previous" and "Next" buttons
- Submit button (disabled until all questions answered, enabled when ready)
- Progress indicator: "3 of 10 answered"

**Loading State:**
- Trigger: Assessment grading (after submit)
- Overlay with spinner: "Grading your assessment..."
- Submit button disabled

**Empty State:**
- N/A (assessment always has questions)

**Error State:**
- Trigger: Submission failure, network timeout
- Error modal:
  - Message: "Submission failed. Your answers are saved. Please retry."
  - Retry button
  - Cancel button (returns to assessment, answers preserved)

**Validation State:**
- Trigger: User tries to submit with unanswered questions
- Validation modal:
  - Message: "You have 3 unanswered questions. Submit anyway?"
  - "Go Back" button (closes modal, highlights unanswered questions)
  - "Submit Anyway" button (proceeds with partial submission)

---

### Additional Screens (Abbreviated State Coverage)

Due to length constraints, remaining screens (SCR-008, SCR-009, SCR-011 to SCR-032) follow the same 5-state pattern. Key highlights:

**SCR-008 (Admin Console):**
- Default: Dashboard with admin KPIs (total users, courses, credit transactions)
- Loading: Skeleton cards
- Empty: N/A (always has data)
- Error: API failure banner
- Validation: N/A

**SCR-013 (Content Management), SCR-027 (Create/Edit Learning Path), SCR-028 (Create/Edit Course):**
- All have extensive **Validation States** due to complex forms
- Loading states for saving/publishing
- Error states for API failures and validation errors

**SCR-015 (Anomaly Detection), SCR-031 (Anomaly Investigation):**
- Empty state: "No anomalies detected!" (positive message)
- Error state: Investigation API failure

**All Screens:**
- Consistent error messaging: "Something went wrong. [Actionable instruction]. [Retry button]."
- Consistent loading indicators: Skeleton screens for list/card views, spinners for buttons/actions
- Consistent empty states: Illustration + message + CTA

---

## 13. Export Requirements

### Platform Export Specifications

**Target Platform:** Figma (Design File)  
**Exports Needed:** Design Tokens, Component Library, Screen Mockups, Prototype Flows

---

### A. Design Tokens Export

**File Format:** JSON (Style Dictionary compatible)  
**Export Location:** `.propel/context/Design/tokens.json`

**Token Structure:**
```json
{
  "color": {
    "primary": { "value": "#0078D4" },
    "secondary": { "value": "#10B981" },
    "accent": { "value": "#8B5CF6" },
    "success": { "value": "#10B981" },
    "warning": { "value": "#F59E0B" },
    "error": { "value": "#EF4444" },
    "info": { "value": "#3B82F6" },
    "neutral": {
      "50": { "value": "#F9FAFB" },
      "100": { "value": "#F3F4F6" },
      ...
      "900": { "value": "#111827" }
    }
  },
  "typography": {
    "fontFamily": {
      "heading": { "value": "Inter, sans-serif" },
      "body": { "value": "Inter, sans-serif" },
      "mono": { "value": "Fira Code, monospace" }
    },
    "fontSize": {
      "h1": { "value": "36px" },
      "h2": { "value": "30px" },
      ...
      "caption": { "value": "12px" }
    }
  },
  "spacing": {
    "base": { "value": "8px" },
    "scale": [4, 8, 12, 16, 24, 32, 48, 64]
  },
  "borderRadius": {
    "small": { "value": "4px" },
    "medium": { "value": "8px" },
    "large": { "value": "16px" },
    "full": { "value": "9999px" }
  }
}
```

**Figma Plugin:** Use **Tokens Studio for Figma** to sync tokens bidirectionally

---

### B. Component Library Export

**File Format:** Figma Component Library (shared library)  
**Export Requirement:** All components documented in Section 10 must be created in Figma as reusable components

**Component Organization in Figma:**
```
Component Library
├── Atoms
│   ├── Button (all variants)
│   ├── Input Field (all states)
│   ├── Checkbox, Radio, Toggle
│   ├── Icons (100+ icon set)
│   ├── Badge, Avatar
│   └── Spinner
├── Molecules
│   ├── Search Bar
│   ├── Dropdown/Select
│   ├── Card
│   ├── Toast Notification
│   ├── Progress Bar
│   ├── Breadcrumb
│   ├── Pagination
│   ├── Tab Group
│   ├── Stat Card
│   ├── Empty State
│   └── File Upload
└── Organisms
    ├── Header Navigation
    ├── Sidebar Navigation
    ├── Data Table
    ├── Modal Dialog
    ├── Form (multi-step)
    ├── Chart (Bar, Line, Pie)
    ├── Leaderboard List
    ├── Course Card
    ├── Video Player
    └── Skill Gap Heatmap
```

**Export Format:** Figma file (`.fig`) + Published Figma Library (accessible to development team)

---

### C. Screen Mockups Export

**File Format:** Figma Frames (32 screens × 5 states = 160 frames minimum)  
**Export Requirements:**
- Each of 32 screens (SCR-001 to SCR-032) designed with all 5 states
- Responsive variants: Desktop (1440px), Tablet (768px), Mobile (375px)
- Total frames: 32 screens × 5 states × 3 viewports = 480 frames

**Figma File Organization:**
```
Figma File: AI Learning Platform
├── Page 1: Design System
│   ├── Tokens (color palette, typography, spacing visualized)
│   └── Component Library
├── Page 2: Learner Screens (Desktop)
│   ├── SCR-001: Login (5 states)
│   ├── SCR-002: Individual Dashboard (5 states)
│   ├── SCR-003: Global Leaderboard (5 states)
│   ...
├── Page 3: Manager Screens (Desktop)
│   ├── SCR-007: Manager Dashboard (5 states)
│   ...
├── Page 4: Admin Screens (Desktop)
│   ├── SCR-008: Admin Console (5 states)
│   ...
├── Page 5: Leadership Screens (Desktop)
│   ├── SCR-009: Leadership Dashboard (5 states)
│   ...
├── Page 6: Responsive - Tablet (768px)
│   └── [Key screens only - SCR-001, SCR-002, SCR-003, SCR-005, SCR-007, SCR-009]
└── Page 7: Responsive - Mobile (375px)
    └── [Key screens only - same as tablet]
```

**Export Assets:**
- **For Developers:** Export screen mockups as PNG (2x resolution for high-DPI displays)
- **For Stakeholders:** Export as PDF for review presentations
- **Figma Handoff:** Use **Figma Dev Mode** to provide CSS, dimensions, and asset downloads to developers

---

### D. Prototype Flows Export

**File Format:** Figma Prototype (interactive)  
**Export Requirements:** Create interactive prototypes for all 8 flows (FL-001 to FL-008)

**Prototype Configuration:**
- **Flow Linking:** Connect screens via Figma's prototype mode (arrows showing transitions)
- **Interactions:** Click/tap triggers, hover states, overlays (modals/drawers)
- **Transitions:** Smart Animate for smooth transitions (300ms duration per UXR-403)

**Shareable Prototype Links:**
- **FL-001 (Authentication):** [Figma Prototype Link - Public or Password-protected]
- **FL-002 (Learning Path Enrollment):** [Figma Prototype Link]
- **FL-003 (Course Completion):** [Figma Prototype Link]
- **FL-004 (Certification Application):** [Figma Prototype Link]
- **FL-005 (Team Monitoring):** [Figma Prototype Link]
- **FL-006 (Content Management):** [Figma Prototype Link]
- **FL-007 (Credit Audit):** [Figma Prototype Link]
- **FL-008 (Executive Reporting):** [Figma Prototype Link]

**Prototype Export Format:** Shareable Figma links (for stakeholder review) + local Figma file backup

---

### E. Developer Handoff Specifications

**Handoff Tool:** Figma Dev Mode (preferred) or Zeplin/Avocode (alternative)

**Handoff Requirements:**
1. **Inspect Mode:** Developers can click on any element to view:
   - CSS properties (color, font-size, padding, margin, etc.)
   - Dimensions (width, height)
   - Asset exports (SVG icons, PNG images)
2. **Component Usage:** Show which components are used on each screen (e.g., "This screen uses Button [Primary variant], Card, Progress Bar")
3. **Spacing Specifications:** All spacing documented with pixel values (use 8px grid system)
4. **Color Values:** All colors reference design tokens (no hard-coded hex values in code)

**Export Checklist:**
- [ ] Design tokens exported as JSON
- [ ] Component library created and published in Figma
- [ ] All 32 screens designed with 5 states each
- [ ] Responsive variants for 16 key screens (desktop + tablet + mobile)
- [ ] 8 prototype flows linked and interactive
- [ ] Figma Dev Mode enabled for developer access
- [ ] Screen mockups exported as PNG (2x) for offline reference
- [ ] PDF export of all screens for stakeholder review

---

## 14. Implementation Notes

**Figma File Delivery:**
- **Timeline:** Complete Figma design file within 4 weeks of spec approval
- **Milestone 1 (Week 1):** Design system tokens + component library
- **Milestone 2 (Week 2):** Learner screens (SCR-001 to SCR-006, SCR-010) - 16 P0 screens priority
- **Milestone 3 (Week 3):** Manager/Admin screens (SCR-007, SCR-008, SCR-013)
- **Milestone 4 (Week 4):** Leadership screens + responsive variants + prototypes

**Design Review Process:**
- **Week 1 Checkpoint:** Design system review with stakeholders (approve tokens and components)
- **Week 2 Checkpoint:** Learner screens review (approve key flows before continuing)
- **Week 4 Final Review:** Complete file review, prototype walkthrough, UAT scheduling

**Post-Design Handoff:**
- **Developer Q&A:** Weekly office hours for Figma questions during implementation
- **Design QA:** Designer reviews implemented screens in staging environment for fidelity check
- **Design Debt Tracking:** Log design deviations or constraints discovered during implementation

---

**Document Version:** 1.0  
**Last Updated:** 2026-04-08  
**Status:** Draft - Awaiting Figma Design Execution  
**Next Phase:** Figma Design File Creation and Stakeholder Review

