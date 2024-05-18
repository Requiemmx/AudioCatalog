namespace AudioCatalog.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int YearOfBirth { get; set; }
        public List<Album> Albums { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
