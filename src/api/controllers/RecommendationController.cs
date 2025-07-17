using Domain.Entities;
using Domain.Interfaces;
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
        public ActionResult<List<IMediaItem>> Recommend([FromBody] Playlist playlist)
        {
            var recommendations = _recommendationEngine.Recommend(playlist);
            return Ok(recommendations);
        }
    }
}
