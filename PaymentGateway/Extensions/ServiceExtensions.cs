using Contracts;
using Entities;


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace PaymentGateway.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// CORS gives rights to the user to access resources from the server on a different domain
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .WithMethods("POST", "GET")
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        /// <summary>
        /// Configure IIS integration
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        /// <summary>
        /// create the service the first time you request it and then every subsequent request is calling the same instance of the service.
        /// </summary>
        /// <param name="services"></param>
       

        /// <summary>
        /// Create the service to connect to database
        /// </summary>
        /// <param name="services"></param>
        
        public static void ConfigureSqlContext(this IServiceCollection services)
        {
            services.AddDbContext<RepositoryContext>(opt => opt.UseInMemoryDatabase(databaseName:"PaymentGateWay"));
            services.AddScoped<RepositoryContext>();
        }
        /// <summary>
        /// groups all the repository
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        /// <summary>
        /// Configure swagger documentation
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureSwagger(this IServiceCollection services)
        {


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "PaymentGateway API", Description = "Checkout GatewayAPI" });
                c.ExampleFilters();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.AddFluentValidationRules();


            });


            services.AddSwaggerExamplesFromAssemblyOf<Startup>();




        }


        /// <summary>
        /// Configure app to use build-in identity services
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<RepositoryContext>();


        }


        /// <summary>
        /// Configure services for healthcheck of dbcontext
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureHealthCheck(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddDbContextCheck<RepositoryContext>();

        }


    }
}
