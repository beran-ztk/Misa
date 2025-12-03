CREATE TABLE item_states
(
    id          INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    name        TEXT NOT NULL UNIQUE,
    synopsis    TEXT,
    sort_order  INT NOT NULL
);

CREATE TABLE item_priorities
(
    id          INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    name        TEXT NOT NULL UNIQUE,
    synopsis    TEXT,
    sort_order  INT NOT NULL
);

CREATE TABLE item_categories
(
    id          INT PRIMARY KEY,
    name        TEXT NOT NULL,
    synopsis    TEXT,
    sort_order  INT NOT NULL
);
CREATE UNIQUE INDEX ux_item_categories_name
    ON item_categories((id/100), name);
CREATE UNIQUE INDEX ux_item_categories_sort_order
    ON item_categories((id/100), sort_order);

CREATE TABLE item_relations
(
    id          INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    name        TEXT NOT NULL UNIQUE,
    synopsis    TEXT,
    sort_order  INT NOT NULL
);
