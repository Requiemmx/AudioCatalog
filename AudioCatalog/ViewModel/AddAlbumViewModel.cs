using AudioCatalog.Commands;
using AudioCatalog.Models;
using AudioCatalog.Services;
using System.Windows.Input;

namespace AudioCatalog.ViewModel
{
    public class AddAlbumViewModel : ViewModelBase
    {
        private readonly AlbumService _albumService;

        private string _title;
        private string _genre;
        private int _year;
        private string _imagePath;
        private int _artistId;

        public string Title
        {
            get { return _title; }
            set { _title = value; onPropertyChanged(); }
        }

        public string Genre
        {
            get { return _genre; }
            set { _genre = value; onPropertyChanged(); }
        }

        public int Year
        {
            get { return _year; }
            set { _year = value; onPropertyChanged(); }
        }

        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; onPropertyChanged(); }
        }

        public int ArtistId
        {
            get { return _artistId; }
            set { _artistId = value; onPropertyChanged(); }
        }

        public ICommand SaveCommand { get; }

        public AddAlbumViewModel(AlbumService albumService)
        {
            _albumService = albumService;
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            var newAlbum = new Album
            {
                Title = Title,
                Genre = Genre,
                Year = Year,
                ImagePath = ImagePath,
                ArtistId = ArtistId
            };

            _albumService.AddAlbum(newAlbum);
        }
    }
}
