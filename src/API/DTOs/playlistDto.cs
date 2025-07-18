public class PlaylistDto
{ 
    public Guid ID { get; set; }
    public required string Name { get; set; }
    public required List<TrackDto> Items { get; set; }
}