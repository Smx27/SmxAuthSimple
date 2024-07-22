# SmxAuthSimple

A Dotnet Core Web API Template with Authentication

## Description

SmxAuthSimple is a dotnet core web api template that aims to reduce the initial setup time for web applications. It
provides default features like authentication and database setup, which are preconfigured in the application.

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
dotnet new --search SmxAuthSimple
dotnet new --install SmxAuthSimple
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

## Contributing

If you would like to contribute to this project, please follow these guidelines:

1. Fork the repository
2. Create a new branch for your feature or bug fix
3. Make your changes and ensure they pass all tests
4. Submit a pull request with a detailed description of your changes

## License

This project is licensed under the [MIT License](./LISENSE.md).