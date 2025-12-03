create table lu_recurrings
(
    id      int generated always as identity primary key,
    name    text not null unique
);
INSERT INTO lu_recurrings (name)
VALUES ('Minutes'),('Hours'),('Days'),('Months'),('Years');



create table lu_actions
(
    id      int primary key,
    name    text not null unique
);
INSERT INTO lu_actions (id, name)
VALUES
    (101, 'State'),(102, 'Priority'),(103, 'Category'),
    (105, 'Name'),(106, 'Note'),

    (202, 'Recurring'),(203, 'Interval'),(204, 'Occurrence'),
    (205, 'InstanceTtlHours'),(206, 'CatchUp'),(207, 'Active'),
    (208, 'Start'),(209, 'Until'),(210, 'LastGenerated'),

    (401, 'UnitId'),(403, 'Completion'),(404, 'Attainment'),(405, 'Purpose'),

    (503, 'Revision'),(504, 'Weight'),(505, 'Discretion'),

    (600, 'TopicId'),(603, 'Recall'),(604, 'Comprehension'),
    (605, 'Analysis'),(606, 'Application'),(607, 'Creation'),
    (608, 'Teachability'),(609, 'Confidence'),

    (701, 'Efficiency'),(702, 'Concentration'),
    (703, 'Objective'),(704, 'Synopsis'),
    (705, 'PlannedDuration'),(706, 'Started'),(707, 'Ended');
-- Zettelkasten

create table lu_revisions
(
    id       int generated always as identity primary key,
    name     text not null unique,
    synopsis text
);
INSERT INTO lu_revisions (name)
VALUES ('Test');

create table lu_weights
(
    id       int generated always as identity primary key,
    name     text not null unique,
    synopsis text
);
INSERT INTO lu_weights (name)
VALUES ('Test');

create table lu_discretions
(
    id       int generated always as identity primary key,
    name     text not null unique,
    synopsis text
);
INSERT INTO lu_discretions (name)
VALUES ('Test');

create table lu_tags
(
    id       int generated always as identity primary key,
    name     text not null unique,
    synopsis text
);
INSERT INTO lu_tags (name)
VALUES ('Meow'),('Evergreen'),('Properties besser'),('Wasser'),('Lampe');

create table lu_properties
(
    id       int generated always as identity primary key,
    name     text not null unique,
    synopsis text
);
INSERT INTO lu_properties (name)
VALUES ('Created'),('Difficulty'),('Readiness'),('Wew'),('Tür');

-- Audit

create table lu_efficiencies
(
    id       int generated always as identity primary key,
    name     text not null unique,
    synopsis text
);
INSERT INTO lu_efficiencies (name)
VALUES ('Wenig'),('Mehh'),('Insane');

create table lu_concentrations
(
    id       int generated always as identity primary key,
    name     text not null unique,
    synopsis text
);
INSERT INTO lu_concentrations (name)
VALUES ('Abgelenkt'),('Müde'),('Hyperfocus');





-- Topic

create table lu_recalls
(
    id       int generated always as identity primary key,
    name     text not null unique,
    synopsis text
);
INSERT INTO lu_recalls (name)
VALUES ('Test');

create table lu_comprehensions
(
    id       int generated always as identity primary key,
    name     text not null unique,
    synopsis text
);
INSERT INTO lu_comprehensions (name)
VALUES ('Test');

create table lu_analyses
(
    id       int generated always as identity primary key,
    name     text not null unique,
    synopsis text
);
INSERT INTO lu_analyses (name)
VALUES ('Test');

create table lu_applications
(
    id       int generated always as identity primary key,
    name     text not null unique,
    synopsis text
);
INSERT INTO lu_applications (name)
VALUES ('Test');

create table lu_creations
(
    id       int generated always as identity primary key,
    name     text not null unique,
    synopsis text
);
INSERT INTO lu_creations (name)
VALUES ('Test');

create table lu_teachabilities
(
    id       int generated always as identity primary key,
    name     text not null unique,
    synopsis text
);
INSERT INTO lu_teachabilities (name)
VALUES ('Test');

create table lu_confidences
(
    id       int generated always as identity primary key,
    name     text not null unique,
    synopsis text
);
INSERT INTO lu_confidences (name)
VALUES ('Test');



-- Unit

create table lu_completions
(
    id       int generated always as identity primary key,
    name     text not null unique,
    synopsis text
);
INSERT INTO lu_completions (name)
VALUES ('Test'),('Completed'),('Above Expactations'),('insanely perfect');

create table lu_attainments
(
    id       int generated always as identity primary key,
    name     text not null unique,
    synopsis text
);
INSERT INTO lu_attainments (name)
VALUES ('Test');
