using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using PluralsightTutorial.Services;
using Microsoft.AspNetCore.Routing;


namespace PluralsightTutorial
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            
        }

        public IConfiguration Configuration { get; set; }
//        public IRouteBuilder RouteBuilder { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            //Place where you configure the Inversion of Control and Dependency Inversion#
            services.AddMvc();
            services.AddSingleton(Configuration);
            services.AddSingleton<IGreeter, Greeter>();
            //Scoped : Way of telling the framework that there should be one instance of the requested object for each HttpRequest
            services.AddScoped<IRestaurantData, InMemoryRestaurantData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IGreeter greeter)
        {
            loggerFactory.AddConsole();
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler(new ExceptionHandlerOptions
                //{
                //    ExceptionHandler = context => context.Response.WriteAsync("Somrthing is wrong")
                //});
            }
            //app.UseDefaultFiles();
            //app.UseStaticFiles();
            app.UseFileServer(); //combo of DefaultFiles + Static Files
                                 //app.UseWelcomePage(new WelcomePageOptions
                                 //{
                                 //    Path = "/welcome"
                                 //});
                                 //app.Run(async (context) =>
                                 //{

            //    var message = Configuration["Greeting"];
            //    await context.Response.WriteAsync(greeter.GetGreeting());
            //});
            // app.UseMvc(configRoutes  => RouteBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{Id?}"));
            app.UseMvc(ConfigureRoutes);
            
            app.Run(ctx => ctx.Response.WriteAsync("Not found"));
            //app.UseWelcomePage();
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{Id?}");
        }
    }
}
