-- Initialize database
CREATE DATABASE todos_app;

\c todos_app

CREATE TABLE IF NOT EXISTS todos (
    id uuid PRIMARY KEY DEFAULT gen_random_uuid() NOT NULL,
    description TEXT NOT NULL,
    due_date timestamptz NOT NULL,
    created_date timestamptz NOT NULL,
    completed BOOLEAN NOT NULL
)