using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Simple_Social_Media_App.DataAccess;
using Simple_Social_Media_App.Repositories;
using Simple_Social_Media_App.Repositories.Interfaces;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddAutoMapper(typeof(MapperService).Assembly);
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

builder.Services.AddScoped<IUserRepository, UserRepository>();



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
