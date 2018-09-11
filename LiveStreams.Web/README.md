# LiveStreams.Web

## Getting Started

1.   Navigate to the `LiveStreams.Web/ClientApp` folder. (this is where the Angular app is located)
     Then run:

             npm install

     (this will install all of the NPM packages for the Angular app)

2.   Stay in the `LiveStreams.Web/ClientApp` folder and run:

             ng build

     (this will build the Angular app)

3.   Navigate back to `LiveStrams.Web/` folder. (main folder for Web project)
     Then run:

             dotnet restore

     (this should install any dependecies that .NET needs)

4.   Stay in the `LiveStrams.Web/` folder.
     Then run:

             dotnet run

     (this should run the Web application at [https://localhost:5001](https://localhost:5001))

## BuildBundlerMinifier

        dotnet bundle

This is the main function. Running dotnet bundle will automatically find the bundleconfig.json file if it exist in the working directory.

        dotnet bundle clean

Executing dotnet bundle clean will delete all output files from disk.

        dotnet bundle watch

To automatically run the bundler when input files change, call dotnet bundle watch. This will monitor any file changes to input files in the working directory and execute the bundler automatically.

        dotnet bundle help

Get help on how to use the CLI.

## Swagger

Once web server is running, open your web browser and go to [http://localhost:5001/swagger/v1/swagger.json](http://localhost:5001/swagger/v1/swagger.json) to see config options.

To see Swagger documentation, you must be in **DEVELOPMENT** mode and not `production` or `staging`. Then go to [https://localhost:5001/swagger](https://localhost:5001/swagger)
