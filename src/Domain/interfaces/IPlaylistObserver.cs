using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    // O Observador
    public interface IPlaylistObserver
    {
        Task OnPlaylistCreated(Playlist playlist);
    }
}