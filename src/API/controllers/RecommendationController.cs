using API.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Enums;
using Domain.Patterns.Factory; 

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendationController : ControllerBase
    {
        private readonly RecommendationStrategyFactory _strategyFactory;
        private readonly IPlaylistRepository _playlistRepository;

        public RecommendationController(RecommendationStrategyFactory strategyFactory, IPlaylistRepository playlistRepository)
        {
            _strategyFactory = strategyFactory;
            _playlistRepository = playlistRepository;
        }

        [HttpPost("recommend")]
        public async Task <ActionResult<List<TrackDto>>> Recommend([FromBody] PlaylistDto playlistDto, [FromQuery] StrategyType strategyType)
        {
            var playlist = new Playlist(playlistDto.Id, playlistDto.Name);

            foreach (var item in playlistDto.Items)
            {
                var track = new Track(item.Id, item.Title, item.Artist, item.Genre);
                playlist.AddItem(track);
            }
            
            await _playlistRepository.AddAsync(playlist);

            var strategy = _strategyFactory.CreateStrategy(strategyType);
            var recommendations = strategy.Recommend(playlist);

            var recommendationDtos = recommendations.Select(x => new TrackDto
            {
                Id = x.Id,
                Title = x.Title,
                Artist = x.Artist,
                Genre = x.Genre
            }).ToList();

            return Ok(recommendationDtos);
        }
    }
}
