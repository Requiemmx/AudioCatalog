using AudioCatalog.ViewModel;
using System.Windows;

namespace AudioCatalog.Views
{
    /// <summary>
    /// Логика взаимодействия для MusicCatalogWindow.xaml
    /// </summary>
    public partial class MusicCatalogWindow : Window
    {
        public MusicCatalogWindow(MusicCatalogViewModel musicCatalogViewModel)
        {
            InitializeComponent();
            DataContext = musicCatalogViewModel;
        }

        private void OpenAlbum_Click(object sender, RoutedEventArgs e)
        {
            // ((VideoWindow)AppServiceProvider.ServiceProvider.GetService(typeof(VideoWindow))).Show();
        }
    }

}
