using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Patterns.Strategy
{
    public class RecentTracksRecommendationStrategy : IRecommendationStrategy
    {
        private readonly IPlaylistRepository _playlistRepository;

        public RecentTracksRecommendationStrategy(IPlaylistRepository playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }

        public List<IMediaItem> Recommend(Playlist contextPlaylist)
        {
            var recentTracksQuery = _playlistRepository.GetAllAsync().Result
                .SelectMany(p => p.Items)
                .OfType<Track>()
                .Reverse()
                .DistinctBy(track => track.Id)
                .Where(track => !contextPlaylist.Items.OfType<Track>().Any(t => t.Id == track.Id))
                .Take(5);

            return recentTracksQuery.Cast<IMediaItem>().ToList();
        }
    }
}