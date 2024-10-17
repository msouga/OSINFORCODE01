using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
// Proyecto para Osinfor Simple 
// Mostrar las variables de entorno de la aplicación

namespace EnvVariablesApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Construir y ejecutar el host
            CreateHostBuilder(args).Build().Run();
        }

        // CreateHostBuilder configura el host con configuraciones predeterminadas y especifica la clase Startup
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Utiliza la clase Startup para configurar los servicios y el pipeline de solicitudes
                    webBuilder.UseStartup<Startup>();
                });
    }

    public class Startup
    {
        private readonly IConfiguration _configuration;

        // Constructor para inicializar la clase Startup con la configuración de la aplicación
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // ConfigureServices se usa para agregar servicios al contenedor de inyección de dependencias (DI)
        public void ConfigureServices(IServiceCollection services)
        {
            // Agregar soporte para controladores con vistas
            services.AddControllersWithViews();
        }

        // Configure establece el pipeline de procesamiento de solicitudes
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Si la aplicación está en desarrollo, usar la página de excepciones del desarrollador para mostrar información detallada de errores
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Habilitar el enrutamiento para la aplicación
            app.UseRouting();

            // Definir los endpoints para la aplicación
            app.UseEndpoints(endpoints =>
            {
                // Mapear una solicitud GET a la URL raíz ("/")
                endpoints.MapGet("/", async context =>
                {
                    // Recuperar todas las variables de entorno
                    var envVariables = Environment.GetEnvironmentVariables();
                    var title = "<h1>Variables de Entorno</h1>";
                    var content = "";

                    // Iterar a través de todas las variables de entorno y construir el contenido HTML
                    foreach (var key in envVariables.Keys)
                    {
                        // Si el valor es nulo, establecerlo como "<vacio>"
                        var value = envVariables[key]?.ToString() ?? "<vacio>";
                        content += $"<p><strong>{key}:</strong> {value}</p>";
                    }

                    // Escribir el contenido HTML en la respuesta
                    await context.Response.WriteAsync($"{title}{content}");
                });
            });
        }
    }
}
