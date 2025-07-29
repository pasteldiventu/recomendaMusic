using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPlaylistRepository
    {
        Task<Playlist?> GetByIdAsync(Guid id);
        Task<IEnumerable<Playlist>> GetAllAsync();
        Task AddAsync(Playlist playlist);
    }
}
