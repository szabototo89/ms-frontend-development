using System;
using ELTE.EVA2.TicTacToe.WPF.Common;

namespace ELTE.EVA2.TicTacToe.WPF.ViewModels
{
    public class NewGameViewModel : ViewModelBase
    {
        public ApplicationViewModel ApplicationViewModel { get; private set; }

        public NewGameViewModel(ApplicationViewModel applicationViewModel)
        {
            if (applicationViewModel == null) throw new ArgumentNullException("applicationViewModel");

            ApplicationViewModel = applicationViewModel;
        }

        public String FirstPlayerName { get; set; }

        public String SecondPlayerName { get; set; }
    }
}