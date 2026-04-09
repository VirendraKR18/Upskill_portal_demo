import React from 'react';
import { Button, Spin } from 'antd';

type SSOButtonProps = {
  onClick: () => void;
  loading?: boolean;
  disabled?: boolean;
  'aria-label'?: string;
};

export default function SSOButton({
  onClick,
  loading = false,
  disabled = false,
  'aria-label': ariaLabel = 'Sign in with Organization Account'
}: SSOButtonProps): JSX.Element {
  const handleKeyDown = (e: React.KeyboardEvent) => {
    if (disabled || loading) return;
    if (e.key === 'Enter' || e.key === ' ') {
      e.preventDefault();
      onClick();
    }
  };

  return (
    <Button
      type="primary"
      onClick={onClick}
      disabled={disabled || loading}
      aria-label={ariaLabel}
      size="large"
      style={{
        minWidth: 320,
        height: 48,
        backgroundColor: '#0078D4',
        borderColor: '#0078D4',
        boxShadow: 'none'
      }}
      onKeyDown={handleKeyDown}
    >
      <div className="flex items-center justify-center gap-3">
        {loading ? (
          <>
            <Spin size="small" />
            <span>Redirecting to SSO...</span>
          </>
        ) : (
          <span>Sign in with Organization Account</span>
        )}
      </div>
    </Button>
  );
}