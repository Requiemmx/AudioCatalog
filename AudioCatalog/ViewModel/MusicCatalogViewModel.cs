using AudioCatalog.Commands;
using AudioCatalog.Models;
using AudioCatalog.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AudioCatalog.ViewModel
{
    public class MusicCatalogViewModel : ViewModelBase
    {
        private readonly TrackService _trackService;
        private readonly ArtistService _artistService;
        private readonly AlbumService _albumService;
        private ObservableCollection<Album> _albums;
        private ObservableCollection<Artist> _artists;
        private ObservableCollection<Track> _tracks;
        private Album _selectedAlbum;
        private Artist _selectedArtist;
        private Track _selectedTrack;

        public ObservableCollection<Album> Albums
        {
            get { return _albums; }
            set
            {
                _albums = value;
                onPropertyChanged();
            }
        }

        public Album SelectedAlbum
        {
            get { return _selectedAlbum; }
            set
            {
                _selectedAlbum = value;
                onPropertyChanged();
            }
        }

        public ObservableCollection<Artist> Artists
        {
            get { return _artists; }
            set
            {
                _artists = value;
                onPropertyChanged();
            }
        }

        public Artist SelectedArtist
        {
            get { return _selectedArtist; }
            set
            {
                _selectedArtist = value;
                onPropertyChanged();
            }
        }

        public ObservableCollection<Track> Tracks
        {
            get { return _tracks; }
            set
            {
                _tracks = value;
                onPropertyChanged();
            }
        }

        public Track SelectedTrack
        {
            get { return _selectedTrack; }
            set
            {
                _selectedTrack = value;
                onPropertyChanged();
            }
        }

        public ICommand AddAlbumCommand { get; }
        public ICommand AddArtistCommand { get; }
        public ICommand AddTrackCommand { get; }
        public ICommand DeleteAlbumCommand { get; }
        public ICommand EditAlbumCommand { get; }

        public MusicCatalogViewModel(AlbumService albumService)
        {
            _selectedAlbum = new Album();
            _selectedArtist = new Artist();
            _selectedTrack = new Track();

            _albumService = albumService;
            Albums = new ObservableCollection<Album>(_albumService.GetAllAlbums());

            AddAlbumCommand = new RelayCommand(AddAlbum);
            AddArtistCommand = new RelayCommand(AddArtist);
            AddTrackCommand = new RelayCommand(AddTrack);
            DeleteAlbumCommand = new RelayCommand(DeleteAlbum, CanDeleteAlbum);

        }

        private void AddAlbum()
        {

            _albumService.AddAlbum(_selectedAlbum);
            Albums.Add(_selectedAlbum);

        }


        private void AddArtist()
        {

            _artistService.AddArtist(_selectedArtist);
            Artists.Add(_selectedArtist);

        }

        private void AddTrack()
        {
            _trackService.AddTrack(_selectedTrack);
            Tracks.Add(_selectedTrack);
        }

        private bool CanDeleteAlbum()
        {
            return SelectedAlbum != null;
        }

        private void DeleteAlbum()
        {
            _albumService.DeleteAlbum(SelectedAlbum.AlbumId);
            Albums.Remove(SelectedAlbum);
        }

        private bool CanEditAlbum()
        {
            return SelectedAlbum != null;
        }


    }
}
