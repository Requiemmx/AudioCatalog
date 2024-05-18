using AudioCatalog.Infrastructure;
using AudioCatalog.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace AudioCatalog
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            AppServiceProvider.Initialize();
            var loginWindow = AppServiceProvider.ServiceProvider.GetService<LoginWindow>();
            loginWindow.Show();
        }
    }

}
