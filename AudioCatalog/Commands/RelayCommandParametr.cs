using System.Windows.Input;

namespace AudioCatalog.Commands
{
    public class RelayCommandParametr<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommandParametr(Action<T> execute) : this(execute, null)
        {
        }
        public RelayCommandParametr(Action<T> execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object? parameter)
        {
            _execute((T)parameter);
        }
    }
}
