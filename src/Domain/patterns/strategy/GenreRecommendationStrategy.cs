using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Patterns.Strategy
{
    public class GenreRecommendationStrategy : IRecommendationStrategy
    {
        private readonly IPlaylistRepository _playlistRepository;

        public GenreRecommendationStrategy(IPlaylistRepository playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }

        public List<IMediaItem> Recommend(Playlist contextPlaylist)
        {
            var mostCommonGenre = contextPlaylist.Items
                .OfType<Track>()
                .GroupBy(track => track.Genre)
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key)
                .FirstOrDefault();

            if (string.IsNullOrEmpty(mostCommonGenre))
            {
                return new List<IMediaItem>(); 
            }

            var allTracksInDb = _playlistRepository.GetAllAsync().Result
                .SelectMany(p => p.Items)
                .OfType<Track>();

            var recommendations = allTracksInDb
                .Where(track => track.Genre == mostCommonGenre)
                .Where(track => !contextPlaylist.Items.OfType<Track>().Any(t => t.Id == track.Id))
                .DistinctBy(track => track.Id)
                .Take(5)
                .ToList();

            return recommendations.Cast<IMediaItem>().ToList();
        }
    }
}