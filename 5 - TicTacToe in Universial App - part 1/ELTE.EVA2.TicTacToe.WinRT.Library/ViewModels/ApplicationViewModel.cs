using System;
using ELTE.EVA2.TicTacToe.WinRT.Library.Common;
using ELTE.EVA2.TicTacToe.WinRT.Library.Models;

namespace ELTE.EVA2.TicTacToe.WinRT.Library.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        public IGameManager GameManager { get; private set; }

        public GameTableViewModel GameTableViewModel { get; private set; }

        public ApplicationViewModel(IMessageDialogService messageDialogService, IGameManager gameManager)
        {
            if (messageDialogService == null) throw new ArgumentNullException("messageDialogService");
            if (gameManager == null) throw new ArgumentNullException("gameManager");

            GameManager = gameManager;
            GameTableViewModel = new GameTableViewModel(messageDialogService, gameManager);
        }
    }
}
