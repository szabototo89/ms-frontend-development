using System;
using System.Collections.Generic;

namespace ELTE.EVA2.TicTacToe.WinRT.Library.Models
{
    public interface IGameManager
    {
        Int32 GameTableSize { get; }
        GameStatus GameStatus { get; }
        Player CurrentPlayer { get; }
        IEnumerable<Player> Players { get; }
        IEnumerable<GameCell> GameCells { get; }

        Player Winner { get; }

        GameState GameState { get; }

        void NewGame(IEnumerable<Player> players);

        void NextTurn(Int32 x, Int32 y);
        void LoadGameState(GameState gameState);
    }
}