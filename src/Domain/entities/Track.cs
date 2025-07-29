namespace Domain.Entities
{
    public class Track : IMediaItem
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Artist { get; private set; }
        public string Genre { get; private set; }

        public Track(Guid id, string title, string artist, string genre)
        {
            Id = id;
            Title = title;
            Artist = artist;
            Genre = genre;
        }
    }
}
