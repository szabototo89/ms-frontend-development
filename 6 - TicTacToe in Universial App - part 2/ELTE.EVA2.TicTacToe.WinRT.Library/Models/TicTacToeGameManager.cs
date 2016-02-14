using System;
using System.Collections.Generic;
using System.Linq;

namespace ELTE.EVA2.TicTacToe.WinRT.Library.Models
{
    public class TicTacToeGameManager : IGameManager
    {
        public GameState GameState { get; private set; }

        public Int32 GameTableSize
        {
            get { return GameState.GameTableSize; }
        }

        public GameStatus GameStatus
        {
            set { GameState.GameStatus = value; }
            get { return GameState.GameStatus; }
        }

        public IEnumerable<GameCell> GameCells
        {
            get { return GameState.GameCells; }
        }

        public Player CurrentPlayer
        {
            get { return Players.ElementAt(GameState.CurrentPlayerIndex); }
        }

        public Player Winner
        {
            set { GameState.Winner = value; }
            get { return GameState.Winner; }
        }

        public IEnumerable<Player> Players
        {
            set { GameState.Players = value; }
            get { return GameState.Players; }
        }

        public TicTacToeGameManager()
        {
            GameState = new GameState { GameTableSize = 3 };
        }

        public void NewGame(IEnumerable<Player> players)
        {
            if (players == null)
                throw new ArgumentNullException(nameof(players));

            if (players.Count() != 2)
                throw new ArgumentException("Only two players can play.");

            Players = players;
            Winner = Player.NonPlayer;

            GameStatus = GameStatus.Playing;
            GameState.CurrentPlayerIndex = 0;

            GameState.GameCells = GenerateGameTable(GameTableSize);
        }

        private GameCell[] GenerateGameTable(Int32 gameTableSize)
        {
            if (gameTableSize <= 0)
                throw new ArgumentException($"{nameof(gameTableSize)} must be positive number");

            var gameCells = new List<GameCell>();

            for (var i = 0; i < gameTableSize; i++)
            {
                for (var j = 0; j < gameTableSize; j++)
                {
                    gameCells.Add(new GameCell(new Coordinate(i, j), Player.NonPlayer));
                }
            }

            return gameCells.ToArray();
        }

        private GameCell GetGameCell(Int32 x, Int32 y)
        {
            var coordinate = new Coordinate(x, y);
            return GameCells.FirstOrDefault(gameCell => gameCell.Location.Equals(coordinate));
        }

        public Player GetWinner()
        {
            if (GameStatus == GameStatus.Playing)
                throw new Exception("Game is not over.");

            throw new NotImplementedException();
        }

        public void NextTurn(Int32 x, Int32 y)
        {
            if (GameStatus == GameStatus.Stopped)
                throw new Exception("Game is over.");

            var gameCell = GetGameCell(x, y);
            gameCell.Owner = CurrentPlayer;

            GameState.CurrentPlayerIndex = (GameState.CurrentPlayerIndex + 1) % Players.Count();

            if (IsGameOver(GameState.GameCells, GameTableSize))
            {
                GameStatus = GameStatus.Stopped;
            }
        }

        public void LoadGameState(GameState gameState)
        {
            GameState = gameState;
        }

        private Boolean IsGameOver(IEnumerable<GameCell> cells, Int32 gameTableSize)
        {
            var hasNoFreeCell = cells.All(cell => !Equals(cell.Owner, Player.NonPlayer));

            var scores = new Int32[2 * gameTableSize + 2];
            var players = Players.ToArray();

            foreach (var cell in cells)
            {
                var point = CalculatePoint(cell, players);
                var row = cell.Location.X;
                var column = cell.Location.Y;

                scores[row] += point;
                scores[gameTableSize + column] += point;
                if (row == column) scores[2 * gameTableSize] += point;
                if (gameTableSize - 1 - column == row) scores[2 * gameTableSize + 1] += point;
            }

            foreach (var score in scores)
            {
                if (score == gameTableSize)
                {
                    Winner = players[0];
                }
                else if (score == -gameTableSize)
                {
                    Winner = players[1];
                }
            }

            var hasWinner = !Equals(Winner, Player.NonPlayer);

            return hasNoFreeCell || hasWinner;
        }

        private static Int32 CalculatePoint(GameCell cell, Player[] players)
        {
            if (Object.Equals(cell.Owner, players[0])) return 1;
            if (Object.Equals(cell.Owner, players[1])) return -1;

            return 0;
        }
    }
}