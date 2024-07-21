# ProtivitiTest.WebAPI

Builded a C# AspNetCore REST API, with an in-memory SQLite DB. Using .net 7.0.

## Features 

- **Entity Framework Core:** The application uses Entity Framework Core as the Object-Relational Mapping (ORM) tool, providing a convenient way to interact with the database.
- **AutoMapper:** AutoMapper simplifies the process of mapping between different objects, enhancing code readability and reducing boilerplate code.
- **Repository Design Patterns:** The project follows the repository design pattern, promoting a clean and modular architecture for data access and manipulation.
- **Dependency Injection:** Used ASP.NET Core provided  built-in, lightweight dependency injection containers that help in managing and injecting dependencies into application components. This loose coupling, modular and testable code.

## API Endpoints
- **POST /api/customers:** create a customer into database and make an external api call for getting avatar of customer.
- **GET /api/customers/GUID:** return a customer by ID.
- **GET /api/customers/int:** return customers of a certain age.
- **PATCH /api/customers/GUID:** PATCH a customer name or date of birth, additionaly an Non functional requirement is when the user name is pached then will also patching the Avatar that is also implemented.
- **GET /api/customers:** return all customers.


## Technologies Used
- **ASP.NET Core WebAPI:** The core framework for building the web application.
- **Entity Framework Core:** The ORM tool for data access and manipulation.
- **AutoMapper:** Simplifies object-to-object mapping.

## Getting Started

To get started with the Academy Portal project, follow these steps:

1. Clone the repository:

    ```bash
    https://github.com/nikhil777jais/ProtivitiTest
    ```

2. Navigate to the project directory:

    ```bash
    cd ProtivitiTest
    ```
3. Build and run the application:

    ```bash
    dotnet build
    dotnet run
    ```

7. Open your web browser and visit [https://localhost:7103](https://localhost:7103) to access the WebAPI.

## ShnapShots
![image](https://github.com/user-attachments/assets/c973863f-ee1c-419f-b968-7a192f7ee037)
