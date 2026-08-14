# demo

This repository contains a demo ASP.NET Core Web API project with CRUD operations.

Structure:
- src/DemoApp: ASP.NET Core Web API

Run locally:
1. Install .NET 8 SDK (or change TargetFramework in the project file).
2. From the repository root run:
   - dotnet restore
   - dotnet run --project src/DemoApp

API endpoints:
- GET    /api/items
- GET    /api/items/{id}
- POST   /api/items
- PUT    /api/items/{id}
- DELETE /api/items/{id}
