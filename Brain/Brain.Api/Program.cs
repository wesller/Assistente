using Brain.Core.Interfaces;
using Brain.InfraEstrutura.Data;
using Brain.InfraEstrutura.Repositories;
using Microsoft.EntityFrameworkCore;
using Brain.Core.Entities; // Adicionado para reconhecer a entidade Item

var builder = WebApplication.CreateBuilder(args);

// Configuração da String de Conexão via Variáveis de Ambiente
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbPort = Environment.GetEnvironmentVariable("DB_PORT") ?? "5432";
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPass = Environment.GetEnvironmentVariable("DB_PASSWORD");

string connectionString;

if (string.IsNullOrEmpty(dbHost) || string.IsNullOrEmpty(dbName) || string.IsNullOrEmpty(dbUser) || string.IsNullOrEmpty(dbPass))
{
    // Fallback para appsettings.json se as variáveis não estiverem definidas (útil para dev local rápido)
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
        ?? throw new InvalidOperationException("As variáveis de ambiente do banco de dados não foram configuradas e nenhuma string de conexão padrão foi encontrada.");
}
else
{
    connectionString = $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPass};Include Error Detail=true";
}

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Brain.Api")));

builder.Services.AddScoped<IGenericRepository<Item>, GenericRepository<Item>>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.MapPost("/itens", async (Item item, IGenericRepository<Item> repository) =>
{
    await repository.Add(item);
    return Results.Created($"/itens/{item.Id}", item);
})
.WithName("CreateItem");

app.Run();
