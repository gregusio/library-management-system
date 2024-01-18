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
  - Keep track of borrowing and returning history for each reader.
  - Monitor reader activity.

- **Borrowing and Returning Resources:**
  - Create borrowings and reservations.
  - Handle the resource return process.

## Class diagram
![classDiagram](https://github.com/gregusio/library-management-system/assets/77176069/068a620e-5040-4f42-8744-58961be32e24)

## Getting started

### Prerequisites
- [.NET 8.0](https://dotnet.microsoft.com/en-us/download)
- dotnet ef
```
dotnet tool install --global --version 8.0.0 dotnet-ef
```

### Installing

#### Cloning repo
```
git clone https://github.com/gregusio/library-management-system.git
cd library-management-system
```

#### Setting up local database
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Running project
```
dotnet watch
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


