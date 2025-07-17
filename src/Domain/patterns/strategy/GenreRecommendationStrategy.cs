using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Patterns.Strategy
{
    public class GenreRecommendationStrategy : IRecommendationStrategy
    {
        public List<IMediaItem> Recommend(Playlist playlist)
        {
            return playlist.Items.Take(2).ToList();
        }
    }
}
