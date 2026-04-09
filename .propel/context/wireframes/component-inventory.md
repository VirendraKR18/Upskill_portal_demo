# Component Inventory - AI-Powered Credit-Based Learning Platform

## Component Specification

**Fidelity Level**: High (Production-Ready Mockups)
**Screen Type**: Responsive Web (Desktop 1440px, Tablet 768px, Mobile 375px)
**Framework**: React 18 + TypeScript + Tailwind CSS
**Design System**: See [designsystem.md](../docs/designsystem.md)

## Component Summary

| Component Name | Type | Screens Used | Priority | Implementation Status |
|---------------|------|-------------|----------|---------------------|
| Header Navigation | Layout | All authenticated screens | High | Wireframed |
| Sidebar Navigation | Layout | All authenticated screens (desktop) | High | Wireframed |
| Bottom Navigation | Layout | All authenticated screens (mobile) | High | Pending |
| KPI Stat Card | Content | SCR-002, SCR-007, SCR-008, SCR-009, SCR-014, SCR-015, SCR-016, SCR-026 | High | Wireframed |
| Course Card | Content | SCR-002, SCR-005, SCR-018 | High | Wireframed |
| Data Table | Content | SCR-007, SCR-012, SCR-014, SCR-015, SCR-022 | High | Wireframed |
| Button (Primary/Secondary) | Interactive | All screens | High | Wireframed |
| Input Field | Interactive | SCR-001, SCR-004, SCR-006, SCR-017, SCR-021, SCR-027, SCR-028, SCR-032 | High | Wireframed |
| Modal Dialog | Feedback | All screens (contextual) | High | Pending |
| Toast Notification | Feedback | All screens | High | Pending |
| Video Player | Content | SCR-010 | High | Wireframed |
| Badge | Content | SCR-002, SCR-003, SCR-004, SCR-012, SCR-015 | Medium | Wireframed |
| Leaderboard List | Content | SCR-003, SCR-022 | High | Wireframed |
| Progress Bar | Feedback | SCR-002, SCR-010, SCR-011, SCR-018, SCR-026, SCR-029 | Medium | Wireframed |
| File Upload Dropzone | Interactive | SCR-021, SCR-029 | Medium | Wireframed |
| Chart (Bar/Line/Doughnut) | Content | SCR-002, SCR-007, SCR-009, SCR-016 | Medium | Wireframed |
| Search Bar | Interactive | SCR-005, SCR-013, SCR-014 | High | Wireframed |
| Filter Dropdown | Interactive | SCR-005, SCR-013, SCR-014, SCR-015, SCR-016 | High | Wireframed |
| Breadcrumb | Navigation | SCR-010, SCR-013, SCR-018, SCR-019, SCR-023, SCR-027 | Medium | Wireframed |
| Tab Group | Navigation | SCR-002, SCR-004, SCR-007, SCR-008, SCR-013 | High | Wireframed |
| Avatar | Content | SCR-003, SCR-004, SCR-007, SCR-011, SCR-012, SCR-022, SCR-025 | Low | Wireframed |
| Skill Gap Heatmap | Content | SCR-007, SCR-026 | Medium | Wireframed |
| Empty State | Feedback | All screens (conditional) | Medium | Pending |
| Loading Skeleton | Feedback | All screens (loading) | Medium | Pending |

## Detailed Component Specifications

### Layout Components

#### Header Navigation
- **Type**: Layout
- **Used In Screens**: All authenticated screens (SCR-002 to SCR-032)
- **Wireframe References**: Embedded in all screen wireframes
- **Description**: Global navigation header with logo, utility icons, and user menu
- **Variants**: 
  - Desktop: Full header with logo left, utility icons right (Notifications, Profile dropdown)
  - Tablet: Logo left, hamburger menu right (for collapsed sidebar)
  - Mobile: Logo center, hamburger left, profile right
- Interactive States**: 
  - Default: bg-white, border-b border-neutral-200, shadow-sm
  - Notification Badge: Red dot indicator (bg-error-500, absolute positioned)
  - Profile Dropdown Open: Dropdown menu visible (bg-white, shadow-lg)
- **Responsive Behavior**:
  - Desktop (1440px): h-16 fixed top-0, px-6, logo + nav + icons
  - Tablet (768px): h-16, logo + hamburger + icons, sidebar hamburger icon visible
  - Mobile (375px): h-14, logo + hamburger + profile icon only
- **Components Within**: Logo (image + text), Notification Icon Button (with badge), Profile Avatar Button (with dropdown), Hamburger Menu Button (tablet/mobile)
- **Implementation Notes**: Sticky positioning (sticky top-0, z-50), React useState for dropdown state, Click outside listener to close dropdown

#### Sidebar Navigation
- **Type**: Layout
- **Used In Screens**: All authenticated screens (desktop/tablet)
- **Wireframe References**: Embedded in all authenticated screen wireframes
- **Description**: Persistent left sidebar with role-specific navigation menu items
- **Variants**:
  - Learner: Dashboard, Browse Paths, Leaderboard, Profile (4 items)
  - Manager: Team Dashboard, Team Members, Approvals, Skill Gaps (4 items)
  - Admin: Admin Console, Content, Audit, Anomalies (4 items)
  - Leadership: AI Readiness, Reports, Analytics (3 items)
- **Interactive States**:
  - Menu Item Default: text-neutral-300, hover:bg-neutral-800
  - Menu Item Active: bg-primary-600, text-white, border-l-4 border-white
  - Menu Item Hover: bg-neutral-800, text-white
  - Collapsed State (desktop optional): Icons only, width 64px
- **Responsive Behavior**:
  - Desktop (1440px): Fixed left sidebar, w-[250px], h-screen, bg-neutral-900, visible by default
  - Tablet (768px): Overlay drawer (z-50, w-64), slide-in from left on hamburger toggle, backdrop overlay
  - Mobile (375px): Hidden completely, replaced by Bottom Navigation
- **Components Within**: Logo (top), Menu Item List (nav links with icons + labels), Collapse Toggle Button (desktop)
- **Implementation Notes**: React Router NavLink for active state, Framer Motion for slide animation (tablet), Focus trap when open (tablet)

#### Bottom Navigation (Mobile)
- **Type**: Layout
- **Used In Screens**: All authenticated screens (mobile only)
- **Wireframe References**: Embedded in mobile wireframe variants
- **Description**: Fixed bottom navigation bar with 5 primary actions
- **Variants**: Role-specific icons (same as sidebar, limited to 5 items)
- **Interactive States**:
  - Item Default: text-neutral-400, icon-only
  - Item Active: text-primary-500, icon + small label
  - Item Tap: scale-95 transform (micro-interaction)
- **Responsive Behavior**:
  - Mobile (375px): Fixed bottom-0, h-16, w-full, bg-white, border-t border-neutral-200, shadow-lg, 5 items flex justify-around
  - Desktop/Tablet: display: none (hidden)
- **Components Within**: Navigation Item (icon + label), Active Indicator (border-top accent)
- **Implementation Notes**: Ensures 44px touch targets, Safe area inset-bottom for iOS notch

### Navigation Components

#### Tab Group
- **Type**: Navigation
- **Used In Screens**: SCR-002 (Dashboard), SCR-007 (Manager Dashboard), SCR-008 (Admin Console), SCR-013 (Content Management)
- **Wireframe References**: [SCR-002](./Hi-Fi/wireframe-SCR-002-individual-dashboard.html), [SCR-007](./Hi-Fi/wireframe-SCR-007-manager-dashboard.html)
- **Description**: Horizontal tab navigation for content organization within a screen
- **Variants**: 
  - Standard (2-5 tabs): "Overview", "Progress", "Recommendations"
  - With Badge Count: "Approvals (3)" - badge shows count in secondary color
- **Interactive States**:
  - Tab Default: text-neutral-600, border-b-2 border-transparent, hover:text-neutral-900
  - Tab Active: text-primary-600, border-b-2 border-primary-600, font-semibold
  - Tab Disabled: text-neutral-400, cursor-not-allowed, opacity-50
- **Responsive Behavior**:
  - Desktop (1440px): Horizontal tabs below page header, full text labels
  - Tablet (768px): Same as desktop, may scroll horizontally if >4 tabs
  - Mobile (375px): Swipeable tabs with scroll indicators, condensed labels
- **Components Within**: Tab Button List, Active Indicator (border-bottom), Badge (optional count)
- **Implementation Notes**: React state for activeTab, Intersection Observer for scroll indicators (mobile), Keyboard navigation (arrow keys)

#### Breadcrumb
- **Type**: Navigation
- **Used In Screens**: SCR-010 (Course Player), SCR-013 (Content Management), SCR-018 (Path Detail), SCR-027 (Create Path)
- **Wireframe References**: [SCR-010](./Hi-Fi/wireframe-SCR-010-course-player.html)
- **Description**: Path-based navigation showing user's location in hierarchy
- **Variants**: 
  - 2-3 levels: "Dashboard > Learning Paths"
  - 4+ levels: "Dashboard > ... > Course Name" (collapse middle items)
- **Interactive States**:
  - Link Default: text-primary-600, hover:underline
  - Current Page: text-neutral-900, no link (plain text)
  - Separator: text-neutral-400 ("/", ">", or "→" icon)
- **Responsive Behavior**:
  - Desktop (1440px): Full breadcrumb path visible, below header
  - Tablet (768px): Full path, may truncate long names with ellipsis
  - Mobile (375px): Hidden, replaced by simple back button in header
- **Components Within**: Link List, Separator Icon, Current Page Text
- **Implementation Notes**: React Router useLocation for path, Truncate text with title attribute for full path on hover

### Content Components

#### KPI Stat Card
- **Type**: Content
- **Used In Screens**: SCR-002 (Individual Dashboard), SCR-007 (Manager Dashboard), SCR-009 (Leadership Dashboard)
- **Wireframe References**: [SCR-002](./Hi-Fi/wireframe-SCR-002-individual-dashboard.html), [SCR-007](./Hi-Fi/wireframe-SCR-007-manager-dashboard.html)
- **Description**: Card displaying single key metric with label, value, and trend indicator
- **Variants**:
  - Standard: Number value + label
  - With Trend: Number + percentage change + up/down arrow icon + color (green/red)
  - With Icon: Leading icon representing metric category
- **Interactive States**:
  - Default: bg-white, border border-neutral-200, rounded-lg, p-6, shadow-sm
  - Hover (if clickable): shadow-md, translate-y-[-2px], cursor-pointer
  - Loading: Skeleton shimmer animation on number area
- **Responsive Behavior**:
  - Desktop (1440px): 4 cards per row (grid-cols-4 gap-6), w-full
  - Tablet (768px): 2 cards per row (grid-cols-2 gap-4)
  - Mobile (375px): 1 card per row (grid-cols-1 gap-4), stacked vertically
- **Components Within**: Icon (optional, top-left), Label (text-sm, text-neutral-600), Value (text-3xl/4xl, font-bold, text-neutral-900), Trend Indicator (text-sm, text-success-600 or text-error-600, with arrow icon)
- **Implementation Notes**: CountUp.js for number animation on load, Loading skeleton with pulse animation, Clickable variant navigates to detail view

#### Course Card
- **Type**: Content
- **Used In Screens**: SCR-005 (Learning Path Browser), SCR-018 (Learning Path Detail), SCR-013 (Content Management)
- **Wireframe References**: [SCR-005](./Hi-Fi/wireframe-SCR-005-learning-path-browser.html)
- **Description**: Card displaying course/learning path with thumbnail, title, metadata, and CTA
- **Variants**:
  - Browse Mode: Thumbnail + Title + Description + Duration + Credits + CTA ("Enroll")
  - In-Progress Mode: + Progress Bar + "Continue" CTA
  - Completed Mode: + Checkmark Badge + "Review" CTA
- **Interactive States**:
  - Default: bg-white, border border-neutral-200, rounded-lg, overflow-hidden
  - Hover: shadow-lg, translate-y-[-4px], border-primary-300
  - Selected: border-2 border-primary-500 (if in selection mode)
- **Responsive Behavior**:
  - Desktop (1440px): Grid 3-4 columns (grid-cols-4 lg:grid-cols-3), aspect-ratio 3/4
  - Tablet (768px): 2 columns (grid-cols-2 gap-4)
  - Mobile (375px): 1 column (grid-cols-1 gap-4), horizontal layout option (image left, content right)
- **Components Within**: 
  - Thumbnail Image (aspect-ratio 16/9, bg-neutral-100 placeholder)
  - Badge Labels (Difficulty: Beginner/Intermediate/Advanced, color-coded)
  - Title (text-lg font-semibold, text-neutral-900)
  - Description (text-sm, text-neutral-600, 2-line clamp)
  - Metadata Row (Duration icon + text, Credits icon + text)
  - Progress Bar (if in-progress, bg-primary-100, fill bg-primary-500)
  - CTA Button (Primary or Secondary based on variant)
- **Implementation Notes**: Lazy load images (Intersection Observer), Skeleton placeholder during load, React.memo for performance (large lists)

#### Data Table
- **Type**: Content
- **Used In Screens**: SCR-007 (Manager Dashboard), SCR-012 (Certification Approval Queue), SCR-014 (Credit Audit), SCR-015 (Anomaly Detection)
- **Wireframe References**: [SCR-007](./Hi-Fi/wireframe-SCR-007-manager-dashboard.html), [SCR-012](./Hi-Fi/wireframe-SCR-012-certification-approval-queue.html)
- **Description**: Tabular data display with sorting, filtering, pagination, and row actions
- **Variants**:
  - Standard Table: Headers + Rows + Pagination
  - With Selection: Checkbox column for multi-select + bulk actions toolbar
  - With Expandable Rows: Chevron icon to expand row for details
  - With Status Badges: Color-coded status cells (Pending/Approved/Rejected)
- **Interactive States**:
  - Row Default: bg-white, border-b border-neutral-100
  - Row Hover: bg-neutral-50
  - Row Selected: bg-primary-50, border-l-4 border-primary-500
  - Header Sort: Arrow icon (up/down), text-primary-600 for active sort
- **Responsive Behavior**:
  - Desktop (1440px): Full table with all columns visible, horizontal scroll if >8 columns
  - Tablet (768px): Hide secondary columns (show "..." button to expand drawer with full details)
  - Mobile (375px): Card view transformation - each row becomes a card with key/value pairs
- **Components Within**: 
  - Table Header (th with sort buttons, sticky top-0)
  - Table Row (tr with hover state)
  - Table Cell (td, truncate text with title tooltip if overflow)
  - Sort Button (in header, icon changes based on sort direction)
  - Pagination (bottom of table, page numbers + prev/next buttons)
  - Action Menu (icon button per row, dropdown with actions like "View", "Edit", "Delete")
  - Checkbox (multi-select mode, in header for "select all")
- **Implementation Notes**: React Table or TanStack Table library, Virtual scrolling for >100 rows, Sticky header (position: sticky), Export to CSV button (optional)

#### Leaderboard List
- **Type**: Content
- **Used In Screens**: SCR-003 (Global Leaderboard), SCR-022 (Team Leaderboard)
- **Wireframe References**: [SCR-003](./Hi-Fi/wireframe-SCR-003-global-leaderboard.html)
- **Description**: Ranked list of users/teams with avatars, names, credits, and trend indicators
- **Variants**:
  - Global Leaderboard: Top 100 users, numbered ranks
  - Team Leaderboard: Top 20 teams, team names
  - "Your Position" Callout: Highlighted row showing current user's rank if not in top 100
- **Interactive States**:
  - Row Default: bg-white, border-b border-neutral-100
  - Row Hover: bg-neutral-50
  - Current User Row: bg-primary-50, font-semibold, border-l-4 border-primary-500
  - Top 3 Ranks: Medal icons (🥇 🥈 🥉 or gradient backgrounds)
- **Responsive Behavior**:
  - Desktop (1440px): Table with columns: Rank, Avatar, Name, Credits, Trend (arrow + %), Actions
  - Tablet (768px): Compact table, hide "Trend" column
  - Mobile (375px): Card layout, rank on left, avatar + name + credits stacked center, trend right
- **Components Within**: 
  - Rank Number (text-lg font-bold, or medal icon for top 3)
  - Avatar (rounded-full, w-10 h-10)
  - User Name (text-neutral-900, font-medium)
  - Credits Value (text-neutral-600, with "credits" label)
  - Trend Indicator (arrow icon + percentage, green for up, red for down)
  - "Your Position" Callout (separate component below table if user not in top 100)
- **Implementation Notes**: Virtualized list for performance (react-window) if >500 rows, Scroll to "Your Position" button, Last updated timestamp displayed

#### Badge
- **Type**: Content
- **Used In Screens**: SCR-002 (Dashboard - achievement badges), SCR-003 (Leaderboard - rank badges), SCR-004 (Profile - badge collection), SCR-005 (Course cards - difficulty badges)
- **Wireframe References**: [SCR-002](./Hi-Fi/wireframe-SCR-002-individual-dashboard.html), [SCR-004](./Hi-Fi/wireframe-SCR-004-user-profile.html)
- **Description**: Visual indicator for achievements, status, or categories
- **Variants**:
  - Achievement Badge: Icon + label (e.g., "ML Beginner", "100 Credits Earned"), bg-accent-500, rounded-full
  - Rank Badge: Tier label (e.g., "Gold", "Platinum"), bg-primary-100, border-primary-500
  - Credit Count Badge: Number in circle (e.g., "250"), bg-success-100, text-success-700
  - Difficulty Badge: Label (Beginner/Intermediate/Advanced), color-coded (Green/Yellow/Red)
  - Status Badge: Small dot (Pending/Approved/Rejected), color-coded
- **Interactive States**:
  - Default: Static display, no interaction
  - Hover (if collection): scale-110, shadow-md, cursor-pointer (shows badge details in tooltip)
  - Locked (not earned): grayscale filter, opacity-50, lock icon overlay
- **Responsive Behavior**:
  - Desktop/Tablet/Mobile: Scales proportionally, maintains aspect ratio
  - Badge Collection Grid: Desktop 6-8 per row, Tablet 4 per row, Mobile 3 per row
- **Components Within**: Icon (SVG or emoji), Label Text, Background Shape (circle, rounded rectangle, or custom SVG badge shape)
- **Implementation Notes**: SVG for custom badge shapes, CSS filter for grayscale (locked state), Tooltip on hover with badge description + unlock criteria

#### Chart (Bar/Line/Doughnut)
- **Type**: Content
- **Used In Screens**: SCR-002 (Dashboard - progress charts), SCR-007 (Manager Dashboard - learning velocity, skill distribution), SCR-009 (Leadership Dashboard - AI readiness, adoption trends)
- **Wireframe References**: [SCR-007](./Hi-Fi/wireframe-SCR-007-manager-dashboard.html), [SCR-009](./Hi-Fi/wireframe-SCR-009-leadership-dashboard.html)
- **Description**: Data visualization charts for metrics and trends
- **Variants**:
  - Bar Chart: Vertical bars for comparisons (e.g., credits by category)
  - Line Chart: Trend over time (e.g., learning velocity past 6 months)
  - Doughnut Chart: Percentage breakdown (e.g., completion rate by path)
  - Heatmap: Skill gap matrix (rows: team members, columns: skills, color: proficiency)
- **Interactive States**:
  - Default: Rendered with design system colors (primary, secondary, accent)
  - Hover: Tooltip appears showing exact values (e.g., "Week 3: 45 credits")
  - Click (if  interactive): Drill-down to detail view or filter table below
  - Loading: Skeleton placeholder (gray bars/circles)
- **Responsive Behavior**:
  - Desktop (1440px): Full-size charts, side-by-side 2-column layout
  - Tablet (768px): Stacked charts, full-width
  - Mobile (375px): Simplified charts (fewer data points), horizontal scroll for wide charts
- **Components Within**: 
  - Chart Container (aspect-ratio 16/9 or 4/3)
  - Chart Canvas (using Chart.js or Recharts library)
  - Legend (horizontal below chart, color-coded labels)
  - Tooltip (on hover, bg-neutral-900, text-white, rounded-md, shadow-lg)
  - Axes Labels (x-axis, y-axis with units)
- **Implementation Notes**: Chart.js or Recharts React library, Responsive container, Accessibility: Underlying data table (visually hidden, for screen readers), Export chart as PNG button (optional)

#### Skill Gap Heatmap
- **Type**: Content
- **Used In Screens**: SCR-007 (Manager Dashboard), SCR-026 (Skill Gap Analysis)
- **Wireframe References**: [SCR-026](./Hi-Fi/wireframe-SCR-026-skill-gap-analysis.html)
- **Description**: Matrix visualization showing team members' proficiency levels across AI skill categories
- **Variants**: Standard (team members × skills, color-coded cells)
- **Interactive States**:
  - Cell Default: Color-coded (Green: Proficient ≥80%, Yellow: Developing 50-79%, Red: Critical Gap <50%)
  - Cell Hover: Tooltip shows exact proficiency score + recommended courses
  - Cell Click: Opens detail drawer with learner's progress in that skill
- **Responsive Behavior**:
  - Desktop (1440px): Full heatmap table, horizontal + vertical scroll if >10 rows/columns
  - Tablet (768px): Horizontal scroll, sticky first column (team member names)
  - Mobile (375px): Transforms to list view: Team member accordion, skills listed with color bars
- **Components Within**: 
  - Table Header (sticky, skill category names)
  - Table Row Header (sticky left, team member names)
  - Heatmap Cell (colored square, 40px × 40px min)
  - Color Legend (bottom of heatmap: Green/Yellow/Red scale)
  - Tooltip (on hover: "Alex Johnson - NLP: 55% (Developing). Recommended: Advanced NLP Course")
- **Implementation Notes**: CSS Grid for layout, Sticky positioning for headers, Tooltip library (e.g., Tippy.js), Color scale from designsystem.md (success-500, warning-500, error-500)

### Interactive Components

#### Button
- **Type**: Interactive
- **Used In Screens**: All screens
- **Wireframe References**: Embedded in all screen wireframes
- **Description**: Primary interactive element for user actions
- **Variants**:
  - Primary: bg-primary-500, text-white, prominent CTA (e.g., "Enroll Now", "Submit")
  - Secondary: bg-white, border border-neutral-300, text-neutral-700, supporting actions (e.g., "Cancel", "Go Back")
  - Tertiary: text-primary-600, no background, minimal (e.g., "Learn More", inline links)
  - Outline: border-2 border-primary-500, text-primary-500, transparent background
  - Ghost: text-primary-600, hover:bg-primary-50, no border (subtle actions)
  - Danger: bg-error-500, text-white, destructive actions (e.g., "Delete Course")
- **Interactive States**:
  - Default: Resting state with base colors
  - Hover: Primary → bg-primary-600, scale-105 (subtle); Secondary → bg-neutral-50; Danger → bg-error-600
  - Active: Primary → bg-primary-700; Secondary → bg-neutral-100
  - Focus: ring-2 ring-primary-300, outline-none (keyboard navigation)
  - Disabled: opacity-50, cursor-not-allowed, bg-neutral-200 (grayed out)
  - Loading: Spinner icon left of text, text changes to "Loading..." or "Submitting...", disabled state
- **Responsive Behavior**:
  - Desktop (1440px): Auto width (px-6 py-3), min-w-[120px]
  - Tablet (768px): Same as desktop
  - Mobile (375px): Full-width option (w-full) for primary CTAs, larger touch targets (min-h-[44px])
- **Components Within**: Button Text (font-medium, text-base), Icon (optional, left or right of text, w-5 h-5), Loading Spinner (animate-spin)
- **Implementation Notes**: Tailwind CSS classes, transition-all duration-300 for smooth hover, disabled={isLoading || isDisabled}, React onClick handler

#### Input Field
- **Type**: Interactive
- **Used In Screens**: SCR-001 (Login), SCR-004 (Profile), SCR-006 (Certification Application), SCR-027 (Create Path), SCR-028 (Create Course)
- **Wireframe References**: [SCR-001](./Hi-Fi/wireframe-SCR-001-login.html), [SCR-004](./Hi-Fi/wireframe-SCR-004-user-profile.html), [SCR-006](./Hi-Fi/wireframe-SCR-006-certification-application.html)
- **Description**: Text input field for user data entry
- **Variants**:
  - Text: Standard single-line input (e.g., Name, Email)
  - Email: Email validation (pattern matching)
  - Password: Masked input with show/hide toggle icon
  - Number: Numeric input with increment/decrement buttons (optional)
  - TextArea: Multi-line input (e.g., Business Justification, Description)
  - Search: Input with search icon left, clear icon right
- **Interactive States**:
  - Default: bg-white, border border-neutral-300, rounded-md, px-4 py-2, text-neutral-900
  - Focused: border-primary-500, ring-2 ring-primary-200, outline-none
  - Filled: border-neutral-400 (subtle change to indicate content)
  - Error: border-error-500, ring-2 ring-error-200, red text for error message below
  - Disabled: bg-neutral-100, text-neutral-500, cursor-not-allowed
  - Read-Only: bg-neutral-50, border-neutral-200, text-neutral-600 (differs from disabled visually)
- **Responsive Behavior**:
  - Desktop (1440px): Width based on content (w-full in form, or constrained like max-w-md)
  - Tablet (768px): w-full in single-column forms
  - Mobile (375px): w-full, min-h-[44px] for touch targets, font-size 16px to prevent zoom on iOS
- **Components Within**: 
  - Label (text-sm font-medium text-neutral-700, mb-1, required asterisk if required)
  - Input Element (<input> or <textarea>)
  - Helper Text (text-sm text-neutral-500, mt-1, optional guidance like "Minimum 8 characters")
  - Error Message (text-sm text-error-500, mt-1, displays on validation error)
  - Icon (optional, left or right side, like search icon or password show/hide eye icon)
  - Character Count (for textarea, text-sm text-neutral-500, "250/500 characters")
- **Implementation Notes**: React Hook Form for validation, onChange debouncing for live validation, Toggle password visibility with useState, Focus on first field in form with useRef, Auto-resize textarea with react-textarea-autosize

#### Search Bar
- **Type**: Interactive
- **Used In Screens**: SCR-005 (Learning Path Browser), SCR-013 (Content Management), SCR-014 (Credit Audit)
- **Wireframe References**: [SCR-005](./Hi-Fi/wireframe-SCR-005-learning-path-browser.html)
- **Description**: Input field with search icon and clear button for filtering content
- **Variants**: Standard (magnifying glass icon left, clear "X" icon right when filled)
- **Interactive States**:
  - Default: bg-white, border border-neutral-300, rounded-md, px-4 py-2 (pl-10 for icon)
  - Focused: border-primary-500, ring-2 ring-primary-200
  - Filled: Clear button visible (X icon), border-neutral-400
  - Searching (loading): Spinner icon right side during debounced search execution
- **Responsive Behavior**:
  - Desktop (1440px): max-w-md, inline with filters
  - Tablet (768px): w-full, top of content area
  - Mobile (375px): w-full, sticky below header when scrolling (optional), font-size 16px
- **Components Within**: 
  - Search Icon (left side, text-neutral-400, w-5 h-5)
  - Input Element (text input, placeholder "Search courses...")
  - Clear Button (X icon, right side, only visible when input has value)
  - Loading Spinner (right side, replaces clear button during search)
- **Implementation Notes**: Debounce input value (300ms) to avoid excessive API calls, React useState for search query, Clear button onClick clears input and resets results, Focus trap on mobile when search is active

#### Filter Dropdown
- **Type**: Interactive
- **Used In Screens**: SCR-005 (Learning Path Browser - Difficulty, Duration, Credits), SCR-013 (Content Management - Status, Type)
- **Wireframe References**: [SCR-005](./Hi-Fi/wireframe-SCR-005-learning-path-browser.html)
- **Description**: Dropdown menu for selecting filter options to narrow search results
- **Variants**:
  - Single Select: Choose one option (e.g., Difficulty: Beginner/Intermediate/Advanced)
  - Multi-Select: Choose multiple options with checkboxes (e.g., Credits: 10-50 + 51-100)
  - With Search: Searchable dropdown for long lists (e.g., Department filter with 50+ options)
- **Interactive States**:
  - Closed Default: bg-white, border border-neutral-300, rounded-md, px-4 py-2, chevron-down icon right
  - Open: Dropdown menu visible below button (bg-white, shadow-lg, border border-neutral-200, max-h-60 overflow-y-auto)
  - Option Hover: bg-neutral-50
  - Option Selected: bg-primary-50, checkmark icon right (if multi-select)
  - Filter Active: badge count on button (e.g., "Difficulty (2)" if 2 selected), border-primary-500
- **Responsive Behavior**:
  - Desktop (1440px): Inline with other filters, dropdown opens below
  - Tablet (768px): Same as desktop
  - Mobile (375px): Opens as full-screen modal or bottom drawer (better UX), larger touch targets
- **Components Within**: 
  - Trigger Button (filter label + chevron icon + badge count if active)
  - Dropdown Menu (list of options, checkboxes for multi-select, radio for single-select)
  - Option Item (label text, checkbox/radio, hover state)
  - Apply Button (for multi-select, "Apply Filters" CTA to close and filter)
  - Clear Filters Link (text-sm text-primary-600, "Clear all" to reset selections)
- **Implementation Notes**: Headless UI Listbox or React Select library, Click outside listener to close dropdown, Keyboard navigation (arrow keys to navigate options, Enter to select, Esc to close), Multi-select state in array (useState or form state)

#### File Upload Dropzone
- **Type**: Interactive
- **Used In Screens**: SCR-021 (Project Submission), SCR-029 (Course Materials Upload)
- **Wireframe References**: [SCR-021](./Hi-Fi/wireframe-SCR-021-project-submission.html), [SCR-029](./Hi-Fi/wireframe-SCR-029-course-materials-upload.html)
- **Description**: Drag-and-drop zone for file uploads with progress tracking
- **Variants**:
  - Standard: Single file upload
  - Multi-File: Upload multiple files with individual progress bars
  - With Preview: Thumbnail previews for images/videos after upload
- **Interactive States**:
  - Default: border-2 border-dashed border-neutral-300, bg-neutral-50, rounded-lg, p-8, text-center
  - Drag Over: border-primary-500, bg-primary-50 (highlight when file dragged over zone)
  - Uploading: Progress bar visible (bg-primary-100, fill bg-primary-500, percentage text)
  - Complete: Green checkmark icon, file name + size displayed
  - Error: border-error-500, error message (e.g., "File exceeds max size (500MB)")
- **Responsive Behavior**:
  - Desktop (1440px): Large dropzone (min-h-[200px]), drag-and-drop + click to browse
  - Tablet (768px): Same as desktop
  - Mobile (375px): Smaller dropzone (min-h-[120px]), click to browse (drag-and-drop less common on mobile)
- **Components Within**: 
  - Upload Icon (cloud-upload icon, w-12 h-12, text-neutral-400)
  - Instructions Text ("Drag & drop files here, or click to browse", text-sm text-neutral-600)
  - File  Input (hidden, triggered by click on dropzone)
  - File List (below dropzone, lists uploaded files with name, size, progress bar, remove button)
  - Progress Bar (linear, width matches file name cell, 0-100%)
  - Remove Button (X icon, text-error-500, removes file from list)
- **Implementation Notes**: React Dropzone library, FileReader API for client-side file preview, Axios or Fetch with upload progress tracking (onUploadProgress callback), Validate file type (accept prop: .pdf,.zip,.mp4) and size before upload, Display thumbnails for image uploads (URL.createObjectURL)

### Feedback Components

#### Modal Dialog
- **Type**: Feedback
- **Used In Screens**: All screens (contextual - confirmations, forms, alerts)
- **Wireframe References**: Embedded contextually in screens (e.g., enrollment confirmation in SCR-018, assessment submission in SCR-020)
- **Description**: Overlay dialog for focused user interaction or information
- **Variants**:
  - Confirmation: Yes/No decision (e.g., "Delete Course?")
  - Form Modal: Inline form submission (e.g., "Add New Path")
  - Success/Error Alert: Informational with single action (e.g., "Credits Awarded!")
  - Full-Detail Modal: Complex content (e.g., Certification Review with full application details)
- **Interactive States**:
  - Hidden: display: none, opacity-0
  - Visible: Fade-in animation (opacity-0 → opacity-100, duration-300ms), backdrop blur
  - Backdrop: bg-black opacity-50, backdrop-blur-sm, z-50
  - Modal Container: bg-white, rounded-lg, shadow-xl, max-w-lg (or max-w-2xl for large modals), z-60, centered
  - Close Button: X icon top-right, text-neutral-400, hover:text-neutral-600
- **Responsive Behavior**:
  - Desktop (1440px): Centered modal, max-w-lg (500px) or max-w-2xl (700px), padding around edges
  - Tablet (768px): max-w-xl (600px), slight padding reduction
  - Mobile (375px): Full-screen transformation (h-screen w-screen), slide-up animation from bottom, no backdrop
- **Components Within**: 
  - Backdrop (overlay, captures clicks to close modal)
  - Modal Container (white box, rounded corners)
  - Header (modal title H2, close button X)
  - Content Area (scrollable if content exceeds viewport height)
  - Footer (action buttons: Primary + Secondary, right-aligned)
- **Implementation Notes**: Headless UI Dialog or React Modal library, Focus trap (focus stays within modal during open), Esc key to close (unless critical modal), Return focus to trigger element on close, Body scroll lock when modal open (prevents background scrolling), ARIA: role="dialog", aria-labelledby, aria-describedby

#### Toast Notification
- **Type**: Feedback
- **Used In Screens**: All screens (global feedback for actions)
- **Wireframe References**: Global component, appears in top-right corner
- **Description**: Temporary notification message for action feedback
- **Variants**:
  - Success: Green background, checkmark icon (e.g., "Course enrolled successfully!")
  - Error: Red background, X icon (e.g., "Failed to save changes. Please try again.")
  - Warning: Yellow background, alert icon (e.g., "Session expiring in 5 minutes")
  - Info: Blue background, info icon (e.g., "Leaderboard will update in 3 minutes")
- **Interactive States**:
  - Hidden: off-screen (translate-x-full), opacity-0
  - Visible: Slide-in from right (translate-x-0), opacity-100, duration-300ms
  - Auto-Dismiss: Fades out after 5 seconds (or 3s for success, 10s for error - configurable)
  - Dismissible: Close button (X icon) to manually close
  - Stacked: Multiple toasts stack vertically with 8px gap
- **Responsive Behavior**:
  - Desktop (1440px): Fixed top-right corner (top-4 right-4), max-w-sm (300px width)
  - Tablet (768px): Same as desktop
  - Mobile (375px): Fixed top-center (top-4, mx-4, w-[calc(100%-2rem)]), slide-down from top instead of right
- **Components Within**: 
  - Icon (left side, color matches variant: success-500, error-500, warning-500, info-500, w-5 h-5)
  - Message Text (text-sm text-white, font-medium)
  - Close Button (X icon, text-white opacity-70, hover:opacity-100)
  - Progress Bar (optional, at bottom of toast, shrinks width from 100% to 0% over auto-dismiss duration)
- **Implementation Notes**: React Toastify or React Hot Toast library, Queue toasts if multiple triggered simultaneously (max 3 visible at once), Z-index 70 (above modals), setTimeout for auto-dismiss, Clear all toasts on navigation (React Router listener)

#### Progress Bar
- **Type**: Feedback
- **Used In Screens**: SCR-002 (Dashboard - course progress), SCR-010 (Course Player - video progress), SCR-021 (Project Submission - upload progress)
- **Wireframe References**: [SCR-002](./Hi-Fi/wireframe-SCR-002-individual-dashboard.html), [SCR-010](./Hi-Fi/wireframe-SCR-010-course-player.html)
- **Description**: Visual indicator of completion percentage
- **Variants**:
  - Linear Bar: Horizontal bar (e.g., course completion 65%)
  - Circular Ring: Donut chart style (e.g., total credits progress toward next tier)
  - Stepped Indicator: Discrete steps (e.g., 1/5 courses complete)
- **Interactive States**:
  - Default: bg-neutral-200 (background bar), h-2 rounded-full
  - Filled: bg-primary-500 (filled portion, width based on percentage, e.g., 65% = width: 65%), transition width duration-500ms ease-in-out (smooth animation)
  - Complete (100%): bg-success-500, pulse animation (subtle)
  - Loading (indeterminate): Animated stripes or shimmer effect (when percentage unknown)
- **Responsive Behavior**:
  - Desktop/Tablet/Mobile: Width scales to container (w-full), height remains consistent (h-2 or h-1 for thin variant)
- **Components Within**: 
  - Background Bar (outer container, full width, bg-neutral-200)
  - Fill Bar (inner bar, width based on percentage, bg-primary-500)
  - Percentage Label (optional, text-xs text-neutral-600, right-aligned above or below bar, "65%")
- **Implementation Notes**: CSS width transition for smooth animation, React state for percentage value (0-100), Indeterminate loading with CSS animation (keyframes: progress-shimmer)

#### Empty State
- **Type**: Feedback
- **Used In Screens**: All screens (conditional - when no data available)
- **Wireframe References**: Embedded in screens (e.g., SCR-005 when no learning paths match filters) 
- **Description**: Placeholder state when content list/table is empty
- **Variants**:
  - No Results (Search/Filter): "No courses match your filters. Try adjusting your search."
  - No Data (First Use): "You haven't enrolled in any learning paths yet. Browse paths to get started!"
  - Error State: "We couldn't load your data. Please try again."
- **Interactive States**: Static (no interaction), provides CTA button for action
- **Responsive Behavior**: Centers in container, scales down illustration on mobile
- **Components Within**: 
  - Illustration (SVG graphic or icon, w-48 h-48 on desktop, w-32 h-32 on mobile, text-neutral-300)
  - Heading (text-lg font-semibold text-neutral-900, "No Courses Found")
  - Description (text-sm text-neutral-600, explains why empty and what to do)
  - CTA Button (Primary, action like "Browse Paths", "Reset Filters", "Reload")
- **Implementation Notes**: Conditional rendering ({data.length === 0 ? <EmptyState /> : <Content />}), CTA button onClick handler (e.g., resetFilters(), navigateToBrowse())

#### Loading Skeleton
- **Type**: Feedback
- **Used In Screens**: All screens (during initial data load)
- **Wireframe References**: Displayed while content loading
- **Description**: Placeholder shimmer effect indicating content is loading
- **Variants**:
  - Card Skeleton: Placeholder for course cards (rectangle for image, lines for text)
  - Table Skeleton: Rows of gray bars mimicking table structure
  - Text Skeleton: Gray lines for headings and paragraphs
- **Interactive States**: Animated pulse/shimmer effect (gradient animation left to right)
- **Responsive Behavior**: Matches layout of actual content (same grid columns)
- **Components Within**: 
  - Skeleton Box (bg-neutral-200, rounded-md, animated pulse or shimmer gradient)
  - Shimmer Gradient (linear-gradient animation, duration 1.5s, infinite loop)
- **Implementation Notes**: CSS @keyframes shimmer animation, Display during isLoading state, React Suspense fallback option, Approximate content structure (e.g., 3 skeleton cards for typical 3-card layout)

---

**Generated**: 2026-04-09
**Total Components**: 25 components (Atoms, Molecules, Organisms)
**Framework**: React 18 + TypeScript + Tailwind CSS
**Component Libraries**: Headless UI, React Hook Form, Chart.js/Recharts, React Dropzone
**Design System**: [designsystem.md](../docs/designsystem.md)
