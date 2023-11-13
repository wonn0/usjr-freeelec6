﻿using ASI.Basecode.Data;
using ASI.Basecode.WebApp.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ASI.Basecode.WebApp
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            this.ConfigureDependencies(services);       // Configuration for dependency injections           
            this.ConfigureDatabase(services);           // Configuration for database connections
            this.ConfigureMapper(services);             // Configuration for entity model and view model mapping
            this.ConfigureCors(services);               // Configuration for CORS
            this.ConfigureAuth(services);               // Configuration for Authentication logic
            this.ConfigureMVC(services);                // Configuration for MVC                  
            

            // Add services to the container.
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddLogging(x => x.AddConfiguration(Configuration.GetLoggingSection()).AddConsole().AddDebug());
            PathManager.Setup(this.Configuration.GetSetupRootDirectoryPath());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");     // Enables site to redirect to page when an exception occurs
                app.UseHsts();                              // Enables the Strict-Transport-Security header.
            }

            this.ConfigureLogger(app, env);
            app.UseStaticFiles();           // Enables the use of static files
            app.UseHttpsRedirection();      // Enables redirection of HTTP to HTTPS requests.
            app.UseCors("CorsPolicy");      // Enables CORS                              
            app.UseRouting();
            app.UseAuthentication();        // Enables the ConfigureAuth service.
            app.UseMvc();
            app.UseAuthorization();
            
            this.ConfigureRoutes(app);      // Configuration for API controller routing
            this.ConfigureAuth(app);        // Configuration for Token Authentication
        }
    }
}
