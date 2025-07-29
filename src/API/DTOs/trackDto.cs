namespace API.DTOs
{
    public class TrackDto
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Artist { get; set; }
        public required string Genre { get; set; }
    }
}