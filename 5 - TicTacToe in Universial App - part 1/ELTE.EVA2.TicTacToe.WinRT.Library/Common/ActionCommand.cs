using System;
using System.Windows.Input;

namespace ELTE.EVA2.TicTacToe.WinRT.Library.Common
{
    public class ActionCommand : ICommand
    {
        private readonly Func<Boolean> canExecute;
        private readonly Action execute;

        public ActionCommand(Action execute, Func<Boolean> canExecute = null)
        {
            if (execute == null) throw new ArgumentNullException("execute");

            this.execute = execute;
            this.canExecute = canExecute;
        }

        public Boolean CanExecute(Object parameter)
        {
            if (canExecute != null)
            {
                canExecute();
            }

            return true;
        }

        public void Execute(Object parameter)
        {
            if (execute != null)
            {
                execute();
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}