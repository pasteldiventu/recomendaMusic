using Domain.Interfaces;
using Domain.Services;
using Domain.Patterns.Strategy;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();

// Injetar Strategy + Engine
services.AddScoped<IRecommendationStrategy, GenreRecommendationStrategy>();
services.AddScoped<IRecommendationEngine, RecommendationEngine>();

var app = builder.Build();
app.MapControllers();
app.Run();
