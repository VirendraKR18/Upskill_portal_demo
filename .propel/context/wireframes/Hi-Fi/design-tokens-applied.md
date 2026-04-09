# Design Tokens Applied

## Token Mapping

All 32 wireframes use a consistent Tailwind CSS configuration extending the design system tokens from `designsystem.md`.

### Color Tokens

| Design Token | Tailwind Class | Hex Value | Usage |
|---|---|---|---|
| Primary/500 | `text-primary-500`, `bg-primary-500` | #0078D4 | CTAs, active nav, links, focus rings |
| Primary/50 | `bg-primary-50` | #E6F2FF | Active row highlights, light badges |
| Primary/600 | `bg-primary-600` | #0060A8 | Hover states, active sidebar items |
| Secondary/500 | `text-secondary-500`, `bg-secondary-500` | #10B981 | Success states, completed badges, positive metrics |
| Accent/500 | `text-accent-500`, `bg-accent-500` | #8B5CF6 | AI insights, achievements, accent badges |
| Error/500 | `text-error-500`, `bg-error-500` | #EF4444 | Error states, critical alerts, at-risk indicators |
| Warning/500 | `text-warning-500`, `bg-warning-500` | #F59E0B | Pending states, SLA warnings, flagged items |
| Neutral/50 | `bg-neutral-50` | #F9FAFB | Page backgrounds, table header backgrounds |
| Neutral/100 | `bg-neutral-100` | #F3F4F6 | Tag backgrounds, secondary fills |
| Neutral/200 | `border-neutral-200` | #E5E7EB | Borders, dividers, progress bar tracks |
| Neutral/300 | `border-neutral-300` | #D1D5DB | Input borders, secondary button borders |
| Neutral/500 | `text-neutral-500` | #6B7280 | Secondary text, labels, placeholders |
| Neutral/600 | `text-neutral-600` | #4B5563 | Body text, table cell text |
| Neutral/700 | `text-neutral-700` | #374151 | Strong body text, button text |
| Neutral/900 | `text-neutral-900`, `bg-neutral-900` | #111827 | Headings, sidebar backgrounds |

### Typography Tokens

| Token | Value | Tailwind Class | Usage |
|---|---|---|---|
| Font Family | Inter, system-ui, sans-serif | Inline style | All text |
| H1 / Page Title | 36px Bold | `text-3xl font-bold` | Hero titles (SCR-018 path header) |
| H2 / Section Title | 24px Bold | `text-2xl font-bold` | Page headings, member names |
| H3 / Card Title | 18px Semibold | `text-lg font-semibold` | Card headers, section titles |
| Body | 14px Regular | `text-sm` | Body content, table cells |
| Caption | 12px Regular | `text-xs` | Labels, KPI subtitles, timestamps |
| Mono | Font-mono | `font-mono` | Transaction IDs, codes |

### Spacing Tokens

| Token | Value | Tailwind Class | Applied |
|---|---|---|---|
| xs | 4px | `p-1`, `gap-1` | Tight inline spacing |
| sm | 8px | `p-2`, `gap-2` | Button groups, tag gaps |
| md | 16px | `p-4`, `gap-4` | Card padding, grid gaps |
| lg | 24px | `p-6`, `gap-6` | Section padding, major gaps |
| xl | 32px | `p-8`, `gap-8` | Page padding, hero sections |

### Border Radius Tokens

| Token | Value | Tailwind Class | Applied |
|---|---|---|---|
| Small | 4px | `rounded` | Badges, tags, small buttons |
| Medium | 8px | `rounded-lg` | Cards, inputs, buttons |
| Large | 12px | `rounded-xl` | Hero sections, modals |
| Full | 9999px | `rounded-full` | Avatars, pill badges, toggles |

### Shadow Tokens

| Token | Tailwind Class | Applied |
|---|---|---|
| sm | `shadow-sm` | Login card (SCR-001, SCR-017) |

### Interactive States

All wireframes implement:
- **Hover**: `hover:bg-neutral-50` (table rows), `hover:bg-primary-600` (primary CTAs), `hover:text-primary-500` (links)
- **Focus**: `focus:ring-2 focus:ring-primary-500 focus:border-primary-500` (inputs, textareas)
- **Active Nav**: `bg-primary-600 text-white` (sidebar), `text-primary-500 font-medium` (header nav)
- **Disabled/Locked**: `opacity-60` (locked course items in SCR-018)

## Screen-Token Coverage

All 32 screens (SCR-001 through SCR-032) apply the above design tokens via the shared `tailwind.config` inline script extending Tailwind's default theme. Every wireframe includes:

1. CDN Tailwind CSS with identical config block
2. Inter font family via inline style
3. Full color palette (primary, secondary, accent, error, warning, neutral scales)
4. Consistent spacing grid (8px-based via Tailwind classes)
5. Standard border-radius and shadow application
6. Hover/focus interactive states on all actionable elements
