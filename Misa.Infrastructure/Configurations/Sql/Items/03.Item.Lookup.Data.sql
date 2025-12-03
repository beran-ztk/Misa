INSERT INTO item_states (name, synopsis, sort_order)
VALUES
    ('Draft',     'Entwurf; noch nicht freigegeben',                    1),
    ('Open',      'Offen; bereit zur Bearbeitung',                      2),
    ('Active',    'In Bearbeitung; aktueller Fokus',                    3),
    ('Paused',    'Kurzfristig gestoppt; jederzeit fortsetzbar',        4),
    ('Blocked',   'Blockiert durch externe Abhängigkeiten',             5),
    ('Done',      'Erledigt und abgeschlossen',                         6),
    ('Canceled',  'Abgebrochen; wird nicht mehr bearbeitet',            7),
    ('Failed',    'Gescheitert; Ziel wurde nicht erreicht',             8),
    ('Archived',  'Aus dem aktiven Bereich ausgelagert',                9),
    ('Removed',   'Entfernt; praktisch gelöscht',                      10),
    ('Expired',   'Abgelaufen; nicht rechtzeitig abgeschlossen',       11);

INSERT INTO item_priorities (name, synopsis, sort_order)
VALUES
    ('None',     'Keine Priorität vergeben',      1),
    ('Low',      'Geringe Wichtigkeit',           2),
    ('Medium',   'Normale Priorität',             3),
    ('High',     'Wichtig; zeitnah bearbeiten',   4),
    ('Urgent',   'Dringend; sofortige Aktion',    5),
    ('Critical', 'Kritische Eskalation',          6);

INSERT INTO item_categories (name, synopsis)
VALUES
    ('Task',         'Konkrete Aufgaben oder To-Dos'),
    ('Calendar',     'Kalendereintrag, Termin oder zeitliche Planung'),
    ('Event',        'Ereignis mit festem Zeitpunkt'),
    ('Notification', 'Benachrichtigung oder Reminder'),
    ('Journal',      'Persönliche oder berufliche Notizen'),
    ('Module',       'Übergeordnetes Lern- oder Projektmodul'),
    ('Unit',         'Einzelne Lerneinheit oder Arbeitsschritt');

INSERT INTO item_relations_types (name, synopsis, sort_order)
VALUES
    ('contains',  'Parent-Item beinhaltet das Child-Item',                           1),
    ('follows',   'Child folgt logisch oder zeitlich nach Parent',                   2),
    ('triggers',  'Parent löst das Child-Item aus (z.B. Event → Action)',            3),
    ('blocks',    'Parent verhindert oder verzögert die Ausführung des Child-Items', 4);

INSERT INTO item_description_types (name, synopsis, sort_order)
VALUES
    ('Text',     'Einfacher Fließtext ohne Formatierung',                           1),
    ('Markdown', 'Formatierter Text mit Überschriften, Listen und Hervorhebungen',  2),
    ('Url',      'Referenz auf externe Inhalte, Webseiten oder Dateien',            3),
    ('Picture',  'Grafiken, Screenshots oder eingebettete Bilder',                  4);
