using System;
using System.Linq;
using ELTE.EVA2.TicTacToe.Model;
using ELTE.EVA2.TicTacToe.WPF.Common;

namespace ELTE.EVA2.TicTacToe.WPF.ViewModels
{
    public class GameCellViewModel : ViewModelBase
    {
        private String symbol;
        private ActionCommand selectGameCellCommand;

        public GameTableViewModel GameTableViewModel { get; private set; }

        public IGameManager GameManager { get; private set; }

        public GameCell GameCell { get; private set; }

        public String Symbol
        {
            get { return symbol; }
            private set
            {
                symbol = value;
                OnPropertyChanged("Symbol");
            }
        }

        public ActionCommand SelectGameCellCommand
        {
            get { return selectGameCellCommand; }
        }

        public GameCellViewModel(GameTableViewModel gameTableViewModel, IGameManager gameManager, GameCell gameCell)
        {
            if (gameManager == null) throw new ArgumentNullException("gameManager");
            if (gameCell == null) throw new ArgumentNullException("gameCell");
            if (gameTableViewModel == null) throw new ArgumentNullException("gameTableViewModel");

            GameTableViewModel = gameTableViewModel;
            GameManager = gameManager;
            GameCell = gameCell;
            Symbol = GetSymbol(GameManager, GameCell);

            InitializeCommands();
        }

        private void InitializeCommands()
        {
            selectGameCellCommand = new ActionCommand(() =>
            {
                GameTableViewModel.NextTurn(GameCell);
                Symbol = GetSymbol(GameManager, GameCell);
            });
        }

        private String GetSymbol(IGameManager gameManager, GameCell gameCell)
        {
            if (gameCell.Owner == Player.NonPlayer)
            {
                return "";
            }

            if (gameCell.Owner == gameManager.Players.First())
            {
                return "X";
            }

            return "O";
        }
    }
} 