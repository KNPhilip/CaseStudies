#region Global usings
global using PokeTranslation.Services.PokeTranslateService;
global using System.Net;
global using PokeTranslation.Models;
global using Microsoft.AspNetCore.Mvc;
#endregion

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

// Adds the PokeTranslateService to the IoC/DI container.
builder.Services.AddScoped<IPokeTranslateService, PokeTranslateService>();

builder.Services.AddControllers();

WebApplication app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
