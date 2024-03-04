
using Serilog.Events;
using Serilog.Formatting.Compact;
using Serilog;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using DataAccess.Mapper;
using PersonMinimalApi.Extensions;
using PersonMinimalApi.ApiCode.Interfaces;
using PersonMinimalApi.ApiCode.Implementations;


// Logger Configuration using Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.WithProcessId()
    .Enrich.WithThreadId()
    .Enrich.WithEnvironmentName()
    .Enrich.WithMachineName()
    .WriteTo.Console(new CompactJsonFormatter())
    .WriteTo.File(new CompactJsonFormatter(), "Log/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
Log.Logger.Information("Starting up");

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Adding the DbContext to the services
builder.Services.AddDbContext<PersonDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// Adding AutoMapper to the services
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddTransient<IPersonRepository, PersonRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/PersonHello",()=>
{
    return "Hello World";
});
PersonApi personApi = new PersonApi();
app.MapApi(personApi);

var personTestApiGroup = app.MapGroup("/api")
    .PersonTestEndpoints()
    .WithTags("Person Test Api");

app.Run();

