using Financial.Control.Infra.Data.Extension.Service;
using Financial.Control.Infra.IoC.Configurations;
using Financial.Control.Infra.IoC.MediatR;
using Financial.Control.Infra.IoC.Repositories;
using Financial.Control.Infra.IoC.Services;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

#region Configuration API
builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureApplicationServices();
#endregion

#region Repositories
builder.Services.AddRepositories();
builder.Services.AddUnitOfWork();
#endregion

#region Configurations

builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.ConfigureApiBehavior();
#endregion


builder.Services.AddApplicationMediatR();
builder.Services.AddBaseRequestHandlerBehavior();

#region Configure Controllers
var assembly = Assembly.Load("Financial.Control.Application");

builder.Services.AddControllers()
        .PartManager.ApplicationParts.Add(new AssemblyPart(assembly));
#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.ConfigureSwagger(app.Configuration);
    app.UseDeveloperExceptionPage();

}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
