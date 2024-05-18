using AudioCatalog.ViewModel;
using System.Windows;

namespace AudioCatalog.Views
{
    /// <summary>
    /// Логика взаимодействия для AddArtistView.xaml
    /// </summary>
    public partial class AddArtistView : Window
    {
        public AddArtistView(AddArtistViewModel addArtistViewModel)
        {
            InitializeComponent();
            DataContext = addArtistViewModel;
        }
    }
}
