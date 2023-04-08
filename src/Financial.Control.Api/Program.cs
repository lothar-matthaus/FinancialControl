using Financial.Control.Infra.Data.Extension.Service;
using Financial.Control.Infra.IoC.MediatR;
using Financial.Control.Infra.IoC.Services;
using Financial.Control.Infra.IoC.Configurations;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

#region Services
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.AddUnitOfWork();
builder.Services.ConfigureApplicationServices(builder.Configuration);
#endregion

#region Configurations
builder.Services.ConfigureApiBehavior();
#endregion


builder.Services.AddApplicationMediatR();

#region Configure Controllers
var assembly = Assembly.Load("Financial.Control.Application");

builder.Services.AddControllers()
        .PartManager.ApplicationParts.Add(new AssemblyPart(assembly));
#endregion

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
