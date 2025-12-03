INSERT INTO lu_states (name)
VALUES
    ('Draft'),('Open'),
    ('Active'),('Paused'),
    ('Blocked'),('Done'),
    ('Canceled'),('Failed'),
    ('Archived'),('Removed'),
    ('Expired');

INSERT INTO lu_priorities (name)
VALUES
    ('Unassigned'),
    ('Minor'),('Normal'),
    ('Important'),('Critical');

INSERT INTO lu_categories (id, domain, name, synopsis)
VALUES
    (100,'Task','Personal',                 'Private oder persönliche Aufgaben'),
    (101,'Task','School',                   'Aufgaben aus der Ausbildung oder Studium'),
    (102,'Task','Work',                     'Berufliche Aufgaben'),

    (200,'Entry','Calendar',                'Kalendereintrag oder Termin'),
    (201,'Entry','Event',                   'Kalenderereignis'),
    (203,'Entry','Module',                 'Moduleintrag'),
    (204,'Entry','Notification',                 'Benachrichtigung'),

    (400,'Journal','General',                 'Tagebucheintrag'),
    (401,'Journal','Personal',                 'Persönliche Geschehen'),
    (402,'Journal','Work',                 'Berufliche  Geschehen'),
    (404,'Journal','School',                 'Schulische Geschehen'),

    (300,'Knowledge','Read_Theory',         'Lies theoretische Inhalte oder Artikel zum Modul'),
    (301,'Knowledge','Watch_Video',         'Schau ein erklärendes Video oder Vortrag'),
    (302,'Knowledge','Read_ResearchPaper',  'Lies und analysiere wissenschaftliche Publikation'),
    (303,'Knowledge','Study_Example',       'Analysiere ein konkretes Beispiel oder Fallstudie'),
    (304,'Knowledge','Compare_Concepts',    'Vergleiche ähnliche Konzepte oder Theorien'),
    (305,'Knowledge','Define_Glossary',     'Zentrale Fachbegriffe präzise definieren'),
    (306,'Knowledge','Write_Questions',     'Offene Fragen und Wissenslücken sammeln'),

    (307,'Knowledge','Write_Summary',       'Erstelle eine Zusammenfassung des Gelernten'),
    (308,'Knowledge','Create_Diagram',      'Visualisiere Wissen als Mindmap, Grafik oder Schaubild'),
    (309,'Knowledge','Create_CheatSheet',   'Kompakter 1-Pager mit Kernpunkten/Formeln'),

    (310,'Knowledge','Solve_Task',          'Löse Übungsaufgaben oder Anwendungsfragen'),
    (311,'Knowledge','Code_Implementation', 'Implementiere Konzepte in Code oder Experiment'),
    (312,'Knowledge','Conduct_Experiment',  'Führe einen praktischen Versuch oder Test durch'),
    (313,'Knowledge','Replicate_Tutorial',  'Beispiel/Tutorial exakt reproduzieren'),
    (314,'Knowledge','Prototype_Solution',  'Entwirf oder implementiere eine Lösung für ein reales Problem'),
    (315,'Knowledge','Design_API',          'APIs/Contracts für Konzepte entwerfen'),
    (316,'Knowledge','Build_TestSuite',     'Tests schreiben, um Verständnis/Code abzusichern'),
    (317,'Knowledge','Code_Refactor',       'Verbessere oder modernisiere bestehenden Code'),
    (318,'Knowledge','Performance_Test',    'Messe Leistungskennzahlen einer Lösung oder Theorie'),
    (319,'Knowledge','Optimization',        'Verbessere bestehende Arbeit oder Implementierung'),
    (320,'Knowledge','Reverse_Engineering', 'Analysiere und zerlege existierende Systeme oder Konzepte'),
    (321,'Knowledge','Create_Template',     'Vorlage/Template für wiederkehrende Arbeit erstellen'),

    (322,'Knowledge','Review_Content',      'Wiederhole Wissen aus früheren Units'),
    (323,'Knowledge','Knowledge_Check',     'Selbsttest zur Überprüfung des Verständnisses'),
    (324,'Knowledge','Rebuild_From_Memory', 'Rekonstruiere Wissen ohne Notizen'),

    (325,'Knowledge','Apply_To_RealWorld',  'Übertrage das Wissen auf ein reales Szenario oder Problem'),
    (326,'Knowledge','Synthesize_Knowledge','Führe Erkenntnisse aus mehreren Units zusammen'),
    (327,'Knowledge','Create_Index',        'Erstelle einen thematischen Index für das Modul'),
    (328,'Knowledge','Teach_Person',        'Erkläre das Thema einer anderen Person'),
    (329,'Knowledge','Peer_Review',         'Ergebnis von anderer Person reviewen lassen'),
    (330,'Knowledge','Contribute_Community','Teile Wissen in einer Community oder Plattform'),
    (331,'Knowledge','Write_Paper',         'Schreibe einen Essay, Bericht oder Blogartikel'),

    (332,'Knowledge','Error_Analysis',      'Untersuche Fehlerquellen oder Missverständnisse'),
    (333,'Knowledge','Brainstorm',          'Generiere neue Fragen oder Forschungsansätze'),
    (334,'Knowledge','Free_Exploration',    'Lerne ohne festes Ziel, um neue Ideen zu entdecken'),
    (335,'Knowledge','Cleanup_Notes',       'Überarbeite Notizen, Markdown oder Obsidian-Einträge');

insert into lu_relations (name, synopsis) values
-- Hierarchische / strukturelle Beziehungen
('contains',               'Parent-Item beinhaltet das Child-Item, z.B. Modul → Unit'),
('part_of',                'Child-Item ist Teil des Parent-Items, inverse von contains'),
('depends_on',             'Child benötigt Parent als Voraussetzung (Abhängigkeit)'),
('follows',                'Child folgt logisch oder zeitlich nach Parent'),
('refers_to',              'Child bezieht sich auf Parent, aber ohne direkte Hierarchie'),

-- Lern- und Wissensbeziehungen
('prerequisite',           'Parent ist notwendige Voraussetzung, um Child zu verstehen'),
('reinforces',             'Child wiederholt oder stärkt Wissen des Parent-Items'),
('contradicts',            'Child steht im Gegensatz oder überprüft die Gültigkeit von Parent'),
('derived_from',           'Child wurde aus Inhalten des Parent abgeleitet oder zusammengefasst'),
('evaluates',              'Child bewertet, überprüft oder testet Inhalte des Parent'),

-- Semantische / inhaltliche Beziehungen
('related_to',             'Lose semantische Verbindung zwischen zwei Items'),
('alternative_to',         'Alternative Lösung oder Sichtweise auf dasselbe Thema'),
('expands',                'Child erweitert den Inhalt des Parent'),
('specializes',            'Child ist eine spezifischere Form oder Unterkategorie des Parent'),
('generalizes',            'Child ist eine allgemeinere oder abstraktere Form von Parent'),

-- Prozess- / Workflow-Beziehungen
('triggers',               'Parent löst das Child-Item aus (z.B. Event → Action)'),
('blocks',                 'Parent verhindert oder verzögert die Ausführung des Child-Items'),
('mirrors',                'Child spiegelt den Fortschritt oder Zustand des Parent wider'),
('records',                'Child dokumentiert oder protokolliert Aktivitäten des Parent'),
('supersedes',             'Child ersetzt oder überarbeitet den Parent'),

-- Soziale / kollaborative Beziehungen (optional)
('authored_by',            'Child wurde von einer Person oder Quelle erstellt'),
('assigned_to',            'Child wurde einer Person, Gruppe oder Rolle zugewiesen'),
('discusses',              'Child behandelt oder analysiert das Thema des Parent'),
('summarizes',             'Child fasst den Inhalt des Parent zusammen'),
('teaches',                'Child dient der Vermittlung des Parent-Inhalts an andere');