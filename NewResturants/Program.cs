

using DAL;
using Microsoft.EntityFrameworkCore;
using Resturant.Business.Interfaces;
using Resturant.Business.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Connection String
builder.Services.AddDbContext<ResturantsContext>(
    options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ResturantsContext")
    ));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthManager, AuthManager>();

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
