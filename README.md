# Library management system
It is a simple system that allows you to manage a library, keep all the books, readers, manage their activity and do all the things that every library needs.

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
- Entity Framework Core

## Authors
- Grzegorz Dynak [gregusio](https://github.com/gregusio)
- Dorota Dyczek [Dora455](https://github.com/Dora455)

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details
