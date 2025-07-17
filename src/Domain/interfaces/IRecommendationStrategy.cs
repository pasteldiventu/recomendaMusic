using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRecommendationStrategy
    {
        List<IMediaItem> Recommend(Playlist playlist);
    }
}
