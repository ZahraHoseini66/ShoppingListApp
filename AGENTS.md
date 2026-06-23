# AGENTS.md

This file provides guidance to Codex (Codex.ai/code) when working with code in this repository.

## Commands

```bash
# Restore dependencies
dotnet restore

# Build
dotnet build

# Run the API (available at http://localhost:5232)
dotnet run --project ShoppingListApi

# Apply EF Core migrations to database
dotnet ef database update --project ShoppingListApi

# Create a new migration after model changes
dotnet ef migrations add <MigrationName> --project ShoppingListApi
```

There is no automated test suite. The file `ShoppingListApi/ShoppingListApi.http` contains manual HTTP test cases for the endpoints.

## Architecture

This is an ASP.NET Core 10 Web API using a layered architecture with strict separation: **Controllers → Services → Repositories → EF Core (SQL Server LocalDB)**.

All controllers inherit from `ApiBaseController`, which exposes a `UserId` property parsed from the JWT claims. Every controller is `[Authorize]`-protected except `AuthController`. The base controller pattern means you can always trust `UserId` is valid within any action method.

The dependency injection chain is:
- Controllers depend on service interfaces (`IShoppingListService`, etc.)
- Services depend on repository interfaces (`IShoppingListRepository`, etc.)
- Repositories depend on `ApplicationDbContext`

All registrations are in `Program.cs`.

### Key domain concepts

- **ShoppingList** — the central aggregate; has a status (`Active`/`Completed`/`Archived`), optional `StoreId`, and belongs to a user via `UserId`
- **ShoppingListItem** — line items on a list; references a `Product`, has `Quantity`, `UnitType`, and `IsChecked` flag
- **ShoppingListUser** — join table for sharing lists with permission levels (`Owner`/`Viewer`/`Editor`)
- **Product** → **Category** — product catalog with categories
- **Store** — store associated with a shopping list

### Authentication

JWT tokens are issued by `AuthController` (register/login). Token payload carries `sub`, `email`, and `nameidentifier` claims. Tokens expire in 2 hours. The JWT secret is in `appsettings.json` under `JwtSettings:SecretKey` — change this before any real deployment.

### Database

SQL Server LocalDB, database name `ShoppingListDb`, Windows-auth trusted connection. EF Core Code-First — always create a migration when changing entities. The `ApplicationDbContext` uses `IdentityDbContext<ApplicationUser>` for ASP.NET Identity tables and explicitly configures cascade vs. restrict delete rules (ShoppingListUser → User is `Restrict` to avoid multiple cascade paths).

### DTOs

Request DTOs live in `ShoppingListApi/DTOs/`. `ShoppingListSearchRequest` supports filtering by `Status`, date range, and `Id`, plus pagination via `PageNumber`/`PageSize`. Filtering logic is applied in `ShoppingListRepository`.
