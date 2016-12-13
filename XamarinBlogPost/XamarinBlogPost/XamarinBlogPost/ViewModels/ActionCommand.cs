using System;
using System.Windows.Input;

namespace XamarinBlogPost.ViewModels
{
    public class ActionCommand : ICommand
    {
        private readonly Action<Object> execute;
        private readonly Predicate<Object> canExecute;

        public ActionCommand(Action execute, Func<Boolean> canExecute = null)
            : this((parameter) => execute(), (parameter) => canExecute?.Invoke() ?? true)
        {
        }

        public ActionCommand(Action<Object> execute, Predicate<Object> canExecute = null)
        {
            if (execute == null) throw new ArgumentNullException(nameof(execute));

            this.execute = execute;
            this.canExecute = canExecute ?? (parameter => true);
        }

        public Boolean CanExecute(Object parameter)
        {
            return canExecute(parameter);
        }

        public void Execute(Object parameter)
        {
            execute(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}