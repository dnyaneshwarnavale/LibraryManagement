using Library.ParamConstraints;
using Library.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace Library
{
    public class Startup
    {

        public Startup()
        {

        }

        public void ConfigureServices (IServiceCollection services)
        {
            services.AddSingleton<IInterface, FirstInstance>();
            services.AddSingleton<IInterface, SecondInstance>();
            services.AddControllersWithViews();
            // services.AddMvcCore();
            // services.AddMvc();

            //authentication
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Home/Login";
            });

            // Runtime razor compilation  -- add during dubug
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
                 // singleton DI
                 services.AddSingleton<IBookRepository, BookRepository>();  // instance life
                 services.AddScoped<IBookRepository, BookRepository>();
                 services.AddTransient<IBookRepository, BookRepository>(); 

            services.AddSingleton<ISingleton, Scope>();
            services.AddScoped<IScoped, Scope>();
            services.AddTransient<ITransient, Scope>();

            services.AddRouting(options =>     //parameter constraints
            {
                options.ConstraintMap.Add("custname",typeof(CustomConstraints));
            });

        }
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
        {
            // for error message
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // middleware for adding images path
              app.UseStaticFiles(new StaticFileOptions 
              {
                  FileProvider=new PhysicalFileProvider (Directory.GetCurrentDirectory()+ "/resources"),
                  RequestPath="/resources"
              });
            

           
            

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("I am from first middleware!!");
            //    await next();
            //    await context.Response.WriteAsync("I am from first after middleware!!");
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("I am from second middleware!!");
            //    await next();
            //});


          /*  app.UseRouting();
            app.UseEndpoints(endpoint =>
           {
               endpoint.MapGet("/", async context =>
                {
                   await context.Response.WriteAsync("The program loaded default!!");
                });
           });
            //  app.UseRouting();  // getting error while complier - becoz order is routing 

               app.UseEndpoints(endpoint =>
               {
                   endpoint.MapGet("/getname", async context =>
                   {
                       await context.Response.WriteAsync("The project name is Library mgmt");
                   });
               });
               app.UseEndpoints(endpoint =>
               {
                   endpoint.MapGet("/getnumber", async context =>
                   {
                       await context.Response.WriteAsync("The project number - 1.0");
                   });
               });
            */

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoint =>
            {
                // endpoint.MapDefaultControllerRoute();

                // EndPoints
                //endpoint.mapget("/", async context =>
                //{
                //    await context.response.writeasync("hello from endpoint");
                //});

                // 3 way
                /* endpoint.MapControllerRoute(
                     name: "Default",
                     pattern:"{controller}/{action}/{id?}", // ? for optional  convential routing
                     defaults: new {contoller="Home",action="Index"} );
                */

                // attribute routing
                endpoint.MapControllers();

            });

        }

    }
}
