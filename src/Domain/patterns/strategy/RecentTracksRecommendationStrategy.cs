using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

public class RecentTracksRecommendationStrategy : IRecommendationStrategy
{
    private readonly IPlaylistRepository _playlistRepository;

    public RecentTracksRecommendationStrategy(IPlaylistRepository playlistRepository)
    {
        _playlistRepository = playlistRepository;
    }

    public List<IMediaItem> Recommend(Playlist contextPlaylist)
    {
        var allPlaylists = _playlistRepository.GetAllAsync().Result;

        var recentTracksQuery = allPlaylists
            .SelectMany(p => p.Items) // Pega todos os itens de todas as playlists
            .OfType<Track>()         
            .Reverse()               // Inverte a lista. Os últimos adicionados agora estão no começo.
            .DistinctBy(track => track.Id) // Pega apenas a ocorrência mais "recente" de cada música
            .Where(track => !contextPlaylist.Items.OfType<Track>().Any(t => t.Id == track.Id)) 
            .Take(5); 

        return recentTracksQuery.Cast<IMediaItem>().ToList();
    }
}