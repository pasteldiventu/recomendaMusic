namespace API.DTOs
{
    public class PlaylistDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required List<TrackDto> Items { get; set; }
    }
}