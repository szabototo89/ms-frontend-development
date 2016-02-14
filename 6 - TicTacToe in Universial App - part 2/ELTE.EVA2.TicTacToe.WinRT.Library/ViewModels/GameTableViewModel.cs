using System;
using System.Collections.Generic;
using System.Linq;
using ELTE.EVA2.TicTacToe.WinRT.Library.Common;
using ELTE.EVA2.TicTacToe.WinRT.Library.Models;

namespace ELTE.EVA2.TicTacToe.WinRT.Library.ViewModels
{
    public class GameTableViewModel : ViewModelBase
    {
        private Boolean isPlaying;
        private String currentPlayer;
        private String gameStatusMessage;

        public IMessageDialogService MessageDialogService { get; private set; }
        public IGameManager GameManager { get; private set; }

        public IEnumerable<GameCellViewModel> GameCells { get; private set; }

        public Int32 TableSize
        {
            get { return GameManager.GameTableSize; }
        }

        public String CurrentPlayer
        {
            get { return currentPlayer; }
            set
            {
                currentPlayer = value;
                OnPropertyChanged("CurrentPlayer");
            }
        }

        public Boolean IsPlaying
        {
            get { return isPlaying; }
            set
            {
                isPlaying = value;
                OnPropertyChanged("IsPlaying");
            }
        }

        public String GameStatusMessage
        {
            get { return gameStatusMessage; }
            set
            {
                gameStatusMessage = value;
                OnPropertyChanged("GameStatusMessage");
            }
        }

        public GameTableViewModel(IMessageDialogService messageDialogService, IGameManager gameManager)
        {
            if (gameManager == null) throw new ArgumentNullException("gameManager");
            if (messageDialogService == null) throw new ArgumentNullException("messageDialogService");

            GameManager = gameManager;
            MessageDialogService = messageDialogService;
            InitializeGameCells(GameManager, GameManager.GameCells);
        }

        private void InitializeGameCells(IGameManager gameManager, IEnumerable<GameCell> gameCells)
        {
            UpdateGameStatus(gameManager);
            GameCells = gameCells.Select(cell => new GameCellViewModel(this, gameManager, cell));
        }

        public void NextTurn(GameCell cell)
        {
            if (cell == null) throw new ArgumentNullException("cell");

            if (Equals(cell.Owner, Player.NonPlayer))
            {
                GameManager.NextTurn(cell.Location.X, cell.Location.Y);
                UpdateGameStatus(GameManager);
            }

            CheckIsGameOver();
        }

        private void CheckIsGameOver()
        {
            if (GameManager.GameStatus == GameStatus.Stopped)
            {
                if (!Equals(GameManager.Winner, Player.NonPlayer))
                {
                    GameStatusMessage = "The winner is " + GameManager.Winner.Name + ".";
                }
                else
                {
                    GameStatusMessage = "The game is tie.";
                }

                MessageDialogService.ShowMessage(GameStatusMessage);
            }
        }

        private void UpdateGameStatus(IGameManager gameManager)
        {
            IsPlaying = gameManager.GameStatus == GameStatus.Playing;
            CurrentPlayer = gameManager.CurrentPlayer.Name;
        }
    }
}