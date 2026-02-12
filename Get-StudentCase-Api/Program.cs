using Get_StudentCase.Data;
using Get_StudentCase.Repositories;
using Get_StudentCase.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
        ));


var app = builder.Build();

// Configure the HTTP request pipline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



/* nuget console commands
 * sqllocaldb create local  -  i CMD vindu f�rst.
 * Lage database:
 * Add-Migration MSSQLInitialMigration
 * Update-Database
 * 
 * Rense:
 * Drop-Database 
 * Remove-Migration 
 */
