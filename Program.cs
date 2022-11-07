global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using Yard_Scan_API.Data.Context;
global using Yard_Scan_API.Data.Entities;
global using Yard_Scan_API.Data.Views;
global using Yard_Scan_API.Dtos.Zone;
global using Yard_Scan_API.Models.SubZoneDtos;
global using Yard_Scan_API.Models.UnitDtos;
global using Yard_Scan_API.Responses;
global using Yard_Scan_API.Services.SubZoneService;
global using Yard_Scan_API.Services.UnitService;
global using Yard_Scan_API.Services.ZoneService;
global using Yard_Scan_API.Services.UserService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var ionicPolicy = "ionic";
builder.Services.AddCors(options =>
{
    options.AddPolicy(ionicPolicy, policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IZoneService, ZoneService>();
builder.Services.AddScoped<ISubZoneService, SubZoneService>();
builder.Services.AddScoped<IUnitService, UnitService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(ionicPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
