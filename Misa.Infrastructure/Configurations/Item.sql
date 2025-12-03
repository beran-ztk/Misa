CREATE EXTENSION IF NOT EXISTS "pgcrypto"; -- For gen_random_uuid() function
       
CREATE TABLE items
(
    id              UUID DEFAULT   gen_random_uuid() PRIMARY KEY,
    
    owner_id        UUID,
    state_id        INT REFERENCES lu_states(id)     ON DELETE RESTRICT,
    priority_id     INT REFERENCES lu_priorities(id) ON DELETE RESTRICT,
    category_id     INT REFERENCES lu_categories(id) ON DELETE RESTRICT,
    
    title           TEXT NOT NULL,
    description     TEXT,
    
    created_at_utc  TIMESTAMPTZ DEFAULT now(),
    updated_at_utc  TIMESTAMPTZ,
);
CREATE INDEX idx_items_owner
    ON items(owner_id);
CREATE INDEX idx_items_state
    ON items(state_id);
CREATE INDEX idx_items_priority
    ON items(priority_id);
CREATE INDEX idx_items_category
    ON items(category_id);
CREATE INDEX idx_items_created
    ON items(created_at_utc);


CREATE TABLE item_relations
(
    id              INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,

    item_parent_id  UUID REFERENCES items(id) ON DELETE RESTRICT,
    item_child_id   UUID REFERENCES items(id) ON DELETE RESTRICT,
    relation_id     INT  REFERENCES lu_relations(id) ON DELETE RESTRICT,

    created_at_utc TIMESTAMPTZ DEFAULT now()

    CONSTRAINT no_self_link CHECK (item_parent_id != item_child_id),
    CONSTRAINT unique_link UNIQUE (item_parent_id, item_child_id, relation_id)
);
CREATE INDEX idx_item_relations_parent 
    ON item_relations(item_parent_id);
CREATE INDEX idx_item_relations_child
    ON item_relations(item_child_id);
CREATE INDEX idx_item_relations_relation
    ON item_relations(relation_id);

create table item_modules
(
    id              int generated always as identity primary key,
    fk_item         int not null references items(id) on delete restrict,
    fk_completion   int references lu_completions(id) on delete restrict, -- Wie viel vom geplanten
    fk_attainment   int references lu_attainments(id) on delete restrict, -- Verständnisgrad der neuen Inhalte
    purpose         text,
    summary         text
);