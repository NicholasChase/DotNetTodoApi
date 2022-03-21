using Microsoft.EntityFrameworkCore;
using Npgsql;
using todoDotNet6;
using todoDotNet6.TodoRepo; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var stringBuilder = new NpgsqlConnectionStringBuilder()
{
    Host = "localhost",
    Port = 5432,
    Username = "postgres",
    Password = "password",
    Database = "todos_app"
};

builder.Services.AddDbContext<DataContext>(options => 
    options.UseNpgsql(stringBuilder.ConnectionString)
        .UseSnakeCaseNamingConvention()
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITodoRepository, TodoRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
