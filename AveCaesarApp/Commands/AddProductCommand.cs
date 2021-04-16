using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AveCaesarApp.Commands
{
    public class AddProductCommand : Command
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public AddProductCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public override bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
