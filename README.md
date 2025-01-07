# Invoice Management API
## Overview
- The Invoice Management API is a robust solution for managing invoices, including creation, retrieval, updating, and deletion. 
- It integrates authentication, validation, and logging mechanisms, ensuring a secure and scalable system.

## Features
CRUD Operations: Create, Read, Update, and Delete invoices.
Authentication: Secured with JWT-based authentication.
Audit Logging: Tracks changes to invoices.
Validation: Validates input using helper methods.
Rate Limiting: Protects against excessive API usage.
Swagger Documentation: Interactive API documentation.
Centralized Error Handling: Manages consistent responses for errors.
Technologies Used
ASP.NET Core (.NET 8)
Entity Framework Core (EF Core)
JWT Authentication
Serilog (Logging)
Swagger (API Documentation)
AspNetCoreRateLimit (Rate Limiting)
Getting Started
Prerequisites
.NET SDK 8.0
SQL Server (LocalDB or any SQL instance)
Postman or Swagger for API testing
Setting Up Locally
Clone the repository:

git clone <repository-url>
cd InvoiceManagementAPI
Restore dependencies:

dotnet restore
Update appsettings.json:

Set your database connection string under ConnectionStrings:DefaultConnection.
Configure JWT settings (Jwt:Key, Jwt:Issuer, Jwt:Audience, etc.).
Apply database migrations:

dotnet ef migrations add InitialCreate
dotnet ef database update
Run the application:

dotnet run
Access Swagger UI: Navigate to https://localhost:<port>/swagger.

## API Endpoints
Authentication
POST /api/auth/login
Request: { "username": "admin", "password": "password" }
Response: { "token": "jwt-token" }
Invoices
GET /api/invoices - Retrieve all invoices.
GET /api/invoices/{id} - Retrieve a specific invoice by ID.
POST /api/invoices - Create a new invoice.
PUT /api/invoices/{id} - Update an existing invoice.
DELETE /api/invoices/{id} - Delete an invoice.
Validation
Customer Name: Must not contain special characters.
Total Amount: Must be a positive number.
Validation is handled via the ValidationHelper class.

Rate Limiting
Globally applied to all endpoints via RateLimitingExtensions.
Configurable in appsettings.json under the IpRateLimiting section.
Logging
Logs stored in logs/app_log.txt.
Includes details for every API action and error.
Contributing
Fork the repository.
Create a feature branch (git checkout -b feature-name).
Commit changes (git commit -m 'Add feature').
Push to the branch (git push origin feature-name).
Open a pull request.
