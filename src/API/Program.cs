// 1. Adicionamos os 'usings' do seu arquivo startup.cs aqui no topo.
using Domain.Interfaces;
using Domain.Services;
using Domain.Patterns.Strategy;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRecommendationStrategy, GenreRecommendationStrategy>();
builder.Services.AddScoped<IRecommendationEngine, RecommendationEngine>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();