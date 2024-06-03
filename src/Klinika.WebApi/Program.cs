using Klinika.Infrastructure;
using Klinika.Application;
using Klinika.Mapper;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Scrutor;
using Klinika.Application.Behaviours;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Klinika.WebApi.OptionsSetup;
using Microsoft.OpenApi.Models;


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

builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

builder.Services.AddValidatorsFromAssembly(
    Klinika.Application.AssemblyReference.Assembly,
    includeInternalTypes: true);

IConfiguration configuration = builder.Configuration.AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();

builder.Services.AddControllers()
    .AddApplicationPart(Klinika.Presentation.AssemblyReference.Assembly)
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        options.JsonSerializerOptions.WriteIndented = true;
    });

builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Please enter JWT with Bearer into field"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
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

app.UseAuthorization();

app.MapControllers();

app.Run();
