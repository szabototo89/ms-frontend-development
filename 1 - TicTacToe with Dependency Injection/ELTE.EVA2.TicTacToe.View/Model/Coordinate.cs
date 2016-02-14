using System;

namespace ELTE.EVA2.TicTacToe.View.Model
{
    public struct Coordinate
    {
        public Coordinate(Int32 x, Int32 y)
        {
            X = x;
            Y = y;
        }

        public Int32 X { get; }
        public Int32 Y { get; }
    }
}