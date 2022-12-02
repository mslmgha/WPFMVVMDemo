using System;
using System.Windows.Input;

namespace MVVMDemo.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public  virtual bool CanExecute(object? parameter)
        {
            return true;
        }
        public abstract void Execute(object? parameter);

        protected virtual void OnCanExecuteChanged(object? parameter)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
        
    }
}
