# .NET CORE 2.1 & Angular 6.1.6 Web Application

## Dotnet EntityFramework Migrations

First database create

        dotnet ef migrations add InitialCreate
    
Update the database

        dotnet ef database update


## BuildBundlerMinifier

        dotnet bundle

This is the main function. Running dotnet bundle will automatically find the bundleconfig.json file if it exist in the working directory.

        dotnet bundle clean

Executing dotnet bundle clean will delete all output files from disk.

        dotnet bundle watch

To automatically run the bundler when input files change, call dotnet bundle watch. This will monitor any file changes to input files in the working directory and execute the bundler automatically.

        dotnet bundle help

Get help on how to use the CLI.