using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AveCaesarApp.Commands
{
    class BackToMainWindowCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            Window mainWindow = parameter as Window;
            mainWindow?.Show();
        }
    }
}
