/**
 * Client-side SSO helper.
 * - Builds SSO redirect URL with state/nonce
 * - Stores state/nonce in sessionStorage for CSRF protection
 * - Parses callback query params and validates state
 */

const SSO_PROVIDER_URL = process.env.REACT_APP_SSO_PROVIDER_URL || 'https://sso.example.com/authorize';
const CLIENT_ID = process.env.REACT_APP_SSO_CLIENT_ID || 'upskill-client';
const REDIRECT_URI = process.env.REACT_APP_SSO_REDIRECT_URI || `${window.location.origin}/login/callback`;

function generateRandom(length = 16): string {
  const arr = new Uint8Array(length);
  if (typeof window !== 'undefined' && window.crypto && window.crypto.getRandomValues) {
    window.crypto.getRandomValues(arr);
  } else {
    for (let i = 0; i < length; i++) arr[i] = Math.floor(Math.random() * 256);
  }
  return Array.from(arr).map((b) => ('0' + b.toString(16)).slice(-2)).join('');
}

export async function initiateSSOLogin(): Promise<void> {
  try {
    const state = generateRandom(12);
    const nonce = generateRandom(12);

    sessionStorage.setItem('sso.state', state);
    sessionStorage.setItem('sso.nonce', nonce);

    const params = new URLSearchParams({
      response_type: 'code',
      client_id: CLIENT_ID,
      redirect_uri: REDIRECT_URI,
      scope: 'openid profile email',
      state,
      nonce
    });

    const url = `${SSO_PROVIDER_URL}?${params.toString()}`;

    // Redirect to provider
    window.location.href = url;
  } catch (err) {
    // Rethrow to allow consumer to handle UI state
    throw new Error('Failed to initiate authentication. Please try again.');
  }
}

export function handleSSOCallback(search: string): { token?: string; error?: string } {
  const params = new URLSearchParams(search);
  const returnedState = params.get('state');
  const code = params.get('code');
  const error = params.get('error');

  const storedState = sessionStorage.getItem('sso.state');

  if (!storedState || !returnedState || storedState !== returnedState) {
    return { error: 'Invalid or missing state. Potential CSRF detected.' };
  }

  // Clean up one-time values
  sessionStorage.removeItem('sso.state');
  sessionStorage.removeItem('sso.nonce');

  if (error) {
    return { error };
  }

  if (!code) {
    return { error: 'Missing authorization code from SSO provider.' };
  }

  // Frontend should not exchange code directly — return code for backend to exchange
  return { token: code };
}