using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class PlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IEnumerable<IPlaylistObserver> _observers;

        // Mágica da DI: Ele recebe o repositório E UMA COLEÇÃO de todos os
        // observers que estiverem registrados no sistema.
        public PlaylistService(IPlaylistRepository playlistRepository, IEnumerable<IPlaylistObserver> observers)
        {
            _playlistRepository = playlistRepository;
            _observers = observers;
        }

        public async Task CreatePlaylistAsync(Playlist playlist)
        {
            // 1. Salva a playlist no repositório
            await _playlistRepository.AddAsync(playlist);

            // 2. Notifica todos os observadores sobre a criação
            foreach (var observer in _observers)
            {
                await observer.OnPlaylistCreated(playlist);
            }
        }
    }
}