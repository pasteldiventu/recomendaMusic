namespace Domain.Entities
{
    public class Playlist
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public List<IMediaItem> Items { get; private set; }

        public Playlist(Guid id, string name)
        {
            Id = id;
            Name = name;
            Items = new List<IMediaItem>();
        }

        public void AddItem(IMediaItem item) => Items.Add(item);
    }
}
