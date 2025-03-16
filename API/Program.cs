using Data;
using Microsoft.EntityFrameworkCore;


//inyecto el servicio
var builder = WebApplication.CreateBuilder(args);

// Configurar Entity Framework Core en memoria
builder.Services.AddDbContext<TaskContext>(opt => opt.UseInMemoryDatabase("TaskDB"));

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/*var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddCors();*/


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod()
            );

app.UseAuthorization();

app.MapControllers();

app.Run();
