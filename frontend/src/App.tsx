import React from 'react';
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import Login from './pages/Login/Login';

const DashboardPlaceholder: React.FC<{ title: string }> = ({ title }) => (
  <main style={{ padding: 32 }}>
    <h2>{title}</h2>
    <p>This is a placeholder page for development/testing.</p>
  </main>
);

export const App: React.FC = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Navigate to="/login" replace />} />
        <Route path="/login" element={<Login />} />
        <Route path="/dashboard" element={<DashboardPlaceholder title="Learner Dashboard" />} />
        <Route path="/manager-dashboard" element={<DashboardPlaceholder title="Manager Dashboard" />} />
        <Route path="/admin-console" element={<DashboardPlaceholder title="Admin Console" />} />
        <Route path="/leadership-dashboard" element={<DashboardPlaceholder title="Leadership Dashboard" />} />
        <Route path="/auth/callback" element={<DashboardPlaceholder title="SSO Callback (handled by backend in production)" />} />
        <Route path="*" element={<Navigate to="/login" replace />} />
      </Routes>
    </BrowserRouter>
  );
};

export default App;