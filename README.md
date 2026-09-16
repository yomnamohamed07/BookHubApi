# BookHub API — Backend

A RESTful **ASP.NET Core Web API** for managing a bookstore's book catalog.

The API provides CRUD operations for books, request validation, duplicate ISBN handling, pagination, database persistence, and Swagger/OpenAPI documentation.

![.NET](https://img.shields.io/badge/.NET-8-512BD4?logo=dotnet\&logoColor=white)
![C#](https://img.shields.io/badge/C%23-12-239120?logo=csharp\&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework%20Core-8-512BD4?logo=dotnet\&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-CC2927?logo=microsoftsqlserver\&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-OpenAPI-85EA2D?logo=swagger\&logoColor=black)

## Overview

BookHub API is the backend service for a bookstore management application.

It exposes RESTful endpoints that allow clients to:

* Retrieve the book catalog.
* Retrieve a specific book.
* Add new books.
* Update existing books.
* Delete books.

The API uses **Entity Framework Core** for database access and **SQL Server** for persistence.

It is designed to work with the accompanying Angular frontend, but can also be tested independently using Swagger or Postman.

## Features

* RESTful CRUD operations.
* Book catalog pagination.
* Request validation.
* Duplicate ISBN validation.
* Proper HTTP status codes.
* Entity Framework Core integration.
* SQL Server database.
* Database migrations.
* Initial data seeding.
* Dependency Injection.
* Swagger/OpenAPI documentation.
* Layered project structure.
* Separation of API, business logic, and infrastructure concerns.

## Tech Stack

* ASP.NET Core Web API
* C#
* Entity Framework Core
* SQL Server
* LINQ
* REST APIs
* Swagger / OpenAPI
* Dependency Injection

## Project Structure

```text
BookHubApi/
│
├── BookHub.Data/
│   └── Models, DTOs and data-related contracts
│
├── BookHub.Infrastructure/
│   └── Database access, EF Core, repositories and seeding
│
├── BookHub.Services/
│   └── Business logic and service implementations
│
├── BookHubApi/
│   └── Controllers and API configuration
│
└── BookHubApi.sln
```

### Data Layer

Contains the application's data models and DTOs used to represent and transfer book information.

### Infrastructure Layer

Responsible for database and infrastructure concerns, including:

* Entity Framework Core
* DbContext
* Database configuration
* Repository implementations
* Data seeding
* Database persistence

### Services Layer

Contains the business logic used by the API.

Keeping business logic in the service layer prevents controllers from becoming responsible for database and business operations.

### API Layer

Contains the HTTP-facing part of the application, including:

* Controllers
* Dependency Injection configuration
* Middleware configuration
* Swagger configuration
* Application startup

## Book Model

Each book contains:

| Property          | Type     | Description                        |
| ----------------- | -------- | ---------------------------------- |
| `id`              | `int`    | Unique book identifier             |
| `title`           | `string` | Book title                         |
| `author`          | `string` | Book author                        |
| `isbn`            | `string` | International Standard Book Number |
| `category`        | `string` | Book category                      |
| `availableCopies` | `int`    | Number of available copies         |

## API Endpoints

### Get All Books

```http
GET /api/books
```

Returns the books using pagination.

Example:

```http
GET /api/books?pageIndex=1&pageSize=10
```

Example response:

```json
{
  "pageIndex": 1,
  "pageSize": 10,
  "count": 4,
  "data": [
    {
      "id": 7,
      "title": "Clean Architecture",
      "author": "Robert C. Martin",
      "isbn": "9780134494166",
      "category": "Software Engineering",
      "availableCopies": 4
    }
  ]
}
```

### Get Book By ID

```http
GET /api/books/{id}
```

Example:

```http
GET /api/books/7
```

Returns the requested book when it exists.

### Add a Book

```http
POST /api/books
```

Example request:

```json
{
  "title": "Clean Code",
  "author": "Robert C. Martin",
  "isbn": "9780132350884",
  "category": "Software Engineering",
  "availableCopies": 5
}
```

### Update a Book

```http
PUT /api/books/{id}
```

Example:

```http
PUT /api/books/7
```

Example request:

```json
{
  "title": "Clean Code",
  "author": "Robert C. Martin",
  "isbn": "9780132350884",
  "category": "Software Engineering",
  "availableCopies": 10
}
```

### Delete a Book

```http
DELETE /api/books/{id}
```

Example:

```http
DELETE /api/books/7
```

## Validation

The API performs server-side validation to protect data integrity even when requests do not come from the Angular frontend.

Validation includes:

* Required title.
* Required author.
* Required ISBN.
* Required category.
* Non-negative available copies.
* Unique ISBN.

Server-side validation ensures that invalid data cannot bypass the frontend and be stored directly in the database.

## Duplicate ISBN

ISBN values must be unique.

If a request attempts to create or update a book using an existing ISBN, the API returns a validation/business error instead of creating a duplicate record.

The Angular frontend reads this server response and displays the ISBN error directly below the ISBN field.

## HTTP Status Codes

| Status Code                 | Usage                               |
| --------------------------- | ----------------------------------- |
| `200 OK`                    | Request completed successfully      |
| `201 Created`               | Book created successfully           |
| `204 No Content`            | Delete completed successfully       |
| `400 Bad Request`           | Invalid request or validation error |
| `404 Not Found`             | Book does not exist                 |
| `500 Internal Server Error` | Unexpected server error             |

## Database

The application uses:

* **SQL Server** as the database.
* **Entity Framework Core** as the ORM.

Entity Framework Core handles:

* Database communication
* Entity mapping
* CRUD operations
* Migrations
* Database initialization

The project also contains data seeding for initial book records.

## Getting Started

### Requirements

* .NET SDK
* SQL Server
* Visual Studio / VS Code or another compatible IDE
* Entity Framework Core CLI

### Clone the Repository

```bash
git clone https://github.com/yomnamohamed07/BookHubApi.git
```

### Navigate to the Project

```bash
cd BookHubApi
```

### Configure the Database

Update the connection string in:

```text
BookHubApi/appsettings.json
```

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=BookHubDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

Use the appropriate SQL Server connection string for your environment.

### Apply Migrations

```bash
dotnet ef database update
```

If the Entity Framework CLI is not installed:

```bash
dotnet tool install --global dotnet-ef
```

### Run the API

```bash
dotnet run
```

The API will start using the HTTP/HTTPS URLs configured by ASP.NET Core.

## Swagger

Swagger/OpenAPI is included for API documentation and testing.

After starting the API, open:

```text
https://localhost:<port>/swagger
```

Swagger can be used to:

* Explore all endpoints.
* Inspect request and response models.
* Test CRUD operations.
* Test validation behavior.
* Test different HTTP responses.

## Testing

The API can be tested using:

* Swagger UI
* Postman
* Angular frontend
* Any REST client

For local frontend integration, the Angular development server normally runs on:

```text
http://localhost:4200
```

## CORS

When the Angular frontend and API run on different origins, the API must allow the frontend origin.

Example:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
```

The policy should then be enabled in the middleware pipeline:

```csharp
app.UseCors("AllowFrontend");
```

The exact CORS configuration may differ depending on the deployment environment.

## Frontend Integration

The API is consumed by the **The Shelf — Bookhub Frontend**, built with Angular 17.

The frontend uses the following endpoints:

| Method   | Route             | Purpose           |
| -------- | ----------------- | ----------------- |
| `GET`    | `/api/books`      | Retrieve books    |
| `GET`    | `/api/books/{id}` | Retrieve one book |
| `POST`   | `/api/books`      | Create a book     |
| `PUT`    | `/api/books/{id}` | Update a book     |
| `DELETE` | `/api/books/{id}` | Delete a book     |

The frontend performs client-side validation for a better user experience, while the backend performs server-side validation to maintain data integrity.

## Application Flow

```text
┌─────────────────────┐
│   Angular Frontend  │
└──────────┬──────────┘
           │ HTTP
           ▼
┌─────────────────────┐
│      Controllers    │
└──────────┬──────────┘
           ▼
┌─────────────────────┐
│       Services      │
└──────────┬──────────┘
           ▼
┌─────────────────────┐
│    Infrastructure   │
└──────────┬──────────┘
           ▼
┌─────────────────────┐
│ Entity Framework    │
│        Core         │
└──────────┬──────────┘
           ▼
┌─────────────────────┐
│      SQL Server     │
└─────────────────────┘
```

## Assessment Requirements

The backend implements the required bookstore functionality:

* [x] Add a new book
* [x] Update book details
* [x] Delete a book
* [x] Retrieve all books
* [x] Retrieve a book by ID
* [x] Store books in SQL Server
* [x] Server-side validation
* [x] Duplicate ISBN handling
* [x] RESTful API endpoints
* [x] Swagger/OpenAPI documentation

## Future Improvements

Potential extensions include:

* Authentication and authorization
* Role-based access control
* Advanced search and filtering
* Unit and integration tests
* Global exception handling
* Structured logging
* Docker containerization
* CI/CD pipeline

## Related Project

**Frontend:** The Shelf — Bookhub Frontend

The Angular application consumes the RESTful endpoints provided by this API.

## Author

**Yomna Mohamed Fathy**

Computer Science Graduate | .NET Backend Developer

GitHub: [yomnamohamed07](https://github.com/yomnamohamed07)

