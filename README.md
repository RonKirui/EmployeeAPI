# EmployeeAPI
A CRUD REST API for managing employees built with ASP.NET Core and Entity Framework Core

# Employee Management API

A simple CRUD REST API built with ASP.NET Core Web API and Entity Framework Core.

## Tech Stack
- ASP.NET Core Web API (.NET 10)
- Entity Framework Core 10
- SQL Server
- Swagger UI

## Endpoints

| Method | URL | Description |
|--------|-----|-------------|
| GET | /api/employees | Get all employees |
| GET | /api/employees/{id} | Get employee by ID |
| POST | /api/employees | Create new employee |
| PUT | /api/employees/{id} | Update employee |
| DELETE | /api/employees/{id} | Delete employee |

## Getting Started

1. Clone the repo
   git clone https://github.com/RonKirui/EmployeeAPI.git

2. Update the connection string in appsettings.json
   "DefaultConnection": "Server=.\\SQLEXPRESS;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True;"

3. Run the API
   dotnet run

4. Open Swagger UI
   http://localhost:5283/swagger
