// 1. Adicionamos os 'usings' do seu arquivo startup.cs aqui no topo.
using Domain.Interfaces;
using Domain.Services;
using Domain.Patterns.Strategy;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Infrastructure.Observers;
using Domain.Patterns.Factory;
using Domain.Enums; 


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 
builder.Services.AddSingleton<SimpleFileLogger>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<PlaylistService>();
builder.Services.AddScoped<IPlaylistObserver, PlaylistLoggerObserver>();
builder.Services.AddSwaggerGen(options => {
    options.AddServer(new() { Url = "http://localhost:5038" });
    options.UseInlineDefinitionsForEnums();
});

builder.Services.AddSingleton<IPlaylistRepository, InMemoryPlaylistRepository>(); 

//factory, pra escolher a estratégia
builder.Services.AddScoped<RecommendationStrategyFactory>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();