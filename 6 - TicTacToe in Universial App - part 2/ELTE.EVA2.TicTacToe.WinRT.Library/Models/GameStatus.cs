using System.Runtime.Serialization;

namespace ELTE.EVA2.TicTacToe.WinRT.Library.Models
{
    [DataContract]
    public enum GameStatus
    {
        Playing = 1,
        Stopped = 2
    }
}