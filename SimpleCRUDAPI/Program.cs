using SimpleCRUDAPI.DB_Class;
using Microsoft.EntityFrameworkCore;
using SimpleCRUDAPI.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TaskManagementdb>(options =>
                                           options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                                           ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")))
                                          .EnableSensitiveDataLogging() // Optional: for debugging
                                          .EnableDetailedErrors());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//first step  : create a model class
//second step : create a db context class
//third step  : create a controller class
//fourth step : configure the connection string in appsettings.json
//fifth step  : register the db context class in program.cs
