# LiveStreams.Api

## Getting Started

1.   Navigate to the `/LiveStreams.Api/` folder. (main folder for the API project)
     Then run:

          dotnet restore

2.   Stay in the `/LiveStreams.Api/` folder and run:

     dotnet run

(this should run the API on [https://localhost:5050/api](https://localhost:5050/api))

## Swagger

Once web server is running, open your web browser and go to [http://localhost:5050/swagger/v1/swagger.json](http://localhost:5050/swagger/v1/swagger.json) to see config options.

To see Swagger documentation, you must be in **DEVELOPMENT** mode and not `production` or `staging`. Then go to [https://localhost:5050/swagger](https://localhost:5050/swagger)

## Entity Framework Migrations

First migration:

        dotnet ef migrations add initial_create -c LiveStreamsAppContext -o Data/Migrations

Update/Apply migrations:

        dotnet ef database update
