using Klinika.Infrastructure;
using Klinika.Application;
using Klinika.Mapper;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Scrutor;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


string connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                .Build().GetConnectionString("DefaultConnection") ??
                throw new NullReferenceException("Database connection string could not be loaded!");

builder.Services.AddDbContext<AppDbContext>(
    (sp, optionsBuilder) => optionsBuilder.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(typeof(MappingConfig));

builder
    .Services
    .Scan(
        selector => selector
            .FromAssemblies(
                Klinika.Infrastructure.AssemblyReference.Assembly)
            .AddClasses(false)
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime());

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(Klinika.Application.AssemblyReference.Assembly));

IConfiguration configuration = builder.Configuration.AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        options.JsonSerializerOptions.WriteIndented = true;
    });
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
