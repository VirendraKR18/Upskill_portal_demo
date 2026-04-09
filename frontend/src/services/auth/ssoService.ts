/* SSO service: constructs redirect URL with CSRF protection via state/nonce and handles callback parsing */
const SSO_PROVIDER_URL = process.env.REACT_APP_SSO_PROVIDER_URL || 'https://sso.example.com/oauth2/authorize';
const CLIENT_ID = process.env.REACT_APP_SSO_CLIENT_ID || 'frontend-client';
const REDIRECT_PATH = '/auth/callback';

function generateRandomString(length = 32): string {
  const charset = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
  let res = '';
  const cryptoObj = typeof crypto !== 'undefined' ? crypto : (window as any).msCrypto;
  if (cryptoObj && cryptoObj.getRandomValues) {
    const values = new Uint32Array(length);
    cryptoObj.getRandomValues(values);
    for (let i = 0; i < length; i++) {
      res += charset[values[i] % charset.length];
    }
  } else {
    for (let i = 0; i < length; i++) {
      res += charset[Math.floor(Math.random() * charset.length)];
    }
  }
  return res;
}

export interface SSOCallback {
  token?: string;
  state?: string | null;
  error?: string | null;
}

/**
 * Initiates an SSO login by constructing the provider URL with query params and redirecting the browser.
 * Stores state and nonce in sessionStorage (temporary) for CSRF protection.
 */
export async function initiateSSOLogin(): Promise<void> {
  try {
    const state = generateRandomString(24);
    const nonce = generateRandomString(24);
    const redirectUri = `${window.location.origin}${REDIRECT_PATH}`;

    // Store state/nonce in sessionStorage
    sessionStorage.setItem('sso_state', state);
    sessionStorage.setItem('sso_nonce', nonce);

    const params = new URLSearchParams({
      response_type: 'code',
      client_id: CLIENT_ID,
      redirect_uri: redirectUri,
      state,
      nonce,
      scope: 'openid profile email'
    });

    const ssoUrl = `${SSO_PROVIDER_URL}?${params.toString()}`;

    // Perform the redirect
    window.location.assign(ssoUrl);
  } catch (err) {
    // Do not leak internal error details to UI; throw generic message
    console.error('SSO initiation failed', err);
    throw new Error('SSO provider temporarily unavailable');
  }
}

/**
 * Handles SSO callback by parsing URL params and validating state/nonce.
 * Does NOT perform token validation; returns extracted token/code for backend exchange.
 */
export function handleSSOCallback(search: string): SSOCallback {
  const params = new URLSearchParams(search);
  const returnedState = params.get('state');
  const code = params.get('code');
  const error = params.get('error');

  const storedState = sessionStorage.getItem('sso_state');
  // Clear stored values (single-use)
  sessionStorage.removeItem('sso_state');
  sessionStorage.removeItem('sso_nonce');

  if (error) {
    return { error, state: returnedState || null };
  }

  if (!returnedState || returnedState !== storedState) {
    throw new Error('Invalid SSO state returned from provider');
  }

  if (!code) {
    throw new Error('Missing authorization code in SSO callback');
  }

  return { token: code, state: returnedState };
}