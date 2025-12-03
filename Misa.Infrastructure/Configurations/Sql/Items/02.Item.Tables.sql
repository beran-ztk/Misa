CREATE TABLE items
(
    id              UUID DEFAULT gen_random_uuid() PRIMARY KEY,
    
    owner_id        UUID,
    state_id        INT NOT NULL REFERENCES item_states(id)     ON DELETE RESTRICT,
    priority_id     INT NOT NULL REFERENCES item_priorities(id) ON DELETE RESTRICT,
    category_id     INT NOT NULL REFERENCES item_categories(id) ON DELETE RESTRICT,
    
    title           TEXT NOT NULL,
    
    created_at_utc  TIMESTAMPTZ NOT NULL DEFAULT now(),
    updated_at_utc  TIMESTAMPTZ
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

CREATE TABLE relations
(
    id              INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,

    item_parent_id  UUID NOT NULL REFERENCES items(id) ON DELETE CASCADE,
    item_child_id   UUID NOT NULL REFERENCES items(id) ON DELETE CASCADE,
    relation_id     INT  NOT NULL REFERENCES item_relations_types(id) ON DELETE RESTRICT,

    created_at_utc TIMESTAMPTZ NOT NULL DEFAULT now(),

    CONSTRAINT no_self_link CHECK (item_parent_id != item_child_id),
    CONSTRAINT unique_link UNIQUE (item_parent_id, item_child_id, relation_id)
);
CREATE INDEX idx_relations_parent 
    ON relations(item_parent_id);
CREATE INDEX idx_relations_child
    ON relations(item_child_id);
CREATE INDEX idx_relations_relation
    ON relations(relation_id);

CREATE TABLE descriptions
(
    id              UUID DEFAULT gen_random_uuid() PRIMARY KEY,
    
    item_id         UUID NOT NULL REFERENCES items(id) ON DELETE CASCADE,
    type_id         INT  NOT NULL REFERENCES item_description_types(id) ON DELETE RESTRICT,
    
    content         TEXT NOT NULL,
    
    sort_order      INT  NOT NULL,
    created_at_utc  TIMESTAMPTZ NOT NULL DEFAULT now(),
    
    CONSTRAINT ux_descriptions_content UNIQUE (item_id, content),
    CONSTRAINT ux_descriptions_sort_order UNIQUE (item_id, sort_order)
);
