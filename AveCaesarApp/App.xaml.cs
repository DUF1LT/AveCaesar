using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using AveCaesarApp.Stores;
using AveCaesarApp.ViewModels;
using AveCaesarApp.Views;

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

            ApplicationView applicationWindow = new ApplicationView()
            {
                DataContext = new ApplicationViewModel(navigationStore)
            };

            applicationWindow.Show();

            



            base.OnStartup(e);
        }
    }
}
