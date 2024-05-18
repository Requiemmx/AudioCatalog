namespace AudioCatalog.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string ImagePath { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public List<Track> Tracks { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
