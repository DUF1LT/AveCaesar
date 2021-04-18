using System;
using System.Windows;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels;

namespace AveCaesarApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                if (MessageBox.Show((args.ExceptionObject as Exception).Message) == MessageBoxResult.OK)
                    App.Current.Shutdown();
            };
           
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navigationStore = new NavigationStore();

            navigationStore.CurrentViewModel = new AuthorizationViewModel(navigationStore);

            ApplicationWindow applicationWindow = new ApplicationWindow()
            {
                DataContext = new ApplicationViewModel(navigationStore)
            };

            applicationWindow.Show();
            base.OnStartup(e);
        }
    }
}
