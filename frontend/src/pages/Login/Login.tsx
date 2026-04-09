import React, { useState } from 'react';
import { Alert } from 'antd';
import { useNavigate } from 'react-router-dom';
import SSOButton from '../../components/SSOButton/SSOButton';
import * as ssoService from '../../services/auth/ssoService';
import { redirectToDashboard } from '../../utils/roleRedirect';
import styles from './Login.module.css';

export default function Login(): JSX.Element {
  const [loading, setLoading] = useState(false);
  const [errorMsg, setErrorMsg] = useState<string | null>(null);
  const navigate = useNavigate();

  const handleSignIn = async () => {
    setErrorMsg(null);
    setLoading(true);
    try {
      await ssoService.initiateSSOLogin();
      // initiateSSOLogin performs a full redirect; if it returns, treat as error
      setLoading(false);
      setErrorMsg('Authentication service temporarily unavailable. Please try again in a few minutes.');
    } catch (err) {
      setLoading(false);
      // Show user-friendly message
      setErrorMsg(
        err instanceof Error
          ? err.message
          : 'Authentication failed. Please try again or contact IT support.'
      );
    }
  };

  const handleRetry = () => {
    setErrorMsg(null);
  };

  // This Login page does not process callback tokens in this task, but if the
  // URL contains code/state, handleSSOCallback would be used by a separate route.
  return (
    <main className={styles.container} aria-live="polite">
      <section className={styles.card} role="region" aria-labelledby="login-heading">
        <div className={styles.logoRow}>
          <div className={styles.logo} aria-hidden>
            U
          </div>
          <div>
            <h1 id="login-heading" className={styles.headerTitle}>UPSKILL Platform</h1>
            <p className={styles.subText}>Sign in with your organization account</p>
          </div>
        </div>

        <div aria-live="polite">
          {errorMsg && (
            <Alert
              message="Authentication unavailable"
              description={errorMsg}
              type="error"
              showIcon
              closable
              onClose={handleRetry}
              style={{ marginBottom: 12 }}
            />
          )}
        </div>

        <div className="flex flex-col items-center">
          <SSOButton onClick={handleSignIn} loading={loading} disabled={!!errorMsg} />
        </div>

        <div className="mt-3 text-sm text-neutral-400" aria-hidden>
          <button
            type="button"
            disabled
            style={{ cursor: 'not-allowed' }}
            className="underline text-neutral-300"
            aria-disabled="true"
          >
            Forgot Password?
          </button>
        </div>
      </section>
    </main>
  );
}