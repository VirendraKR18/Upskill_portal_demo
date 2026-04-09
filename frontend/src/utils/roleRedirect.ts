import type { UserRole } from '../types';
import type { NavigateFunction } from 'react-router-dom';

/**
 * Maps user role claim to application route and performs navigation.
 * Unknown roles are mapped to Learner dashboard with a console warning.
 */
export function redirectToDashboard(navigate: NavigateFunction, role: UserRole): void {
  const mapping: Record<string, string> = {
    Learner: '/dashboard',
    Manager: '/manager-dashboard',
    Admin: '/admin-console',
    Leadership: '/leadership-dashboard'
  };

  const route = mapping[role] || mapping['Learner'];

  if (!mapping[role]) {
    console.warn(`Unrecognized role claim "${role}". Defaulting to Learner dashboard.`);
  }

  navigate(route, { replace: true });
}