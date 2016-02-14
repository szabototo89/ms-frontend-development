using System;
using System.Collections.Generic;

namespace ELTE.EVA2.TicTacToe.View.Model
{
    public interface IGameManager
    {
        Int32 GameTableSize { get; }
        GameStatus GameStatus { get; }

        Player CurrentPlayer { get; }
        IEnumerable<Player> Players { get; }
        IEnumerable<GameCell> GameCells { get; }
        Player Winner { get; }

        void StartGame(IEnumerable<Player> players);
        void NextTurn(Int32 x, Int32 y);
    }
}