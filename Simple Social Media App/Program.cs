using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Simple_Social_Media_App.DataAccess;
using Simple_Social_Media_App.Repositories;
using Simple_Social_Media_App.Repositories.Interfaces;
using static System.Net.Mime.MediaTypeNames;
using Simple_Social_Media_App.Controllers;

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
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddAuthentication()
    .AddCookie("cookie", o =>
    {
        o.Cookie.Name = "SSMA";
        o.ExpireTimeSpan = TimeSpan.FromHours(2);
        o.LoginPath = "/api/Users/login";
    });


builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", policy =>
        {
            policy
            // .AllowAnyOrigin()
            .WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        });
    });


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers()
    .RequireAuthorization();    // Require login for all endpoint that are not declared 'AllowAnonymous'


app.Run();
