# StudentsAppSQL9Pro

A simple `ASP.NET Core Razor Pages` CRUD application for managing students with `SQL Server`.

## Tech Stack

- `.NET 10` (`net10.0`)
- `Razor Pages`
- `Microsoft.Data.SqlClient`
- `AutoMapper`
- `Serilog`

## Features

- Create student
- View all students
- Update student
- Delete student
- Success feedback page after actions
- Request and file logging (`Logs/logs.txt`)

## Project Structure

- `Pages/Students` - Razor Pages for student workflows
- `Services` - business logic layer
- `DAO` - data access layer
- `Core/DBHelper.cs` - SQL connection helper
- `DTO` - input/output models

## Prerequisites

- `.NET 10 SDK`
- `SQL Server` (local or remote)

## Configuration

Set the connection string under `ConnectionStrings:DefaultConnection`.

Recommended with User Secrets:

1. Initialize secrets (if needed):
   - `dotnet user-secrets init`
2. Set connection string:
   - `dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Database=StudentsAppSqlDB9Pro;User ID=your_user;Password=your_password;TrustServerCertificate=True;Encrypt=True"`

You can also set it in `appsettings.Development.json` for local development.

## Run

From the project directory:

- `dotnet restore`
- `dotnet run --project StudentsAppSQL9Pro/StudentsAppSQL9Pro.csproj`

Default development URLs are configured in `Properties/launchSettings.json`.

## Logging

Serilog is configured to write logs to:

- Console
- `Logs/logs.txt` (daily rolling files)