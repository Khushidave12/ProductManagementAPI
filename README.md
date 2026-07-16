# Product Management API

A scalable, maintainable, and production-ready RESTful backend API built using **.NET 10** and **C#**, adhering to the principles of **Clean Architecture** and **Domain-Driven Design (DDD)**. This project provides comprehensive product management capabilities with secure JWT authentication, MySQL database integration, and containerized deployment support.

---

## 📋 Table of Contents

- [Project Overview](#project-overview)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Prerequisites](#prerequisites)
- [Setup Instructions](#setup-instructions)
- [Database Migrations](#database-migrations)
- [Docker Setup & Deployment](#docker-setup--deployment)
- [API Authentication (JWT)](#api-authentication-jwt)
- [API Endpoints](#api-endpoints)
- [Configuration](#configuration)
- [Contributing](#contributing)

---

## 📌 Project Overview

The **Product Management API** is a comprehensive backend solution designed for managing product data with robust security, validation, and clean architecture principles. It provides RESTful endpoints for creating, reading, updating, and deleting products with built-in authorization.

### Key Features:
- ✅ **Clean Architecture** - Separated concerns across layers (Controllers, Services, Repositories, Domain)
- ✅ **JWT Authentication** - Secure token-based authentication with configurable expiration
- ✅ **FluentValidation** - Strict input validation for all DTOs
- ✅ **Entity Framework Core** - Code-first database approach with MySQL support
- ✅ **Swagger/OpenAPI** - Interactive API documentation and testing
- ✅ **Docker Support** - Multi-stage Dockerfile for containerized deployment
- ✅ **CORS Enabled** - Cross-Origin Resource Sharing support

---

## 🛠️ Tech Stack

| Component | Technology | Version |
|-----------|-----------|---------|
| **Framework** | .NET | 10.0 |
| **Language** | C# | 12+ |
| **Database** | MySQL | 5.7+ |
| **ORM** | Entity Framework Core | 8.0.13 |
| **Authentication** | JWT Bearer | Built-in |
| **API Documentation** | Swagger (Swashbuckle) | 10.2.3 |
| **Validation** | FluentValidation | 12.1.1 |
| **Containerization** | Docker | Latest |

### Installed NuGet Packages:
```
- FluentValidation (12.1.1)
- Microsoft.AspNetCore.Authentication.JwtBearer (8.0.12)
- Microsoft.AspNetCore.OpenApi (10.0.9)
- Microsoft.EntityFrameworkCore (8.0.13)
- Microsoft.EntityFrameworkCore.Design (8.0.13)
- Microsoft.EntityFrameworkCore.Tools (8.0.13)
- Pomelo.EntityFrameworkCore.MySql (8.0.3)
- Swashbuckle.AspNetCore (10.2.3)
```

---

## 📁 Project Structure

```
ProductManagementAPI/
├── Controllers/                    # API endpoint definitions
│   └── ProductController.cs        # Product endpoints (Create, Read, Update, Delete)
├── Domain/                         # Core business entities
│   ├── Entities/                   # Domain models
│   └── Enums/                      # Enumeration types
├── Application/                    # Application layer
│   └── DTOs/                       # Data Transfer Objects
│       ├── CreateProductDto.cs
│       └── UpdateProductDto.cs
├── Services/                       # Business logic services
│   ├── IProductService.cs          # Service interface
│   └── ProductService.cs           # Service implementation
├── Infrastructure/                 # Data access & external services
│   └── Data/
│       ├── ApplicationDbContext.cs # Entity Framework context
│       └── Repositories/           # Data repository implementations
│           └── ProductRepository.cs
├── Interfaces/                     # Service/Repository contracts
│   └── IProductRepository.cs
├── Validators/                     # FluentValidation validators
│   ├── CreateProductDtoValidator.cs
│   └── UpdateProductDtoValidator.cs
├── Migrations/                     # Entity Framework migrations
│   └── [Migration files]
├── Properties/                     # Project properties & launch settings
│   └── launchSettings.json
├── Program.cs                      # Application startup & configuration
├── appsettings.json               # Configuration file
├── appsettings.Development.json   # Development-specific settings
├── Dockerfile                      # Docker container configuration
├── .dockerignore                  # Docker build ignore patterns
├── ProductManagementAPI.csproj    # Project file
└── README.md                       # This file
```

---

## 🔧 Prerequisites

Before setting up the project, ensure you have the following installed:

### Required Software:
- **[.NET 8](https://dotnet.microsoft.com/download)** - For building and running the application
- **[MySQL Server](https://dev.mysql.com/downloads/mysql/)** (5.7 or higher) - Database server
- **[Visual Studio 2022](https://visualstudio.microsoft.com/)** or **[VS Code](https://code.visualstudio.com/)** - Code editor (optional)
- **[Docker](https://www.docker.com/products/docker-desktop)** - For containerized deployment (optional)
- **[Git](https://git-scm.com/)** - Version control

### Verify Installation:
```bash
# Check .NET version
dotnet --version

# Check MySQL version
mysql --version

# Check Docker version (if installed)
docker --version
```

---

## 📦 Setup Instructions

### Step 1: Clone the Repository

```bash
git clone https://github.com/Khushidave12/ProductManagementAPI.git
cd ProductManagementAPI
```

### Step 2: Restore Dependencies

```bash
# Restore all NuGet packages
dotnet restore
```

### Step 3: Configure the Database

Edit `appsettings.json` and update the MySQL connection string with your credentials:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=productdata;User=your_mysql_username;Password=your_mysql_password;"
  },
  ...
}
```

**Configuration Parameters:**
- `Server`: MySQL server address (default: `localhost`)
- `Port`: MySQL port (default: `3306`)
- `Database`: Database name (default: `productdata`)
- `User`: MySQL username
- `Password`: MySQL password

### Step 4: Configure JWT Settings

Update the JWT configuration in `appsettings.json`:

```json
{
  "Jwt": {
    "SecretKey": "your_very_secure_secret_key_minimum_32_characters_long",
    "Issuer": "ProductManagementAPI",
    "Audience": "ProductManagementAPIClient",
    "ExpirationMinutes": 15
  },
  ...
}
```

**JWT Parameters:**
- `SecretKey`: A strong secret key (minimum 32 characters) for signing tokens
- `Issuer`: The issuer of the token (who created it)
- `Audience`: The intended recipients of the token
- `ExpirationMinutes`: Token expiration time in minutes

### Step 5: Run Database Migrations

See the [Database Migrations](#database-migrations) section below.

### Step 6: Build the Project

```bash
dotnet build
```

### Step 7: Run the Application

```bash
dotnet run
```

The API will be available at:
- **HTTP:** `http://localhost:5000`
- **HTTPS:** `https://localhost:5001`
- **Swagger UI:** `https://localhost:5001/swagger/index.html`

---

## 🗄️ Database Migrations

### Create Initial Migration

If this is your first setup, create the initial migration:

```bash
dotnet ef migrations add InitialCreate
```

### Apply Migrations to Database

Run pending migrations to create/update the database schema:

```bash
dotnet ef database update
```

### Create a New Migration (After Model Changes)

If you modify the Entity models, create a new migration:

```bash
# Create migration with descriptive name
dotnet ef migrations add YourMigrationDescription

# Example:
dotnet ef migrations add AddProductCategoryColumn
```

### Remove Last Migration

If you need to revert the last migration (before applying to database):

```bash
dotnet ef migrations remove
```

### Drop Database (Development Only)

⚠️ **Warning:** This deletes all data. Only use in development!

```bash
dotnet ef database drop
```

### View Migration Status

To see applied and pending migrations:

```bash
dotnet ef migrations list
```

### Generate SQL Script

Generate SQL for migrations without executing:

```bash
dotnet ef migrations script
```

---

## 🐳 Docker Setup & Deployment

### Build Docker Image

```bash
# Build the Docker image
docker build -t productmanagementapi:latest .

# With specific tag
docker build -t productmanagementapi:v1.0 .
```

### Run Docker Container

```bash
# Run container with environment variables
docker run -d \
  --name productapi \
  -p 8080:8080 \
  -p 8081:8081 \
  -e ConnectionStrings__DefaultConnection="Server=host.docker.internal;Port=3306;Database=productdata;User=your_user;Password=your_password;" \
  -e Jwt__SecretKey="your_secret_key" \
  -e Jwt__Issuer="ProductManagementAPI" \
  -e Jwt__Audience="ProductManagementAPIClient" \
  productmanagementapi:latest
```

### Docker Compose Setup (Recommended)

Create a `docker-compose.yml` file:

```yaml
version: '3.8'

services:
  mysql:
    image: mysql:8.0
    environment:
      MYSQL_ROOT_PASSWORD: rootpassword
      MYSQL_DATABASE: productdata
      MYSQL_USER: api_user
      MYSQL_PASSWORD: api_password
    ports:
      - "3306:3306"
    volumes:
      - mysql_data:/var/lib/mysql
    healthcheck:
      test: ["CMD", "mysqladmin", "ping", "-h", "localhost"]
      timeout: 20s
      retries: 10

  api:
    build: .
    ports:
      - "8080:8080"
      - "8081:8081"
    environment:
      ConnectionStrings__DefaultConnection: "Server=mysql;Port=3306;Database=productdata;User=api_user;Password=api_password;"
      Jwt__SecretKey: "your_very_secure_secret_key_minimum_32_characters"
      Jwt__Issuer: "ProductManagementAPI"
      Jwt__Audience: "ProductManagementAPIClient"
      Jwt__ExpirationMinutes: "15"
    depends_on:
      mysql:
        condition: service_healthy

volumes:
  mysql_data:
```

Run with Docker Compose:

```bash
# Start services
docker-compose up -d

# View logs
docker-compose logs -f api

# Stop services
docker-compose down
```

### Common Docker Commands

```bash
# List running containers
docker ps

# View container logs
docker logs productapi

# Stop container
docker stop productapi

# Remove container
docker rm productapi

# Remove image
docker rmi productmanagementapi:latest
```

---

## 🔐 API Authentication (JWT)

This API uses **JWT (JSON Web Tokens)** for stateless authentication. All protected endpoints require a valid Bearer token in the `Authorization` header.

### JWT Configuration

The JWT settings are configured in `appsettings.json`:

```json
{
  "Jwt": {
    "SecretKey": "your_secure_secret_key_here",
    "Issuer": "ProductManagementAPI",
    "Audience": "ProductManagementAPIClient",
    "ExpirationMinutes": 15
  }
}
```

### Token Structure

A JWT token consists of three parts separated by dots (`.`):
- **Header:** Token type and hashing algorithm
- **Payload:** Claims (user data, roles, expiration)
- **Signature:** Cryptographic signature using the secret key

Example token:
```
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIn0.dozjgNryP4J3jVmNHl0w5N_XgL0n3I9PlFUP0THsR8U
```

### Authentication Flow

#### Step 1: Generate Token (Manual Creation in Development)

For development purposes, you can manually create a token in `appsettings.json`. In production, implement a proper login endpoint.

#### Step 2: Use Token in API Requests

Include the token in the `Authorization` header:

```bash
curl -X GET "https://localhost:5001/api/product/getProduct/1" \
  -H "Authorization: Bearer YOUR_ACCESS_TOKEN_HERE"
```

#### Step 3: Token Validation

The API validates:
- ✅ Token signature (matches secret key)
- ✅ Issuer (matches configured issuer)
- ✅ Audience (matches configured audience)
- ✅ Expiration (token not expired)

### Testing with Swagger UI

1. Navigate to Swagger UI: `https://localhost:5001/swagger/index.html`
2. Click the **"Authorize"** button (🔒) at the top right
3. Enter your token in the format: `Bearer YOUR_TOKEN`
4. Click **"Authorize"** to apply the token to all requests
5. Test protected endpoints directly from Swagger

### Example: Using Token in JavaScript/Fetch

```javascript
const token = "your_jwt_token_here";

fetch("https://localhost:5001/api/product/getProduct/1", {
  method: "GET",
  headers: {
    "Authorization": `Bearer ${token}`,
    "Content-Type": "application/json"
  }
})
.then(response => response.json())
.then(data => console.log(data));
```

### Token Security Best Practices

1. **Keep Secret Key Safe:** Never commit the secret key to version control
2. **Use HTTPS:** Always transmit tokens over encrypted HTTPS
3. **Short Expiration:** Set reasonable token expiration times (15-60 minutes)
4. **Refresh Tokens:** Implement refresh token rotation for better security
5. **Environment Variables:** Store sensitive settings in environment variables
6. **Validate Tokens:** Always validate token signature and claims

---

## 🔌 API Endpoints

### Product Management Endpoints

Base URL: `https://localhost:5001/api/product`

#### 1. Create Product
```http
POST /api/product/createProduct
Content-Type: application/json
Authorization: Bearer YOUR_TOKEN

{
  "name": "Product Name",
  "description": "Product Description",
  "price": 99.99,
  "quantity": 10
}
```

**Response (201 Created):**
```json
{
  "id": 1,
  "name": "Product Name",
  "description": "Product Description",
  "price": 99.99,
  "quantity": 10,
  "createdAt": "2024-07-15T12:00:00Z"
}
```

#### 2. Get Product by ID
```http
GET /api/product/getProduct/{id}
Authorization: Bearer YOUR_TOKEN
```

**Response (200 OK):**
```json
{
  "id": 1,
  "name": "Product Name",
  "description": "Product Description",
  "price": 99.99,
  "quantity": 10,
  "createdAt": "2024-07-15T12:00:00Z"
}
```

#### 3. Update Product
```http
PUT /api/product/updateProduct/{id}
Content-Type: application/json
Authorization: Bearer YOUR_TOKEN

{
  "name": "Updated Name",
  "description": "Updated Description",
  "price": 149.99,
  "quantity": 5
}
```

**Response (204 No Content)**

#### 4. Delete Product
```http
DELETE /api/product/deleteProduct/{id}
Authorization: Bearer YOUR_TOKEN
```

**Response (204 No Content)**

### Error Responses

**400 Bad Request** (Validation Error):
```json
{
  "errors": [
    {
      "field": "price",
      "message": "Price must be greater than 0"
    }
  ]
}
```

**401 Unauthorized** (Missing/Invalid Token):
```json
{
  "error": "Unauthorized",
  "message": "Invalid or missing JWT token"
}
```

**404 Not Found**:
```json
{
  "error": "Not Found",
  "message": "Product with ID 999 was not found."
}
```

---

## ⚙️ Configuration

### appsettings.json Structure

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=productdata;User=root;Password=password;"
  },
  "Jwt": {
    "SecretKey": "your_secure_secret_key_minimum_32_characters_long",
    "Issuer": "ProductManagementAPI",
    "Audience": "ProductManagementAPIClient",
    "ExpirationMinutes": 15
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### Environment-Specific Settings

**appsettings.Development.json** (Development overrides):
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "Microsoft.AspNetCore": "Debug"
    }
  }
}
```

### Using Environment Variables

Set environment variables to override configuration:

```bash
# Linux/macOS
export ConnectionStrings__DefaultConnection="Server=db.example.com;Port=3306;Database=productdata;User=user;Password=pass;"
export Jwt__SecretKey="your_secret_key"

# Windows (PowerShell)
$env:ConnectionStrings__DefaultConnection="Server=localhost;Port=3306;Database=productdata;User=root;Password=password;"
$env:Jwt__SecretKey="your_secret_key"

# Windows (CMD)
set ConnectionStrings__DefaultConnection=Server=localhost;Port=3306;Database=productdata;User=root;Password=password;
```

---

## 📚 Development Commands

### Build Project
```bash
dotnet build
```

### Run Project
```bash
dotnet run
```

### Run Tests (if test project exists)
```bash
dotnet test
```

### Clean Build
```bash
dotnet clean
dotnet build
```

### Publish for Production
```bash
dotnet publish -c Release -o ./publish
```

### Add NuGet Package
```bash
dotnet add package PackageName --version Version
```

---

## 🤝 Contributing

Contributions are welcome! Please follow these guidelines:

1. **Fork** the repository
2. **Create** a feature branch (`git checkout -b feature/AmazingFeature`)
3. **Commit** your changes (`git commit -m 'Add some AmazingFeature'`)
4. **Push** to the branch (`git push origin feature/AmazingFeature`)
5. **Open** a Pull Request

---

## 📝 License

This project is part of a technical assessment. For licensing details, contact the project owner.

---

## 📞 Support & Questions

For issues, questions, or suggestions, please:
- Open an **Issue** on GitHub
- Check existing documentation
- Review the Swagger API documentation at `/swagger/index.html`

---

## 🎯 Checklist for Production Deployment

- [ ] Update `appsettings.json` with production database credentials
- [ ] Set strong JWT secret key (minimum 32 characters)
- [ ] Configure proper CORS policy for your frontend domain
- [ ] Enable HTTPS and SSL certificates
- [ ] Set up proper logging and monitoring
- [ ] Configure database backups
- [ ] Review and update security headers
- [ ] Test all API endpoints thoroughly
- [ ] Set up environment-specific configurations
- [ ] Document API changes and versions

---

**Last Updated:** July 2024  
**Version:** 1.0.0  
**Author:** Product Management API Team
