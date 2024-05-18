using AudioCatalog.Commands;
using AudioCatalog.Models;
using AudioCatalog.Services;
using System.Windows.Input;

namespace AudioCatalog.ViewModel
{
    public class AddTrackViewModel : ViewModelBase
    {
        private readonly TrackService _trackService;
        private string _title;
        private int _duration;
        private int _albumId;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                onPropertyChanged();
            }
        }

        public int Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                onPropertyChanged();
            }
        }

        public int AlbumId
        {
            get { return _albumId; }
            set
            {
                _albumId = value;
                onPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        public AddTrackViewModel(TrackService trackService)
        {
            _trackService = trackService;
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            var newTrack = new Track
            {
                Title = Title,
                Duration = Duration,
                AlbumId = AlbumId
            };

            _trackService.AddTrack(newTrack);

            Title = "";
            Duration = 0;
            AlbumId = 0;
        }
    }
}
