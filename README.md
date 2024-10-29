 <img align="left" width="116" height="116" src=".\doc\img\authApi_icon.png" />

# Clean Architecture AuthApi

This full-stack solution demonstrates user registration, login, and role-based access control using Angular and .NET. The backend showcases **Authentication** and **Authorization** with **JWT tokens**, demonstrating the use of Authorization policies in **minimal API** endpoints and adding custom claims through middleware. These are all implemented following Clean Architecture and various design patterns. The frontend illustrates managing JWT tokens using **guards** and **interceptors**, with all components implemented as **standalone components** and **signals**.


Example API allows to: 
 * **register** user
 * **login** user
 * **change user role**
 * get user and service info

Endpoints use different types of authorization policies.

# Menu
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Get Started](#get-started)
    - [Run only Backend](#run-only-backend)
  - [Test Using SwaggerUI](#test-using-swaggerui)
  - [Test Using .http file (VS2022)](#test-using-http-file-vs2022)
- [Motivation](#motivation)
  - [Backend Architecture](#backend-architecture)
  - [Frontend Example](#frontend-example)
  - [Technologies](#technologies)

# Prerequisites
* **.NET SDK 8.0+**
* **Angular CLI 18+**
* **Node.js 18.19.1+**

# Installation

To install the project using Git Bash:

1. Clone the repository:
   ```bash
   git clone https://github.com/Gramli/AuthApi.git
   ```
2. Navigate to the project directory:
   ```bash
   cd FileApi/src
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
5. Run the solution in Visual Studio 2019+ by selecting the "Run API and FE" startup item to start both the API and the frontend servers. More about run in next section.

# Get Started

**Expected IDE: Visual Studio 2019+**

### Run only Backend
Select the **Auth.API** startup item and try it.

## Test Using SwaggerUI
![SwaggerUI](./doc/img/login.gif)

## Test Using .http file (VS2022)
 * Go to Tests/HttpDebugTests folder and open **debug-tests.http** file (in VS2022
 * Send Login request
 * Obtain jwtToken from response and use it in another requests in Authorization header

# Motivation
Main motivation is to write practical example of Authorization and Authentication with minimal API and Clean Architecture and also improve my skills with Angular.

## Backend Architecture


The project follows **[Clean Architecture](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#clean-architecture)**, but the application layer is split into Core and Domain projects. The Core project holds the business rules, while the Domain project contains the business entities..

As Minimal API allows for injecting handlers into endpoint map methods, I decided not to use **[MediatR](https://github.com/jbogard/MediatR)**. Nonetheless, every endpoint still has its own request and handler.The solution folows the **[CQRS pattern](https://learn.microsoft.com/en-us/azure/architecture/patterns/cqrs)**, , meaning that handlers are separated into commands and queries; command handlers handle command requests, and query handlers handle query requests. Additionally, repositories, following the (**[Repository pattern](https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application)**), are also separated into commands and queries..

Instead of throwing exceptions, the project uses the **[Result pattern](https://www.forevolve.com/en/articles/2018/03/19/operation-result/)** (using [FluentResuls package](https://github.com/altmann/FluentResults)). For returning precise HTTP responses, every handler returns data wrapped in an HttpDataResponse object, which also contains a collection of error messages and the HTTP response code.

## Frontend Example



## Technologies
* [ASP.NET Core 8](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-8.0)
* [Entity Framework Core InMemory](https://learn.microsoft.com/en-us/ef/core/providers/in-memory/?tabs=dotnet-core-cli)
* [Mapster](https://github.com/MapsterMapper/Mapster)
* [SmallApiToolkit](https://github.com/Gramli/SmallApiToolkit)
* [FluentResuls](https://github.com/altmann/FluentResults)
* [Validot](https://github.com/bartoszlenar/Validot)
* [GuardClauses](https://github.com/ardalis/GuardClauses)
* [Moq](https://github.com/moq/moq4)
* [Xunit](https://github.com/xunit/xunit)
* [Angular 18](https://angular.dev)
