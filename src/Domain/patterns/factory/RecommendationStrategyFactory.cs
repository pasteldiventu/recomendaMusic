using Domain.Enums;
using Domain.Interfaces;
using Domain.Patterns.Strategy;

namespace Domain.Patterns.Factory
{
    public class RecommendationStrategyFactory
    {
        private readonly IPlaylistRepository _playlistRepository;
        public RecommendationStrategyFactory(IPlaylistRepository playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }

        public IRecommendationStrategy CreateStrategy(StrategyType type)
        { 
            return type switch
            {
                StrategyType.Genre => new GenreRecommendationStrategy(_playlistRepository),
                StrategyType.Popular => new PopularTracksRecommendationStrategy(_playlistRepository),
                StrategyType.Recent => new RecentTracksRecommendationStrategy(_playlistRepository),
                _ => throw new ArgumentOutOfRangeException(nameof(type), $"Estratégia não encontrada: {type}"),
            };
        }
    }   
}