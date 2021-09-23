using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CloudBackup.Library
{
    public class CloudBackupPageViewModel
    {
        public CloudBackupPageViewModel()
        {
            AutoBackupCommand = new CommandViewModel(obj => true, Execute);
        }
        public IList<string> BackupOptions { get; set; } = new List<string>
        {
            "Google",
            "DropBox"
        };

        public ICommand AutoBackupCommand { get; set; }

        private void Execute(object parameter)
        {

        }
    }

    public class CommandViewModel : ICommand
    {
        private readonly Predicate<object> canExecute;
        private readonly Action<object> execute;

        public event EventHandler CanExecuteChanged;

        public CommandViewModel(Predicate<object> canExecute, Action<object> execute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
