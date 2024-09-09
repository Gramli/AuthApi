 <img align="left" width="116" height="116" src=".\doc\img\authApi_icon.png" />

# Clean Architecture AuthApi

The REST API demonstrates **Authentication** and **Authorization** with **JWT token**. It also shows how to use different **Authorization policies** in minimal API endpoints, all implemented using Clean Architecture and various design patterns


Example API allows to: 
 * **register** user
 * **login** user
 * **change user role**
 * get user and service info
 * add custom **claim using middleware**

Endpoints use different types of authorization policies.

# Menu
* [Get Started](#get-started)
* [Motivation](#motivation)
* [Architecture](#architecture)
* [Technologies](#technologies)

# Get Started

Simply Run **Auth.API** and try it.

## Test Using SwaggerUI
![SwaggerUI](./doc/img/login.gif)

## Test Using .http file (VS2022)
 * Go to Tests/HttpDebugTests folder and open **debug-tests.http** file (in VS2022
 * Send Login request
 * Obtain jwtToken from response and use it in another requests in Authorization header

# Motivation
Main motivation is to write practical example of Authorization and Authentication with minimal API and Clean Architecture.

# Architecture

The project follows **[Clean Architecture](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#clean-architecture)**, but the application layer is split into Core and Domain projects. The Core project holds the business rules, while the Domain project contains the business entities..

As Minimal API allows for injecting handlers into endpoint map methods, I decided not to use **[MediatR](https://github.com/jbogard/MediatR)**. Nonetheless, every endpoint still has its own request and handler.The solution folows the **[CQRS pattern](https://learn.microsoft.com/en-us/azure/architecture/patterns/cqrs)**, , meaning that handlers are separated into commands and queries; command handlers handle command requests, and query handlers handle query requests. Additionally, repositories, following the (**[Repository pattern](https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application)**), are also separated into commands and queries..

Instead of throwing exceptions, the project uses the **[Result pattern](https://www.forevolve.com/en/articles/2018/03/19/operation-result/)** (using [FluentResuls package](https://github.com/altmann/FluentResults)). For returning precise HTTP responses, every handler returns data wrapped in an HttpDataResponse object, which also contains a collection of error messages and the HTTP response code.

#### Clean Architecture Layers

Solution contains four layers: 
* **Auth.Api** - entry point of the application, top layer
	*  Endpoints
	*  Middlewares (or Filters)
	*  API Configuration
* **Auth.Infrastructure** - layer for communication with external resources like database, cache, web service.. 
	*  Repositories Implementation - access to database
	*  External Services Proxies - proxy classes implementation - to obtain data from external web services
	*  Infastructure Specific Services - services which are needed to interact with external libraries and frameworks
* **Auth.Core** - business logic of the application
	*  Request Handlers/Managers/.. - business implementation
	*  Abstractions - besides abstractions for business logic are there abstractions for Infrastructure layer (Service, Repository, ..) to be able use them in this (core) layer
* **Auth.Domain** - all what should be shared across all projects
	* DTOs
	* General Extensions

#### Horizontal Diagram (references)
![Project Clean Architecture Diagram](./doc/img/cleanArchitecture.jpg)

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
