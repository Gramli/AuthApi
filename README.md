 <img align="left" width="116" height="116" src=".\doc\img\authApi_icon.png" />


# Clean Architecture AuthApi
[![.NET Build and Test](https://github.com/Gramli/AuthApi/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Gramli/AuthApi/actions/workflows/dotnet.yml)
[![Angular Build](https://github.com/Gramli/AuthApi/actions/workflows/angular.yml/badge.svg)](https://github.com/Gramli/AuthApi/actions/workflows/angular.yml)

This full-stack solution demonstrates user registration, login, and role-based access control using Angular and .NET. The backend showcases **Authentication** and **Authorization** with **JWT tokens**, demonstrating the use of Authorization policies in **minimal API** endpoints, adding custom claims through middleware, and an example of using **HTTP response caching** via an extension method. These are all implemented following Clean Architecture and various design patterns. The frontend illustrates managing JWT tokens using **guards** and **interceptors**, with all components implemented as **standalone components** and **signals**.


Example API allows to: 
 * **register** user
 * **login** user
 * **change user role**
 * get user and service info

Endpoints use different types of authorization policies.

# Menu
- [Clean Architecture AuthApi](#clean-architecture-authapi)
- [Menu](#menu)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Get Started](#get-started)
  - [Run Solution](#run-solution)
  - [Test Using SwaggerUI](#test-using-swaggerui)
  - [Test Using .http file (VS2022)](#test-using-http-file-vs2022)
- [Motivation](#motivation)
  - [Backend Architecture](#backend-architecture)
    - [Key Patterns and Decisions:](#key-patterns-and-decisions)
    - [Features](#features)
  - [Frontend Structure](#frontend-structure)
    - [JWT Handling](#jwt-handling)
  - [Technologies](#technologies)

# Prerequisites
* **.NET SDK 10.0+**
* **Angular CLI 19+**
* **Node.js 20.11.1+**

# Installation
To install the project using Git Bash:

1. Clone the repository:
   ```bash
   git clone https://github.com/Gramli/AuthApi.git
   ```
2. Navigate to the project directory:
   ```bash
   cd AuthApi/src
   ```
3. Install the backend dependencies:
   ```bash
   dotnet restore
   ```
4. Navigate to the frontend directory and install dependencies:
   ```bash
   cd Auth.Frontend
   npm install
   ```

# Get Started

## Run Solution
**Expected IDE**
- **Backend**: Visual Studio 2019+ or JetBrains Rider 2024.2.7+
- **Frontend**: Visual Studio Code 1.94.2+ or WebStorm 2024.2.4+

1. **Run Frontend**
    1. Open the **Auth.Frontend** project folder:
       - In WebStorm, use the run or debug button to start the project.
       - In VS Code, run the project in the terminal using the command `ng serve`.
    2. In your browser, navigate to [http://localhost:4200/](http://localhost:4200/).

2. **Run Backend**
    1. Open the **AuthSol.sln** project in Rider or Visual Studio.
    2. Use the run button to start the backend project.

3. Once both the frontend and backend are running, you’re all set to start using the app. Enjoy! :)

## Test Using SwaggerUI
Select the **Auth.API** startup item in VS or Rider and try it.

![SwaggerUI](./doc/img/login.gif)

## Test Using .http file (VS2022)
 * Go to Tests/HttpDebugTests folder and open **debug-tests.http** file in VS2022
 * Send Login request
 * Obtain jwtToken from response and use it in another requests in Authorization header

# Motivation
The primary goal of this project is to create a practical example of authorization and authentication using Minimal API and Clean Architecture, while also enhancing my skills with Angular.

## Backend Architecture
The backend follows **[Clean Architecture](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#clean-architecture)**, with the application layer split into **Core** and **Domain** projects:
- The **Core** project contains business rules.
- The **Domain** project holds business entities.

### Key Patterns and Decisions:
- **CQRS Pattern**: Separates handlers into commands and queries, with repositories structured similarly.
- **No MediatR**: Minimal API supports injecting handlers directly into endpoint map methods, eliminating the need for **[MediatR](https://github.com/jbogard/MediatR)**.
- **Result Pattern**: Uses the **[Result pattern](https://www.forevolve.com/en/articles/2018/03/19/operation-result/)** (via [FluentResults package](https://github.com/altmann/FluentResults)) instead of throwing exceptions. Each handler returns an `HttpDataResponse` object containing data, error messages, and the HTTP response code.

### Features
- **Response caching** - adding http response caching using extension method *AddResponseCachePolicy*
- **Claims Middleware** - adding custom claims through middleware *ClaimsMiddleware*

## Frontend Structure
The Angular frontend is organized into two main folders:
- **Core**: Contains "feature" components (each with specific feature logic).
- **Shared**: Stores common components, services, and extensions shared between feature components.

### JWT Handling
This example demonstrates JWT token management on the client side. After obtaining the token from the API, it is stored in local storage via the **JwtTokenService**. The **AuthorizeGuard** checks if the client already has a token to protect routes, and **authInterceptor** automatically adds the token header to every request.

The project uses **PrimeNG** and **PrimeFlex** for styling and layout.

## Technologies
* [ASP.NET Core 10](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-10.0)
* [Entity Framework Core InMemory](https://learn.microsoft.com/en-us/ef/core/providers/in-memory/?tabs=dotnet-core-cli)
* [Mapster](https://github.com/MapsterMapper/Mapster)
* [SmallApiToolkit](https://github.com/Gramli/SmallApiToolkit)
* [FluentResuls](https://github.com/altmann/FluentResults)
* [Validot](https://github.com/bartoszlenar/Validot)
* [GuardClauses](https://github.com/ardalis/GuardClauses)
* [Angular 19](https://angular.dev)
* [PrimeNG](https://primeng.org)
* [PrimeFlex](https://primeflex.org)
