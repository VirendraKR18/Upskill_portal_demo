import React, { useState, useEffect } from 'react';
import { Alert, Button } from 'antd';
import { useNavigate } from 'react-router-dom';
import SSOButton from '../../components/SSOButton/SSOButton';
import * as ssoService from '../../services/auth/ssoService';
import styles from './Login.module.css';

const ERROR_MESSAGES = {
  network: 'Authentication service temporarily unavailable. Please try again in a few minutes.',
  failure: 'Authentication failed. Please try again or contact IT support.'
};

export const Login: React.FC = () => {
  const navigate = useNavigate();
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [autoDismissTimer, setAutoDismissTimer] = useState<number | null>(null);

  useEffect(() => {
    return () => {
      if (autoDismissTimer) {
        window.clearTimeout(autoDismissTimer);
      }
    };
  }, [autoDismissTimer]);

  const handleSSO = async () => {
    setError(null);
    setLoading(true);
    try {
      await ssoService.initiateSSOLogin();
      // initiateSSOLogin will redirect the browser; if it returns, stop loading.
      setLoading(false);
    } catch (err) {
      // Provide user-friendly messages; differentiate unknown vs network via thrown message.
      const message =
        (err instanceof Error && err.message === 'SSO provider temporarily unavailable')
          ? ERROR_MESSAGES.network
          : ERROR_MESSAGES.failure;
      setError(message);
      setLoading(false);
      // Auto-dismiss after 10s
      const id = window.setTimeout(() => setError(null), 10000);
      setAutoDismissTimer(id);
    }
  };

  const handleRetry = () => {
    setError(null);
  };

  return (
    <main className={styles.container} aria-live="polite">
      <section className={styles.card} role="region" aria-labelledby="login-heading">
        <div className={styles.header}>
          <div className={styles.logo} aria-hidden>AL</div>
          <div>
            <h1 id="login-heading" className={styles.title}>AI Learning Platform</h1>
            <p className={styles.subtitle}>Sign in with your organization account</p>
          </div>
        </div>

        {error && (
          <Alert
            type="error"
            message={error}
            showIcon
            style={{ marginTop: 8 }}
            action={<Button onClick={handleRetry}>Retry</Button>}
            aria-live="assertive"
          />
        )}

        <div style={{ marginTop: 8 }}>
          <SSOButton onClick={handleSSO} loading={loading} disabled={false} />
        </div>

        <div style={{ marginTop: 12 }}>
          <button
            aria-disabled="true"
            disabled
            style={{ color: '#9CA3AF', background: 'transparent', border: 'none', cursor: 'not-allowed' }}
            title="Forgot Password (managed by organization)"
          >
            Forgot password?
          </button>
        </div>
      </section>
    </main>
  );
};

export default Login;