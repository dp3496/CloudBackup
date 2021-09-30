using System;
using System.Windows.Input;

namespace CloudBackup.Library
{
    public class CommandViewModel : ICommand
    {
        private Func<object, bool> _canExecute;
        private Action<object> _execute;

        public CommandViewModel(Func<object, bool> canExecute, Action<object> execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            Execute(parameter);
        }
    }
}
