using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sample._4
{
    public class RelayCommand<T> : ICommand where T : class
    {
        private readonly Action<T> execute;
        private readonly Func<T, bool> canExecute;

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged;

        [DebuggerStepThrough]
        public bool CanExecute(object? parameter)
        {
            return canExecute == null ? true : canExecute(parameter as T);
        }

        public void Execute(object? parameter)
        {
            execute(parameter as T);
        }
    } }
 