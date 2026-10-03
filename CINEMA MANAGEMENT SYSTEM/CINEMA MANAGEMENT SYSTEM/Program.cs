using AutoMapper;
using CINEMA_MANAGEMENT_SYSTEM.Data;
using CINEMA_MANAGEMENT_SYSTEM.Mapping;
using CINEMA_MANAGEMENT_SYSTEM.Repo.Implmentation;
using CINEMA_MANAGEMENT_SYSTEM.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(
    x => x.AddProfile<MapperProfile>()
);


builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<GenreCustomRepo>();
builder.Services.AddScoped<CustomerCustomRepo>();
builder.Services.AddScoped<MovieCustomRepo>();
builder.Services.AddScoped<BookingCustomRepo>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IGenre, GenreCustomRepo>();
builder.Services.AddScoped<ICustomer, CustomerCustomRepo>();
builder.Services.AddScoped<IMovie, MovieCustomRepo>();
builder.Services.AddScoped<IBooking, BookingCustomRepo>();


builder.Services.AddDbContext<My_AppContext>(options =>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("conn")
    ));


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
