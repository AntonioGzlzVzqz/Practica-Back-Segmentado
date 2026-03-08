using LibreriaApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var Conexion = builder.Configuration.GetConnectionString("MiConexion");

builder.Services.AddDbContext<LibDbContext>(options =>
options.UseSqlServer(Conexion));

// Registro de repositories
builder.Services.AddScoped<IBookRepository, BookRepository>();

// Registro de services
builder.Services.AddScoped<IBookService, BookService>();

// Registro de handlers
builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddProblemDetails();

//

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
