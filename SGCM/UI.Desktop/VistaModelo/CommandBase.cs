using System;
using System.Windows.Input;

namespace Sgcm.UI.Desktop.VistaModelo
{
    public class CommandBase : ICommand
    {
        //Fields
        private readonly Action<object>? _executeAction;

        private readonly Predicate<object>? _canExecuteAction;

        //Constructors
        public CommandBase(Action<object> executeAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = null;
        }

        public CommandBase(Action<object> executeAction, Predicate<object> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        //Events
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        //Methods

        public bool CanExecute(object? parameter)
        {
            return _canExecuteAction == null ? true : _canExecuteAction(parameter);
        }

        public void Execute(object? parameter)
        {
            _executeAction(parameter);
        }
    }
}