using AudioCatalog.Context;
using AudioCatalog.Repository;
using AudioCatalog.Services;
using AudioCatalog.ViewModel;
using AudioCatalog.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AudioCatalog.Infrastructure
{
    public static class AppServiceProvider
    {
        public static ServiceProvider ServiceProvider { get; set; }

        public static void Initialize()
        {
            var services = new ServiceCollection();
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();

            //Context 
            string connectionString = configuration.GetConnectionString("MusicDatabase");
            services.AddDbContext<MusicDbContext>(option => option.UseSqlServer(connectionString));
            //Repository
            services.AddTransient<AlbumRepository>();
            services.AddTransient<ArtistRepository>();
            services.AddTransient<TrackRepository>();
            services.AddTransient<UserRepository>();
            //Services
            services.AddTransient<AlbumService>();
            services.AddTransient<ArtistService>();
            services.AddTransient<AuthentificationService>();
            services.AddTransient<PasswordHasher>();
            services.AddTransient<TrackService>();
            //ViewModels
            services.AddTransient<AddAlbumViewModel>();
            services.AddTransient<AddArtistViewModel>();
            services.AddTransient<AddTrackViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<MusicCatalogViewModel>();
            services.AddTransient<RegisterViewModel>();


            //Window
            services.AddTransient<AddAlbumView>();
            services.AddTransient<AddArtistView>();
            services.AddTransient<AddTrackView>();
            services.AddTransient<LoginWindow>();
            services.AddTransient<RegisterWindow>();
            services.AddTransient<MusicCatalogWindow>();
            services.AddTransient<OpenAlbumWindow>();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
