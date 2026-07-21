# Shopping List API

A backend REST API for managing shopping lists, stores, products, and shopping list items.
The project includes user authentication, protected endpoints, ownership checks, request validation, and DTO-based API responses.

## Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- JWT Authentication
- C#
- REST API architecture

## Features

- User registration and login
- JWT-based authentication
- Create and manage stores
- Create and manage products
- Create shopping lists
- Get current user's shopping lists
- Get shopping list details with items
- Add items to shopping lists
- Check and uncheck shopping list items
- Delete shopping list items
- User ownership checks for protected data
- Request validation using data annotations
- DTO-based responses to avoid exposing EF entities directly

## Project Structure

The API follows a layered structure:

- `Controllers` handle HTTP requests and responses
- `Services` contain business logic
- `Repositories` handle database access
- `DTOs` define request and response models
- `Domain/Entities` contains database entities
- `Data/ApplicationDbContext` configures EF Core and relationships

## Getting Started

### Prerequisites

Make sure you have installed:

- .NET SDK
- SQL Server
- Entity Framework Core tools

### Setup

Clone the repository:

```powershell
git clone <your-repository-url>
cd ShoppingListApp
```

Restore packages:

```powershell
dotnet restore
```

Build the project:

```powershell
dotnet build
```

## Database Setup

This project currently uses SQL Server. The development connection string is configured in:

```text
ShoppingListApi/appsettings.Development.json
```

Apply database migrations:

```powershell
dotnet ef database update --project ShoppingListApi
```

The API does not include a demo database yet, so products, stores, shopping lists, and shopping list items should be created through the API demo requests after registration and login.

Run the API:

```powershell
dotnet run --project ShoppingListApi --launch-profile http
```

The API will run at:

```text
http://localhost:5232
```

## Authentication

Most endpoints require a JWT token.

First register or login, then send the token in the request header:

```text
Authorization: Bearer <your-token>
```

## OpenAPI

When running in development mode, the OpenAPI document is available at:

```text
http://localhost:5232/openapi/v1.json
```

Protected endpoints require a JWT bearer token. Use the demo requests in `ShoppingListApi/ShoppingListApi.http` to register, login, and send authenticated requests.

## Main API Endpoints

### Auth

```text
POST /api/Auth/register
POST /api/Auth/Login
```

### Shopping Lists

```text
GET  /api/ShoppingLists
POST /api/ShoppingLists
GET  /api/ShoppingLists/{shoppingListId}
```

### Shopping List Items

```text
POST   /api/ShoppingListItem
POST   /api/ShoppingListItem/{shoppingListItemId}/checked?isChecked=true
DELETE /api/ShoppingListItem/{shoppingListItemId}
```

### Stores

```text
POST   /api/Store
GET    /api/Store/{storeId}
GET    /api/Store/search?storeName=Aldi
DELETE /api/Store/{storeId}
```

### Products

```text
POST /api/Product
GET  /api/Product/{productId}
GET  /api/Product/search?title=milk
```

## API Demo Requests

Ready-to-run demo requests are available in `ShoppingListApi/ShoppingListApi.http`.

Suggested test order:

1. Register a user
2. Login and copy the JWT token
3. Paste the token into `@token`
4. Create a product and copy its returned id into `@productId`
5. Create a store and copy its returned id into `@storeId`
6. Create a shopping list and copy its returned id into `@shoppingListId`
7. Create a shopping list item and copy its returned id into `@shoppingListItemId`
8. Test list details, check/uncheck, and delete requests

## Testing

Automated tests are in the `ShoppingListApi.Tests` project.

Run tests with:

```powershell
dotnet test
```

Current unit test coverage includes:

- `ProductService`
- `StoreService`
- `ShoppingListService`
- `ShoppingListItemService`
- Request DTO validation

Validation tests use `System.ComponentModel.DataAnnotations.Validator` to verify request DTO rules.

## What This Project Demonstrates

This project demonstrates backend development skills including:

- Building REST APIs with ASP.NET Core
- Using Entity Framework Core with SQL Server
- Implementing authentication with ASP.NET Core Identity and JWT
- Protecting user data with ownership checks
- Separating code into controllers, services, and repositories
- Creating DTOs for clean API responses
- Validating request models
- Working with relational data and navigation properties
- Handling common API errors with appropriate status codes

## Status

This project is a backend portfolio API focused on the core features of a shopping list application.
Future improvements may include:

- Swagger JWT authorization setup
- Integration tests
- Deployment
- Frontend client
