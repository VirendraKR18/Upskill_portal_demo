# Task - task_001_fe_login_ui

## Requirement Reference
- User Story: us_001 - SSO Authentication via Corporate Identity Provider
- Story Location: .propel/context/tasks/us_001/us_001.md
- Acceptance Criteria:  
    - AC-1: Given I navigate to the platform login page, When I click "Sign In", Then I am redirected to the Organization SSO identity provider login page
    - AC-2: Given I am authenticated, When the system processes my SSO claims, Then my role is mapped and I am redirected to the appropriate dashboard
    - AC-5: Given the SSO provider is temporarily unavailable, When I attempt to log in, Then the system displays a user-friendly error message
- Edge Case:
    - How does the system handle SSO token with unrecognized role claims? (Default to Learner role; log warning)

## Design References (Frontend Tasks Only)
| Reference Type | Value |
|----------------|-------|
| **UI Impact** | Yes |
| **Figma URL** | N/A |
| **Wireframe Status** | AVAILABLE |
| **Wireframe Type** | HTML |
| **Wireframe Path/URL** | .propel/context/wireframes/Hi-Fi/wireframe-SCR-001-login.html |
| **Screen Spec** | figma_spec.md#SCR-001 |
| **UXR Requirements** | UXR-001, UXR-101-105, UXR-201-204, UXR-301-303, UXR-401-404, UXR-501-504 |
| **Design Tokens** | designsystem.md#3-design-tokens, designsystem.md#4-typography, designsystem.md#5-color-system |

> **Wireframe Status Legend:**
> - **AVAILABLE**: Local file exists at specified path
> - **PENDING**: UI-impacting task awaiting wireframe (provide file or URL)
> - **EXTERNAL**: Wireframe provided via external URL
> - **N/A**: Task has no UI impact
>
> If UI Impact = No, all design references should be N/A

### **CRITICAL: Wireframe Implementation Requirement (UI Tasks Only)**
**IF Wireframe Status = AVAILABLE or EXTERNAL:**
- **MUST** open and reference the wireframe file/URL during UI implementation
- **MUST** match layout, spacing, typography, and colors from the wireframe
- **MUST** implement all states shown in wireframe (default, hover, focus, error, loading)
- **MUST** validate implementation against wireframe at breakpoints: 375px, 768px, 1440px
- Run `/analyze-ux` after implementation to verify pixel-perfect alignment

## Applicable Technology Stack
| Layer | Technology | Version |
|-------|------------|---------|
| Frontend | React with TypeScript | 18.x |
| UI Component Library | Ant Design | 5.x |
| State Management | Redux Toolkit | 2.x |
| Styling | Tailwind CSS | 3.4+ |
| Routing | React Router | 6.x |
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

> **AI Impact Legend:**
> - **Yes**: Task involves LLM integration, RAG pipeline, prompt engineering, or AI infrastructure
> - **No**: Task is deterministic (FE/BE/DB only)
>
> If AI Impact = No, all AI references should be N/A

## Task Overview
Implement the Login UI (SCR-001) for the AI Learning Platform with SSO authentication entry point. The screen provides a branded, accessible interface with a single "Sign in with Organization Account" button that redirects users to the corporate SSO provider (OAuth 2.0/SAML 2.0). The component must handle all 5 screen states: Default, Loading, Empty (N/A for login), Error, and Validation (N/A). This task focuses exclusively on the frontend presentation layer and SSO redirect initiation.

**Key Capabilities:**
- Responsive login screen matching wireframe-SCR-001-login.html specifications
- SSO button with loading and error states
- Accessible design meeting WCAG 2.2 AA standards (UXR-101-105)
- Error handling for SSO provider unavailability with user-friendly messaging
- Role-based redirect after successful authentication (to respective dashboards)

## Dependent Tasks
- None (This is the first task in EP-001)

## Impacted Components
| Action | Component/Module | Project |
|--------|------------------|---------|
| CREATE | `app/src/pages/Login/Login.tsx` | Frontend (React) |
| CREATE | `app/src/pages/Login/Login.module.css` | Frontend (CSS Module) |
| CREATE | `app/src/components/SSOButton/SSOButton.tsx` | Frontend (Reusable Component) |
| CREATE | `app/src/services/auth/ssoService.ts` | Frontend (SSO redirect service) |
| CREATE | `app/src/utils/roleRedirect.ts` | Frontend (Role-based routing utility) |
| CREATE | `app/src/pages/Login/Login.test.tsx` | Frontend (Unit tests) |

## Implementation Plan

### Phase 1: Setup and Project Structure (1 hour)
1. **Create project structure**:
   - Initialize React app with TypeScript if not exists: `npx create-react-app app --template typescript`
   - Install dependencies: `npm install antd@5.x react-router-dom@6.x @reduxjs/toolkit@2.x tailwindcss@3.4`
   - Configure Tailwind CSS with design tokens from designsystem.md
   - Setup project folder structure: `app/src/pages/Login`, `app/src/components/SSOButton`, `app/src/services/auth`

2. **Configure design tokens**:
   - Extract color palette from designsystem.md (primary: #0078D4, error: #EF4444, neutral shades)
   - Create Tailwind config extending with custom colors
   - Define spacing scale based on 8px base unit
   - Configure typography (font family, sizes, weights)

### Phase 2: Component Implementation (3 hours)
3. **Implement SSOButton component** (`SSOButton.tsx`):
   - Props: `onClick`, `loading`, `disabled`
   - States: Default, Hover, Focus, Active, Disabled, Loading
   - Accessibility: `aria-label`, `role="button"`, keyboard navigation (Enter/Space)
   - Loading state shows spinner + "Redirecting to SSO..." text
   - Use Ant Design Button as base with Tailwind custom styles
   - Reference wireframe for exact button dimensions (min-width: 320px, height: 48px)

4. **Implement Login page** (`Login.tsx`):
   - Layout: Centered card container on branded gradient background (from wireframe)
   - Logo + platform name header section
   - SSOButton prominently displayed
   - Optional "Forgot Password?" link (prepare for future US, grayed out/disabled for now)
   - Responsive breakpoints: Mobile (375px), Tablet (768px), Desktop (1440px)
   - Use React Router `useNavigate()` hook for post-auth redirect

5. **Implement SSO service** (`ssoService.ts`):
   - `initiateSSOLogin()` function:
     - Construct SSO provider redirect URL with query params: `redirect_uri`, `state`, `nonce`
     - Store `state` and `nonce` in sessionStorage for CSRF protection
     - Execute `window.location.href = ssoUrl` to redirect to SSO provider
   - `handleSSOCallback()` function (for return from SSO):
     - Validate `state` parameter matches sessionStorage value
     - Extract auth token from URL query params
     - Return token to caller for backend validation (will be handled by backend task)

6. **Implement role-based redirect utility** (`roleRedirect.ts`):
   - `redirectToDashboard(role: string)` function
   - Role mapping: Learner → `/dashboard`, Manager → `/manager-dashboard`, Admin → `/admin-console`, Leadership → `/leadership-dashboard`
   - Fallback: Unknown role defaults to `/dashboard` (Learner), log warning to console
   - Use React Router's `navigate()` API

### Phase 3: State Management and Error Handling (2 hours)
7. **Implement screen states** (per figma_spec.md#SCR-001):
   - **Default State**: SSO button enabled, no errors
   - **Loading State**: Trigger on button click, show spinner, disable button, overlay dimmed
   - **Error State**: Red error banner above button with message:
     - Network error: "Authentication service temporarily unavailable. Please try again in a few minutes."
     - SSO failure: "Authentication failed. Please try again or contact IT support."
     - Retry button clears error and returns to default state
   - Use React `useState` for local state management (loading, error message)

8. **Implement error handling**:
   - Try-catch block in `initiateSSOLogin()` for network failures
   - Display error banner using Ant Design Alert component
   - Error auto-dismiss after 10 seconds (optional, with close button)
   - Log errors to console (will integrate with Application Insights in future task)

### Phase 4: Accessibility and Responsiveness (1.5 hours)
9. **Accessibility implementation** (UXR-101-105):
   - Semantic HTML: `<main>`, `<section>`, `<button>`
   - ARIA labels: `aria-label="Sign in with Organization Account"`, `aria-live="polite"` for error announcements
   - Keyboard navigation: Tab focus on SSO button, visible focus ring (3px primary color, per UXR-103)
   - Color contrast: Verify 4.5:1 for text, 3:1 for UI components (use WebAIM contrast checker)
   - Screen reader testing: Ensure error messages announced correctly

10. **Responsive design** (UXR-201-204):
    - Mobile (375px): Full-width button, stacked layout, reduced padding
    - Tablet (768px): Medium card width (500px), increased button padding
    - Desktop (1440px): Large card width (600px), hero background image
    - Test on Chrome DevTools device emulation
    - Match wireframe specifications exactly at each breakpoint

### Phase 5: Testing and Validation (0.5 hours)
11. **Write unit tests** (`Login.test.tsx`):
    - Test SSO button click triggers `initiateSSOLogin()`
    - Test loading state disables button and shows spinner
    - Test error state displays error banner with correct message
    - Test retry button clears error and returns to default state
    - Use React Testing Library (`@testing-library/react`)
    - Minimum 80% code coverage (per NFR-011)

12. **Manual testing checklist**:
    - [ ] SSO button visible and clickable on all breakpoints
    - [ ] Loading state animation smooth (no jank)
    - [ ] Error banner displays correctly with accessible color contrast
    - [ ] Keyboard navigation works (Tab, Enter, Space)
    - [ ] Screen reader announces errors (test with NVDA or JAWS)
    - [ ] Matches wireframe pixel-perfectly (screenshot comparison)

## Current Project State
```
UPSKILL/
├── .propel/
│   ├── context/
│   │   ├── docs/
│   │   │   ├── design.md (Tech stack: React 18.x, ASP.NET Core 8.0, PostgreSQL 14+)
│   │   │   ├── spec.md (FR-001, NFR-004, NFR-005, UC-007)
│   │   │   ├── figma_spec.md (SCR-001 screen specs)
│   │   │   └── designsystem.md (Design tokens, colors, typography)
│   │   ├── wireframes/
│   │   │   └── Hi-Fi/
│   │   │       └── wireframe-SCR-001-login.html (Login screen wireframe)
│   │   └── tasks/
│   │       └── us_001/
│   │           ├── us_001.md (Parent user story)
│   │           └── task_001_fe_login_ui.md (This task)
├── app/ [TO BE CREATED]
│   ├── src/
│   │   ├── pages/Login/ [TO BE CREATED]
│   │   ├── components/SSOButton/ [TO BE CREATED]
│   │   ├── services/auth/ [TO BE CREATED]
│   │   └── utils/ [TO BE CREATED]
│   └── package.json [TO BE CREATED]
├── README.md
└── BRD.txt
```

## Expected Changes
| Action | File Path | Description |
|--------|-----------|-------------|
| CREATE | app/package.json | React 18.x project with TypeScript, Ant Design 5.x, Tailwind CSS 3.4+, React Router 6.x |
| CREATE | app/tailwind.config.js | Tailwind configuration with design tokens (colors, spacing, typography) |
| CREATE | app/src/pages/Login/Login.tsx | Main login page component with SSO button and state management |
| CREATE | app/src/pages/Login/Login.module.css | Login page specific styles (gradient background, card layout) |
| CREATE | app/src/components/SSOButton/SSOButton.tsx | Reusable SSO button component with loading/error states |
| CREATE | app/src/services/auth/ssoService.ts | SSO redirect initialization and callback handling service |
| CREATE | app/src/utils/roleRedirect.ts | Role-based dashboard redirect utility (Learner/Manager/Admin/Leadership) |
| CREATE | app/src/pages/Login/Login.test.tsx | Unit tests for Login component (React Testing Library) |
| CREATE | app/src/App.tsx | Main app component with React Router configuration |
| CREATE | app/src/index.tsx | App entry point |

## Implementation Checklist
- [ ] Setup React 18.x project with TypeScript and install dependencies (Ant Design, Tailwind, React Router)
- [ ] Configure Tailwind CSS with design tokens from designsystem.md (colors, spacing, typography)
- [ ] Create SSOButton component with all states (Default, Hover, Focus, Loading, Error) and accessibility attributes
- [ ] Implement Login page with responsive layout matching wireframe-SCR-001-login.html at 375px, 768px, 1440px breakpoints
- [ ] Implement ssoService.ts with initiateSSOLogin() and handleSSOCallback() functions (CSRF protection via state/nonce)
- [ ] Implement roleRedirect.ts utility for role-based dashboard routing (Learner/Manager/Admin/Leadership)
- [ ] Implement error handling with user-friendly error messages (SSO unavailable, auth failed) using Ant Design Alert
- [ ] Validate accessibility (WCAG 2.2 AA): semantic HTML, ARIA labels, keyboard navigation, color contrast 4.5:1
- [ ] Write unit tests with React Testing Library achieving >80% code coverage
- [ ] Manual testing: verify pixel-perfect match with wireframe, test on all breakpoints, validate keyboard/screen reader

## Validation Criteria
✅ **Functional Requirements:**
- SSO button click redirects to SSO provider URL with correct query params
- Loading state activates on button click, disables interactions
- Error state displays user-friendly messages for network/auth failures
- Role-based redirect works for all 4 roles (Learner, Manager, Admin, Leadership)
- Unknown role defaults to Learner dashboard with console warning logged

✅ **Design Requirements:**
- Layout matches wireframe-SCR-001-login.html pixel-perfectly (<5px tolerance)
- Responsive at 375px (mobile), 768px (tablet), 1440px (desktop) breakpoints
- Design tokens correctly applied (primary color #0078D4, error #EF4444)
- Typography matches designsystem.md specifications

✅ **Accessibility Requirements (UXR-101-105):**
- Semantic HTML tags used (`<main>`, `<button>`, correct heading hierarchy)
- Color contrast meets WCAG 2.2 AA (4.5:1 for text, 3:1 for UI components)
- Keyboard navigation functional (Tab focus, Enter/Space activation)
- Screen reader announces all states correctly (error messages use `aria-live="polite"`)
- Focus indicators visible (3px outline in primary color)

✅ **Testing Requirements:**
- Unit tests pass with >80% code coverage
- Manual tests verify all screen states (Default, Loading, Error)
- Cross-browser testing (Chrome, Firefox, Safari, Edge)
- Performance: Login page loads in <1 second, SSO redirect <500ms

✅ **Traceability:**
- US_001 AC-1: SSO button redirects to SSO provider ✓
- US_001 AC-5: User-friendly error message for SSO unavailability ✓
- NFR-004: SSO authentication OAuth 2.0/SAML 2.0 (frontend redirect setup) ✓
- UXR-001: Max 3 clicks to login (1 click on SSO button) ✓
