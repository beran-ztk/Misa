# MISA

MISA is a personal meta-organization and orchestration system.  
It is designed to model, connect, and control tasks, units, sessions, and actions in a structured and explicit way.

## Concept
MISA is not a traditional task manager.  
It treats work and knowledge as **Items** with clearly defined lifecycles, dependencies, and state transitions that can be orchestrated.

## Core Concepts
• Items – central entities (tasks, modules, units, etc.)  
• Sessions – time-based activity units  
• Actions – state or content changes  
• States – explicit lifecycle states

## Architecture
Clean Architecture with a strict separation between Domain, Application, Infrastructure, API, and UI layers.  
DDD-oriented modeling with clear responsibilities.

## Direction
MISA includes a deeply integrated calendar used for orchestration rather than scheduling.  
Its long-term goal is to manage a Zettelkasten-like knowledge system where topics, work units, and decisions can be critically evaluated over time.

## Status
Work in progress.  
No stable release, ongoing re-architecture.

## Tech Stack
• .NET  
• ASP.NET Web API  
• Avalonia UI (MVVM)  
• PostgreSQL  
• REST
