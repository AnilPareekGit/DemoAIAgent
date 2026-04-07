# Supplier Management API

A basic Supplier Management backend API built with .NET Core Web API following a clean layered architecture.

## Architecture

The solution follows a three-layer architecture pattern:

- **API Layer** (`SupplierManagement.API`): Contains controllers and API configuration
- **Domain Layer** (`SupplierManagement.Domain`): Contains entities and repository interfaces
- **Infrastructure Layer** (`SupplierManagement.Infrastructure`): Contains data access implementation (EF Core DbContext and repositories)

## Features

- **Supplier Entity** with the following fields:
  - Id (int)
  - Name (string)
  - Type (string)
  - Email (string)
  - Phone (string)
  - Status (string)

- **API Endpoints**:
  - `GET /api/suppliers` - Get all suppliers
  - `GET /api/suppliers/{id}` - Get supplier by ID
  - `POST /api/suppliers` - Create a new supplier

- **Technologies**:
  - .NET 10.0
  - ASP.NET Core Web API
  - Entity Framework Core with In-Memory Database
  - Swagger/OpenAPI for API documentation

## Getting Started

### Prerequisites

- .NET 10.0 SDK or later

### Running the Application

1. Clone the repository
2. Navigate to the API project directory:
   ```bash
   cd src/SupplierManagement.API
   ```
3. Run the application:
   ```bash
   dotnet run
   ```
4. The API will start on `http://localhost:5170`

### Access Swagger UI

Once the application is running, navigate to:
```
http://localhost:5170/swagger
```

## Sample Data

The application is pre-seeded with three sample suppliers:

1. **Acme Corporation** (Manufacturer, Active)
2. **Tech Solutions Inc** (Distributor, Active)
3. **Global Supplies Ltd** (Wholesaler, Inactive)

## API Examples

### Get All Suppliers
```bash
curl http://localhost:5170/api/suppliers
```

### Get Supplier by ID
```bash
curl http://localhost:5170/api/suppliers/1
```

### Create New Supplier
```bash
curl -X POST http://localhost:5170/api/suppliers \
  -H "Content-Type: application/json" \
  -d '{
    "name": "New Supplier Co",
    "type": "Vendor",
    "email": "sales@newsupplier.com",
    "phone": "+1-555-0400",
    "status": "Active"
  }'
```

## Building the Solution

To build the entire solution:
```bash
dotnet build
```

## Project Structure

```
├── src/
│   ├── SupplierManagement.API/          # Web API project
│   │   ├── Controllers/                 # API controllers
│   │   ├── DTOs/                        # Data Transfer Objects
│   │   └── Program.cs                   # Application entry point
│   ├── SupplierManagement.Domain/       # Domain layer
│   │   ├── Entities/                    # Domain entities
│   │   └── Repositories/                # Repository interfaces
│   └── SupplierManagement.Infrastructure/ # Infrastructure layer
│       ├── Data/                        # DbContext
│       └── Repositories/                # Repository implementations
└── SupplierManagement.slnx              # Solution file
```

## Design Decisions

- **DTO Pattern**: The Create endpoint uses a `CreateSupplierRequest` DTO to prevent clients from setting their own IDs, ensuring data integrity
- **In-Memory Database**: Using EF Core's in-memory database for simplicity and quick testing
- **Repository Pattern**: Abstracts data access logic for better testability and separation of concerns

## Future Enhancements

The following features were excluded from the initial implementation as per requirements but could be added:
- Input validation (e.g., required fields, email format validation, phone number format)
- Authentication and authorization
- Update and Delete operations
- Pagination for Get All endpoint
- Filtering and sorting capabilities
- Using enums for Type and Status fields for better type safety