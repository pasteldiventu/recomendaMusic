using API.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Enums;
using Domain.Patterns.Factory;
using Domain.Services; // Adicionado para usar o PlaylistService
using Infrastructure.Services; // Adicionado para usar o SimpleFileLogger

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendationController : ControllerBase
    {
        private readonly RecommendationStrategyFactory _strategyFactory;
        private readonly PlaylistService _playlistService;
        private readonly SimpleFileLogger _logger;

        public RecommendationController(
            RecommendationStrategyFactory strategyFactory, 
            PlaylistService playlistService,
            SimpleFileLogger logger)
        {
            _strategyFactory = strategyFactory;
            _playlistService = playlistService;
            _logger = logger;
        }

        [HttpPost("recommend")]
        public async Task<ActionResult<List<TrackDto>>> Recommend([FromBody] PlaylistDto playlistDto, [FromQuery] StrategyType strategyType)
        {
            _logger.Log($"Requisição de recomendação recebida para a playlist '{playlistDto.Name}' com a estratégia '{strategyType}'.");
            
            var playlist = new Playlist(playlistDto.Id, playlistDto.Name);
            foreach (var item in playlistDto.Items)
            {
                var track = new Track(item.Id, item.Title, item.Artist, item.Genre);
                playlist.AddItem(track);
            }
            
            await _playlistService.CreatePlaylistAsync(playlist);

            var strategy = _strategyFactory.CreateStrategy(strategyType);
            var recommendations = strategy.Recommend(playlist);

            var recommendationDtos = recommendations.OfType<Track>()
                .Select(x => new TrackDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Artist = x.Artist,
                    Genre = x.Genre
                }).ToList();

            _logger.Log($"Retornando {recommendationDtos.Count} recomendações.");
            return Ok(recommendationDtos);
        }
    }
}