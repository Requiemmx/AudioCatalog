using AudioCatalog.ViewModel;
using System.Windows;

namespace AudioCatalog.Views
{
    /// <summary>
    /// Логика взаимодействия для AddTrackView.xaml
    /// </summary>
    public partial class AddTrackView : Window
    {
        public AddTrackView(AddTrackViewModel addTrackViewModel)
        {
            InitializeComponent();
            DataContext = addTrackViewModel;
        }
    }
}
