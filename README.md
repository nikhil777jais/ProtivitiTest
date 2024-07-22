# ProtivitiTest.WebAPI And ProtivitiTest.UI

- Builded a C# AspNetCore REST API, with an in-memory SQLite DB. Using .net 7.0.
-Builded Sigle page application for the API using Angular.

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

## Getting Started - ProtivitiTest.WebAPI

To get started with the ProtivitiTest.WebAPI  project, follow these steps:

1. Clone the repository:

    ```bash
    https://github.com/nikhil777jais/ProtivitiTest
    ```

2. Navigate to the project directory:

    ```bash
    cd ProtivitiTest.ProtivitiTest.WebAPI
    ```
3. Build and run the application:

    ```bash
    dotnet build
    dotnet run
    ```

4. Open your web browser and visit [https://localhost:7103](https://localhost:7103) to access the WebAPI.

## Getting Started -  ProtivitiTest.WebUI

1. Requiremeent for angular application:
    ```bash
        Angular CLI: 16.0.6
        Node: 18.16.1
        Package Manager: npm 9.5.1
    ```
    
3. Navigate to the project directory

    ```bash
    cd ProtivitiTest.ProtivitiTest.WebUI
    ```
4. Install packegs
    ```bash
    npm install
    ```
5. run angualar application
     ```bash
    ng serve --port 4300
    ```

6. Open your web browser and visit [https://localhost:4300](https://localhost:4300) to access the WebUI.

## ShnapShots
![image](https://github.com/user-attachments/assets/c973863f-ee1c-419f-b968-7a192f7ee037)
![image](https://github.com/user-attachments/assets/2b5b1c32-466f-491b-bd51-59a6e7c9ad83)
![image](https://github.com/user-attachments/assets/c4fb1fa5-8e6a-408d-95ef-46351d115f39)
![image](https://github.com/user-attachments/assets/0e48383e-afd5-437d-b082-5db7e027a65e)



