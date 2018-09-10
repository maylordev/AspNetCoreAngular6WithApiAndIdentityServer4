# .NET CORE 2.1 & Angular 6.1.6 Web Application

## Getting Started

1.   Navigate to `LiveStrams.IdentityServer4/` folder. (main folder for IdentityServer project)
     Then run;

             dotnet restore

     (this should install any dependecies that .NET needs)

2.   Navigate to `LiveStrams.IdentityServer4/` folder.
     Then run;

             dotnet run

## Dotnet EntityFramework Migrations

First Migration made (initial identity)

        dotnet ef migrations add initial_identity_migration -c ApplicationDbContext -o Data/Migrations/AspNetIdentity/ApplicationDb

Second Migration made (server config)

        dotnet ef migrations add initial_is4_server_config_migration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb

Third Migration made (persisted grant db)

        dotnet ef migrations add initial_is4_persisted_grant_migration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb

Apply the migrations

        dotnet ef database update --context ApplicationDbContext

        dotnet ef database update --context ConfigurationDbContext

        dotnet ef database update --context PersistedGrantDbContext

## Seeding the database

Navigate to `LiveStrams.IdentityServer4/` folder. (main folder for IdentityServer project)
Then run:

        dotnet run /seed

(command logic can be found in Program.cs)
