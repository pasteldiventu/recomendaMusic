using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Services;
using System.Threading.Tasks;

namespace Infrastructure.Observers
{
    public class PlaylistLoggerObserver : IPlaylistObserver
    {
        private readonly SimpleFileLogger _logger;

        public PlaylistLoggerObserver(SimpleFileLogger logger)
        {
            _logger = logger;
        }

        public Task OnPlaylistCreated(Playlist playlist)
        {
            _logger.Log($"OBSERVER: Nova playlist criada -> Nome: '{playlist.Name}', ID: {playlist.Id}");
            return Task.CompletedTask;
        }
    }
}