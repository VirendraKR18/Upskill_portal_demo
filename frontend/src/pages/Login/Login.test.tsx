import React from 'react';
import { render, screen, fireEvent, waitFor } from '@testing-library/react';
import Login from './Login';
import * as ssoService from '../../services/auth/ssoService';
import { BrowserRouter } from 'react-router-dom';
import { redirectToDashboard, mapRoleToRoute } from '../../utils/roleRedirect';

jest.mock('../../services/auth/ssoService');

describe('Login Page', () => {
  beforeEach(() => {
    jest.resetAllMocks();
  });

  test('SSO button click triggers initiateSSOLogin and shows loading', async () => {
    const initiateMock = jest.spyOn(ssoService, 'initiateSSOLogin').mockImplementation(async () => {
      // Simulate redirect that doesn't complete in test
      return;
    });

    render(
      <BrowserRouter>
        <Login />
      </BrowserRouter>
    );

    const button = screen.getByRole('button', { name: /Sign in with Organization Account/i });
    fireEvent.click(button);

    expect(initiateMock).toHaveBeenCalled();

    // Loading indicator text appears
    await waitFor(() => {
      expect(screen.getByText(/Redirecting to SSO/i)).toBeInTheDocument();
    });
  });

  test('displays error banner when initiateSSOLogin throws', async () => {
    jest.spyOn(ssoService, 'initiateSSOLogin').mockImplementation(async () => {
      throw new Error('Network failure');
    });

    render(
      <BrowserRouter>
        <Login />
      </BrowserRouter>
    );

    const button = screen.getByRole('button', { name: /Sign in with Organization Account/i });
    fireEvent.click(button);

    await waitFor(() => {
      expect(screen.getByRole('alert')).toBeInTheDocument();
      expect(screen.getByText(/Network failure/i)).toBeInTheDocument();
    });

    // Retry: close the alert
    const closeButton = screen.getByLabelText('close');
    fireEvent.click(closeButton);

    await waitFor(() => {
      // Alert should be removed
      expect(screen.queryByRole('alert')).not.toBeInTheDocument();
    });
  });
});

describe('roleRedirect utility', () => {
  test('maps known roles to routes', () => {
    expect(mapRoleToRoute('Learner')).toBe('/dashboard');
    expect(mapRoleToRoute('Manager')).toBe('/manager-dashboard');
    expect(mapRoleToRoute('Admin')).toBe('/admin-console');
    expect(mapRoleToRoute('Leadership')).toBe('/leadership-dashboard');
  });

  test('unknown role defaults to /dashboard and logs warning', () => {
    const warn = jest.spyOn(console, 'warn').mockImplementation(() => {});
    expect(mapRoleToRoute('Stranger')).toBe('/dashboard');
    expect(warn).toHaveBeenCalledWith(expect.stringContaining('Unrecognized role claim'));
    warn.mockRestore();
  });
});