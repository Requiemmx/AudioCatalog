using AudioCatalog.ViewModel;
using System.Windows;

namespace AudioCatalog.Views
{
    /// <summary>
    /// Логика взаимодействия для AddAlbumView.xaml
    /// </summary>
    public partial class AddAlbumView : Window
    {
        public AddAlbumView(AddAlbumViewModel addAlbumViewModel)
        {
            InitializeComponent();
            DataContext = addAlbumViewModel;
        }
    }
}
