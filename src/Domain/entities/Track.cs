namespace Domain.Entities
{
    public class Track : IMediaItem
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Artist { get; private set; }
        public TimeSpan Duration { get; private set; }

        public Track(Guid id, string title, string artist, TimeSpan duration)
        {
            Id = id;
            Title = title;
            Artist = artist;
            Duration = duration;
        }
    }
}
