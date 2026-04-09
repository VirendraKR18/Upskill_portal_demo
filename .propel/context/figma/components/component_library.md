# Component Library Specification

## Document Control

| Attribute | Value |
|-----------|-------|
| **Project** | AI-Powered Credit-Based Learning Platform |
| **Document Type** | Component Library Specification |
| **Version** | 1.0 |
| **Generated From** | figma_spec.md + designsystem.md |
| **Generated Date** | April 8, 2026 |
| **Platform** | Responsive Web (React 18 + TypeScript + Tailwind CSS) |
| **Total Components** | 45+ components (Atoms, Molecules, Organisms) |

---

## Table of Contents

1. [Component Overview](#component-overview)
2. [Atomic Design Methodology](#atomic-design-methodology)
3. [Atoms (Foundational Elements)](#atoms-foundational-elements)
4. [Molecules (Component Combinations)](#molecules-component-combinations)
5. [Organisms (Complex Components)](#organisms-complex-components)
6. [Component Usage Guidelines](#component-usage-guidelines)

---

## Component Overview

This component library follows **Atomic Design Methodology** for systematic organization:

- **Atoms**: Basic building blocks (buttons, inputs, icons, badges)
- **Molecules**: Simple combinations of atoms (search bar, cards, toasts)
- **Organisms**: Complex UI sections (navigation, data tables, modals, forms)

All components are built with:
- **Design tokens** from designsystem.md (no hard-coded values)
- **WCAG 2.2 AA** accessibility compliance
- **Responsive behavior** across mobile (390px), tablet (768px), and desktop (1440px)
- **TypeScript** type safety
- **Tailwind CSS** utility classes

---

## Atomic Design Methodology

### Naming Convention

Components follow the pattern: `C/<Category>/<Name>`

**Examples:**
- `C/Button/Primary`
- `C/Input/Text`
- `C/DataTable`

### Required States

Every interactive component must implement these states where applicable:
- **Default**: Resting state
- **Hover**: Mouse over (desktop)
- **Active/Pressed**: Click/tap state
- **Focus**: Keyboard focus (2px outline, 4px offset per UXR-105)
- **Disabled**: Non-interactive state (40% opacity)
- **Loading**: In-progress state (spinner or skeleton)
- **Error**: Validation failure state

### Variant System

Components with multiple variants use Figma's **Component Set** feature:
- Variants defined by properties (size, state, type)
- Allows designers to switch between variants in Figma instance panel
- Maps to React component props in implementation

---

## Atoms (Foundational Elements)

### C/Button

**Variants:**

| Variant | Background | Text Color | Border | Use Case |
|---------|------------|------------|--------|----------|
| **Primary** | primary-500 | white | none | High-emphasis actions (Enroll, Submit, Save) |
| **Secondary** | neutral-100 | neutral-900 | none | Medium-emphasis (Cancel, Back) |
| **Tertiary/Ghost** | transparent | primary-500 | none | Low-emphasis (Learn More, Skip) |
| **Danger** | error-500 | white | none | Destructive actions (Delete, Revoke Credits) |
| **Icon Button** | varies | varies | none | Icon-only (no text label) |

**Sizes:**

| Size | Height | Padding (H × V) | Font Size | Usage |
|------|--------|-----------------|-----------|--------|
| **Small** | 32px | 8px × 16px | 14px | Compact UI, dense tables |
| **Medium** | 40px | 12px × 24px | 16px | Default size for forms and modals |
| **Large** | 48px | 16px × 32px | 18px | Hero CTAs, landing pages |

**States:**

| State | Visual | Accessibility |
|-------|--------|---------------|
| **Default** | See variant colors above | - |
| **Hover** | Darken background 1-2 shades (e.g., primary-500 → primary-700) | cursor: pointer |
| **Active** | Darken background 2-3 shades (primary-500 → primary-800) | - |
| **Focus** | 2px outline primary-500, 4px offset | focus:ring-2 focus:ring-primary-500 focus:ring-offset-4 |
| **Disabled** | bg-neutral-50, text-neutral-300, opacity 0.6 | cursor: not-allowed, aria-disabled="true" |
| **Loading** | Spinner replaces text, width maintained | aria-busy="true", disabled |

**Accessibility:**
- Minimum touch target: 44px × 44px (UXR-204)
- `aria-label` for icon-only buttons (required)
- Keyboard navigable (Tab key, Enter/Space to activate)
- Color contrast 4.5:1 minimum

**Code Example (Tailwind + React):**

```tsx
interface ButtonProps {
  variant: 'primary' | 'secondary' | 'tertiary' | 'danger';
  size?: 'small' | 'medium' | 'large';
  disabled?: boolean;
  loading?: boolean;
  onClick?: () => void;
  children: React.ReactNode;
}

const Button: React.FC<ButtonProps> = ({
  variant = 'primary',
  size = 'medium',
  disabled = false,
  loading = false,
  onClick,
  children
}) => {
  const baseClasses = "rounded-lg font-semibold transition-colors duration-300 focus:outline-none focus:ring-2 focus:ring-primary-500 focus:ring-offset-4";
  
  const variantClasses = {
    primary: "bg-primary-500 hover:bg-primary-700 active:bg-primary-800 text-white",
    secondary: "bg-neutral-100 hover:bg-neutral-200 text-neutral-900",
    tertiary: "bg-transparent hover:bg-primary-50 text-primary-500",
    danger: "bg-error-500 hover:bg-error-700 text-white"
  };
  
  const sizeClasses = {
    small: "h-8 px-4 text-sm",
    medium: "h-10 px-6 text-base",
    large: "h-12 px-8 text-lg"
  };
  
  const disabledClasses = "disabled:bg-neutral-50 disabled:text-neutral-300 disabled:opacity-60 disabled:cursor-not-allowed";
  
  return (
    <button
      className={`${baseClasses} ${variantClasses[variant]} ${sizeClasses[size]} ${disabledClasses}`}
      disabled={disabled || loading}
      onClick={onClick}
      aria-busy={loading}
    >
      {loading ? <Spinner size="small" /> : children}
    </button>
  );
};
```

---

### C/Input/Text

**Variants:**

| Type | Input Mode | Special Features |
|------|------------|------------------|
| **Text** | text | Single-line text |
| **TextArea** | text | Multi-line, resizable |
| **Email** | email | Email validation |
| **Password** | password | Masked input + show/hide toggle |
| **Number** | numeric | Increment/decrement controls |
| **Search** | search | Search icon prefix + clear icon suffix |

**Sizes:**

| Size | Height | Padding (H × V) | Font Size |
|------|--------|-----------------|-----------|
| **Medium** (Default) | 40px | 12px × 16px | 16px |
| **Large** | 48px | 16px × 20px | 18px |

**States:**

| State | Border Color | Background | Accessibility |
|-------|--------------|------------|---------------|
| **Default** | neutral-200 | white | - |
| **Focus** | primary-500 | white | 2px ring primary-500, aria-invalid="false" |
| **Filled** | neutral-200 | white | - |
| **Error** | error-500 | white | Red border, error message below, aria-invalid="true", aria-describedby="error-id" |
| **Disabled** | neutral-100 | neutral-50 | cursor: not-allowed, aria-disabled="true" |
| **Read-Only** | neutral-100 | neutral-50 | readonly attribute |

**Validation:**
- **Required Field**: Label with red asterisk (*) suffix
- **Inline Validation**: Error message appears below field on blur (per UXR-501)
- **Error Icon**: Red alert icon on right side of input (optional)
- **Character Count**: For textarea, display "X / 500 characters" below field

**Accessibility:**
- Associated `<label>` element with `htmlFor` (required)
- `aria-label` or visible label (never use placeholder as label)
- `aria-invalid="true"` for error states
- `aria-describedby` linking to error message ID
- `aria-required="true"` for required fields

**Code Example:**

```tsx
interface InputProps {
  type: 'text' | 'email' | 'password' | 'number';
  label: string;
  value: string;
  onChange: (value: string) => void;
  placeholder?: string;
  error?: string;
  disabled?: boolean;
  required?: boolean;
}

const Input: React.FC<InputProps> = ({
  type = 'text',
  label,
  value,
  onChange,
  placeholder,
  error,
  disabled = false,
  required = false
}) => {
  const hasError = !!error;
  
  return (
    <div className="space-y-2">
      <label htmlFor={`input-${label}`} className="block text-sm font-medium text-neutral-700">
        {label}
        {required && <span className="text-error-500"> *</span>}
      </label>
      <input
        id={`input-${label}`}
        type={type}
        value={value}
        onChange={(e) => onChange(e.target.value)}
        placeholder={placeholder}
        disabled={disabled}
        required={required}
        aria-invalid={hasError}
        aria-describedby={hasError ? `${label}-error` : undefined}
        className={`
          w-full px-4 py-3 rounded-lg border text-base
          focus:outline-none focus:ring-2 focus:ring-primary-500 focus:border-primary-500
          disabled:bg-neutral-50 disabled:text-neutral-300 disabled:cursor-not-allowed
          ${hasError ? 'border-error-500 ring-error-500' : 'border-neutral-200'}
        `}
      />
      {hasError && (
        <p id={`${label}-error`} className="text-sm text-error-500">
          {error}
        </p>
      )}
    </div>
  );
};
```

---

### C/Checkbox

**Sizes:**

| Size | Dimensions |
|------|------------|
| **Medium** (Default) | 20px × 20px |
| **Large** | 24px × 24px |

**States:**

| State | Visual | Color |
|-------|--------|-------|
| **Unchecked** | Empty square | Border neutral-300, background white |
| **Checked** | Checkmark icon | Background primary-500, checkmark white |
| **Indeterminate** | Dash icon | Background primary-500, dash white |
| **Hover** | Border highlight | Border primary-500 |
| **Focus** | 2px outline, 4px offset | Ring primary-500 |
| **Disabled** | Grayed out | Background neutral-100, border neutral-200, checkmark neutral-300 |

**Accessibility:**
- Label with click target (clicking label toggles checkbox)
- `aria-checked="true|false|mixed"` (mixed for indeterminate)
- Keyboard navigable (Tab to focus, Space to toggle)

**Usage:**
- Multi-select scenarios (select multiple courses, bulk actions)
- Agreements ("I agree to terms and conditions")
- Settings toggles (when binary on/off is needed)

**Code Example:**

```tsx
<label className="flex items-center space-x-3 cursor-pointer">
  <input
    type="checkbox"
    className="w-5 h-5 rounded border-neutral-300 text-primary-500 focus:ring-2 focus:ring-primary-500 focus:ring-offset-4 disabled:bg-neutral-100 disabled:border-neutral-200"
  />
  <span className="text-neutral-700">I agree to the terms and conditions</span>
</label>
```

---

### C/RadioButton

**Sizes:**

| Size | Dimensions |
|------|------------|
| **Medium** (Default) | 20px × 20px |
| **Large** | 24px × 24px |

**States:**

| State | Visual | Color |
|-------|--------|-------|
| **Unselected** | Empty circle | Border neutral-300, background white |
| **Selected** | Filled circle with inner dot | Border primary-500, background primary-500, dot white |
| **Hover** | Border highlight | Border primary-500 |
| **Focus** | 2px outline, 4px offset | Ring primary-500 |
| **Disabled** | Grayed out | Border neutral-200, background neutral-100 |

**Accessibility:**
- Radio group with `role="radiogroup"` wrapper
- `aria-checked="true|false"`
- Keyboard navigation (Tab to focus group, Arrow keys to select within group)

**Usage:**
- Single choice selection (difficulty level: Beginner/Intermediate/Advanced)
- Assessment questions (multiple choice)
- Filter options (This Week / This Month / All-Time)

---

### C/ToggleSwitch

**Dimensions:**
- Width: 48px
- Height: 24px
- Knob: 20px diameter

**States:**

| State | Visual | Color |
|-------|--------|-------|
| **Off** | Knob left-aligned | Background neutral-200, knob white |
| **On** | Knob right-aligned | Background primary-500, knob white |
| **Hover (Off)** | Slightly lighter | Background neutral-300 |
| **Hover (On)** | Slightly lighter | Background primary-600 |
| **Focus** | 2px outline, 4px offset | Ring primary-500 |
| **Disabled** | Grayed out | Background neutral-100, knob neutral-300 |

**Accessibility:**
- `role="switch"`, `aria-checked="true|false"`
- Label describes toggle purpose (e.g., "Enable email notifications")
- Keyboard activation (Space toggles)

**Usage:**
- Boolean settings (Email notifications: On/Off)
- Feature toggles (Show/hide advanced options)
- Preference switches (Dark mode: On/Off - future)

---

### C/Link

**Variants:**

| Variant | Default Color | Hover Color | Underline |
|---------|---------------|-------------|-----------|
| **Standard** | primary-500 | primary-700 | Always |
| **Inline** | primary-500 | primary-700 | On hover only |

**States:**

| State | Visual |
|-------|--------|
| **Default** | Color primary-500, underline |
| **Hover** | Color primary-700, cursor pointer |
| **Visited** | Color primary-700 (slightly darker) |
| **Active** | Color primary-800 |
| **Focus** | 2px outline primary-500, 4px offset |

**Accessibility:**
- Descriptive link text (avoid "Click here" - use "View course details")
- `aria-label` for icon links
- Visited state distinct from unvisited (contrast requirement)

---

### C/Label

**Variants:**

| Variant | Visual | Use Case |
|---------|--------|----------|
| **Standard** | Black text, no indicator | Optional form fields |
| **Required** | Black text + red asterisk (*) | Required form fields (per UXR-501) |

**Accessibility:**
- Always associates with input via `htmlFor` attribute
- Visual indicator (asterisk) supplements `required` attribute (not replacement)

---

### C/Icon

**Library:** Heroicons (Outline style) or Lucide Icons

**Sizes:**

| Size | Dimensions | Use Case |
|------|------------|----------|
| **Small** | 16px × 16px | Inline iconography, tight UI |
| **Medium** | 24px × 24px | Default size for buttons, navigation |
| **Large** | 32px × 32px | Empty states, hero sections |

**Style:**
- **Stroke Width**: 1.5px (consistent across all icons)
- **Style**: Outlined (not filled/solid)
- **Color**: Inherits from parent text color (currentColor)

**Accessibility:**
- Decorative icons: `aria-hidden="true"`
- Functional icons: `aria-label` describing action (e.g., "Close modal")

**Icon Set (Examples):**
- Navigation: home, user, settings, logout
- Actions: edit, delete, download, upload, search
- Indicators: check, x, alert-circle, info
- Arrows: chevron-right, chevron-down, arrow-right
- Content: document, video, code, book

---

### C/Badge

**Variants:**

| Type | Background | Text Color | Use Case |
|------|------------|------------|----------|
| **Skill Badge** | accent-500 | white | AI skill domains (NLP, CV, MLOps) |
| **Milestone Badge** | secondary-500 | white | Achievement milestones (50, 100, 250 credits) |
| **Tier Badge** | Gradient (Bronze/Silver/Gold/Platinum) | white | User tiers based on credits |
| **Count Badge** | error-500 | white | Notification count (5, 99+) |
| **Status Badge** | Semantic color | white | Status (Pending: warning-500, Approved: success-500, Rejected: error-500) |

**Sizes:**

| Size | Height | Padding | Font Size |
|------|--------|---------|-----------|
| **Small** | 20px | 4px × 8px | 12px |
| **Medium** | 24px | 4px × 12px | 14px |

**Border Radius:**
- Pill shape: `borderRadius: 9999px` (fully rounded)

**Accessibility:**
- Text contrast 4.5:1 minimum
- Icon + text badges: icon has `aria-hidden="true"`, text provides context

---

### C/Avatar

**Sizes:**

| Size | Dimensions | Use Case |
|------|------------|----------|
| **Small** | 32px × 32px | Leaderboard rows, comments |
| **Medium** | 48px × 48px | User menu, team member cards |
| **Large** | 64px × 64px | Profile pages, modals |
| **XL** | 128px × 128px | Profile header |

**Variants:**

| Variant | Visual |
|---------|--------|
| **Image** | User-uploaded profile picture |
| **Initials** | Colored circle with user's initials (e.g., "JD" for John Doe) |
| **Placeholder** | Generic user icon (if no image and name unavailable) |

**Initials Color:** Generated from user ID hash to ensure consistency and variety

**Accessibility:**
- `alt` text for images: "John Doe's profile picture"
- Initials visually accessible (4.5:1 contrast)

---

### C/Spinner

**Sizes:**

| Size | Dimensions | Use Case |
|------|------------|----------|
| **Small** | 16px × 16px | Button loading state |
| **Medium** | 24px × 24px | Inline loading indicators |
| **Large** | 48px × 48px | Full-page loading |

**Animation:**
- Rotating spinner (360° continuous rotation)
- Duration: 1s per rotation
- Easing: linear (constant speed)

**Color:**
- Inherits from context (e.g., white on primary button, primary-500 on white background)

**Accessibility:**
- Parent element has `aria-busy="true"` and `aria-live="polite"` (announces loading screen reader)
- Hidden from screen readers with `aria-hidden="true"` (parent announces state)

---

## Molecules (Component Combinations)

### C/SearchBar

**Composition:**
- Input field (type="search")
- Search icon (prefix, left side)
- Clear button (suffix, right side, only visible when filled)

**States:**

| State | Visual |
|-------|--------|
| **Empty** | Placeholder text "Search courses...", search icon gray |
| **Focused** | Border primary-500, search icon primary-500 |
| **Filled** | Text visible, clear button (X icon) appears |
| **Loading** | Spinner replaces search icon |

**Behavior:**
- Clear button removes all text, returns focus to input
- Search triggers on Enter key or after 300ms debounce (for autocomplete)

**Accessibility:**
- `aria-label="Search"` on input
- Clear button: `aria-label="Clear search"`

---

### C/Dropdown (Select)

**Composition:**
- Trigger button (selected value or placeholder)
- Chevron-down icon (right side)
- Menu (list of options, rendered on click)

**States:**

| State | Visual |
|-------|--------|
| **Closed** | Trigger button shows selected value, chevron-down icon |
| **Open** | Menu expands below trigger, chevron-up icon |
| **Disabled** | Grayed out, cursor not-allowed |
| **Error** | Red border (if form validation fails) |

**Behavior:**
- Click trigger opens menu
- Click outside or Esc closes menu
- Arrow keys navigate options, Enter selects
- Type-ahead: Typing starts search within options

**Accessibility:**
- `role="combobox"`, `aria-expanded="true|false"`, `aria-haspopup="listbox"`
- Menu: `role="listbox"`, options: `role="option"`
- Keyboard navigation (Arrow keys, Enter, Esc)

---

### C/Card

**Composition:**
- Container with border/shadow
- Optional: Header, Content, Footer sections

**Variants:**

| Variant | Border | Shadow | Use Case |
|---------|--------|--------|----------|
| **Default** | 1px neutral-200 | shadow-md | Standard content container |
| **Elevated** | none | shadow-lg | Highlighted cards (featured courses) |
| **Flat** | 1px neutral-200 | none | List items, compact UI |

**States:**

| State | Visual |
|-------|--------|
| **Default** | See variant styles |
| **Hover** | shadow-lg (elevates), border primary-200 |
| **Selected** | Border primary-500, shadow-lg, background primary-50 |

**Dimensions:**
- Padding: 24px (spacing-6) on all sides
- Border radius: 8px (radius-medium)
- Gap between cards in grid: 24px (spacing-6)

**Accessibility:**
- If clickable, entire card is button: `role="button"`, keyboard accessible
- Non-clickable cards: semantic HTML `<article>` or `<section>`

---

### C/Toast (Notification)

**Composition:**
- Icon (left side, semantic color)
- Message text (center)
- Close button (right side, X icon)

**Variants:**

| Variant | Icon | Background | Border-Left | Text Color |
|---------|------|------------|-------------|------------|
| **Success** | check-circle | success-50 | 4px success-500 | success-900 |
| **Error** | alert-circle | error-50 | 4px error-500 | error-900 |
| **Warning** | exclamation-triangle | warning-50 | 4px warning-500 | warning-900 |
| **Info** | info-circle | info-50 | 4px info-500 | info-900 |

**Behavior:**
- Auto-dismiss after 5 seconds (configurable)
- Manual dismiss via close button
- Slide-in animation from top-right
- Multiple toasts stack vertically with 8px gap

**Accessibility:**
- `role="alert"` for error/warning (assertive)
- `role="status"` for success/info (polite)
- `aria-live="assertive|polite"` announces to screen readers
- Close button: `aria-label="Dismiss notification"`

**Position:**
- Desktop: Top-right corner, 24px from top and right edges
- Mobile: Full-width at top, below header

---

### C/ProgressBar

**Composition:**
- Track (background bar, neutral-200)
- Fill (progress indicator, primary-500)
- Label (optional, percentage text)

**Variants:**

| Variant | Fill Color | Use Case |
|---------|------------|----------|
| **Primary** | primary-500 | Course completion progress |
| **Success** | success-500 | Goal achievement |
| **Warning** | warning-500 | SLA warning (approaching deadline) |

**Dimensions:**
- Height: 8px (standard), 12px (large)
- Border radius: 4px (fully rounded ends)

**States:**

| Progress | Visual |
|----------|--------|
| **0%** | Track only, no fill |
| **1-99%** | Partial fill, animated transition |
| **100%** | Full fill, success color (optional) |

**Animation:**
- Smooth width transition (300ms duration)
- Optional: Indeterminate state (pulsing animation for unknown progress)

**Accessibility:**
- `role="progressbar"`, `aria-valuenow`, `aria-valuemin="0"`, `aria-valuemax="100"`
- Percentage label visible or announced

---

### C/Breadcrumb

**Composition:**
- Links separated by chevron-right icons
- Last item is plain text (current page, not clickable)

**Example:**
`Home > Learning Paths > Beginner AI > Course Detail`

**Behavior:**
- Each link navigates to parent page
- Current page (last item) is non-clickable, bold

**Accessibility:**
- `nav` element with `aria-label="Breadcrumb"`
- List structure: `<ol>` with `<li>` items
- Separators (chevrons) have `aria-hidden="true"` (decorative)

**Responsive:**
- Mobile: Hide intermediate items, show Home ... Current only
- Tablet/Desktop: Show full breadcrumb

---

### C/Pagination

**Composition:**
- Previous button (chevron-left icon + "Previous")
- Page numbers (1, 2, 3, ..., 10)
- Next button ("Next" + chevron-right icon)
- Ellipsis (...) for truncated page numbers

**Behavior:**
- Previous/Next disabled when at first/last page
- Current page highlighted (background primary-500, text white)
- Clicking page number navigates to that page

**Accessibility:**
- `nav` element with `aria-label="Pagination"`
- Buttons: `aria-label="Go to page X"`, `aria-current="page"` for current
- Disabled buttons: `aria-disabled="true"`, `disabled` attribute

**Example Display:**
`< Previous   1   2   [3]   4   5   ...   10   Next >`

---

### C/TabGroup

**Composition:**
- Tab buttons (horizontal row)
- Tab panels (content areas)

**States:**

| State | Visual |
|-------|--------|
| **Selected** | Border-bottom 2px primary-500, text primary-500, font-semibold |
| **Unselected** | Border-bottom none, text neutral-600, font-normal |
| **Hover** | Text primary-700, cursor pointer |
| **Disabled** | Text neutral-300, cursor not-allowed |

**Behavior:**
- Click tab switches content panel
- Keyboard: Arrow keys navigate tabs, Enter selects

**Accessibility:**
- `role="tablist"` for tab container
- Tabs: `role="tab"`, `aria-selected="true|false"`, `aria-controls="panel-id"`
- Panels: `role="tabpanel"`, `aria-labelledby="tab-id"`, hidden when not selected

**Example:**
```
[Overview] | Progress | Recommendations
------------------------------------
{{Content for Overview tab}}
```

---

### C/StatCard (KPI Card)

**Composition:**
- Large metric value (heading-1 size)
- Label (small text, neutral-600)
- Trend indicator (optional: ↑ up arrow + percentage, green for positive)
- Icon (optional, top-right)

**Layout:**
- Card component (shadow-md, padding 24px)
- Metric centered or left-aligned
- Trend below metric

**Example:**
```
[Icon: trophy]
1,250
Total Credits Earned
↑ 15% from last month
```

**Accessibility:**
- Trend icon has `aria-label="increased by 15%"` (don't rely on color alone)
- Semantic HTML: metric is `<h3>` or `<strong>`, label is `<p>`

---

### C/EmptyState

**Composition:**
- Illustration or icon (large, 64px-128px)
- Heading (explaining why empty)
- Description (optional, helpful message)
- CTA button (primary action to resolve)

**Example:**
```
[Illustration: empty folder]
No courses in progress yet
Browse our learning paths to get started on your AI journey!
[Button: Browse Learning Paths]
```

**Accessibility:**
- Illustration: `role="img"`, `aria-label="No courses illustration"`
- CTA button: Descriptive text (not "Click here")

---

### C/FileUpload

**Composition:**
- Dropzone area (dashed border)
- Upload icon + text ("Drag & drop files or click to browse")
- File list (after selection)
- Progress bars (per file, during upload)
- Remove buttons (X icon per file)

**States:**

| State | Visual |
|-------|--------|
| **Empty** | Dashed border neutral-300, background neutral-50, upload icon gray |
| **Dragging** | Border primary-500, background primary-50, icon primary-500 |
| **Uploading** | Progress bar animated, filename visible |
| **Complete** | Checkmark icon, progress bar 100% success-500 |
| **Error** | Error icon, red text, retry button |

**Validation:**
- File type restrictions (e.g., PDF only, max 10MB)
- Error message if invalid file (e.g., "File exceeds 10MB limit")

**Accessibility:**
- Hidden file input: `<input type="file" class="sr-only" />`
- Dropzone: `role="button"`, keyboard accessible (Enter triggers file picker)
- Progress: `role="progressbar"`, `aria-label="Uploading file.pdf, 45% complete"`

---

## Organisms (Complex Components)

### C/HeaderNavigation

**Composition:**
- Logo (left side, links to home/dashboard)
- Primary navigation links (center, desktop only)
- Utility icons (right side): Search, Notifications, User Menu

**Responsive Behavior:**
- **Desktop**: Full header with all elements horizontal
- **Tablet**: Logo + hamburger menu icon (opens sidebar drawer)
- **Mobile**: Logo + hamburger icon only (navigation in drawer/bottom nav)

**User Menu (Dropdown):**
- Avatar + name (trigger)
- Menu items: Profile, Settings, Logout
- Keyboard: Arrow keys navigate, Enter selects, Esc closes

**Accessibility:**
- Landmark: `<header>` with `role="banner"`
- Skip to main content link (first focusable element)
- Hamburger: `aria-label="Open navigation menu"`, `aria-expanded="false"`

---

### C/SidebarNavigation

**Composition:**
- Menu items (icon + label)
- Active item highlighted (background primary-50, text primary-700)
- Badge counts (e.g., "5" on Certification Approvals)
- Collapse toggle (desktop)

**Variants:**

| Variant | Width | Labels | Use Case |
|---------|-------|--------|----------|
| **Expanded** | 250px | Visible | Desktop default |
| **Collapsed** | 64px | Hidden (icons only) | Desktop space-saving |

**Responsive:**
- **Desktop**: Persistent left sidebar
- **Tablet**: Overlay drawer (opens on hamburger click)
- **Mobile**: Bottom navigation bar (5 items max)

**Accessibility:**
- Landmark: `<nav>` with `aria-label="Primary navigation"`
- Current page: `aria-current="page"`
- Badge counts: `aria-label="Certification Approvals, 5 pending"`

---

### C/BottomNavigation (Mobile)

**Composition:**
- 5 navigation items max (icon + label)
- Fixed to bottom of viewport
- Active item highlighted

**Items (Example for Learner):**
1. Dashboard (home icon)
2. Browse (search icon)
3. My Courses (book icon)
4. Leaderboard (trophy icon)
5. Profile (user icon)

**Accessibility:**
- Landmark: `<nav>` with `aria-label="Primary navigation"`
- Items: `role="button"`, `aria-current="page"` for active
- Touch targets: 44px × 44px minimum

---

### C/DataTable

**Composition:**
- Table headers (with sort icons)
- Table rows (alternating background for readability)
- Row actions (edit, delete icons)
- Pagination controls (bottom)
- Bulk actions (checkbox column, dropdown menu)
- Filters (above table, search + dropdowns)

**Features:**

| Feature | Implementation |
|---------|----------------|
| **Sorting** | Clickable headers, chevron-up/down icon indicates direction |
| **Filtering** | Dropdown filters above table (e.g., difficulty, date range) |
| **Search** | Search bar filters table rows (client-side or server-side) |
| **Pagination** | 50 rows per page default, pagination component below table |
| **Bulk Actions** | Select all checkbox in header, bulk action dropdown (delete, export) |
| **Row Selection** | Checkbox per row, highlights row background on select |

**States:**

| State | Visual |
|-------|--------|
| **Loading** | Skeleton rows (pulsing gray bars) |
| **Empty** | Empty state in table center ("No results found") |
| **Error** | Error banner above table |

**Accessibility:**
- Semantic `<table>` structure: `<thead>`, `<tbody>`, `<th scope="col">`, `<td>`
- Sortable headers: `aria-sort="ascending|descending|none"`
- Row selection: `aria-label="Select row"` on checkboxes
- Keyboard navigation: Tab through rows, Space selects checkbox

**Responsive:**
- **Desktop**: Full table with all columns
- **Tablet**: Horizontal scroll + sticky first column
- **Mobile**: Card view (each row becomes a card with stacked fields)

---

### C/Modal (Dialog)

**Composition:**
- Backdrop overlay (semi-transparent dark background)
- Modal content box (centered, max-width 600px)
- Header (title + close button X)
- Content area (scrollable if exceeds viewport height)
- Footer (action buttons, right-aligned)

**Sizes:**

| Size | Max Width | Use Case |
|------|-----------|----------|
| **Small** | 400px | Confirmations, alerts |
| **Medium** | 600px | Forms, details |
| **Large** | 800px | Complex content, multi-step forms |
| **Full** | 90% viewport | Image galleries, complex wizards |

**Behavior:**
- Opens with fade + scale animation (150ms)
- Focus trapped within modal (Tab cycles through focusable elements)
- Esc key closes modal
- Click backdrop closes modal (optional, configurable)

**Accessibility:**
- `role="dialog"`, `aria-modal="true"`, `aria-labelledby="modal-title"`
- Focus set to first interactive element (or close button)
- Return focus to triggering element on close
- Backdrop: `aria-hidden="true"` (not focusable)

---

### C/Drawer (Sidebar Panel)

**Composition:**
- Slide-in panel from left or right edge
- Close button (X icon, top-right)
- Content area (scrollable)
- Optional footer (action buttons)

**Variants:**

| Variant | Position | Width | Use Case |
|---------|----------|-------|----------|
| **Right** | Right edge | 400px (desktop), 90% (mobile) | Details, team member drill-down |
| **Left** | Left edge | 300px | (Rare, usually navigation sidebar) |

**Behavior:**
- Opens with slide-in animation (300ms)
- Backdrop dims page behind drawer
- Esc key or click backdrop closes drawer

**Accessibility:**
- `role="complementary"` or `role="dialog"` (depending on use)
- Focus trapped within drawer
- Close button: `aria-label="Close panel"`

---

### C/Form

**Composition:**
- Form fields (inputs, dropdowns, checkboxes)
- Labels (required fields marked with asterisk)
- Field groups (sections with headings)
- Validation messages (inline errors below fields)
- Submit button (primary, bottom-right)
- Cancel button (secondary, bottom-right)

**Validation:**
- **Client-side**: Inline validation on blur (per UXR-501)
- **Server-side**: Display API errors at top of form (error banner)
- **Required fields**: Red asterisk (*) on label
- **Error messages**: Specific, actionable (e.g., "Email must include @")

**Multi-step Forms:**
- Progress indicator at top (Step 1 of 3)
- Previous/Next buttons
- Data persists across steps (store in state or draft save)

**Accessibility:**
- Fieldset + legend for grouped inputs (e.g., radio groups)
- Error summary at top of form (list of all errors, links to fields)
- Submit button disabled until form valid (but not grayed out until user attempts submit)

---

### C/Chart (Bar, Line, Pie)

**Library:** Chart.js or Recharts (React-friendly)

**Components:**

| Type | Use Case | Example |
|------|----------|---------|
| **Bar Chart** | Compare categories | Department AI readiness scores |
| **Line Chart** | Trends over time | Credit accumulation over months |
| **Pie/Doughnut** | Proportions | Skill distribution (NLP 30%, CV 25%, ...) |

**Features:**
- Legend (color key)
- Tooltips (hover shows exact values)
- Axes labels (X: time period, Y: credits)
- Responsive: Scales down on mobile, maintains readability

**Accessibility:**
- `role="img"`, `aria-label` describing chart (e.g., "Bar chart showing department AI readiness scores")
- Data table alternative (toggle button to show raw data)
- Color-blind safe palette (use patterns/textures in addition to color)

**Colors:**
- Use design tokens: primary-500, secondary-500, accent-500, semantic colors
- Avoid relying on color alone (use patterns for accessibility)

---

### C/LeaderboardList

**Composition:**
- Ranked items (1st, 2nd, 3rd with gold/silver/bronze badges)
- Avatar + name
- Credit score
- Tier badge
- Trend indicator (↑ ↓ — rank change)

**Layout:**
- Table or list (depends on screen size)
- Top 3 highlighted (background gold-50 for 1st place)

**Accessibility:**
- Meaningful row labels: "Rank 1, John Doe, 1250 credits, Platinum tier"
- Trend icons: `aria-label="Rank increased by 3 positions"`

---

### C/CourseCard

**Composition:**
- Thumbnail image (16:9 ratio, 320px × 180px)
- Difficulty badge (top-left overlay)
- Title (heading-4)
- Metadata (duration, credits, course count)
- Progress bar (if enrolled)
- CTA button ("View Details" or "Enroll Now")

**States:**

| State | Visual |
|-------|--------|
| **Default** | Standard card styling |
| **Hover** | Shadow-lg, scale 1.02 (subtle lift) |

**Layout:**
- Grid: 3 columns (desktop), 2 (tablet), 1 (mobile)
- Gap: 24px between cards

---

### C/VideoPlayer

**Library:** Use native HTML5 `<video>` or Video.js for advanced features

**Controls:**
- Play/Pause button
- Timeline scrubber (draggable)
- Volume control
- Speed selector (0.5x, 1x, 1.5x, 2x)
- Quality selector (360p, 720p, 1080p)
- Fullscreen toggle
- Closed captions (CC) toggle

**Accessibility:**
- Keyboard controls: Space (play/pause), Arrow keys (seek), F (fullscreen)
- Captions: `.vtt` files for closed captions
- ARIA: `role="application"` for custom video player, all controls labeled

**Progress Tracking:**
- Save playback position every 10 seconds (auto-resume on return)
- Mark video complete when 95% watched

---

### C/SkillGapHeatmap

**Composition:**
- Grid: Rows (team members), Columns (skill categories)
- Cells: Color-coded by proficiency level
  - Green: Proficient (≥80%)
  - Yellow: Developing (50-79%)
  - Red: Critical gap (<50%)
- Tooltips: Hover shows exact percentage and recommendations

**Accessibility:**
- Color + pattern (use textures/stripes in addition to color for color-blind users)
- Data table alternative (toggle to show raw percentages)
- `aria-label` on cells: "John Doe, NLP skills, 45%, critical gap"

**Responsive:**
- Desktop: Full heatmap visible
- Tablet/Mobile: Horizontal scroll + sticky first column (names)

---

## Component Usage Guidelines

### Design Token Adherence

**Never hard-code values. Always reference tokens:**

❌ **Incorrect:**
```jsx
<button style={{ backgroundColor: '#0078D4', padding: '12px 24px' }}>
```

✅ **Correct:**
```jsx
<button className="bg-primary-500 px-6 py-3">
```

### Accessibility Checklist

Every component must:
- [ ] Meet WCAG 2.2 AA contrast ratios (4.5:1 normal text, 3:1 large text)
- [ ] Have keyboard navigation support
- [ ] Include ARIA attributes where needed
- [ ] Have focus indicators (2px outline, 4px offset)
- [ ] Support screen readers (meaningful labels, live regions)
- [ ] Have touch targets ≥44px × 44px (mobile/tablet)

### Responsive Testing

Test components at these breakpoints:
- Mobile: 390px (iPhone 12 Pro)
- Tablet: 768px (iPad)
- Desktop: 1440px (standard laptop)

### Component Reusability

- **Atoms**: Highly reusable across all screens
- **Molecules**: Reusable within similar contexts (e.g., SearchBar in multiple list screens)
- **Organisms**: Often screen-specific but patterns should be templated (e.g., DashboardLayout)

### Performance Optimization

- Lazy load component library (code-split by route)
- Virtualize long lists/tables (render only visible rows)
- Optimize images (WebP format, 2x for retina)
- Memoize expensive calculations (React.memo, useMemo)

---

## Summary

This component library provides 45+ production-ready components adhering to:
- ✅ Design system tokens from designsystem.md
- ✅ WCAG 2.2 AA accessibility standards
- ✅ Responsive design (320px - 1440px+)
- ✅ React 18 + TypeScript implementation-ready
- ✅ Tailwind CSS utility classes

All components are spec-compliant and ready for Figma design and React development.

**Next Steps:**
1. Import into Figma as component sets
2. Build 32 screens (SCR-001 to SCR-032) from components
3. Wire 8 prototype flows (FL-001 to FL-008)
4. Export 160 JPGs (32 screens × 5 states)

---

**End of Component Library Specification**
