# Product Management API — Technical Assessment

A scalable, maintainable, and production-ready RESTful backend API built using **.NET 8** and **C#**, adhering to the principles of **Clean Architecture** and **Domain-Driven Design (DDD)**. This project fulfills the requirements for the CRN Technical Assessment.

---

## 🏗️ Architecture & Project Structure

The solution is split into distinct layers to isolate concerns, maximize testability, and keep the core business logic independent of external frameworks or databases.


---

## 🛠️ Tech Stack & Key Features

*   **Framework:** .NET 8 Web API (C#)
*   **Database:** SQL Server managed via Entity Framework Core (Code-First approach with Fluent API configurations).
*   **Authentication:** Robust JWT authentication mechanism featuring a secure short-lived access token system combined with **Refresh Token Rotation**.
*   **Validation:** Strict input validation pipelines powered by `FluentValidation`.
*   **Global Exception Handling:** Custom exception middleware translating domain errors into standardized, clean JSON problem details.
*   **Structured Logging:** Configured utilizing a logging framework to capture structured traces across database operations and API endpoints.
*   **Testing Suite:** Comprehensive coverage built with `xUnit`, `Moq`, and `WebApplicationFactory` for endpoint simulation.

---


### 🔑 Authentication Flow via Swagger

When running locally in development mode, you can explore, test, and interact with the secured endpoints directly through the interactive Swagger UI interface.

* **Swagger Endpoint:** `https://localhost:[PORT]/swagger/index.html`

🔑 Authentication Flow via Swagger
Send a POST request to the /api/v1/auth/login endpoint with valid user credentials.

Copy the returned AccessToken string from the JSON response.

Click the "Authorize" button at the top right of the Swagger interface.

Input the token in the format: Bearer YOUR_ACCESS_TOKEN and click authorize to unlock the secured Product management endpoints.
