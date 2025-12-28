<div align="center">

<img src="./doc/img/authApi_icon.png" alt="" align="center" height="96" />

# Clean Architecture AuthApi

[![.NET Build and Test](https://github.com/Gramli/AuthApi/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Gramli/AuthApi/actions/workflows/dotnet.yml)
[![Angular Build](https://github.com/Gramli/AuthApi/actions/workflows/angular.yml/badge.svg)](https://github.com/Gramli/AuthApi/actions/workflows/angular.yml)
![.NET](https://img.shields.io/badge/.NET-10-512BD4?style=flat-square&logo=dotnet)
![Angular](https://img.shields.io/badge/Angular-21-DD0031?style=flat-square&logo=angular)
[![License](https://img.shields.io/badge/License-MIT-yellow?style=flat-square)](LICENSE.md)

⭐ If you like this project, star it on GitHub!

[Overview](#overview) • [Features](#features) • [Getting started](#getting-started) • [Running Tests](#running-tests) • [Limitations](#limitations) • [Architecture](#architecture) • [Technologies](#technologies)

</div>

A full-stack authentication and authorization solution demonstrating Clean Architecture principles with .NET 10 and Angular 21. This project showcases multiple authentication methods (JWT Bearer and Basic Authentication), role-based access control, and modern frontend patterns.

## Overview

This application demonstrates authentication and authorization patterns using a clean architecture approach. The backend implements **dual authentication schemes** (JWT Bearer tokens and Basic Authentication) with **minimal APIs**, while the frontend showcases modern Angular practices with standalone components and signals.

**Key capabilities:**
- User registration and login with JWT tokens
- Basic Authentication for service-to-service or admin access
- Role-based authorization with custom policies
- Custom claims middleware
- HTTP response caching
- Angular guards and interceptors for client-side auth

> [!TIP]
> The project uses in-memory Entity Framework for quick setup and testing. Perfect for learning and prototyping!

## Features

### Authentication Methods

- **JWT Bearer Authentication**: Secure token-based authentication for user sessions with configurable expiration and validation
- **Basic Authentication**: HTTP Basic auth scheme for service accounts, admin tools, or simple API access
- **Swagger Integration**: Pre-configured UI with support for both authentication methods, allowing easy API testing

### Application Features

- **CQRS Pattern**: Command-Query separation without the complexity of MediatR
- **Result Pattern**: No exceptions for flow control; uses [FluentResults](https://github.com/altmann/FluentResults) for explicit error handling
- **Response Caching**: HTTP response caching configured via extension methods
- **Custom Claims Middleware**: Dynamically enriches user claims during request processing
- **In-Memory Database**: Entity Framework Core InMemory provider for quick setup and testing
- **Standalone Components**: Modern Angular architecture without NgModules
- **Signals**: Reactive state management with Angular signals
- **JWT Token Management**: Automatic token storage and injection via interceptors
- **Route Guards**: Protect routes based on authentication state
- **PrimeNG UI**: UI components with PrimeFlex layout utilities

## Getting started

### Prerequisites

- **.NET SDK 10.0+** - [Download](https://dotnet.microsoft.com/download)
- **Node.js 20.x or 22.x** (LTS versions) - [Download](https://nodejs.org/)
- **Angular CLI 21+** - Install via `npm install -g @angular/cli`
- **IDE**: Visual Studio, JetBrains Rider, or VS Code

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/Gramli/AuthApi.git
   cd AuthApi/src
   ```

2. Install backend dependencies:
   ```bash
   dotnet restore
   ```

3. Install frontend dependencies:
   ```bash
   cd Auth.Frontend
   npm install
   ```

### Default Credentials

The application automatically seeds a default administrator account on startup:

**Default User:**
- **Username**: `admin`
- **Password**: `admin`
- **Role**: Administrator

You can use these credentials for:
- JWT Bearer Authentication: Login via `/api/auth/login` to get a token
- Basic Authentication: Direct HTTP Basic auth for API access
- New users can register via `/api/auth/register` endpoint

### Running the application

#### Run both backend and frontend:

1. **Start the backend**:
   ```bash
   # From the src directory
   dotnet run --project Auth.Api/Auth.Api.csproj
   ```
   The API will be available at `https://localhost:7190` or `http://localhost:5166`.

2. **Start the frontend** (in a new terminal):
   ```bash
   # From the src directory, navigate to Auth.Frontend
   cd Auth.Frontend
   ng serve
   ```
   Navigate to [http://localhost:4200](http://localhost:4200) in your browser.


#### Test using Swagger UI:

1. Open your IDE (Visual Studio or Rider) and run the **Auth.Api** project
2. Navigate to the Swagger UI (automatically opens, or go to `/swagger`)
3. Authenticate using either method:

   **Option 1: JWT Bearer Authentication** (Recommended for user sessions)
   - Use the `/api/auth/login` endpoint with credentials (`admin`/`admin`)
   - Click the "Authorize" button and select "Bearer"
   - Enter the token in the format: `Bearer <your-token>`
   - **When to use**: User authentication, web/mobile applications, token expiration needed

   **Option 2: Basic Authentication** (For service-to-service communication)
   - Click the "Authorize" button and select "Basic"
   - Enter credentials (username: `admin`, password: `admin`)
   - **When to use**: Server-to-server calls, admin tools, quick testing without token management

4. Try the protected endpoints with your chosen authentication method

### API Endpoints

Key endpoints available:

**Authentication** (Public):
- `POST /v1/auth/register` - Register new user
- `POST /v1/auth/login` - Login and get JWT token
- `GET /v1/auth/user` - Get current user info (authenticated)

**User Management** (Requires authentication):
- `GET /v1/users` - Get all users (admin only)
- `POST /v1/users/{id}/role` - Change user role (admin only)

**Service** (Requires authentication):
- Additional service endpoints (check Swagger UI for full list)

For complete API documentation, run the application and visit the Swagger UI at `/swagger`.

> [!NOTE]
> Basic Authentication credentials can be configured in [appsettings.json](src/Auth.Api/appsettings.json) under the `Authentication:Schemes:Basic` section.

#### Test using .http files:

1. Navigate to [Tests/HttpDebugTests/debug-tests.http](src/Tests/HttpDebugTests/debug-tests.http)
2. The file includes examples with default credentials (`admin`/`admin`)
3. Send the Login request to obtain a JWT token
4. Copy the token from the response
5. Use the token in subsequent requests by adding it to the `Authorization` header:
   ```http
   Authorization: Bearer <your-token>
   ```
   Alternatively, test Basic Authentication by adding:
   ```http
   Authorization: Basic YWRtaW46YWRtaW4=
   ```
   (Base64 encoded `admin:admin`)

## Architecture

This project follows **Clean Architecture** principles with clear separation of concerns.

**Layer Responsibilities:**

- **Auth.Api**: Entry point - endpoints, middleware, configuration, authentication schemes
- **Auth.Core**: Business logic - use cases, validation, command/query handlers
- **Auth.Domain**: Domain models - entities, commands, queries, domain rules
- **Auth.Infrastructure**: External concerns - database, repositories, external services

### Design patterns and decisions

**CQRS without MediatR**: Command-Query separation is achieved through direct handler injection in Minimal APIs. This reduces complexity and abstraction layers while maintaining separation between writes (commands) and reads (queries). Simpler and more maintainable for small-to-medium projects.

**Result Pattern**: Uses [FluentResults](https://github.com/altmann/FluentResults) instead of exceptions for flow control, providing explicit error handling and better type safety.

**Validation**: [Validot](https://github.com/bartoszlenar/Validot) provides declarative, performant validation rules integrated via dependency injection.

**Mapping**: [Mapster](https://github.com/MapsterMapper/Mapster) handles object-to-object mapping with high performance and low ceremony.

### Backend Architecture

- **Dual Authentication**: JWT Bearer for user sessions, Basic Auth for service-to-service communication
- **Authorization Policies**: Role-based access control with custom policies
- **Response Caching**: HTTP response caching for improved performance
- **Claims Middleware**: Dynamic user claims enrichment
- **Database Seeding**: Automatic creation of default roles and admin user on startup

### Frontend architecture

The Angular frontend is organized into:

- **Core**: Feature components with specific business logic (login, register, user management)
- **Shared**: Reusable components, services, guards, and interceptors

**JWT Token Flow**:
1. User logs in via API
2. `JwtTokenService` stores token in local storage
3. `AuthorizeGuard` protects routes by checking token presence
4. `authInterceptor` automatically adds `Authorization` header to all HTTP requests

## Technologies

**Backend**:
- [ASP.NET Core 10](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-10.0) - Minimal APIs
- [Entity Framework Core InMemory](https://learn.microsoft.com/en-us/ef/core/providers/in-memory/?tabs=dotnet-core-cli) - Data persistence
- [Mapster](https://github.com/MapsterMapper/Mapster) - Object mapping
- [SmallApiToolkit](https://github.com/Gramli/SmallApiToolkit) - API utilities
- [FluentResults](https://github.com/altmann/FluentResults) - Result pattern
- [Validot](https://github.com/bartoszlenar/Validot) - Validation
- [GuardClauses](https://github.com/ardalis/GuardClauses) - Defensive programming

**Frontend**:
- [Angular 21](https://angular.dev) - Framework with standalone components
- [PrimeNG](https://primeng.org) - UI component library
- [PrimeFlex](https://primeflex.org) - CSS utility framework
