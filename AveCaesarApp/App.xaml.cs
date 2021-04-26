using System;
using System.Windows;
using AveCaesarApp.Services;
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
            AuthenticationStore authenticationStore = new AuthenticationStore(new AuthenticationService());

            navigationStore.CurrentViewModel = new AuthorizationViewModel(navigationStore, authenticationStore);

            ApplicationWindow applicationWindow = new ApplicationWindow()
            {
                DataContext = new ApplicationViewModel(navigationStore)
            };

            applicationWindow.Show();
            base.OnStartup(e);
        }
    }
}
