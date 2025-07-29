// 1. Adicionamos os 'usings' do seu arquivo startup.cs aqui no topo.
using Domain.Interfaces;
using Domain.Services;
using Domain.Patterns.Strategy;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IPlaylistRepository, InMemoryPlaylistRepository>(); 
builder.Services.AddScoped<IRecommendationEngine, RecommendationEngine>();


// ESCOLHA APENAS UMA ESTRATÉGIA e comente ou apague as outras:

// Opção 1: Usar a estratégia por gênero
// builder.Services.AddScoped<IRecommendationStrategy, GenreRecommendationStrategy>();

// Opção 2: Usar a estratégia de populares
// builder.Services.AddScoped<IRecommendationStrategy, PopularTracksRecommendationStrategy>();

// Opção 3: Usar a estratégia de recentes (ESTA ESTÁ ATIVA)
builder.Services.AddScoped<IRecommendationStrategy, RecentTracksRecommendationStrategy>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();