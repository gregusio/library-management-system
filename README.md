# Library management system
It is a simple system that allows you to manage a library, keep all the books, readers, manage their activity and do all the things that every library needs.

## Features

- **Book Management:**
  - Add, edit, and delete book information.
  - Categorize and index resources.
  - Assign unique identifiers to each resource.

- **Reader Management:**
  - User registration and authentication.
  - Add, edit, and delete reader information.
  - Monitor reader activity.

- **Borrowing and Returning Resources:**
  - Create borrowings and reservations.
  - Handle the resource return process.

## Getting started

### Prerequisites
- [.NET 8.0](https://dotnet.microsoft.com/en-us/download)
- dotnet ef
```
dotnet tool install --global dotnet-ef
```

### Installing

#### Cloning repo
```
git clone https://github.com/gregusio/library-management-system.git
cd library-management-system
```

#### Setting up local database
```
dotnet ef --project library-management-system migrations add InitialCreate
dotnet ef --project library-management-system database update
```

### Running project
```
dotnet watch --project library-management-system
```

### Running tests
To run all tests in project library-management-system.test just type
```
dotnet test
```

## Technologies used
- .NET 8.0
- Blazor

- **Database:**
  - SQLite
  - Entity Framework Core

- **Backend:**
  - ASP.NET Core
  - C# 

- **Others:**
  - Git
  - Rider


## Authors
- Grzegorz Dynak [gregusio](https://github.com/gregusio)
- Dorota Dyczek [Dora455](https://github.com/Dora455)

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details


