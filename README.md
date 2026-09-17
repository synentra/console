# Synentra Console

Synentra Console is a .NET 10 Blazor Server application for operating and monitoring a Synentra gateway.

## What it provides

- Dashboard with key gateway metrics
- Agent management (register, view details, assign policy, delete)
- Policy browsing and details
- Token exchange flow for issuing access tokens
- HITL (Human-in-the-Loop) queue review and decisions
- Audit browsing
- Health status checks
- Proxy request lab for sending upstream requests through Synentra

## Tech stack

- .NET 10 (`net10.0`)
- Blazor Server (interactive server components)
- MudBlazor UI components
- Blazored LocalStorage for client preferences (theme/drawer state)

## Prerequisites

- .NET SDK 10.0+

## Run locally

From the repository root:

1. Restore dependencies
   - `dotnet restore ./src/Console.csproj`
2. Run the app
   - `dotnet run --project ./src/Console.csproj`

By default, launch profiles expose:

- HTTP: `http://localhost:8180`
- HTTPS: `https://localhost:7181`

## Runtime configuration

The app can load configuration from standard ASP.NET Core sources (JSON files, environment variables, user secrets, command-line).

You can also provide a dedicated config file using the `config` command-line key. When this is set, only that file is loaded.

Example:

- `dotnet run --project ./src/Console.csproj -- --config C:\configs\console.json`

### Endpoint configuration shape

Use an `Endpoints` section like:

`Endpoints.Http.Port` (default `8180`)
`Endpoints.Https.Enabled` (default `false`)
`Endpoints.Https.Port` (default `8443`)
`Endpoints.Https.Certificate.Path`
`Endpoints.Https.Certificate.Password` (optional)

If HTTPS is enabled, HTTP and HTTPS ports must be different.

## Container build

A Dockerfile is available at `.docker/Dockerfile`.

Typical build and run:

- `docker build -f .docker/Dockerfile -t synentra-console .`
- `docker run --rm -p 6264:6264 synentra-console`

## Project structure

- `src/Program.cs` - app startup and configuration loading
- `src/Extensions` - HTTP server and service registration extensions
- `src/Services` - API client and shared session state
- `src/Pages` - Blazor pages for dashboard, security, operations, and health
- `src/Layout` - shell layout and navigation
- `src/Models` - API contracts and view models

## License

See `LICENSE`.
