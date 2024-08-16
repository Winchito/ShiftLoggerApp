using System;
using Microsoft.EntityFrameworkCore;
using ShiftLoggerApp.Data;
using ShiftLoggerApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Dependency Injection (DONT FORGET THIS, ITS IMPORTANT!!!)
builder.Services.AddDbContext<WorkerShiftContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));
builder.Services.AddScoped<WorkerService>();
builder.Services.AddScoped<ShiftService>();
builder.Services.AddScoped<WorkerShiftService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
