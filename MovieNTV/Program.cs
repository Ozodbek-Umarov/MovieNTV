using Application.Common.Validators;
using Application.Interfaces;
using Application.Services;
using Data.DbContexts;
using Data.Interfaces;
using Data.Repositories;
using Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MovieNTV.Configurations;
using MovieNTV.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Db Context
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// Unit Of Work
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Service
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IAuthManager, AuthManager>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IGenreService, GenreService>();
builder.Services.AddTransient<IMovieService, MovieService>();

builder.Services.ConfigureJwtAuthorize(builder.Configuration);
builder.Services.ConfigurationSwaggerAuthorize(builder.Configuration);


//Validator
builder.Services.AddScoped<IValidator<User>, UserValidator>();
builder.Services.AddScoped<IValidator<Genre>, GenreValidator>();
builder.Services.AddScoped<IValidator<Movie>, MovieValidator>();


var app = builder.Build();

// Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionHandleMiddleware>();

app.Run();
