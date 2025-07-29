using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class InMemoryPlaylistRepository : IPlaylistRepository
    {
        private static readonly List<Playlist> _playlists = new();
        public Task AddAsync(Playlist playlist)
        {
            _playlists.Add(playlist);
            return Task.CompletedTask;
        }
        public Task<IEnumerable<Playlist>> GetAllAsync()
        {
            return Task.FromResult(_playlists.AsEnumerable());
        }

        public Task<Playlist?> GetByIdAsync(Guid id)
        {
            var playlist = _playlists.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(playlist);
        }  
    }
}