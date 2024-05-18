using AudioCatalog.Models;
using Microsoft.EntityFrameworkCore;

namespace AudioCatalog.Context
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One To Many
            modelBuilder.Entity<Album>().HasOne(album => album.Artist).WithMany(artist => artist.Albums).HasForeignKey(album => album.ArtistId);
            modelBuilder.Entity<Track>().HasOne(album => album.Album).WithMany(artist => artist.Tracks).HasForeignKey(album => album.AlbumId);


        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
