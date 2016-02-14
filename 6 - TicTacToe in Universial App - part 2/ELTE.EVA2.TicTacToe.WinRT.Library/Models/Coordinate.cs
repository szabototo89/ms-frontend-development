using System;
using System.Runtime.Serialization;

namespace ELTE.EVA2.TicTacToe.WinRT.Library.Models
{
    [DataContract]
    public struct Coordinate
    {
        public Coordinate(Int32 x, Int32 y)
        {
            X = x;
            Y = y;
        }

        [DataMember]
        public Int32 X { get; set; }

        [DataMember]
        public Int32 Y { get; set; }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }
    }
}