using azuirte_api.Endpoints;
using azuirte_api.Models;
using azuirte_api.Models.TableEntities;
using azuirte_api.Service;
using azuirte_api.Service.Interface;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITableService<Graffiti_TE, Graffiti>, AzureTableService_Graffiti>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Demo API");
        
    });
}

app.UseHttpsRedirection();

app.Configure_GraffitiEndpoints();
app.Run();

