using System;
using System.Text;
using ASI.Basecode.Data;
using ASI.Basecode.Data.Repositories;
using ASI.Basecode.Resources.Constants;
using ASI.Basecode.Services.Manager;
using ASI.Basecode.Services.Services;
using ASI.Basecode.WebApp.Authentication;
using ASI.Basecode.WebApp.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ASI.Basecode.WebApp.Models;
using ASI.Basecode.WebApp.Services;
using Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

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
            services.AddScoped<IBookReviewRepository, BookReviewRepository>();
            services.AddScoped<IBookReviewService, BookReviewService>();
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddLogging(x => x.AddConfiguration(Configuration.GetLoggingSection()).AddConsole().AddDebug());
            PathManager.Setup(this.Configuration.GetSetupRootDirectoryPath());
            //Configuration
            services.Configure<TokenAuthentication>(Configuration.GetSection("TokenAuthentication"));

            // Session
            services.AddSession(options =>
            {
                options.Cookie.Name = Const.Issuer;
            });

            // DI Services AutoMapper(Add Profile)
            this.ConfigureAutoMapper();

            // DI Services
            this.ConfigureOtherServices();

            // Authorization (Add Policy)
            this.ConfigureAuthorization();

            services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = 1024 * 1024 * 100;
            });

            services.AddSingleton<IFileProvider>(
                new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
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
