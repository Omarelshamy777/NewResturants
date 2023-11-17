


using Microsoft.EntityFrameworkCore;
using Resturant.Application.AppServices;
using Resturant.Application.Contracts;
using Resturants.Application;
using Resturants.DAL;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

DalModule.ConfigureService(builder.Services, builder.Configuration.GetConnectionString("ResturantsContext"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ApplicationModule.ConfigureService(builder.Services);


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
