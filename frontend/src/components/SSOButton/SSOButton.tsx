import React from 'react';
import { Button, Spin } from 'antd';
import { PoweroffOutlined } from '@ant-design/icons';
import styles from './SSOButton.module.css';

interface SSOButtonProps {
  onClick: () => void;
  loading?: boolean;
  disabled?: boolean;
}

export const SSOButton: React.FC<SSOButtonProps> = ({ onClick, loading = false, disabled = false }) => {
  const handleKeyDown = (e: React.KeyboardEvent<HTMLButtonElement>) => {
    if (disabled || loading) return;
    if (e.key === 'Enter' || e.key === ' ') {
      e.preventDefault();
      onClick();
    }
  };

  return (
    <Button
      type="primary"
      aria-label="Sign in with Organization Account"
      role="button"
      className={`${styles.ssoButton} tw-font-sans`}
      onClick={() => {
        if (!disabled && !loading) onClick();
      }}
      onKeyDown={handleKeyDown}
      disabled={disabled}
      style={{
        backgroundColor: '#0078D4',
        borderColor: '#0078D4',
        height: 48,
        minWidth: 320,
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        gap: 12
      }}
    >
      {loading ? (
        <>
          <Spin size="small" />
          <span>Redirecting to SSO...</span>
        </>
      ) : (
        <>
          <PoweroffOutlined aria-hidden />
          <span>Sign in with Organization Account</span>
        </>
      )}
    </Button>
  );
};

export default SSOButton;