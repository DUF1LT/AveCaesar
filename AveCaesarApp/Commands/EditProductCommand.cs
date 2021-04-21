﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AveCaesarApp.Commands
{
    class EditProductCommand : Command
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public EditProductCommand(Action<object> execute, Func<object, bool> canExecute = null)
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