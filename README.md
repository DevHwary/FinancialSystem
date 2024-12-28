# FinancialSystem

# Financial System API
This project is a backend service built using .NET Core 6 and MySQL Server. It provides APIs for managing user registration, authentication, and finance requests, with features like JWT-based authentication, role-based authorization, and pagination.

The project includes a Postman collection for API testing and a database dump for easy setup.
______________________________________________________________________________________________

# Features
# 1- User Registration & Authentication:

  - Register new users with validation for email, password, and names.
  - Login to obtain a JWT token for secure API access.
  - Role-based access (e.g., Admin).

# 2- Finance Requests Management:

  - Fetch finance requests with filtering, sorting, and pagination.
  - Fields:
    - Request Number
    - Payment Amount
    - Payment Period (in months)
    - Total Profit
    - Request Status (approved/declined)

# 3- API Documentation:

  - Interactive Swagger UI for testing APIs.
  - Postman collection for testing endpoints.
  - Error Handling:

# 4- Middleware for structured error responses.
  - Unified response structure for success and error cases.

# 5- Validation:
  - Input validation is implemented using FluentValidation for consistent and reusable validation logic.
  - Example: Ensures email format is valid, passwords are at least 8 characters, and more.
______________________________________________________________________________________________

# Technologies Used
  - .NET Core 6
  - MySQL Server (Database)
  - Swagger UI (API Documentation)
  - Postman (API Testing)
______________________________________________________________________________________________
# Setup Instructions
1. Clone the Repository
  >> git clone {{repository-url}}
>  >
>  > cd FinancialSystem

2. Restore Dependencie
  >> dotnet restore

3. Restore the database <fine_system>
4. Run the Application
  >> dotnet run --project FinSystem.WebApi
