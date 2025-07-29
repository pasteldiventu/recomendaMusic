namespace Domain.Entities
{
    public interface IMediaItem
    {
        Guid Id { get; }
        string Title { get; }
        string Artist { get; }
        string Genre { get; }
    }
}
