using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace ELTE.EVA2.TicTacToe.WinRT.Library.Models
{
    [DataContract]
    public class GameState : IEquatable<GameState>
    {
        [DataMember]
        public Int32 GameTableSize { get; set; }

        [DataMember]
        public GameStatus GameStatus { get; set; }

        [DataMember]
        public Int32 CurrentPlayerIndex { get; set; }

        [DataMember]
        public IEnumerable<GameCell> GameCells { get; set; }

        [DataMember]
        public Player Winner { get; set; }

        [DataMember]
        public IEnumerable<Player> Players { get; set; }

        #region Equality members

        public bool Equals(GameState other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return GameTableSize == other.GameTableSize && GameStatus == other.GameStatus && CurrentPlayerIndex == other.CurrentPlayerIndex && Equals(GameCells, other.GameCells) && Equals(Winner, other.Winner) && Equals(Players, other.Players);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((GameState) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = GameTableSize;
                hashCode = (hashCode*397) ^ (int) GameStatus;
                hashCode = (hashCode*397) ^ CurrentPlayerIndex;
                hashCode = (hashCode*397) ^ (GameCells != null ? GameCells.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Winner != null ? Winner.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Players != null ? Players.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion
    }
}