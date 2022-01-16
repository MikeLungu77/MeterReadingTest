using MeterReading.Business.BusinessProcess;
using MeterReading.Business.Interfaces;
using MeterReading.Controllers;
using MeterReading.Data;
using MeterReading.Services;
using MeterReading.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILogger, Logger<MeterReadingService>>();
builder.Services.AddScoped<ILogger, Logger<MeterReadingController>>();
builder.Services.AddScoped<IMeterReadingService, MeterReadingService>();
builder.Services.AddScoped<IMeterReadingProcess, MeterReadingProcess>();
builder.Services.AddScoped<ISqlDbContext, SqlDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

