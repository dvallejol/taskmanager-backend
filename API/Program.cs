using Data;
using Microsoft.EntityFrameworkCore;

// Crear la aplicación Web con el constructor
var builder = WebApplication.CreateBuilder(args);

// 🔹 Configuración de Entity Framework Core con base de datos en memoria
builder.Services.AddDbContext<TaskContext>(opt => opt.UseInMemoryDatabase("TaskDB"));

// 🔹 Agregar servicios al contenedor
builder.Services.AddControllers(); // Habilita el uso de controladores para manejar solicitudes HTTP

// 🔹 Configuración de Swagger (documentación de la API)
builder.Services.AddEndpointsApiExplorer(); // Permite descubrir los endpoints disponibles
builder.Services.AddSwaggerGen(); // Genera la documentación de la API en Swagger

/* 
   🔹 Código comentado para usar SQL Server en lugar de una base de datos en memoria
   Si decides usar SQL Server en lugar de InMemory, descomenta y configura:
   
   var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
   builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
   builder.Services.AddCors(); // Habilita CORS (Cross-Origin Resource Sharing) si es necesario
*/

// 🔹 Construcción de la aplicación
var app = builder.Build();

// 🔹 Configuración del middleware para Swagger (solo en entorno de desarrollo)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();     // Habilita la generación de Swagger
    app.UseSwaggerUI();   // Habilita la interfaz de Swagger para probar la API
}

// 🔹 Configuración de CORS para permitir solicitudes desde cualquier origen
app.UseCors(x => x.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod()
            );

// 🔹 Habilita la autorización (si tienes autenticación configurada)
app.UseAuthorization();

// 🔹 Mapeo de los controladores para que puedan manejar las solicitudes HTTP
app.MapControllers();

// 🔹 Iniciar la aplicación y escuchar solicitudes
app.Run();
