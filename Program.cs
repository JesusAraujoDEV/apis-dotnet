using apis_dotnet;
using apis_dotnet.Services;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using apis_dotnet.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("cnTareas");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("La cadena de conexión 'cnTareas' no se encontró en la configuración.");
}

builder.Services.AddDbContext<TareasContext>(options =>
    options.UseSqlServer(connectionString)
);


builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
builder.Services.AddScoped<ITareaService, TareaService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage();
//app.UseTimeMiddleware();

app.MapControllers();

app.Run();