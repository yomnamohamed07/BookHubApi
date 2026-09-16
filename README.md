# 📚 BookHub API

A RESTful Web API built with **ASP.NET Core** for managing a bookstore's book inventory.

The API provides complete **CRUD operations** for books, including creating, retrieving, updating, and deleting book records. It is designed with a clean and maintainable backend structure and can be consumed by any frontend application such as Angular.

---

## 🚀 Features

* 📖 Create a new book
* 🔍 Retrieve all books
* 🔎 Retrieve a book by ID
* ✏️ Update book details
* 🗑️ Delete a book
* ✅ Input validation
* 🗄️ Entity Framework Core integration
* 🌐 RESTful API architecture
* 📑 Swagger/OpenAPI documentation
* 🧩 Layered project structure
* 🌱 Database seeding with initial book data

---

## 🛠️ Technologies

* **C#**
* **ASP.NET Core Web API**
* **Entity Framework Core**
* **SQL Server**
* **LINQ**
* **REST APIs**
* **Swagger / OpenAPI**
* **Dependency Injection**
* **Git & GitHub**

---

## 🏗️ Project Structure

The solution is organized into separate projects to keep responsibilities clear and maintainable:

```text
BookHubApi
│
├── BookHub.Data
│   └── Data models, DTOs and application contracts
│
├── BookHub.Infrastructure
│   └── Database configuration, EF Core
│       repositories and data seeding
│
├── BookHub.Services
│   └── Business logic and service implementations
│
├── BookHubApi
│   └── API layer, controllers and application configuration
│
└── BookHubApi.sln
```

### 🔹 BookHub.Data

Contains the application's core data-related models and DTOs used to transfer data between the API and clients.

### 🔹 BookHub.Infrastructure

Responsible for database-related concerns such as:

* Entity Framework Core
* DbContext configuration
* Database access
* Data seeding
* Infrastructure implementations

### 🔹 BookHub.Services

Contains the application's business logic and service layer.

This layer keeps business operations separated from controllers and infrastructure concerns.

### 🔹 BookHubApi

The main ASP.NET Core Web API project.

It contains:

* Controllers
* API configuration
* Dependency Injection setup
* Middleware configuration
* Swagger configuration

---

## 📖 Book Model

Each book contains the following information:

| Property          | Type     | Description                        |
| ----------------- | -------- | ---------------------------------- |
| `Id`              | `int`    | Unique identifier                  |
| `Title`           | `string` | Book title                         |
| `Author`          | `string` | Book author                        |
| `ISBN`            | `string` | International Standard Book Number |
| `Category`        | `string` | Book category                      |
| `AvailableCopies` | `int`    | Number of available copies         |

---

## 🔗 API Endpoints

### Get All Books

```http
GET /api/books
```

Returns a paginated list of books.

Example response:

```json
{
  "pageIndex": 1,
  "pageSize": 10,
  "count": 4,
  "data": [
    {
      "id": 1,
      "title": "Clean Architecture",
      "author": "Robert C. Martin",
      "isbn": "9780134494166",
      "category": "Software Engineering",
      "availableCopies": 4
    }
  ]
}
```

---

### Get Book By ID

```http
GET /api/books/{id}
```

Returns the details of a specific book.

Example:

```http
GET /api/books/1
```

---

### Add a New Book

```http
POST /api/books
```

Request body:

```json
{
  "title": "Clean Code",
  "author": "Robert C. Martin",
  "isbn": "9780132350884",
  "category": "Software Engineering",
  "availableCopies": 5
}
```

---

### Update a Book

```http
PUT /api/books/{id}
```

Example request:

```http
PUT /api/books/1
```

Request body:

```json
{
  "title": "Clean Code",
  "author": "Robert C. Martin",
  "isbn": "9780132350884",
  "category": "Software Engineering",
  "availableCopies": 10
}
```

---

### Delete a Book

```http
DELETE /api/books/{id}
```

Example:

```http
DELETE /api/books/1
```

---

## 🧪 API Testing

The API can be tested using:

* Swagger UI
* Postman
* Angular frontend
* Any HTTP client

After running the application, open:

```text
https://localhost:<port>/swagger
```

Swagger provides an interactive interface for exploring and testing all available endpoints.

---

## ⚙️ Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/yomnamohamed07/BookHubApi.git
```

### 2. Navigate to the Project

```bash
cd BookHubApi
```

### 3. Configure the Database

Update the connection string in:

```text
appsettings.json
```

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=BookHubDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

> Update the connection string according to your local SQL Server configuration.

### 4. Apply Database Migrations

Run:

```bash
dotnet ef database update
```

### 5. Run the Application

```bash
dotnet run
```

The API will start on the configured HTTP/HTTPS ports.

### 6. Open Swagger

Navigate to:

```text
https://localhost:<port>/swagger
```

---

## 🗄️ Database

The project uses **SQL Server** with **Entity Framework Core**.

Entity Framework Core is responsible for:

* Database communication
* Entity mapping
* Migrations
* CRUD operations
* Database initialization

The application also includes initial data seeding to provide sample books when the database is initialized.

---

## 🔄 Application Flow

```text
Client / Angular
       │
       ▼
   Controllers
       │
       ▼
    Services
       │
       ▼
 Infrastructure
       │
       ▼
 Entity Framework Core
       │
       ▼
    SQL Server
```

This separation keeps the API organized and makes the application easier to maintain, test, and extend.

---

## 🎯 Assessment Requirements

This project implements the main requirements of the bookstore management assessment:

* [x] Add a new book
* [x] Retrieve books
* [x] Retrieve a book by ID
* [x] Update book details
* [x] Delete a book
* [x] Store book information in a database
* [x] Validate incoming data
* [x] Expose RESTful endpoints
* [x] Provide Swagger documentation

---

## 🔮 Possible Improvements

Future improvements could include:

* Authentication and authorization
* Role-based access control
* Advanced filtering and searching
* Sorting and pagination enhancements
* Global exception handling
* Automated unit and integration tests
* Docker support
* CI/CD pipeline
* Logging and monitoring

---

## 👩‍💻 Author

**Yomna Mohamed Fathy**

Computer Science Graduate | .NET Backend Developer

### GitHub

[github.com/yomnamohamed07](https://github.com/yomnamohamed07)

---

## ⭐ Project

If you find this project useful, feel free to explore the repository and check out the implementation.
