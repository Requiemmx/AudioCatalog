using AudioCatalog.Commands;
using AudioCatalog.Models;
using AudioCatalog.Services;
using System.Windows.Input;

namespace AudioCatalog.ViewModel
{
    public class AddArtistViewModel : ViewModelBase
    {
        private readonly ArtistService _artistService;
        private string _name;
        private string _country;
        private int _yearOfBirth;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                onPropertyChanged();
            }
        }

        public string Country
        {
            get { return _country; }
            set
            {
                _country = value;
                onPropertyChanged();
            }
        }

        public int YearOfBirth
        {
            get { return _yearOfBirth; }
            set
            {
                _yearOfBirth = value;
                onPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        public AddArtistViewModel(ArtistService artistService)
        {
            _artistService = artistService;
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            var newArtist = new Artist
            {
                Name = Name,
                Country = Country,
                YearOfBirth = YearOfBirth
            };

            _artistService.AddArtist(newArtist);

            Name = "";
            Country = "";
            YearOfBirth = 0;
        }
    }
}
