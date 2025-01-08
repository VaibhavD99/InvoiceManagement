# Invoice Management API
## Overview
-	The Invoice Management API is a robust solution for managing invoices, including creation, retrieval, updating, and deletion. 
-	It integrates authentication, validation, and logging mechanisms, ensuring a secure and scalable system.
________________________________________
## Features
-	CRUD Operations: Create, Read, Update, and Delete invoices.
-	Authentication: Secured with JWT-based authentication.
-	Audit Logging: Tracks changes to invoices.
-	Validation: Validates input using helper methods.
-	Rate Limiting: Protects against excessive API usage.
-	Swagger Documentation: Interactive API documentation.
-	Centralized Error Handling: Manages consistent responses for errors.
________________________________________
## Technologies Used
-	ASP.NET Core (.NET 8)
-	Entity Framework Core (EF Core)
-	JWT Authentication
-	Serilog (Logging)
-	Swagger (API Documentation)
-	AspNetCoreRateLimit (Rate Limiting)
________________________________________
## Getting Started
### Prerequisites
•	.NET SDK 8.0
•	SQL Server (LocalDB or any SQL instance)
•	Postman or Swagger for API testing
### Setting Up Locally
1.	Clone the repository:
git clone <repository-url>
cd InvoiceManagementAPI
2.	Restore dependencies:
dotnet restore
3.	Update appsettings.json:
4. Set your database connection string under ConnectionStrings:DefaultConnection.
5. Configure JWT settings (Jwt:Key, Jwt:Issuer, Jwt:Audience, etc.).
6.	Apply database migrations:
- dotnet ef migrations add InitialCreate
- dotnet ef database update
7.Run the application:
dotnet run
8.Access Swagger UI: Navigate to https://localhost:<port>/swagger.
________________________________________
## API Endpoints
### Authentication
- POST /api/auth/login
- Request: { "username": "admin", "password": "password" }
- Response: { "token": "jwt-token" }

### Invoices
- GET /api/invoices - Retrieve all invoices.
- GET /api/invoices/{id} - Retrieve a specific invoice by ID.
- POST /api/invoices - Create a new invoice.
- 	PUT /api/invoices/{id} - Update an existing invoice.
- 	DELETE /api/invoices/{id} - Delete an invoice.
________________________________________
## Validation
- Customer Name: Must not contain special characters.
- 	Total Amount: Must be a positive number.
Validation is handled via the ValidationHelper class.
________________________________________
## Rate Limiting
- Globally applied to all endpoints via RateLimitingExtensions.
- Configurable in appsettings.json under the IpRateLimiting section.
________________________________________
## Logging
- Logs stored in logs/app_log.txt.
- Includes details for every API action and error.
________________________________________
## Contributing
1.	Fork the repository.
2.	Create a feature branch (git checkout -b feature-name).
3.	Commit changes (git commit -m 'Add feature').
4.	Push to the branch (git push origin feature-name).
5.	Open a pull request.

