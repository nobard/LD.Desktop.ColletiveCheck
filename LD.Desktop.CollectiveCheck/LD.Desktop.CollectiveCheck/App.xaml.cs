using Autofac;
using LD.Desktop.CollectiveCheck.MVVM.Views;
using LD.Desktop.CollectiveCheck.Services.DI;
using System.Windows;

namespace LD.Desktop.CollectiveCheck
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IContainer container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            container = AutofacConfig.GetConfiguredContainer();

            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }
}
