# SmxAuthSimple

A Dotnet Core Web API Template with Authentication

## Description

SmxAuthSimple is a dotnet core web api template that aims to reduce the initial setup time for web applications. It
provides default features like authentication and database setup, which are pre-configured in the application. Also this used 
Unit of Work with repository pattern to make data handling easier.

## Features

- JWT Token service
- Identity Services (`UserManager`, `RoleManager`, and `SignInManager`)
- Exception Middleware and custom logs on the database
- Auth controller with required actions like `Login`, `Register`, and `RefreshToken`
- Support for multiple databases: `SQLite` and `SQL Server` (with plans to add more upon requirement)
- Support for multiple frameworks: `net8.0` and `net7.0`

## Installation

This package is available on NuGet, so you can directly download it from the Package Manager. If you prefer using the
CLI, run the following commands:

```bash
# To search this template use 
dotnet new search Smx27.DotNetCore.SmxAuthSimple
dotnet new install Smx27.DotNetCore.SmxAuthSimple
```

To create a new project with this template, you can use the following arguments:

### Arguments

- `-n, --name <name>`: The name for the output being created. If no name is specified, the name of the output directory
  is used.
- `-o, --output <output>`: Location to place the generated output.
- `--dry-run`: Displays a summary of what would happen if the given command line were run if it results in a template
  creation.
- `--force`: Forces content to be generated even if it changes existing files.
- `--no-update-check`: Disables checking for the template package updates when instantiating a template.
- `--project <project>`: The project that should be used for context evaluation.
- `-lang, --language <c#>`: Specifies the template language to instantiate.
- `--type <project>`: Specifies the template type to instantiate.

### Template Options

- `-F, --Framework <net7.0|net8.0>`: The target framework version. Default: `net8.0`
- `-db, --dbType <dbType>`: The database type to use. Default: `sqlite`
- `-E, --EnableSwaggerSupport`: Enable swagger support for this application or not. Default: `true`
- `-s, --skipRestore`: If specified, skips the automatic restore of the project on create. Default: `false`


## After Project Creation Setup

Once you have created your project, the next step is to set up the database migrations. If you are using the command line interface (CLI), you can generate the initial migration by executing the following commands:

```bash
dotnet ef migrations add InitialMigration
dotnet database update # Optional
```

### Project Structure

Your project structure should resemble the following layout:

```plaintext
├───Controllers
│   ├───Authentication
│   └───DTO
│       ├───Authentication
│       └───Exception
├───Data
│   ├───Entities
│   ├───Interfaces
│   ├───Migrations
│   ├───Repository
│   └───Seeder
├───Extensions
├───Middleware
├───Properties
└───Services
```

### Using a Generic Repository

To streamline your development process, it is highly recommended to utilize a Generic Repository. This approach simplifies data access and management. You can find the Generic Repository in the `Data\Repository\GenericRepository` path.

#### Steps to Create a New Repository

1. **Create a New Entity**: For example, you might create an entity called `Products`.
   
2. **Define a New Interface**: Create a new interface for the repository in the `Data\Interfaces` folder. For instance, name it `IProductRepository`.
   - Ensure that this interface derives from the `IGenericRepository`. For example:
     ```csharp
     public interface IProductRepository : IGenericRepository<Products>
     ```

3. **Implement the Repository Class**: Create a new repository class named `ProductRepository` in the `Data\Repository` folder and implement the interface. For example:
   ```csharp
   public class ProductRepository : GenericRepository<Products>, IProductRepository
   ```

4. **Constructor Setup**: Pass the `DataContext` to the constructor of your repository class.

5. **Update the Unit of Work**: When creating the interface, add it to the `Data\Interfaces\IUnitOfWork` by including a property for the new repository:
   ```csharp
   IProductRepository Product { get; }
   ```

6. **Implement in Unit of Work**: Add this member to `Data\UnitOfWork.cs`:
   ```csharp
   public IProductRepository Product { get; private set; }
   ```
   Make sure to initialize this in the constructor:
   ```csharp
   Product = new ProductRepository(_context);
   ```

Congratulations! You have successfully created a new repository with basic functionalities in just a few minutes.

### FAQ

You may have some questions regarding this setup:

1. **Why create a new interface and derive from the generic one instead of using it directly?**
   - The Generic Repository provides basic functionalities, but it does not allow for the addition of custom methods. By creating a new interface, you can define complex methods specific to your repository without affecting other repositories.

2. **Is the Generic Repository really necessary?**
   - While it is not strictly required, using a Generic Repository helps reduce repetitive code, such as methods for retrieving items by ID or fetching all records. If you prefer not to use it, you are free to do so.

3. **Do we really need to follow the Unit of Work pattern here?**
   - The Unit of Work pattern is used to ensure data integrity across multiple operations. However, if you find it unnecessary for your project, you can choose to omit it.

If you have any other questions or concerns, please feel free to ask in the `Issues` or `Discussions` section of the GitHub repository.


## Contributing

If you would like to contribute to this project, please follow these guidelines:

1. Fork the repository
2. Create a new branch for your feature or bug fix
3. Make your changes and ensure they pass all tests
4. Submit a pull request with a detailed description of your changes

## License

This project is licensed under the [MIT License](./LISENSE.md).