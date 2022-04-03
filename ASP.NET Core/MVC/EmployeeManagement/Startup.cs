using EmployeeManagement.Models;
using EmployeeManagement.Repository_EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _configuration;

        // Notice we are using Dependency Injection here
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(
         options => options.UseSqlServer(_configuration.GetConnectionString("EmployeeDBConnection")));


            /*
            //Security identity invoke
            services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<AppDbContext>();

            //defualt passowrd ovveride rule
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireNonAlphanumeric = false;
            });
            */

            //Security identity invoke
            //defualt passowrd ovveride rule
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 12;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            //services.AddMvc();
            //services.AddMvc(options => options.EnableEndpointRouting = false).AddXmlSerializerFormatters();
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
                config.EnableEndpointRouting = false;
            }).AddXmlSerializerFormatters();

            services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = "131332157123-0unr2dhehd2pi1ugqn0tpr8ocuu7f5e7.apps.googleusercontent.com";
                options.ClientSecret = "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";
            });

            //path to custom accees denied
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Administration/AccessDenied");
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("SuperAdminPolicy", policy => policy.RequireRole("Developer", "Admin")); //role based policy authorization
                options.AddPolicy("DeleteRolePolicy", policy => policy.RequireClaim("Delete Role").RequireClaim("Create Role"));//Claim based policy authorization
                options.AddPolicy("EditRolePolicy", policy => policy.RequireClaim("Edit Role"));
            });
            // for mock repository for memory storage
            //services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
            // for db driven sql EF dependency injection
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
                ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions
                {
                    SourceCodeLineCount = 10
                };
                app.UseDeveloperExceptionPage(developerExceptionPageOptions);
            }
            else
            {
                //resonse as a status code on browser text view that we get in request
                //app.UseStatusCodePages();
                //return a custom error view of ErrorController  => redirect first request response 200 and second 302
                //app.UseStatusCodePagesWithRedirects("/Error/{0}");

                //404 response in single request
                //app.UseStatusCodePagesWithReExecute("/Error/{0}");

                //generic ERROR
                app.UseExceptionHandler("/Error");

            }

            /*app.Use(async (context, next) =>
            {
                logger.LogInformation("MW1: Incoming Request");
                await next();
                logger.LogInformation("MW1: Outgoing Response");
            });

            app.Use(async (context, next) =>
            {
                logger.LogInformation("MW2: Incoming Request");
                await next();
                logger.LogInformation("MW2: Outgoing Response");
            });*/

            /*app.Run(async (context) =>
            {
                await context.Response.WriteAsync("MW3: Request handled and response produced");
                logger.LogInformation("MW3: Request handled and response produced");
            });*/

            /*
            // Specify foo.html as the default document
            DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            defaultFilesOptions.DefaultFileNames.Clear();
            defaultFilesOptions.DefaultFileNames.Add("newDefault.html");
            app.UseDefaultFiles(defaultFilesOptions);     
            app.UseStaticFiles();
            */
            // Use UseFileServer instead of UseDefaultFiles & UseStaticFiles
            /*FileServerOptions fileServerOptions = new FileServerOptions();
            fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("newDefault.html");
            app.UseFileServer(fileServerOptions);*/

            /*app.Run(async (context) =>
            {
                throw new Exception("Some error processing the request");
                //await context.Response.WriteAsync("Hello World!");
            });*/
            /* app.UseRouting();


             app.UseEndpoints(endpoints =>
             {
                 endpoints.MapGet("/", async context =>
                 {
                     await context.Response.WriteAsync("Hello from 1st Middleware");

                 });
                 /*endpoints.MapGet("/hello", async context =>
                 {
                     await context.Response.WriteAsync("Hello from 2nd Middleware");

                 });
             });*/

            app.UseStaticFiles();

            app.UseAuthentication();

            //default routing => {controller=Home}/{action=Index}/{id?}
            //app.UseMvcWithDefaultRoute();

            //Custome routing => Conventional 
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


            //default setup to routing return string for every request if not provided
            /*
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });*/

        }
    }
}
