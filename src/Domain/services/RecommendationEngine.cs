using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Services
{
    public class RecommendationEngine : IRecommendationEngine
    {
        private readonly IRecommendationStrategy _strategy;

        public RecommendationEngine(IRecommendationStrategy strategy)
        {
            _strategy = strategy;
        }

        public List<IMediaItem> Recommend(Playlist playlist)
        {
            return _strategy.Recommend(playlist);
        }
    }
}
