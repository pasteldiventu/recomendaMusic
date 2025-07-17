using Domain.Entities;

namespace Domain.Services
{
    public interface IRecommendationEngine
    {
        List<IMediaItem> Recommend(Playlist playlist);
    }
}
