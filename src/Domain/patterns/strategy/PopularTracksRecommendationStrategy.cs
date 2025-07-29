using Domain.Entities;
using Domain.Interfaces;

public class PopularTracksRecommendationStrategy : IRecommendationStrategy
{
    private readonly IPlaylistRepository _playlistRepository;
    public PopularTracksRecommendationStrategy(IPlaylistRepository playlistRepository)
    {
        _playlistRepository = playlistRepository;
    }

    public List<IMediaItem> Recommend(Playlist contextPlaylist)
    { 
        // Passo 2: Usa o repositório para buscar todas as playlists "salvas".
        // O .Result aqui é um atalho, pois sabemos que a operação em memória é síncrona.
        var allPlaylists = _playlistRepository.GetAllAsync().Result;

        var allTracks = allPlaylists
            .SelectMany(p => p.Items) 
            .OfType<Track>();

        var popularTracks = allTracks
            .GroupBy(track => track.Id)
            .OrderByDescending(group => group.Count()) // Ordena pelos mais populares (maior contagem)
            .Select(group => group.First()) // Pega um representante de cada grupo
            
            .Where(track => !contextPlaylist.Items.OfType<Track>().Any(t => t.Id == track.Id)) 
            .Take(5) // Pega as 5 mais populares
            .ToList();

        return popularTracks.Cast<IMediaItem>().ToList();
    }
}