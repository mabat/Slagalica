using System;
using System.Windows.Input;

namespace Slagalica
{
    class DelegateCommand : ICommand
    {
        private Action methodToExecute;
        private Action<object> handlePreviewDrop;

        public DelegateCommand(Action methodToExecute)
        {
            this.methodToExecute = methodToExecute;
        }

        public DelegateCommand(Action<object> handlePreviewDrop)
        {
            this.handlePreviewDrop = handlePreviewDrop;
        }

        private Action<KeyEventArgs> onKeyDown;

        public DelegateCommand(Action<KeyEventArgs> onKeyDown)
        {
            this.onKeyDown = onKeyDown;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            this.methodToExecute.Invoke();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
