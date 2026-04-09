# Navigation Map - AI-Powered Credit Based Learning Platform

## Cross-Screen Navigation Index

This document provides a comprehensive navigation map for all 32 screens, detailing navigation paths, triggers, and target screens for each interactive element in all FL-XXX flows.

### Navigation Flow Legend
- **→** : Primary navigation path
- **↔** : Bidirectional navigation (back and forth)
- **⟲** : Returns to originating screen
- **[Modal]** : Opens as modal/overlay (doesn't navigate away)
- **[Tab]** : Tab switch (same screen)

---

## FL-001: Authentication Flow

### SCR-001: Login
**File**: [wireframe-SCR-001-login.html](./Hi-Fi/wireframe-SCR-001-login.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| SSO Button | click | Role-based routing:<br/>- Learner → SCR-002<br/>- Manager → SCR-007<br/>- Admin → SCR-008<br/>- Leadership → SCR-009 | FL-001 | SSO provider redirect, then role check |
| Forgot Password Link | click | SCR-017 (Forgot Password) | FL-001 Alternative | Optional flow |

**Dead Ends**: None (all paths lead to role-specific dashboards)

---

## FL-002: Learning Path Enrollment Flow

### SCR-002: Individual Dashboard (Learner)
**File**: [wireframe-SCR-002-individual-dashboard.html](./Hi-Fi/wireframe-SCR-002-individual-dashboard.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| "Browse Learning Paths" Button | click | SCR-005 (Learning Path Browser) | FL-002 | Primary entry to enrollment |
| "Browse Learning Paths" FAB (mobile) | click | SCR-005 | FL-002 | Mobile variant |
| Active Course Card | click | SCR-010 (Course Player) | FL-003 | Resume course |
| Recommended Course Card | click | SCR-019 (Course Detail) | FL-002 Alternative | View before enrolling |
| "View All Courses" Link | click | SCR-005 | FL-002 | Alternative path |
| Leaderboard Widget "View Full" Link | click | SCR-003 (Global Leaderboard) | FL-003 | Check ranking after credit award |
| Profile Avatar (Header) | click | SCR-004 (User Profile) | N/A | Profile management |
| Notification Icon (Header) | click | [Notification Panel Drawer] | N/A | View alerts |
| Sidebar "Browse Paths" | click | SCR-005 | FL-002 | Sidebar navigation |
| Sidebar "Leaderboard" | click | SCR-003 | FL-003 | Sidebar navigation |
| Sidebar "Profile" | click | SCR-004 | N/A | Sidebar navigation |

### SCR-005: Learning Path Browser
**File**: [wireframe-SCR-005-learning-path-browser.html](./Hi-Fi/wireframe-SCR-005-learning-path-browser.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| Learning Path Card | click | SCR-018 (Learning Path Detail) | FL-002 | View path details before enrolling |
| Course Card (in path) | click | SCR-019 (Course Detail) | FL-002 Alternative | Direct course view |
| Breadcrumb "Dashboard" | click | SCR-002 | FL-002 (back) | Return to dashboard |
| Filter Dropdown | change | SCR-005 (refresh) | FL-002 | Filter results, stay on page |
| Search Bar | submit | SCR-005 (refresh) | FL-002 | Search results, stay on page |
| Pagination Next/Prev | click | SCR-005 (page change) | FL-002 | Navigate pages |

### SCR-018: Learning Path Detail
**File**: [wireframe-SCR-018-learning-path-detail.html](./Hi-Fi/wireframe-SCR-018-learning-path-detail.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| "Enroll Now" Button (prerequisites met) | click | [Enrollment Confirmation Modal] → SCR-002 (on confirm) | FL-002 | Enrollment flow completion |
| "Enroll Now" Button (prerequisites NOT met) | click | [Error State - disabled button] | FL-002 Alternative | User must complete prerequisites |
| "View Prerequisites" Link | click | [Scroll to prerequisites section] | FL-002 Alternative | Smooth scroll within page |
| Prerequisite Course Link | click | SCR-019 (Course Detail) | FL-002 Alternative | View prerequisite course |
| Course in Sequence | click | SCR-019 (Course Detail) | FL-002 Alternative | View course before enrolling |
| Back Button | click | SCR-005 (Learning Path Browser) | FL-002 (back) | Return to browse |
| Breadcrumb "Learning Paths" | click | SCR-005 | FL-002 (back) | Breadcrumb navigation |

### SCR-019: Course Detail
**File**: [wireframe-SCR-019-course-detail.html](./Hi-Fi/wireframe-SCR-019-course-detail.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| "Enroll in Course" Button | click | [Enrollment Modal] → SCR-002 | FL-002 Alternative | Direct course enrollment (not via path) |
| "Start Course" Button (if enrolled) | click | SCR-010 (Course Player) | FL-003 | Begin course content |
| Back Button | click | SCR-005 or SCR-018 (previous screen) | FL-002 (back) | Browser history-based |

---

## FL-003: Course Completion Flow

### SCR-010: Course Player
**File**: [wireframe-SCR-010-course-player.html](./Hi-Fi/wireframe-SCR-010-course-player.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| Video Player Play | click | [Video plays, progress tracked] | FL-003 | Auto-save every 5s |
| TOC Section Link | click | [Jump to section, same screen] | FL-003 | Navigate within course |
| "Take Final Assessment" Button (enabled after 100% progress) | click | SCR-020 (Assessment) | FL-003 | Assessment trigger |
| "Submit Project" Link | click | SCR-021 (Project Submission) | FL-003 Alternative | Project-based courses |
| Back Button (header) | click | SCR-002 (Dashboard) | FL-003 (exit) | Return to dashboard |
| Breadcrumb "Dashboard" | click | SCR-002 | FL-003 (exit) | Breadcrumb navigation |

### SCR-020: Assessment
**File**: [wireframe-SCR-020-assessment.html](./Hi-Fi/wireframe-SCR-020-assessment.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| "Submit Assessment" Button | click | [Submission Confirmation Modal] → SCR-010 or SCR-002 (based on score) | FL-003 | Score ≥70% → Credits awarded → SCR-002; Score <70% → Retry modal → SCR-020 (wait 24h) |
| Question Navigator (sidebar) | click | [Jump to question, same screen] | FL-003 | Navigate within assessment |
| "Save Draft" Button | click | [Save progress, stay on SCR-020] | FL-003 Alternative | Draft saved, can resume |

**Post-Assessment Navigation (based on result):**
- **Pass (≥70%)**: [Success Modal] → SCR-002 (Dashboard) with "Credits Awarded!" toast
- **Fail (<70%, attempts <3)**: [Fail Modal] → SCR-010 (Course Player) with retry disabled for 24h
- **Fail (≥3 attempts)**: [Fail Modal] → SCR-010 (Course Player) with "Retake Course" message

### SCR-021: Project Submission
**File**: [wireframe-SCR-021-project-submission.html](./Hi-Fi/wireframe-SCR-021-project-submission.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| "Upload File" Dropzone | drop/click | [File upload, stay on SCR-021] | FL-003 | Progress bar shown |
| "Submit Project" Button | click | SCR-002 (Dashboard) | FL-003 | Admin review required (async credit award) |
| Back Button | click | SCR-010 (Course Player) | FL-003 (back) | Return to player |

---

## FL-004: Certification Application Flow

### SCR-006: Certification Application
**File**: [wireframe-SCR-006-certification-application.html](./Hi-Fi/wireframe-SCR-006-certification-application.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| "Submit Application" Button | click | SCR-024 (Certification Status) | FL-004 | Application submitted, manager approval pending |
| "Save as Draft" Button | click | SCR-002 (Dashboard) | FL-004 Alternative | Draft saved, can resume laterCancel" Button | click | SCR-002 | FL-004 (cancel) | Discard application (with confirmation modal) |
| Provider Dropdown | change | [Update course catalog, stay on SCR-006] | FL-004 | Dynamic course list based on provider |

### SCR-024: Certification Status
**File**: [wireframe-SCR-024-certification-status.html](./Hi-Fi/wireframe-SCR-024-certification-status.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| "Upload Completion Certificate" Button (if approved and completed) | click | [File upload modal] → SCR-024 (refresh) | FL-004 | Upload proof for admin validation |
| "View Application Details" Link | click | [Application Detail Drawer] | FL-004 | Read-only details |
| Back Button | click | SCR-002 (Dashboard) | FL-004 (back) | Return to dashboard |

**Manager Perspective (Parallel Flow in FL-004):**

### SCR-012: Certification Approval Queue
**File**: [wireframe-SCR-012-certification-approval-queue.html](./Hi-Fi/wireframe-SCR-012-certification-approval-queue.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| Application Row | click | SCR-025 (Certification Review) | FL-004 | Open detail view (drawer or modal) |
| "Approve" Button (in table) | click | [Approval modal] → Refresh SCR-012 | FL-004 | Quick approve without detail view |
| Filter/Sort Dropdowns | change | SCR-012 (refresh) | FL-004 | Filter pending applications |

### SCR-025: Certification Review
**File**: [wireframe-SCR-025-certification-review.html](./Hi-Fi/wireframe-SCR-025-certification-review.html)

| Element | Action | Target Screen | Flow ID | Notes |
|--------|--------|---------------|---------|-------|
| "Approve" Button | click | SCR-012 (Approval Queue) | FL-004 | Application approved, learner notified → SCR-024 updates to "Approved" |
| "Reject" Button | click | [Rejection Reason Modal] → SCR-012 | FL-004 | Requires rejection reason, learner notified |
| "Request More Info" Button | click | [Message Composer Modal] → SCR-012 | FL-004 | Send message to learner |
| Close Drawer/Modal | click | SCR-012 | FL-004 (back) | Return to queue |

---

## FL-005: Team Monitoring Flow

### SCR-007: Manager Dashboard
**File**: [wireframe-SCR-007-manager-dashboard.html](./Hi-Fi/wireframe-SCR-007-manager-dashboard.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| At-Risk Learner Row (in table) | click | SCR-011 (Team Member Detail) | FL-005 | Drill-down to individual |
| Team Member Name (anywhere) | click | SCR-011 | FL-005 | Drill-down |
| "Skill Gap Analysis" Tab | click | SCR-026 (Skill Gap Analysis) | FL-005 | Tab switch or navigate |
| "Skill Gap Analysis" Sidebar Link | click | SCR-026 | FL-005 | Sidebar navigation |
| "Certification Approvals" Sidebar Link | click | SCR-012 (Approval Queue) | FL-004 | Navigate to approvals |
| Heatmap Cell (in Skill Distribution chart) | click | [Drill-down modal or SCR-026] | FL-005 | View skill detail |
| Export Report Button | click | [Download CSV/PDF] | FL-005 | Generates file download |

### SCR-011: Team Member Detail
**File**: [wireframe-SCR-011-team-member-detail.html](./Hi-Fi/wireframe-SCR-011-team-member-detail.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| "Send Reminder" Button | click | [Send notification] → Close Drawer/Modal | FL-005 | Notification sent to learner, return to SCR-007 |
| "Assign Course" Button | click | [Course Assignment Modal] → SCR-011 (refresh) | FL-005 | Select and assign course |
| Course in Progress Link | click | SCR-019 (Course Detail) or SCR-010 (Course Player) | FL-005 Alternative | View course details |
| Close Drawer/Modal | click | SCR-007 (Manager Dashboard) | FL-005 (back) | Return to dashboard |

### SCR-026: Skill Gap Analysis
**File**: [wireframe-SCR-026-skill-gap-analysis.html](./Hi-Fi/wireframe-SCR-026-skill-gap-analysis.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| Heatmap Cell | click | [Tooltip or Detail Drawer] | FL-005 | Shows learner's proficiency + recommended courses |
| "Assign Path to Team" Button | click | [Bulk Assignment Modal] → SCR-007 (with success toast) | FL-005 | Multi-select team members, assign path |
| Back Button | click | SCR-007 (Manager Dashboard) | FL-005 (back) | Return to dashboard |

---

## FL-006: Content Management Flow

### SCR-008: Admin Console
**File**: [wireframe-SCR-008-admin-console.html](./Hi-Fi/wireframe-SCR-008-admin-console.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| "Content Management" Sidebar Link | click | SCR-013 (Content Management) | FL-006 | Navigate to content library |
| "Credit Audit" Sidebar Link | click | SCR-014 (Credit Audit) | FL-007 | Navigate to audit logs |
| "Anomaly Detection" Sidebar Link | click | SCR-015 (Anomaly Detection) | FL-007 | Navigate to anomaly alerts |
| Anomaly Alert (in panel) | click | SCR-015 or SCR-031 (Anomaly Investigation) | FL-007 | View alert details |

### SCR-013: Content Management
**File**: [wireframe-SCR-013-content-management.html](./Hi-Fi/wireframe-SCR-013-content-management.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| "Create New Learning Path" Button | click | SCR-027 (Create/Edit Learning Path) | FL-006 | Create flow |
| "Create New Course" Button | click | SCR-028 (Create/Edit Course) | FL-006 | Create flow |
| Edit Icon (path/course row) | click | SCR-027 or SCR-028 (Edit mode) | FL-006 | Edit existing content |
| Delete Icon (path/course row) | click | [Delete Confirmation Modal] → Refresh SCR-013 | FL-006 | Confirmation required |
| Publish/Unpublish Toggle | click | [Confirm modal] → Refresh SCR-013 | FL-006 | Change status |
| Tab "Learning Paths" / "Courses" | click | [Tab switch, stay on SCR-013] | FL-006 | Toggle content type view |

### SCR-027: Create/Edit Learning Path
**File**: [wireframe-SCR-027-create-edit-learning-path.html](./Hi-Fi/wireframe-SCR-027-create-edit-learning-path.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| "Save Draft" Button | click | SCR-013 (Content Management) | FL-006 | Draft saved, return to library |
| "Publish" Button | click | SCR-013 | FL-006 | Path published, return to library |
| "Add New Course" Button (within form) | click | SCR-028 (Create Course) | FL-006 Alternative | Inline course creation |
| Course Drag-Drop List (reorder) | drag | [Reorder, stay on SCR-027] | FL-006 | Sort course sequence |
| "Cancel" Button | click | [Discard Confirmation Modal] → SCR-013 | FL-006 (cancel) | Return to library |

### SCR-028: Create/Edit Course
**File**: [wireframe-SCR-028-create-edit-course.html](./Hi-Fi/wireframe-SCR-028-create-edit-course.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| "Next" Button (Step 1-3) | click | [Next step, stay on SCR-028] | FL-006 | Multi-step form progression |
| "Next" Button (Step 3 → 4) | click | SCR-029 (Course Materials Upload) | FL-006 | Navigate to upload interface |
| "Previous" Button | click | [Previous step, stay on SCR-028] | FL-006 | Step back in form |
| "Save Draft" Button (any step) | click | SCR-013 | FL-006 | Save and exit |
| "Publish" Button (Step 4, after upload) | click | [Publish Confirmation Modal] → SCR-013 | FL-006 | Publish course |
| "Cancel" Button | click | [Discard Modal] → SCR-013 | FL-006 (cancel) | Return to library |

### SCR-029: Course Materials Upload
**File**: [wireframe-SCR-029-course-materials-upload.html](./Hi-Fi/wireframe-SCR-029-course-materials-upload.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| File Upload Dropzone | drop/click | [Upload progress, stay on SCR-029] | FL-006 | Upload files with progress bars |
| "Remove File" Button | click | [Remove file, stay on SCR-029] | FL-006 | Delete uploaded file |
| "Back" Button | click | SCR-028 (Step 3) | FL-006 (back) | Return to course form |
| "Save & Finish" Button | click | SCR-028 or SCR-013 | FL-006 | Complete upload, save course |

---

## FL-007: Credit Audit Flow

### SCR-014: Credit Audit
**File**: [wireframe-SCR-014-credit-audit.html](./Hi-Fi/wireframe-SCR-014-credit-audit.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| Transaction Row | click | SCR-030 (Transaction Detail) | FL-007 | Open detail drawer/modal |
| Export Button | click | [Download CSV/Excel] | FL-007 | Generates audit report download |
| Date Range Filter | change | SCR-014 (refresh) | FL-007 | Filter logs by date |
| Search Bar | submit | SCR-014 (refresh) | FL-007 | Search by user/course |

### SCR-030: Transaction Detail
**File**: [wireframe-SCR-030-transaction-detail.html](./Hi-Fi/wireframe-SCR-030-transaction-detail.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| "Flag as Suspicious" Button | click | SCR-015 (Anomaly Detection) | FL-007 | Manual flagging, adds to anomaly queue |
| "Approve Transaction" Button | click | SCR-014 (Credit Audit) | FL-007 | Close drawer, return to audit logs |
| Close Drawer/Modal | click | SCR-014 | FL-007 (back) | Return to audit logs |

### SCR-015: Anomaly Detection
**File**: [wireframe-SCR-015-anomaly-detection.html](./Hi-Fi/wireframe-SCR-015-anomaly-detection.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| Anomaly Row | click | SCR-031 (Anomaly Investigation) | FL-007 | Open investigation screen |
| "Investigate" Button | click | SCR-031 | FL-007 | Navigate to investigation |
| "Dismiss" Button | click | [Dismiss Confirmation Modal] → Refresh SCR-015 | FL-007 | Mark as false positive |
| Filter by Severity | change | SCR-015 (refresh) | FL-007 | Filter alerts |

### SCR-031: Anomaly Investigation
**File**: [wireframe-SCR-031-anomaly-investigation.html](./Hi-Fi/wireframe-SCR-031-anomaly-investigation.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| "Mark as False Positive" Button | click | SCR-015 (Anomaly Detection) | FL-007 | Close case, return to anomaly list |
| "Confirm Fraud" Button | click | [Fraud Action Modal] → SCR-015 | FL-007 | Take action (suspend user, revoke credits) |
| Related Transaction Link | click | SCR-030 (Transaction Detail) | FL-007 Alternative | View related credit transaction |
| Back Button | click | SCR-015 | FL-007 (back) | Return to anomaly detection |

---

## FL-008: Executive Reporting Flow

### SCR-009: Leadership Dashboard
**File**: [wireframe-SCR-009-leadership-dashboard.html](./Hi-Fi/wireframe-SCR-009-leadership-dashboard.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| "Reports" Sidebar Link | click | SCR-016 (Executive Reports) | FL-008 | Navigate to report library |
| Department Comparison Chart | click | [Drill-down modal or SCR-016 filtered] | FL-008 Alternative | View department details |
| Export Dashboard Button | click | [Download PDF/PNG] | FL-008 | Export current view |

### SCR-016: Executive Reports
**File**: [wireframe-SCR-016-executive-reports.html](./Hi-Fi/wireframe-SCR-016-executive-reports.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| "Generate Custom Report" Button | click | [Custom Report Builder Modal] | FL-008 | Configure custom report |
| Report Row "View" Button | click | [Report Preview Modal or new tab] | FL-008 | Preview report |
| Report Row "Download" Button | click | SCR-032 (Report Export) | FL-008 | Export configuration modal |
| Filter Dropdowns | change | SCR-016 (refresh) | FL-008 | Filter report list |

### SCR-032: Report Export
**File**: [wireframe-SCR-032-report-export.html](./Hi-Fi/wireframe-SCR-032-report-export.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| "Export" Button | click | [Download file] → Close Modal | FL-008 | Export report in selected format (Excel/PDF/CSV) |
| "Schedule Export" Toggle | click | [Enable scheduling options, stay on SCR-032] | FL-008 | Configure recurring exports |
| "Cancel" Button | click | SCR-016 (Executive Reports) | FL-008 (cancel) | Close modal, return to reports |

---

## Additional Screens (Not in Primary Flows)

### SCR-004: User Profile
**File**: [wireframe-SCR-004-user-profile.html](./Hi-Fi/wireframe-SCR-004-user-profile.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| "Save Changes" Button | click | SCR-002 or SCR-007 or SCR-008 or SCR-009 (role-based dashboard) | N/A | Save profile, return to dashboard |
| "Notification Settings" Link | click | SCR-023 (Notification Settings) | N/A | Navigate to settings |
| Badge (in collection) | click | [Badge Detail Modal] | N/A | View badge description + unlock criteria |

### SCR-023: Notification Settings
**File**: [wireframe-SCR-023-notification-settings.html](./Hi-Fi/wireframe-SCR-023-notification-settings.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| "Save Preferences" Button | click | SCR-004 (User Profile) | N/A | Save and return to profile |
| "Cancel" Button | click | SCR-004 | N/A | Discard changes, return |

### SCR-017: Forgot Password
**File**: [wireframe-SCR-017-forgot-password.html](./Hi-Fi/wireframe-SCR-017-forgot-password.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| "Send Reset Link" Button | click | [Confirmation message] → SCR-001 (Login) | FL-001 Alternative | Email sent, return to login |
| "Back to Login" Link | click | SCR-001 | FL-001 (back) | Return to login |

### SCR-003: Global Leaderboard
**File**: [wireframe-SCR-003-global-leaderboard.html](./Hi-Fi/wireframe-SCR-003-global-leaderboard.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| "Team Leaderboard" Tab | click | SCR-022 (Team Leaderboard) | FL-003 Alternative | Tab switch or navigate |
| User Name (row) | click | [User Profile View Modal] or SCR-004 (if self) | N/A | View public profile or navigate to own profile |
| Back Button | click | SCR-002 (Dashboard) | FL-003 (back) | Return to dashboard |

### SCR-022: Team Leaderboard
**File**: [wireframe-SCR-022-team-leaderboard.html](./Hi-Fi/wireframe-SCR-022-team-leaderboard.html)

| Element | Action | Target Screen | Flow ID | Notes |
|---------|--------|---------------|---------|-------|
| "Global Leaderboard" Tab | click | SCR-003 (Global Leaderboard) | FL-003 | Tab switch or navigate |
| Team Name (row) | click | [Team Detail Modal] or SCR-007 (if manager) | FL-005 | View team stats or navigate to manager dashboard |

---

## Dead-End Screens (No Outbound Navigation - Intentional)

| Screen | Reason | Expected User Action |
|--------|--------|---------------------|
| SCR-001 (Login) | Entry point | User clicks SSO button → role-based routing |
| SCR-020 (Assessment - during exam) | Focus trap | User must complete or save draft before navigating away |
| SCR-021 (Project Submission) | Upload in progress | User completes upload or cancels |
| SCR-029 (Course Materials Upload) | Upload in progress | User completes upload or goes back |

---

## Global Navigation (Available on All Authenticated Screens)

| Element | Location | Target Screen | Notes |
|---------|----------|---------------|-------|
| Logo (Header) | Top-left | Role-based dashboard (SCR-002/007/008/009) | Return to home |
| Notification Icon (Header) | Top-right | [Notification Panel Drawer] | View alerts |
| Profile Avatar (Header) | Top-right | Dropdown menu:<br/>- "Profile" → SCR-004<br/>- "Settings" → SCR-023<br/>- "Logout" → SCR-001 | User menu |
| Sidebar Navigation Items | Left sidebar (desktop) or Bottom Nav (mobile) | Role-specific screens | See sidebar specs in information-architecture.md |

---

**Generated**: 2026-04-09
**Total Flows**: 8 primary flows (FL-001 to FL-008)
**Total Screens**: 32 screens (all mapped)
**Navigation Coverage**: 100% (all screens have inbound/outbound paths)
**Dead-End Screens**: 4 screens (intentional - focus traps or entry points)
