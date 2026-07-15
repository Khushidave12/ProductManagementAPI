Product Management API — Technical Assessment
A scalable, maintainable, and production-ready RESTful backend API built using .NET 8 and C#, adhering to the principles of Clean Architecture and Domain-Driven Design (DDD). This project fulfills the requirements for the CRN Technical Assessment.

🏗️ Architecture & Project Structure
The solution is split into distinct layers to isolate concerns, maximize testability, and keep the core business logic independent of external frameworks or databases.

Solution/
├── src/
│   ├── API/                  # ASP.NET Core Web API (Controllers, Middleware, DI Configuration)
│   ├── Application/          # Application Logic (DTOs, Interfaces, Services, FluentValidation, Mappings)
│   ├── Domain/               # Enterprise Core (Entities, Enums, Custom Exceptions)
│   └── Infrastructure/       # Data, Identity (JWT), Logging, and External Services
├── tests/
│   ├── API.Tests/            # Integration Tests via WebApplicationFactory
│   ├── Application.Tests/    # Unit Tests for Services and Business Rules
│   └── Infrastructure.Tests/ # Database and External Integration Tests
└── docker-compose.yml        # Multi-container orchestration (API + SQL Server)
🛠️ Tech Stack & Key Features
Framework: .NET 8 Web API (C#)

Database: SQL Server managed via Entity Framework Core (Code-First approach with Fluent API configurations).

Authentication: Robust JWT authentication mechanism featuring a secure short-lived access token system combined with Refresh Token Rotation.

Validation: Strict input validation pipelines powered by FluentValidation.

Global Exception Handling: Custom exception middleware translating domain errors into standardized, clean JSON problem details.

Structured Logging: Configured utilizing a logging framework to capture structured traces across database operations and API endpoints.

Testing Suite: Comprehensive coverage built with xUnit, Moq, and WebApplicationFactory for endpoint simulation.

💾 Database Schema
The database relies on the specified relational schema optimized with proper foreign keys and tracking properties:

SQL
CREATE TABLE [dbo].[Product]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [ProductName] NVARCHAR(255) NOT NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL,
    [CreatedOn] DATETIME NOT NULL,
    [ModifiedBy] NVARCHAR(100) NULL,
    [ModifiedOn] DATETIME NULL
);

CREATE TABLE [dbo].[Item]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [ProductId] INT NOT NULL FOREIGN KEY REFERENCES Product(Id),
    [Quantity] INT NOT NULL
);
⚡ Performance & Security Highlights
Query Optimization: Leverages EF Core's .AsNoTracking() for read-heavy operations to avoid unnecessary overhead.

Asynchronous Flow: Complete end-to-end async/await implementation protecting thread-pool availability under load.

Pagination: Built-in server-side pagination across all list/collection endpoints.

Cross-Cutting Security: Fully enforced CORS policy, secure security headers, and strong role-based authorization rules applied to administrative endpoints.

🚀 Local Setup & Getting Started
Prerequisites
.NET 8 SDK installed locally.

Docker Desktop installed and running.

Option 1: Running via Docker Compose (Recommended)
To spin up both the API and the SQL Server database instantly in a containerized environment, execute the following command at the root directory:

Bash
docker-compose up --build
Once healthy, the API will be accessible at http://localhost:5000 (or the port defined in your docker-compose.yml).

Option 2: Local Development Environment
Update Connection String: Modify src/API/appsettings.json to point to your local SQL Server instance.

Apply Migrations: Run the database migrations using the .NET Core CLI:

Bash
dotnet ef database update --project src/Infrastructure --startup-project src/API
Run the Application:

Bash
dotnet run --project src/API
📝 API Documentation & Swagger
When running locally in development mode, you can explore, test, and interact with the endpoints directly through the interactive Swagger UI interface.

Swagger Endpoint: https://localhost:[PORT]/swagger/index.html

🔑 Authentication Flow via Swagger
Send a POST request to the /api/v1/auth/login endpoint with valid user credentials.

Copy the returned AccessToken string from the JSON response.

Click the "Authorize" button at the top right of the Swagger interface.

Input the token in the format: Bearer YOUR_ACCESS_TOKEN and click authorize to unlock the secured Product management endpoints.
