using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using LiveStreamsApp.Models;
using static LiveStreamsApp.Models.LiveStreamsAppContext;
using Swashbuckle.AspNetCore.Swagger;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace LiveStreamsApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(opts => opts.LowercaseUrls = true);
            // Add Cors
			// services.AddCors();
            
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddFeatureFolders();
            
            // allows for instances of INodeServices in your application. 
            // INodeServices is the API through which .NET code can make calls into JavaScript that runs in a Node environment.
            services.AddNodeServices();

            var connection = @"Server=(mysql)\mysqllocaldb;Database=LiveStreamsApp;Trusted_Connection=True;";

            services.AddDbContext<LiveStreamsAppContext>(options => options.UseSqlServer(connection));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot/dist";
            });

            // Add Swagger Auto Document Generation service
			services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "LiveStreams.Web",
                    Description = "A Livestream aggregate site",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Maylor Taylor",
                        Email = string.Empty,
                        Url = "https://maylortaylor.github.io"
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory
            )
        {

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // Setup Swagger Auto Document Generation
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "LiveStreamsApp WEB V1");
                });
            }
            else
            {
                app.UseExceptionHandler("/Shared/Error");
                // app.UseHsts();
            }

            // Setup Cors
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            // app.UseHttpsRedirection();
            // app.UseCookiePolicy();
            app.UseSpaStaticFiles();
            app.UseStaticFiles(
            //     new StaticFileOptions() {
            //     OnPrepareResponse = c => {

            //         //Do not add cache to json files. We need to have new versions when we add new translations.
            //         if (!c.Context.Request.Path.Value.Contains(".json"))
            //         {
            //             c.Context.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue()
            //             {
            //                 MaxAge = TimeSpan.FromDays(30) // Cache everything except json for 30 days
            //             };
            //         }
            //         else
            //         {
            //             c.Context.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue()
            //             {
            //                 MaxAge = TimeSpan.FromMinutes(15) // Cache json for 15 minutes
            //             };
            //         }
            //     }
            // }
            );

            //The app.MapWhen function says when the route has "Reader" in it change the spa fallback. You would do this for each app.
            // app.MapWhen(context => context.Request.Path.Value.StartsWith("/Reader"), builder =>
            // {
            //     builder.UseMvc(routes =>
            //     {
            //         routes.MapSpaFallbackRoute("reader-fallback", new { area = "Reader", controller = "Default", action="Index" });
            //     });
            // });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // app.UseSpa(spa =>
            // {
            //     // To learn more about options for serving an Angular SPA from ASP.NET Core,
            //     // see https://go.microsoft.com/fwlink/?linkid=864501

            //     spa.Options.SourcePath = "ClientApp";

            //     if (env.IsDevelopment())
            //     {
            //         spa.UseAngularCliServer(npmScript: "start");
            //     }
            // });
        }
    }
}
