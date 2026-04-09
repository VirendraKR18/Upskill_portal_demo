import React from 'react';
import { Routes, Route, Navigate } from 'react-router-dom';
import Login from './pages/Login/Login';

function DashboardPlaceholder({ title }: { title: string }) {
  return (
    <main className="min-h-screen flex items-center justify-center">
      <section className="bg-white p-8 rounded shadow-card">
        <h1 className="text-2xl font-semibold">{title}</h1>
        <p className="text-neutral-500 mt-2">This is a placeholder route for {title}.</p>
      </section>
    </main>
  );
}

export default function App(): JSX.Element {
  return (
    <Routes>
      <Route path="/login" element={<Login />} />
      <Route path="/dashboard" element={<DashboardPlaceholder title="Learner Dashboard" />} />
      <Route path="/manager-dashboard" element={<DashboardPlaceholder title="Manager Dashboard" />} />
      <Route path="/admin-console" element={<DashboardPlaceholder title="Admin Console" />} />
      <Route path="/leadership-dashboard" element={<DashboardPlaceholder title="Leadership Dashboard" />} />
      <Route path="/" element={<Navigate to="/login" replace />} />
    </Routes>
  );
}