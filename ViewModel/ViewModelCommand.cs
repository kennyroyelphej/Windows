using System;
using System.Windows.Input;

namespace WPF_MVVM_Example.ViewModel
{
    internal class ViewModelCommand : ICommand
    {
        private readonly Action _executeAction;
        private readonly Func<bool> _canExecuteAction;

        public ViewModelCommand(Action executeAction):this(executeAction, ()=> true)
        {
            _executeAction = executeAction;
        }
        public ViewModelCommand(Action executeAction, Func<bool> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        event EventHandler? ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecuteAction();
        }

        public void Execute(object? parameter)
        {
            _executeAction();
        }
    }
}
