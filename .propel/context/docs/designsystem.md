# Design System Reference

## Document Control

| Attribute | Value |
|-----------|-------|
| **Project Name** | AI-Powered Credit-Based Learning Platform |
| **Document Type** | Design System & Component Specification |
| **Version** | 1.0 |
| **Status** | Draft - Awaiting Design Execution |
| **Created** | 2026-04-08 |
| **Last Updated** | 2026-04-08 |
| **Author(s)** | Design Team |
| **Stakeholders** | Product Team, Engineering Team, UX Team |

---

## Table of Contents

1. [Design System Overview](#1-design-system-overview)
2. [Brand Guidelines](#2-brand-guidelines)
3. [Design Tokens](#3-design-tokens)
4. [Typography](#4-typography)
5. [Color System](#5-color-system)
6. [Spacing & Layout](#6-spacing--layout)
7. [Component Specifications](#7-component-specifications)
8. [Iconography](#8-iconography)
9. [Accessibility Standards](#9-accessibility-standards)
10. [Responsive Design Grid](#10-responsive-design-grid)
11. [Animation & Motion](#11-animation--motion)
12. [Implementation Guidelines](#12-implementation-guidelines)

---

## 1. Design System Overview

### Purpose
This design system provides a comprehensive, scalable foundation for designing and building the AI-Powered Credit-Based Learning Platform. It ensures visual consistency, accelerates development, and maintains accessibility standards across all screens and components.

### Principles

**1. Clarity First**
- Prioritize readability and comprehension over decoration
- Use whitespace generously to create visual breathing room
- Ensure every UI element has a clear purpose

**2. Accessible by Default**
- WCAG 2.2 Level AA compliance minimum (per UXR-101)
- 4.5:1 contrast ratio for normal text, 3:1 for large text (per UXR-102)
- Keyboard navigation for all interactive elements (per UXR-103)

**3. Scalable & Consistent**
- Systematic use of design tokens (colors, spacing, typography)
- Component-driven architecture (Atomic Design methodology)
- Responsive across all viewport sizes (320px to 1920px+)

**4. Performance-Oriented**
- Optimized asset exports (SVG for icons, WebP for images)
- Minimal animation complexity (60fps target)
- Lazy loading for heavy components

### Design System Stack

| Layer | Technology | Purpose |
|-------|------------|---------|
| **Design Tool** | Figma | UI design, prototyping, design tokens |
| **Token Management** | Tokens Studio for Figma | Design token creation and export |
| **Token Build** | Style Dictionary | Transform tokens to CSS variables, Tailwind config |
| **Component Library** | React 18 + TypeScript | Component implementation |
| **Styling** | Tailwind CSS 3.4+ | Utility-first CSS framework |
| **Component Base** | shadcn/ui or Ant Design | Pre-built accessible components |

---

## 2. Brand Guidelines

### Brand Identity

**Platform Name:** AI Learning Platform (short form) / AI-Powered Credit-Based Learning Platform (long form)

**Tagline:** "Systematically upskill your team in AI technologies"

**Brand Voice:**
- **Encouraging**: Celebrate progress, gamification creates positive reinforcement
- **Professional**: Enterprise B2B tone, avoid overly casual language
- **Empowering**: Learners take ownership of their AI upskilling journey
- **Data-Driven**: Use metrics and insights to demonstrate value

**Content Tone Guidelines:**
- Use second person ("You've earned 50 credits!") for learner-facing content
- Use first person plural ("Let's explore AI skills") for collaborative actions
- Avoid jargon; explain AI terms with tooltips/inline help (per UXR-003)
- Error messages are helpful, not punitive ("Oops! Try again." vs "Error: Invalid input")

### Logo Usage

**Primary Logo:**
- Logotype: "AI Learning Platform" in primary typeface (Inter Bold)
- Logo mark: Abstract neural network icon or stylized "AI" monogram
- Minimum size: 120px width (digital), 1 inch width (print)
- Clear space: 16px padding on all sides (minimum)

**Logo Variations:**
- **Full Color**: Primary brand color (#0078D4) logo on white/light backgrounds
- **Reversed**: White logo on dark backgrounds (neutral-900 or darker)
- **Monochrome**: Neutral-900 logo for grayscale contexts

**Incorrect Usage (Avoid):**
- Stretching or distorting logo proportions
- Applying shadows, outlines, or effects
- Placing logo on low-contrast backgrounds
- Using logo smaller than minimum size

### Imagery Style

**Photography:**
- **Subject Matter**: Diverse teams collaborating, learners engaged with technology, modern office environments
- **Composition**: Natural lighting, minimal depth of field, candid (not overly staged)
- **Editing**: Slightly warm color grading, high contrast, vibrant (not muted)
- **Representation**: Showcase diversity in age, gender, ethnicity, ability

**Illustrations:**
- **Style**: Minimalist, geometric, abstract (not overly literal)
- **Use Cases**: Empty states, onboarding, achievement celebrations, error states
- **Color Palette**: Primary and secondary brand colors with neutral backgrounds
- **Line Weight**: Consistent 2-3px stroke weight

**Icons** (see Section 8 for detailed specs):
- Outlined style with 1.5px stroke weight
- 24px × 24px default size on 28px grid

---

## 3. Design Tokens

Design tokens are the core atomic values of the design system. All visual decisions should reference tokens, not hard-coded values.

### Token Categories

1. **Color**: Brand colors, semantic colors, neutral grays
2. **Typography**: Font families, sizes, weights, line heights
3. **Spacing**: Base unit (8px) and scale
4. **Border Radius**: Rounding scale for buttons, cards, inputs
5. **Shadows**: Elevation levels
6. **Transitions**: Animation durations and easing functions

### Token Export Format (JSON)

```json
{
  "color": {
    "primary": {
      "50": { "value": "#E6F2FF" },
      "100": { "value": "#B3DBFF" },
      "200": { "value": "#80C4FF" },
      "300": { "value": "#4DADFF" },
      "400": { "value": "#1A96FF" },
      "500": { "value": "#0078D4" },
      "600": { "value": "#0060A8" },
      "700": { "value": "#00487C" },
      "800": { "value": "#003050" },
      "900": { "value": "#001824" }
    },
    "secondary": {
      "50": { "value": "#E6FAF2" },
      "100": { "value": "#B3F0D9" },
      "200": { "value": "#80E7C0" },
      "300": { "value": "#4DDDA7" },
      "400": { "value": "#1AD48E" },
      "500": { "value": "#10B981" },
      "600": { "value": "#0D9467" },
      "700": { "value": "#0A6F4D" },
      "800": { "value": "#074A33" },
      "900": { "value": "#03251A" }
    },
    "accent": {
      "500": { "value": "#8B5CF6" }
    },
    "success": {
      "500": { "value": "#10B981" }
    },
    "warning": {
      "500": { "value": "#F59E0B" }
    },
    "error": {
      "500": { "value": "#EF4444" }
    },
    "info": {
      "500": { "value": "#3B82F6" }
    },
    "neutral": {
      "50": { "value": "#F9FAFB" },
      "100": { "value": "#F3F4F6" },
      "200": { "value": "#E5E7EB" },
      "300": { "value": "#D1D5DB" },
      "400": { "value": "#9CA3AF" },
      "500": { "value": "#6B7280" },
      "600": { "value": "#4B5563" },
      "700": { "value": "#374151" },
      "800": { "value": "#1F2937" },
      "900": { "value": "#111827" }
    }
  },
  "spacing": {
    "base": { "value": "8px" },
    "0": { "value": "0px" },
    "1": { "value": "4px" },
    "2": { "value": "8px" },
    "3": { "value": "12px" },
    "4": { "value": "16px" },
    "5": { "value": "20px" },
    "6": { "value": "24px" },
    "8": { "value": "32px" },
    "10": { "value": "40px" },
    "12": { "value": "48px" },
    "16": { "value": "64px" },
    "20": { "value": "80px" }
  },
  "borderRadius": {
    "none": { "value": "0px" },
    "small": { "value": "4px" },
    "medium": { "value": "8px" },
    "large": { "value": "12px" },
    "xlarge": { "value": "16px" },
    "full": { "value": "9999px" }
  },
  "fontSize": {
    "xs": { "value": "12px" },
    "sm": { "value": "14px" },
    "base": { "value": "16px" },
    "lg": { "value": "18px" },
    "xl": { "value": "20px" },
    "2xl": { "value": "24px" },
    "3xl": { "value": "30px" },
    "4xl": { "value": "36px" },
    "5xl": { "value": "48px" }
  },
  "fontWeight": {
    "normal": { "value": "400" },
    "medium": { "value": "500" },
    "semibold": { "value": "600" },
    "bold": { "value": "700" }
  },
  "lineHeight": {
    "tight": { "value": "1.25" },
    "normal": { "value": "1.5" },
    "relaxed": { "value": "1.75" }
  },
  "boxShadow": {
    "none": { "value": "none" },
    "sm": { "value": "0 1px 2px 0 rgba(0, 0, 0, 0.05)" },
    "base": { "value": "0 1px 3px 0 rgba(0, 0, 0, 0.1), 0 1px 2px 0 rgba(0, 0, 0, 0.06)" },
    "md": { "value": "0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -1px rgba(0, 0, 0, 0.06)" },
    "lg": { "value": "0 10px 15px -3px rgba(0, 0, 0, 0.1), 0 4px 6px -2px rgba(0, 0, 0, 0.05)" },
    "xl": { "value": "0 20px 25px -5px rgba(0, 0, 0, 0.1), 0 10px 10px -5px rgba(0, 0, 0, 0.04)" }
  },
  "transition": {
    "fast": { "value": "150ms" },
    "base": { "value": "300ms" },
    "slow": { "value": "500ms" }
  }
}
```

### Token Usage in Code (CSS Variables)

```css
/* Auto-generated from tokens.json via Style Dictionary */
:root {
  --color-primary-500: #0078D4;
  --color-secondary-500: #10B981;
  --color-accent-500: #8B5CF6;
  --color-success-500: #10B981;
  --color-warning-500: #F59E0B;
  --color-error-500: #EF4444;
  --color-info-500: #3B82F6;
  
  --spacing-base: 8px;
  --spacing-2: 8px;
  --spacing-4: 16px;
  --spacing-6: 24px;
  
  --border-radius-medium: 8px;
  --border-radius-large: 12px;
  
  --font-size-base: 16px;
  --font-weight-semibold: 600;
  
  --box-shadow-md: 0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -1px rgba(0, 0, 0, 0.06);
  
  --transition-base: 300ms;
}

/* Usage Example */
.button-primary {
  background-color: var(--color-primary-500);
  padding: var(--spacing-3) var(--spacing-6);
  border-radius: var(--border-radius-medium);
  transition: all var(--transition-base) ease-in-out;
}
```

### Token Usage in Tailwind Config

```javascript
// tailwind.config.js (auto-generated from tokens.json)
module.exports = {
  theme: {
    extend: {
      colors: {
        primary: {
          50: '#E6F2FF',
          100: '#B3DBFF',
          // ... all shades
          500: '#0078D4', // Default
          900: '#001824',
        },
        secondary: {
          500: '#10B981',
        },
        accent: {
          500: '#8B5CF6',
        },
        success: '#10B981',
        warning: '#F59E0B',
        error: '#EF4444',
        info: '#3B82F6',
      },
      spacing: {
        '1': '4px',
        '2': '8px',
        '3': '12px',
        '4': '16px',
        '6': '24px',
        '8': '32px',
        '12': '48px',
        '16': '64px',
      },
      borderRadius: {
        'small': '4px',
        'medium': '8px',
        'large': '12px',
        'xlarge': '16px',
      },
    }
  }
}
```

---

## 4. Typography

### Type Scale

Typography establishes hierarchy and improves readability. The platform uses a modular type scale based on a 1.25 ratio (Major Third).

| Style | Size | Weight | Line Height | Usage |
|-------|------|--------|-------------|-------|
| **Heading 1** | 36px (2.25rem) | Bold (700) | 1.25 (tight) | Page titles (Dashboard, Admin Console) |
| **Heading 2** | 30px (1.875rem) | Bold (700) | 1.3 | Section headings (Leaderboard, Team Overview) |
| **Heading 3** | 24px (1.5rem) | Semibold (600) | 1.35 | Card titles, widget headers |
| **Heading 4** | 20px (1.25rem) | Semibold (600) | 1.4 | Subsection headings, modal titles |
| **Heading 5** | 18px (1.125rem) | Semibold (600) | 1.45 | List item titles, table headers |
| **Body Large** | 18px (1.125rem) | Normal (400) | 1.5 (normal) | Prominent body text, intro paragraphs |
| **Body** | 16px (1rem) | Normal (400) | 1.5 (normal) | Default body text, descriptions |
| **Body Small** | 14px (0.875rem) | Normal (400) | 1.5 | Secondary text, helper text |
| **Caption** | 12px (0.75rem) | Normal (400) | 1.5 | Timestamps, metadata, footnotes |
| **Button Text** | 16px (1rem) | Semibold (600) | 1.0 | Button labels |
| **Link** | 16px (1rem) | Medium (500) | 1.5 | Inline links (underlined) |

### Font Families

**Primary Typeface:** **Inter** (Google Fonts)
- Modern, highly legible sans-serif
- Excellent web font performance (variable font support)
- Wide character set (support for multiple languages)
- Usage: All UI text (headings, body, buttons)

**Monospace Typeface:** **Fira Code** (Google Fonts)
- Used for code snippets, API keys, JSON payloads
- Programming ligatures for improved readability
- Usage: Code blocks, technical documentation, developer-facing screens

**Fallback Stack:**
```css
font-family: 'Inter', -apple-system, BlinkMacSystemFont, 'Segoe UI', 
             'Roboto', 'Helvetica Neue', Arial, sans-serif;

font-family-mono: 'Fira Code', 'Courier New', Courier, monospace;
```

### Type Rendering

**Font Rendering CSS:**
```css
body {
  font-family: 'Inter', -apple-system, BlinkMacSystemFont, 'Segoe UI', sans-serif;
  font-size: 16px;
  line-height: 1.5;
  font-weight: 400;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-rendering: optimizeLegibility;
}
```

### Accessibility Compliance (UXR-102)

**Minimum Text Sizes:**
- Body text: 16px minimum (per WCAG 2.2)
- Mobile body text: 16px (prevent zoom on iOS)
- Caption text: 12px minimum (use sparingly, ensure sufficient contrast)

**Contrast Ratios:**
- Normal text (< 18px): 4.5:1 minimum
- Large text (≥ 18px or ≥ 14px bold): 3:1 minimum
- Test all color combinations with contrast checker

### Responsive Typography

**Mobile (320px - 767px):**
- Scale down heading sizes by 10-20% to prevent overflow
- H1: 30px (instead of 36px)
- H2: 24px (instead of 30px)
- Body: 16px (maintain for readability)

**Tablet (768px - 1023px):**
- Use desktop scale with slightly tighter line height if needed

**Desktop (1024px+):**
- Full type scale as defined above

---

## 5. Color System

### Color Palette Philosophy

The color system is designed for:
1. **Brand Recognition**: Primary blue (#0078D4) establishes platform identity
2. **Semantic Clarity**: Success (green), warning (orange), error (red), info (blue) follow universal conventions
3. **Accessibility**: All color combinations meet WCAG 2.2 AA contrast requirements (4.5:1 for normal text)
4. **Scalability**: 9-shade scales for primary/secondary allow flexible dark/light variants

### Primary Colors

**Primary Blue** (Brand Color)
- **Purpose**: CTAs, links, active states, progress indicators
- **Shades**:
  - `primary-50`: `#E6F2FF` (very light backgrounds, hover states)
  - `primary-100`: `#B3DBFF` (light backgrounds)
  - `primary-500`: `#0078D4` (Default - buttons, links)
  - `primary-700`: `#00487C` (hover/active states)
  - `primary-900`: `#001824` (very dark text)

**Secondary Green** (Success/Positive)
- **Purpose**: Success messages, positive metrics, completion states
- **Shades**:
  - `secondary-50`: `#E6FAF2` (light backgrounds)
  - `secondary-500`: `#10B981` (Default - success indicators)
  - `secondary-700`: `#0A6F4D` (dark success text)

**Accent Purple** (Gamification)
- **Purpose**: Badges, achievements, leaderboard highlights, tier upgrades
- **Value**: `accent-500`: `#8B5CF6`

### Semantic Colors

**Success**: `#10B981` (Green)
- Usage: Course completion, credit award, badge unlock, positive toast notifications

**Warning**: `#F59E0B` (Orange/Amber)
- Usage: Pending approvals, approaching deadlines, caution alerts, SLA warnings

**Error**: `#EF4444` (Red)
- Usage: Validation errors, failed assessments, critical alerts, system errors

**Info**: `#3B82F6` (Blue)
- Usage: Informational banners, tooltips, inline help, neutral notifications

### Neutral Grays

**Neutral Scale** (9 shades)
- **Usage**:
  - `neutral-50`: `#F9FAFB` (page background, disabled button backgrounds)
  - `neutral-100`: `#F3F4F6` (card backgrounds, hover states)
  - `neutral-200`: `#E5E7EB` (borders, dividers)
  - `neutral-300`: `#D1D5DB` (disabled text, placeholder text)
  - `neutral-500`: `#6B7280` (secondary text, icons)
  - `neutral-700`: `#374151` (body text)
  - `neutral-900`: `#111827` (headings, high-emphasis text)

### Color Usage Guidelines

**Text on Backgrounds:**
| Background Color | Text Color | Contrast Ratio | Pass WCAG AA? |
|------------------|------------|----------------|---------------|
| White (#FFFFFF) | neutral-900 (#111827) | 16.1:1 | ✅ Pass (AAA) |
| White (#FFFFFF) | neutral-700 (#374151) | 8.9:1 | ✅ Pass (AAA) |
| White (#FFFFFF) | primary-500 (#0078D4) | 4.64:1 | ✅ Pass (AA) |
| primary-500 (#0078D4) | White (#FFFFFF) | 4.64:1 | ✅ Pass (AA) |
| neutral-900 (#111827) | White (#FFFFFF) | 16.1:1 | ✅ Pass (AAA) |
| neutral-50 (#F9FAFB) | neutral-700 (#374151) | 8.4:1 | ✅ Pass (AAA) |

**Button Color Applications:**
- **Primary Button**: `bg-primary-500`, `text-white`, hover: `bg-primary-700`
- **Secondary Button**: `bg-neutral-100`, `text-neutral-900`, hover: `bg-neutral-200`
- **Success Button**: `bg-success-500`, `text-white`, hover: `bg-success-700`
- **Danger Button**: `bg-error-500`, `text-white`, hover: `bg-error-700`

**State Colors:**
- **Hover**: Darken background by 1-2 shades (e.g., primary-500 → primary-700)
- **Active/Pressed**: Darken background by 2-3 shades (e.g., primary-500 → primary-800)
- **Disabled**: `bg-neutral-50`, `text-neutral-300`, opacity: 0.6
- **Focus**: 2px outline in primary-500 with 4px offset (per UXR-104)

### Dark Mode Considerations (Future)

While the initial release targets light mode only, tokens are structured to support dark mode in future iterations:

**Light Mode (Default):**
- Background: White (`#FFFFFF`)
- Surface: `neutral-50` (`#F9FAFB`)
- Text: `neutral-900` (`#111827`)

**Dark Mode (Future):**
- Background: `neutral-900` (`#111827`)
- Surface: `neutral-800` (`#1F2937`)
- Text: `neutral-50` (`#F9FAFB`)
- Primary: Lighten to `primary-400` for better contrast on dark backgrounds

---

## 6. Spacing & Layout

### Spacing System (8px Grid)

All spacing uses multiples of 8px to maintain vertical rhythm and consistency.

**Spacing Scale:**
| Token | Value | Usage |
|-------|-------|-------|
| `spacing-0` | 0px | No spacing |
| `spacing-1` | 4px | Tight spacing (icon-to-text gap) |
| `spacing-2` | 8px | Component internal padding (button, input) |
| `spacing-3` | 12px | Small gaps (form field spacing) |
| `spacing-4` | 16px | Standard spacing (card padding, section margins) |
| `spacing-5` | 20px | Medium gaps |
| `spacing-6` | 24px | Large gaps (section spacing) |
| `spacing-8` | 32px | Extra large gaps (page section dividers) |
| `spacing-10` | 40px | Section padding |
| `spacing-12` | 48px | Large section padding |
| `spacing-16` | 64px | Page header/footer padding |
| `spacing-20` | 80px | Hero section padding |

### Layout Grid

**Desktop (≥1024px):**
- 12-column grid
- Gutter: 24px (spacing-6)
- Margin: 48px (spacing-12) on each side
- Max content width: 1440px (centered)

**Tablet (768px - 1023px):**
- 12-column grid (collapsible to 8 columns for narrow layouts)
- Gutter: 16px (spacing-4)
- Margin: 24px (spacing-6) on each side

**Mobile (320px - 767px):**
- 4-column grid
- Gutter: 16px (spacing-4)
- Margin: 16px (spacing-4) on each side

### Component Spacing Guidelines

**Card Components:**
- Padding: 24px (spacing-6) on all sides
- Gap between cards: 24px (spacing-6)
- Card border radius: 8px (medium)

**Form Elements:**
- Label to input gap: 8px (spacing-2)
- Input field padding: 12px horizontal, 8px vertical (spacing-3 × spacing-2)
- Form field to form field gap: 16px (spacing-4)

**Buttons:**
- Padding: 12px horizontal, 8px vertical (spacing-3 × spacing-2) for medium size
- Icon-to-text gap: 8px (spacing-2)
- Button-to-button gap in button groups: 12px (spacing-3)

**Data Tables:**
- Row height: 48px (spacing-12) minimum
- Cell padding: 16px horizontal, 12px vertical (spacing-4 × spacing-3)
- Header row padding: 12px (spacing-3)

**Modals/Dialogs:**
- Padding: 24px (spacing-6) on all sides
- Header padding: 24px (spacing-6)
- Footer padding: 16px (spacing-4)
- Gap between sections: 24px (spacing-6)

---

## 7. Component Specifications

This section provides detailed specifications for all components identified in the Figma spec (Section 10 of figma_spec.md).

### Atoms

#### Button

**Variants:**
- **Primary**: High-emphasis actions (Enroll, Submit, Save)
- **Secondary**: Medium-emphasis actions (Cancel, Back)
- **Tertiary/Ghost**: Low-emphasis actions (Learn More, Skip)
- **Danger**: Destructive actions (Delete, Revoke Credits)
- **Icon Button**: Icon-only (No text label)

**Sizes:**
- **Small**: Height 32px, padding 8px × 16px, font-size 14px
- **Medium** (Default): Height 40px, padding 12px × 24px, font-size 16px
- **Large**: Height 48px, padding 16px × 32px, font-size 18px

**States:**
- **Default**: See color specifications above
- **Hover**: Darken background by 1-2 shades, cursor: pointer
- **Active/Pressed**: Darken background by 2-3 shades
- **Focus**: 2px outline in primary-500, 4px offset (per UXR-104)
- **Disabled**: `bg-neutral-50`, `text-neutral-300`, opacity: 0.6, cursor: not-allowed
- **Loading**: Spinner icon replaces text, button width maintained, disabled state

**Accessibility:**
- Minimum touch target: 44px × 44px (per WCAG 2.2)
- Aria-label for icon-only buttons
- Keyboard navigable (Tab key)
- Enter/Space to activate

**Code Example (Tailwind CSS + React):**
```tsx
// Primary Button
<button className="
  bg-primary-500 hover:bg-primary-700 active:bg-primary-800
  text-white font-semibold
  px-6 py-3 rounded-lg
  transition-colors duration-300
  focus:outline-none focus:ring-2 focus:ring-primary-500 focus:ring-offset-4
  disabled:bg-neutral-50 disabled:text-neutral-300 disabled:opacity-60
">
  Enroll Now
</button>

// Secondary Button
<button className="
  bg-neutral-100 hover:bg-neutral-200
  text-neutral-900 font-semibold
  px-6 py-3 rounded-lg
  transition-colors duration-300
  focus:outline-none focus:ring-2 focus:ring-primary-500 focus:ring-offset-4
">
  Cancel
</button>
```

---

#### Input Field

**Types:**
- **Text**: Single-line text input
- **Textarea**: Multi-line text (max characters displayed)
- **Number**: Numeric input with increment/decrement controls
- **Email**: Email validation
- **Password**: Masked input with show/hide toggle
- **Search**: Search icon prefix, clear icon suffix

**Sizes:**
- **Medium** (Default): Height 40px, padding 12px × 16px, font-size 16px
- **Large**: Height 48px, padding 16px × 20px, font-size 18px

**States:**
- **Default**: Border `neutral-200`, background white
- **Focus**: Border `primary-500`, 2px outline (per UXR-104)
- **Error**: Border `error-500`, error message below (red text)
- **Disabled**: Background `neutral-50`, text `neutral-300`, cursor: not-allowed
- **Read-Only**: Background `neutral-50`, border `neutral-100`

**Validation:**
- **Required Field**: Label with red asterisk (*) suffix
- **Inline Validation**: Error message appears below field on blur (per UXR-501)
- **Error Icon**: Red alert icon on right side of input

**Accessibility:**
- `aria-label` or associated `<label>` element (required)
- `aria-invalid="true"` for error states
- `aria-describedby` linking to error message ID

**Code Example:**
```tsx
// Text Input with Label and Error State
<div className="space-y-2">
  <label htmlFor="courseName" className="block text-sm font-medium text-neutral-700">
    Course Name <span className="text-error-500">*</span>
  </label>
  <input
    id="courseName"
    type="text"
    className="
      w-full px-4 py-3 rounded-lg border border-neutral-200
      focus:outline-none focus:ring-2 focus:ring-primary-500 focus:border-primary-500
      invalid:border-error-500 invalid:ring-error-500
      disabled:bg-neutral-50 disabled:text-neutral-300
    "
    aria-invalid={hasError}
    aria-describedby="courseName-error"
  />
  {hasError && (
    <p id="courseName-error" className="text-sm text-error-500">
      Course name is required.
    </p>
  )}
</div>
```

---

#### Checkbox & Radio Button

**Sizes:**
- **Medium** (Default): 20px × 20px
- **Large**: 24px × 24px

**States:**
- **Unchecked**: Border `neutral-300`, background white
- **Checked**: Background `primary-500`, checkmark icon white
- **Indeterminate** (Checkbox only): Dash icon instead of checkmark
- **Hover**: Border `primary-500`
- **Focus**: 2px outline `primary-500`, 4px offset
- **Disabled**: Background `neutral-100`, border `neutral-200`, checkmark `neutral-300`

**Accessibility:**
- Label with click target (clicking label toggles checkbox/radio)
- `aria-checked` attribute
- Keyboard navigable (Tab to focus, Space to toggle)

**Code Example:**
```tsx
// Checkbox with Label
<label className="flex items-center space-x-3 cursor-pointer">
  <input
    type="checkbox"
    className="
      w-5 h-5 rounded border-neutral-300
      text-primary-500 focus:ring-2 focus:ring-primary-500 focus:ring-offset-4
      disabled:bg-neutral-100 disabled:border-neutral-200
    "
  />
  <span className="text-neutral-700">I agree to the terms and conditions</span>
</label>
```

---

#### Toggle Switch

**Size:**
- Width: 48px, Height: 24px
- Knob: 20px diameter

**States:**
- **Off**: Background `neutral-200`, knob left-aligned
- **On**: Background `primary-500`, knob right-aligned
- **Hover**: Lighten/darken background slightly
- **Focus**: 2px outline `primary-500`, 4px offset
- **Disabled**: Background `neutral-100`, knob `neutral-300`

**Accessibility:**
- `role="switch"`, `aria-checked="true/false"`
- Label describes toggle purpose (e.g., "Enable email notifications")

**Code Example:**
```tsx
// Toggle Switch (using Headless UI)
<Switch
  checked={enabled}
  onChange={setEnabled}
  className={`
    ${enabled ? 'bg-primary-500' : 'bg-neutral-200'}
    relative inline-flex h-6 w-12 items-center rounded-full
    transition-colors focus:outline-none focus:ring-2 focus:ring-primary-500 focus:ring-offset-4
  `}
>
  <span className={`
    ${enabled ? 'translate-x-6' : 'translate-x-1'}
    inline-block h-5 w-5 transform rounded-full bg-white transition-transform
  `} />
</Switch>
```

---

#### Badge

**Variants:**
- **Status**: Colored background with text (Success, Warning, Error, Info, Neutral)
- **Count**: Numeric badge (notification count, red background)
- **Tier**: Rank badge (Bronze, Silver, Gold, Diamond with icons)

**Sizes:**
- **Small**: Height 20px, padding 4px × 8px, font-size 12px
- **Medium** (Default): Height 24px, padding 6px × 12px, font-size 14px

**Color Mapping:**
- **Success**: `bg-success-50`, `text-success-700`, `border-success-200`
- **Warning**: `bg-warning-50`, `text-warning-700`, `border-warning-200`
- **Error**: `bg-error-50`, `text-error-700`, `border-error-200`
- **Info**: `bg-info-50`, `text-info-700`, `border-info-200`
- **Neutral**: `bg-neutral-100`, `text-neutral-700`, `border-neutral-200`

**Code Example:**
```tsx
// Status Badge
<span className="
  inline-flex items-center px-3 py-1 rounded-full
  bg-success-50 text-success-700 border border-success-200
  text-sm font-medium
">
  Approved
</span>

// Count Badge (notification)
<span className="
  inline-flex items-center justify-center w-5 h-5 rounded-full
  bg-error-500 text-white text-xs font-bold
">
  3
</span>
```

---

### Molecules

#### Search Bar

**Components:**
- Search icon (left prefix)
- Text input
- Clear icon (right suffix, appears when input has text)
- Optional: Filter dropdown (right of search)

**States:**
- **Default**: Border `neutral-200`, placeholder `neutral-400`
- **Focus**: Border `primary-500`, icon color changes to `primary-500`
- **Filled**: Clear icon visible (clickable to clear input)

**Behavior:**
- Auto-search (debounced 300ms after typing stops) OR manual search (Enter key)
- Escape key clears input (if filled)

**Accessibility:**
- `aria-label="Search courses"`
- Clear button has `aria-label="Clear search"`

**Code Example:**
```tsx
<div className="relative">
  <SearchIcon className="absolute left-4 top-1/2 -translate-y-1/2 w-5 h-5 text-neutral-400" />
  <input
    type="search"
    placeholder="Search courses..."
    className="
      w-full pl-12 pr-12 py-3 rounded-lg border border-neutral-200
      focus:outline-none focus:ring-2 focus:ring-primary-500 focus:border-primary-500
    "
    aria-label="Search courses"
  />
  {hasValue && (
    <button
      className="absolute right-4 top-1/2 -translate-y-1/2"
      aria-label="Clear search"
      onClick={clearSearch}
    >
      <XIcon className="w-5 h-5 text-neutral-400 hover:text-neutral-600" />
    </button>
  )}
</div>
```

---

#### Card

**Anatomy:**
- Header (optional): Title, icon, actions (dropdown menu)
- Body: Main content (text, images, lists)
- Footer (optional): Actions (buttons), metadata (timestamps)

**Variants:**
- **Default**: White background, border `neutral-200`, shadow-sm
- **Elevated**: White background, no border, shadow-md (hover: shadow-lg)
- **Interactive**: Hoverable (cursor pointer, subtle scale transform)

**Sizes:**
- **Small**: Padding 16px (spacing-4)
- **Medium** (Default): Padding 24px (spacing-6)
- **Large**: Padding 32px (spacing-8)

**Code Example:**
```tsx
// Course Card (Elevated, Interactive)
<div className="
  bg-white rounded-lg shadow-md hover:shadow-lg
  transition-shadow duration-300 cursor-pointer
  p-6 space-y-4
">
  {/* Header */}
  <div className="flex items-start justify-between">
    <h3 className="text-xl font-semibold text-neutral-900">
      Introduction to Neural Networks
    </h3>
    <Badge>Beginner</Badge>
  </div>
  
  {/* Body */}
  <p className="text-neutral-600">
    Learn the fundamentals of neural networks with hands-on examples.
  </p>
  
  {/* Footer */}
  <div className="flex items-center justify-between">
    <span className="text-sm text-neutral-500">Duration: 4 hours</span>
    <Button variant="primary">View Details</Button>
  </div>
</div>
```

---

### Organisms

#### Header Navigation

**Components:**
- Logo (left-aligned)
- Primary navigation links (center or left)
- User menu (right-aligned): Avatar, dropdown with Profile, Settings, Logout
- Notification icon (right, left of user menu)

**Responsive Behavior:**
- **Desktop**: Full horizontal nav
- **Tablet**: Collapse to hamburger menu (≤1023px)
- **Mobile**: Hamburger menu with drawer/slide-out navigation

**Height:**
- Desktop: 64px
- Mobile: 56px

**Code Example:**
```tsx
<header className="bg-white border-b border-neutral-200 h-16 px-6">
  <div className="max-w-screen-xl mx-auto flex items-center justify-between h-full">
    {/* Logo */}
    <div className="flex items-center space-x-8">
      <Logo className="h-8" />
      <nav className="hidden lg:flex space-x-6">
        <NavLink to="/dashboard">Dashboard</NavLink>
        <NavLink to="/courses">Courses</NavLink>
        <NavLink to="/leaderboard">Leaderboard</NavLink>
      </nav>
    </div>
    
    {/* Right side */}
    <div className="flex items-center space-x-4">
      <NotificationButton count={3} />
      <UserMenu />
    </div>
  </div>
</header>
```

---

#### Data Table

**Components:**
- Table header row (sortable columns with arrow icons)
- Table body rows (alternating row colors optional)
- Pagination controls (bottom)
- Row actions (kebab menu or icon buttons)
- Bulk actions (checkboxes, bulk action toolbar)

**States:**
- **Default Row**: Background white
- **Hover Row**: Background `neutral-50`
- **Selected Row**: Background `primary-50`, left border `primary-500` (4px)
- **Loading**: Skeleton rows

**Sorting:**
- Sortable columns show up/down arrow icons
- Active sort column highlighted with icon and darker text

**Accessibility:**
- `role="table"`, `role="row"`, `role="columnheader"`, `role="cell"`
- Keyboard navigation (Tab through rows, Enter to select)
- Screen reader announces sort state

**Code Example:**
```tsx
<table className="w-full border-collapse">
  <thead>
    <tr className="border-b border-neutral-200 bg-neutral-50">
      <th className="px-4 py-3 text-left text-sm font-semibold text-neutral-700">
        <button className="flex items-center space-x-1">
          <span>Name</span>
          <SortIcon className="w-4 h-4" />
        </button>
      </th>
      <th className="px-4 py-3 text-left text-sm font-semibold text-neutral-700">Credits</th>
      <th className="px-4 py-3 text-left text-sm font-semibold text-neutral-700">Rank</th>
    </tr>
  </thead>
  <tbody>
    {data.map((row) => (
      <tr key={row.id} className="border-b border-neutral-200 hover:bg-neutral-50">
        <td className="px-4 py-3 text-neutral-900">{row.name}</td>
        <td className="px-4 py-3 text-neutral-900">{row.credits}</td>
        <td className="px-4 py-3 text-neutral-900">{row.rank}</td>
      </tr>
    ))}
  </tbody>
</table>
```

---

#### Modal Dialog

**Anatomy:**
- Backdrop overlay (semi-transparent black, 60% opacity)
- Modal container (white, centered, max-width 600px)
- Header: Title, close button (X icon)
- Body: Content (text, forms, lists)
- Footer: Actions (Primary and Secondary buttons, right-aligned)

**Sizes:**
- **Small**: Max-width 400px (confirmation dialogs)
- **Medium** (Default): Max-width 600px (forms, content)
- **Large**: Max-width 960px (complex forms, data tables)
- **Full Screen** (Mobile): 100% width/height on mobile

**Behavior:**
- **Open**: Fade-in backdrop (300ms), scale-in modal container (300ms with spring easing)
- **Close**: Fade-out (reverse animation)
- **Dismiss**: Click backdrop, Escape key, or close button
- **Focus Trap**: Focus moves to modal on open, traps Tab navigation within modal

**Accessibility:**
- `role="dialog"`, `aria-modal="true"`, `aria-labelledby="modal-title"`
- Focus automatically moves to first focusable element on open
- Escape key closes modal

**Code Example:**
```tsx
// Modal (using Headless UI Transition)
<Transition show={isOpen} as={Fragment}>
  <Dialog onClose={closeModal} className="relative z-50">
    {/* Backdrop */}
    <Transition.Child
      as={Fragment}
      enter="ease-out duration-300"
      enterFrom="opacity-0"
      enterTo="opacity-100"
      leave="ease-in duration-200"
      leaveFrom="opacity-100"
      leaveTo="opacity-0"
    >
      <div className="fixed inset-0 bg-black bg-opacity-60" />
    </Transition.Child>

    {/* Modal Container */}
    <div className="fixed inset-0 flex items-center justify-center p-4">
      <Transition.Child
        as={Fragment}
        enter="ease-out duration-300"
        enterFrom="opacity-0 scale-95"
        enterTo="opacity-100 scale-100"
        leave="ease-in duration-200"
        leaveFrom="opacity-100 scale-100"
        leaveTo="opacity-0 scale-95"
      >
        <Dialog.Panel className="w-full max-w-md bg-white rounded-lg shadow-xl p-6">
          {/* Header */}
          <Dialog.Title className="text-xl font-semibold text-neutral-900 mb-4">
            Confirm Enrollment
          </Dialog.Title>
          
          {/* Body */}
          <p className="text-neutral-600 mb-6">
            Are you sure you want to enroll in "Beginner AI Path"? This will be added to your active learning paths.
          </p>
          
          {/* Footer */}
          <div className="flex justify-end space-x-3">
            <Button variant="secondary" onClick={closeModal}>Cancel</Button>
            <Button variant="primary" onClick={confirmEnroll}>Enroll Now</Button>
          </div>
        </Dialog.Panel>
      </Transition.Child>
    </div>
  </Dialog>
</Transition>
```

---

## 8. Iconography

### Icon Library

**Primary Icon Set:** **Heroicons 2.0** (Tailwind Labs)
- **Style**: Outlined (default) with 1.5px stroke weight
- **Sizes**: 20px, 24px (default), 28px
- **Format**: SVG (inline or sprite)
- **License**: MIT (free for commercial use)

**Icon Categories:**
- **Navigation**: Home, Dashboard, Menu, ChevronDown, ChevronRight
- **Actions**: Plus, Edit, Trash, Download, Upload, Share, Filter, Search
- **Status**: Check, X, Exclamation, Information, QuestionMark
- **Data**: Chart, Table, Calendar, Clock, Folder, Document
- **User**: User, UserGroup, Bell, Cog, Logout
- **Learning**: AcademicCap, BookOpen, PlayCircle, Trophy, Star

### Icon Usage Guidelines

**Size Mapping:**
- **Small** (20px): Inline with text, button icons (small buttons)
- **Medium** (24px): Default button icons, navigation icons, toolbar icons
- **Large** (28px): Empty state illustrations, header icons

**Color:**
- **Default**: `neutral-500` (medium gray) - neutral, non-intrusive
- **Active/Hover**: `primary-500` (blue) - interactive elements
- **Error**: `error-500` (red) - validation errors, critical alerts
- **Success**: `success-500` (green) - confirmation, completion indicators
- **Disabled**: `neutral-300` (light gray) - inactive elements

**Accessibility:**
- Decorative icons (next to text): `aria-hidden="true"` (hidden from screen readers)
- Standalone icons (icon-only buttons): `aria-label` describing action (e.g., "Close modal")
- Icon + text: Text provides context, icon is decorative

**Code Example:**
```tsx
// Icon with Text (Decorative)
<button className="flex items-center space-x-2">
  <PlusIcon className="w-5 h-5" aria-hidden="true" />
  <span>Add Course</span>
</button>

// Icon-Only Button (Aria-Label Required)
<button aria-label="Close modal">
  <XIcon className="w-6 h-6 text-neutral-500 hover:text-neutral-700" />
</button>
```

### Custom Icons

For platform-specific icons not in Heroicons (e.g., AI brain, skill badges):
- **Create**: SVG with 24px × 24px viewBox
- **Stroke Weight**: 1.5px (match Heroicons)
- **Export**: Optimize with SVGO (remove unnecessary metadata)
- **Naming**: Use kebab-case (e.g., `ai-brain.svg`, `skill-nlp.svg`)

---

## 9. Accessibility Standards

### WCAG 2.2 Level AA Compliance

The platform MUST meet WCAG 2.2 Level AA standards per UXR-101 to UXR-105.

#### UXR-101: WCAG 2.2 AA Compliance
**Requirement**: All UI elements must meet WCAG 2.2 Level AA standards

**Key Criteria:**
- **1.4.3 Contrast (Minimum)**: 4.5:1 for normal text, 3:1 for large text (see Color System)
- **1.4.11 Non-Text Contrast**: 3:1 for UI components and graphical objects
- **2.1.1 Keyboard**: All functionality available via keyboard
- **2.4.7 Focus Visible**: Focus indicator visible for all interactive elements
- **3.2.3 Consistent Navigation**: Navigation menus consistent across pages
- **4.1.2 Name, Role, Value**: All UI components have accessible names and roles

#### UXR-102: Text Contrast
**Requirement**: Minimum 4.5:1 contrast ratio for normal text, 3:1 for large text (≥18px or ≥14px bold)

**Implementation:**
- Use color combinations validated with contrast checker (see Color System section)
- Avoid low-contrast grays for body text (use `neutral-700` or darker on white)
- Error messages in red must have sufficient contrast (test `error-500` on white)

**Testing Tools:**
- WebAIM Contrast Checker: https://webaim.org/resources/contrastchecker/
- Figma Plugin: Stark (real-time contrast checking)

#### UXR-103: Keyboard Navigation
**Requirement**: All interactive elements (buttons, links, form fields, modals) must be keyboard accessible

**Implementation:**
- **Tab Order**: Logical tab order (top-to-bottom, left-to-right)
- **Focus Indicators**: Visible 2px outline in `primary-500` with 4px offset (per UXR-104)
- **Keyboard Shortcuts**:
  - Enter/Space: Activate buttons
  - Escape: Close modals, clear search
  - Arrow Keys: Navigate dropdown menus, table rows
  - Tab/Shift+Tab: Move between focusable elements

**Testing:**
- Manual test: Navigate entire flow using keyboard only (no mouse)
- Automated: axe DevTools (checks focusable elements)

#### UXR-104: Focus Indicators
**Requirement**: 2px outline with 4px offset for focused elements

**Implementation:**
```css
/* Tailwind CSS Focus Ring */
focus:outline-none focus:ring-2 focus:ring-primary-500 focus:ring-offset-4
```

**Custom Focus States:**
- Never remove focus indicators (`outline: none`) without replacement
- Use visible, high-contrast focus indicators (primary-500 blue ring)

#### UXR-105: Screen Reader Support
**Requirement**: All content and functionality accessible via screen reader (NVDA, JAWS, VoiceOver)

**Implementation:**
- **Semantic HTML**: Use correct elements (`<button>`, `<nav>`, `<main>`, `<article>`)
- **ARIA Labels**: Provide labels for non-text elements (icons, charts)
- **ARIA Live Regions**: Announce dynamic content updates (toast notifications, loading states)
- **Alt Text**: All images have descriptive alt text (or `alt=""` if decorative)

**Example:**
```tsx
// Accessible Button
<button
  type="button"
  aria-label="Close modal"
  aria-pressed={isPressed}
>
  <XIcon className="w-6 h-6" aria-hidden="true" />
</button>

// ARIA Live Region (Toast Notification)
<div role="alert" aria-live="polite" aria-atomic="true">
  Successfully enrolled in "Beginner AI Path"!
</div>
```

**Testing:**
- Manual: Use screen reader (NVDA on Windows, VoiceOver on Mac)
- Automated: axe DevTools, WAVE browser extension

---

## 10. Responsive Design Grid

### Breakpoints

| Breakpoint | Min Width | Max Width | Device Type | Columns |
|------------|-----------|-----------|-------------|---------|
| **xs** | 320px | 639px | Mobile (portrait) | 4 |
| **sm** | 640px | 767px | Mobile (landscape), Small tablets | 4 |
| **md** | 768px | 1023px | Tablets (portrait) | 8-12 |
| **lg** | 1024px | 1279px | Tablets (landscape), Small desktops | 12 |
| **xl** | 1280px | 1919px | Desktops | 12 |
| **2xl** | 1920px+ | - | Large desktops | 12 |

### Responsive Strategy

**Mobile-First Approach:**
- Base styles target mobile (320px+)
- Use `@media (min-width: ...)` to progressively enhance for larger viewports
- Test on real devices (iOS Safari, Android Chrome)

**Layout Adjustments:**

**Navigation:**
- **Mobile (< 768px)**: Hamburger menu, drawer navigation, bottom nav bar for primary actions
- **Tablet (768px - 1023px)**: Sidebar navigation (collapsible), top header bar
- **Desktop (≥ 1024px)**: Persistent sidebar navigation (left), top header bar

**Data Tables:**
- **Mobile**: Stacked cards (each row becomes a card with label-value pairs)
- **Tablet**: Horizontal scroll with sticky first column
- **Desktop**: Full table layout

**Modals:**
- **Mobile**: Full-screen modal (100% width/height)
- **Tablet/Desktop**: Centered modal with max-width (600px default)

**Forms:**
- **Mobile**: Single column form layout (vertical stack)
- **Tablet/Desktop**: Two-column layout for short fields (first name / last name side-by-side)

### Grid Implementation (Tailwind CSS)

```tsx
// Responsive Grid (Cards)
<div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-6">
  {courses.map(course => (
    <CourseCard key={course.id} course={course} />
  ))}
</div>

// Responsive Form (Two Columns on Desktop)
<div className="grid grid-cols-1 lg:grid-cols-2 gap-4">
  <InputField label="First Name" />
  <InputField label="Last Name" />
</div>
```

---

## 11. Animation & Motion

### Motion Principles

**Purpose-Driven Animation:**
- Animations should enhance UX, not distract
- Provide feedback for user actions (button clicks, form submissions)
- Guide attention (highlight new content, direct focus to errors)
- Reduce perceived latency (skeleton screens during loading)

**Performance:**
- Target 60fps for all animations (16.67ms per frame)
- Use CSS transforms (`translate`, `scale`, `rotate`) and `opacity` (GPU-accelerated)
- Avoid animating `width`, `height`, `margin` (triggers layout reflow, slow)

### Animation Tokens

**Duration:**
- **Fast**: `150ms` - Micro-interactions (button hover, checkbox toggle)
- **Base**: `300ms` - Standard transitions (modal open, drawer slide)
- **Slow**: `500ms` - Complex animations (page transitions, multi-step sequences)

**Easing Functions:**
- **Ease-In-Out**: `cubic-bezier(0.4, 0, 0.2, 1)` - Default (smooth acceleration/deceleration)
- **Ease-Out**: `cubic-bezier(0, 0, 0.2, 1)` - Elements entering (modals, dropdowns)
- **Ease-In**: `cubic-bezier(0.4, 0, 1, 1)` - Elements exiting (fade out, collapse)
- **Spring**: `cubic-bezier(0.34, 1.56, 0.64, 1)` - Playful bounce (achievement animations)

### Common Animations

**Fade In/Out:**
```css
/* Fade In */
.fade-in {
  animation: fadeIn 300ms ease-in-out;
}

@keyframes fadeIn {
  from { opacity: 0; }
  to { opacity: 1; }
}

/* Fade Out */
.fade-out {
  animation: fadeOut 300ms ease-in-out;
}

@keyframes fadeOut {
  from { opacity: 1; }
  to { opacity: 0; }
}
```

**Slide In/Out (Drawer, Modal):**
```css
/* Slide In from Right */
.slide-in-right {
  animation: slideInRight 300ms ease-out;
}

@keyframes slideInRight {
  from { transform: translateX(100%); }
  to { transform: translateX(0); }
}

/* Slide Out to Right */
.slide-out-right {
  animation: slideOutRight 300ms ease-in;
}

@keyframes slideOutRight {
  from { transform: translateX(0); }
  to { transform: translateX(100%); }
}
```

**Scale (Modal Open):**
```css
.scale-in {
  animation: scaleIn 300ms cubic-bezier(0.34, 1.56, 0.64, 1);
}

@keyframes scaleIn {
  from { transform: scale(0.95); opacity: 0; }
  to { transform: scale(1); opacity: 1; }
}
```

**Loading Spinner:**
```css
.spinner {
  animation: spin 1s linear infinite;
}

@keyframes spin {
  from { transform: rotate(0deg); }
  to { transform: rotate(360deg); }
}
```

**Skeleton Screen Pulse:**
```css
.skeleton {
  animation: pulse 1.5s cubic-bezier(0.4, 0, 0.6, 1) infinite;
}

@keyframes pulse {
  0%, 100% { opacity: 1; }
  50% { opacity: 0.5; }
}
```

### Reduced Motion (Accessibility)

**Respect User Preference:**
Users with vestibular disorders may prefer reduced motion. Respect `prefers-reduced-motion` media query.

```css
/* Disable animations if user prefers reduced motion */
@media (prefers-reduced-motion: reduce) {
  *,
  *::before,
  *::after {
    animation-duration: 0.01ms !important;
    animation-iteration-count: 1 !important;
    transition-duration: 0.01ms !important;
  }
}
```

**Implementation:**
- Test with OS-level reduced motion setting enabled (Windows, macOS accessibility settings)
- Provide instant state changes (no animation) when `prefers-reduced-motion: reduce` is active

---

## 12. Implementation Guidelines

### Design-to-Code Handoff Checklist

**Phase 1: Design System Setup (Week 1)**
- [ ] Export design tokens from Figma to JSON using Tokens Studio plugin
- [ ] Transform tokens to CSS variables and Tailwind config using Style Dictionary
- [ ] Set up component library project (React + TypeScript + Tailwind CSS)
- [ ] Install shadcn/ui or Ant Design for base accessible components
- [ ] Create storybook for component documentation and visual testing

**Phase 2: Component Development (Week 2-3)**
- [ ] Implement all atoms (Button, Input, Checkbox, Badge, etc.)
- [ ] Implement all molecules (Search Bar, Card, Dropdown, etc.)
- [ ] Implement all organisms (Header, Sidebar, Data Table, Modal, etc.)
- [ ] Write unit tests for each component (Jest + React Testing Library)
- [ ] Document components in Storybook with all variants and states

**Phase 3: Screen Implementation (Week 4-8)**
- [ ] Implement priority screens (P0 first): SCR-001, SCR-002, SCR-003, SCR-005, SCR-010
- [ ] Implement all 5 states for each screen (Default, Loading, Empty, Error, Validation)
- [ ] Integrate with backend APIs (mock data in development, real APIs in staging)
- [ ] Responsive testing on mobile (375px), tablet (768px), desktop (1440px)
- [ ] Accessibility audit with axe DevTools (fix all critical/serious issues)

**Phase 4: Quality Assurance (Week 9-10)**
- [ ] Cross-browser testing (Chrome, Firefox, Safari, Edge)
- [ ] Accessibility testing with screen readers (NVDA, VoiceOver)
- [ ] Performance testing (Lighthouse - target 90+ performance score)
- [ ] Visual regression testing (Percy, Chromatic)
- [ ] User acceptance testing (UAT) with 5-10 representative users

### Code Standards

**React Component Structure:**
```tsx
// ComponentName.tsx
import React from 'react';
import { ComponentNameProps } from './ComponentName.types';
import './ComponentName.styles.css'; // or use CSS-in-JS

/**
 * Component Description
 * 
 * @param {ComponentNameProps} props - Component props
 * @returns {JSX.Element} Rendered component
 */
export const ComponentName: React.FC<ComponentNameProps> = ({
  variant = 'default',
  size = 'medium',
  disabled = false,
  children,
  ...rest
}) => {
  return (
    <div
      className={`component-name component-name--${variant} component-name--${size}`}
      aria-disabled={disabled}
      {...rest}
    >
      {children}
    </div>
  );
};
```

**TypeScript Prop Types:**
```tsx
// ComponentName.types.ts
export interface ComponentNameProps {
  variant?: 'default' | 'primary' | 'secondary';
  size?: 'small' | 'medium' | 'large';
  disabled?: boolean;
  children: React.ReactNode;
  onClick?: () => void;
}
```

**Tailwind CSS (Preferred over CSS Modules):**
```tsx
// Use Tailwind utility classes for styling
export const Button: React.FC<ButtonProps> = ({ variant, children }) => {
  const baseClasses = 'px-6 py-3 rounded-lg font-semibold transition-colors duration-300';
  const variantClasses = {
    primary: 'bg-primary-500 text-white hover:bg-primary-700',
    secondary: 'bg-neutral-100 text-neutral-900 hover:bg-neutral-200',
  };

  return (
    <button className={`${baseClasses} ${variantClasses[variant]}`}>
      {children}
    </button>
  );
};
```

### Design QA Process

**Fidelity Check:**
- Designer reviews implemented screens in staging environment
- Compare against Figma mockups (overlay screenshots to check pixel perfection)
- Log deviations in design debt backlog (non-blocking issues fixed in future sprints)

**Feedback Loop:**
- Weekly design/dev sync meetings to resolve ambiguities
- Figma comments on specific screens for feedback (tag developers)
- Design updates versioned in Figma (notify developers of breaking changes)

---

## Document Control

**Version History:**

| Version | Date | Author | Changes |
|---------|------|--------|---------|
| 1.0 | 2026-04-08 | Design Team | Initial design system specification |

**Approval:**

| Role | Name | Date | Signature |
|------|------|------|-----------|
| **Design Lead** | [Name] | [Date] | [Signature] |
| **Engineering Lead** | [Name] | [Date] | [Signature] |
| **Product Manager** | [Name] | [Date] | [Signature] |

**Next Steps:**
1. Stakeholder review of design system (target: Week of 2026-04-15)
2. Figma design file creation begins (target start: 2026-04-20)
3. Component library development sprint 1 (target start: 2026-05-01)

---

**Document Status:** Draft - Awaiting Stakeholder Review  
**Contact:** design-team@company.com for questions or feedback on design system

