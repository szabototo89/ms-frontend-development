using System;
using System.Windows.Input;

namespace ELTE.Lecture.SuperHeroManager.ViewModels
{
    public class ActionCommand : ICommand
    {
        private readonly Action execute;
        private readonly Func<Boolean> canExecute;
        private EventHandler internalCanExecuteChanged;

        public ActionCommand(Action execute, Func<Boolean> canExecute = null)
        {
            if (execute == null) throw new ArgumentNullException(nameof(execute));

            this.execute = execute;
            this.canExecute = canExecute;
        }

        public Boolean CanExecute(Object parameter)
        {
            if (canExecute != null)
            {
                return canExecute();
            }
            return true;
        }

        public void Execute(Object parameter)
        {
            execute();
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            if (canExecute != null)
                OnCanExecuteChanged();
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}