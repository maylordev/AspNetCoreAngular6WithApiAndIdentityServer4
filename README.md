# .NET CORE 2.1 & Angular 6.1.6 Web Application

## Getting Started

1. Navigate to the `LiveStreams.Web/ClientApp` folder. (this is where the Angular app is located)
        Then run:

        npm install
(this will install all of the NPM packages for the Angular app)

2. Navigate to the `LiveStreams.Web/ClientApp` folder. 
        Then run:

        ng build
(this will build the Angular app)

3. Navigate to `LiveStrams.Web/` folder. (main folder for Web project)
        Then run;

        dotnet restore
(this should install any dependecies that .NET needs)

4. Navigate to `LiveStrams.Web/` folder.
        Then run;

        dotnet run
(this should run the Web application at **[https://localhost:5001](https://localhost:5001)**)

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





# MVC + Angular + Features Design Pattern
I would like to thank [Mikelunn](https://medium.com/@LunnCheck/a-mini-spa-approach-with-angular-and-net-core-mvc-bb3a35da9eba) for [this wonderful template](https://github.com/mikelunn/net-core-mvc-angular)
## Architecture
![Single App Component](https://github.com/mikelunn/net-core-mvc-angular/blob/master/AngularMvc.png)

With this approach, the MVC framework handles the rendering of the app shell, and any other features that just display data to the user. Then I use Angular for features that involve a lot of partial page refreshing. And rather than pulling in the complexity of server-side pre-rendering into my projects, I chose to use a very simple method of data pre-loading.
By not replacing my server-side framework entirely with a client-side framework, I feel that much complexity is reduced within my client-side code. A lot of infrastructure related code is also moved out of my SPA app and back into the server side where it belongs. So let’s look at the key components of this approach.

## Feature Modules
With this approach I make sure each mini-spa is accessed with a good ‘ole fashioned full page refresh. The server then retrieves data from the backend, preloads the view with data, and renders a simple html page that contains the app component tag and related script dependencies.

What I like about this approach is that it allows me to handle authorization logic on the server, as well as retrieve data from the back end before redrawing the page. So every mini spa in my application will follow this approach.
At the surface, this approach may seem somewhat reckless. Because if a user is accessing Feature B, we wouldn’t want to unnecessarily include Feature C dependencies. This simply would not scale well. By taking a feature module approach, i’m able to keep my root module as thin as possible and lazy load each individual feature on demand.

## Preloading Feature Modules
By preloading my views with data i’m able to increase the initial page load of each mini spa. I use a simple service to hold the initial state of each feature, and the root component uses this service to set the initial data.
I also needed a way to dynamically inject the angular-cli generated app scripts into my razor pages. So I decided to create a simple html helper extension that just reads the index.html file from the dist folder.

Lastly, we need to tell the server how to handle routes within our spa application. There are many examples of handling this with custom routing middleware. And this was how I initially was handling my spa fallback routes. But I haven’t had any issue with just specifying the fallback using route attributes. I find it a little more explicit than the middleware approach.

Just to recap. This post was not meant to be a step by step guide to using Angular with Net Core MVC, nor do I consider it “the right way” to use the two frameworks together. I just wanted to share an approach that I have been successful with, and I hope it may help you be successful on a future project.