
using Microsoft.OpenApi.Models;
using RoaSystems.DemoKPI.Service;
using RoaSystems.DemoKPI.Service.Interfaces;

namespace RoaSystems.DemoKPI.API
{
    public class Program
    {
        /*
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // 🗃️ DbContexts
            var environmentMode = builder.Configuration["Environment"] ?? "Development";
            var connectionString = GetConnectionStringForEnvironment(builder.Configuration, environmentMode);
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            // 💼 Application Services and Repositories
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            // Services
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();

            // 🌐 CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // 📘 Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OLaughlin.API.Demo.Local", Version = "v1" });
            });

            // 📦 Controllers
            builder.Services.AddControllers();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
        */


        /* public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 📘 Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DemoKPI.API", Version = "v1" });
            });


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        } */


        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1. Configuración de Controllers
            builder.Services.AddControllers();

            // 2. Configuración de Swagger (Swashbuckle)
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DemoKPI.API", Version = "v1" });
            });

            // 3. Registro de tus servicios de Gemini (¡Importante!)
            builder.Services.AddHttpClient<IAIService, AIService>();
            builder.Services.AddScoped<IAIService, AIService>();

            // 4. OpenAPI nativo de .NET 9
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // 5. Configuración del Pipeline HTTP
            if (app.Environment.IsDevelopment())
            {
                // Esto habilita el documento JSON de OpenAPI
                app.MapOpenApi();

                // Esto habilita la interfaz visual de Swagger (la página que buscas)
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DemoKPI.API v1");
                    c.RoutePrefix = "swagger"; // Esto hace que entres vía localhost:PORT/swagger
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }

    }
}
