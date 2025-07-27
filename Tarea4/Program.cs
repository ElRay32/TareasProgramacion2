using Microsoft.EntityFrameworkCore;
using Tarea2Api.Contract;
using Tarea2Api.Data;
using Tarea2Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuración de DbContext
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de servicios
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();