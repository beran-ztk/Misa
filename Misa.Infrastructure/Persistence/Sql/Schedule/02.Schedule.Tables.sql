CREATE TABLE schedule_frequency_types
(
    id        INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    name      TEXT NOT NULL UNIQUE,
    synopsis  TEXT
);

INSERT INTO schedule_frequency_types (name)
VALUES
    ('Minutes'),
    ('Hours'),
    ('Days'),
    ('Weeks'),
    ('Months'),
    ('Years');

CREATE TABLE scheduled_deadlines
(
    id              UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    item_id         UUID NOT NULL REFERENCES items(entity_id) ON DELETE CASCADE,

    deadline_at_utc TIMESTAMPTZ NOT NULL,

    created_at_utc  TIMESTAMPTZ NOT NULL DEFAULT now(),

    CONSTRAINT uq_scheduled_deadlines_item UNIQUE (item_id)
);

-- Enums
CREATE TYPE schedule_rule_state AS ENUM ('running', 'paused', 'done');
CREATE TYPE schedule_misfire_policy AS ENUM ('skip', 'catchup', 'run_once');

CREATE TABLE scheduled_recurrence_rules
(
    id                      UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    schedule_id             UUID NOT NULL REFERENCES schedule(entity_id) ON DELETE CASCADE,

    freq_type_id            INT  NOT NULL REFERENCES schedule_frequency_types(id) ON DELETE RESTRICT,
    freq_interval           INT  NOT NULL DEFAULT 1,

    occurrence_count_limit  INT  NULL,

    by_day                  INT[] NULL, -- 1=Mon..7=Sun
    by_month_day            INT[] NULL, -- 1..31
    by_month                INT[] NULL, -- 1..12

    misfire_policy          schedule_misfire_policy NOT NULL DEFAULT 'catchup',

    lookahead_count         INT NOT NULL DEFAULT 1 CHECK (lookahead_count >= 0),

    occurrence_ttl          INTERVAL NULL CHECK (occurrence_ttl IS NULL OR occurrence_ttl > INTERVAL '0'),

    state                  schedule_rule_state NOT NULL DEFAULT 'running',

    payload                JSONB NULL,

    timezone               TEXT NOT NULL CHECK (timezone != ''),

    start_time             TIME NULL,
    end_time               TIME NULL,

    active_from_utc           TIMESTAMPTZ NOT NULL,
    active_until_utc           TIMESTAMPTZ NULL,

    last_run_at_utc        TIMESTAMPTZ NULL,
    next_due_at_utc        TIMESTAMPTZ NULL,

    -- invariants
    CHECK (
        (start_time IS NULL AND end_time IS NULL)
            OR (start_time IS NOT NULL AND end_time IS NOT NULL AND start_time < end_time)
        ),
    CHECK (active_until_utc IS NULL OR active_until_utc > active_from_utc),
    CHECK (frequency_interval >= 1),
    CHECK (occurrence_count_limit IS NULL OR occurrence_count_limit >= 1),
    CHECK (next_due_at_utc IS NULL OR last_run_at_utc IS NULL OR next_due_at_utc >= last_run_at_utc),
    CHECK (by_day IS NULL OR (1 <= ALL(by_day) AND ALL(by_day) <= 7)),
    CHECK (by_month_day IS NULL OR (1 <= ALL(by_month_day) AND ALL(by_month_day) <= 31)),
    CHECK (by_month IS NULL OR (1 <= ALL(by_month) AND ALL(by_month) <= 12))
);

-- sinnvolle Indizes für den Runner
CREATE INDEX ix_srr_schedule_id ON scheduled_recurrence_rules(schedule_id);
CREATE INDEX ix_srr_due_running ON scheduled_recurrence_rules(next_due_at_utc)
    WHERE state = 'running';


ExecutionLog / RunHistory
id
rule_id
scheduled_for
started_at, finished_at
status (ok/fail)
dedupe_key = (rule_id, scheduled_for) (unique)

Optional but common:
Outbox table for notifications/events (reliable delivery).
Concurrency + safety = Lock table

-- create table calendar_occurrences
-- (
--     id                  uuid primary key default gen_random_uuid(),
--     recurrence_rule_id   uuid not null references schedule_recurrence_rules(id) on delete cascade,
--     
--     occurs_at_utc       timestamptz not null,
--     expires_at_utc      timestamptz null,
--     generated_at_utc    timestamptz not null default now()
-- );
