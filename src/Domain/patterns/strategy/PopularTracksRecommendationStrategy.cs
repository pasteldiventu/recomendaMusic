using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Patterns.Strategy
{
    public class PopularTracksRecommendationStrategy : IRecommendationStrategy
    {
        private readonly IPlaylistRepository _playlistRepository;

        public PopularTracksRecommendationStrategy(IPlaylistRepository playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }

        public List<IMediaItem> Recommend(Playlist contextPlaylist)
        {
            var allTracks = _playlistRepository.GetAllAsync().Result
                .SelectMany(p => p.Items)
                .OfType<Track>();

            var popularTracks = allTracks
                .GroupBy(track => track.Id)
                .OrderByDescending(group => group.Count())
                .Select(group => group.First())
                .Where(track => !contextPlaylist.Items.OfType<Track>().Any(t => t.Id == track.Id))
                .Take(5)
                .ToList();

            return popularTracks.Cast<IMediaItem>().ToList();
        }
    }
}