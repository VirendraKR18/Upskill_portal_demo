import React from 'react';
import { render, screen, fireEvent, waitFor } from '@testing-library/react';
import Login from './Login';
import * as ssoService from '../../services/auth/ssoService';
import { BrowserRouter } from 'react-router-dom';

jest.mock('../../services/auth/ssoService');

describe('Login Page', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('clicking SSO button triggers initiateSSOLogin and shows loading', async () => {
    const initiateMock = ssoService.initiateSSOLogin as jest.MockedFunction<typeof ssoService.initiateSSOLogin>;
    // Simulate a promise that doesn't resolve (since real function would redirect)
    initiateMock.mockImplementation(() => new Promise(() => {}));

    render(
      <BrowserRouter>
        <Login />
      </BrowserRouter>
    );

    const button = screen.getByRole('button', { name: /Sign in with Organization Account/i });
    expect(button).toBeInTheDocument();
    fireEvent.click(button);

    // Loading state - button should show redirecting text
    await waitFor(() => {
      expect(screen.getByText(/Redirecting to SSO\.\.\./i)).toBeInTheDocument();
    });

    expect(initiateMock).toHaveBeenCalledTimes(1);
  });

  test('shows network error when initiateSSOLogin throws and retry clears error', async () => {
    const initiateMock = ssoService.initiateSSOLogin as jest.MockedFunction<typeof ssoService.initiateSSOLogin>;
    initiateMock.mockRejectedValue(new Error('SSO provider temporarily unavailable'));

    render(
      <BrowserRouter>
        <Login />
      </BrowserRouter>
    );

    const button = screen.getByRole('button', { name: /Sign in with Organization Account/i });
    fireEvent.click(button);

    const errorMessage = await screen.findByText(/Authentication service temporarily unavailable/i);
    expect(errorMessage).toBeInTheDocument();

    const retryButton = screen.getByRole('button', { name: /Retry/i });
    fireEvent.click(retryButton);

    await waitFor(() => {
      expect(screen.queryByText(/Authentication service temporarily unavailable/i)).not.toBeInTheDocument();
    });
  });
});