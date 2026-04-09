import { NavigateFunction } from 'react-router-dom';

export function mapRoleToRoute(role: string): string {
  const normalized = (role || '').trim().toLowerCase();
  switch (normalized) {
    case 'learner':
    case 'student':
      return '/dashboard';
    case 'manager':
      return '/manager-dashboard';
    case 'admin':
    case 'administrator':
      return '/admin-console';
    case 'leadership':
    case 'leader':
      return '/leadership-dashboard';
    default:
      console.warn(`Unrecognized role claim "${role}". Defaulting to Learner dashboard.`);
      return '/dashboard';
  }
}

export function redirectToDashboard(navigate: NavigateFunction, role: string): void {
  const path = mapRoleToRoute(role);
  navigate(path, { replace: true });
}