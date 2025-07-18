using Domain.Entities;
using API.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendationController : ControllerBase
    {
        private readonly IRecommendationEngine _recommendationEngine;

        public RecommendationController(IRecommendationEngine recommendationEngine)
        {
            _recommendationEngine = recommendationEngine;
        }

        [HttpPost("recommend")]
        public ActionResult<List<TrackDto>> Recommend([FromBody] PlaylistDto playlistDto)
        {
            var playlist = new Playlist(playlistDto.Id, playlistDto.Name);

            foreach (var item in playlistDto.Items)
            {
                var track = new Track(item.Id, item.Title, item.Artist, item.Duration);
                playlist.AddItem(track);
            }

            var recommendations = _recommendationEngine.Recommend(playlist);
            var recommendationDtos = recommendations.Select(x => new TrackDto
            {
                Id = x.Id,
                Title = x.Title,
                Artist = x.Artist,
                Duration = x.Duration
            }).ToList();

            return Ok(recommendationDtos);
        }
    }
}
