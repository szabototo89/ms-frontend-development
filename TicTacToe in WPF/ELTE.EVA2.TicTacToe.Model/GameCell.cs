﻿namespace ELTE.EVA2.TicTacToe.Model
{
    public class GameCell
    {
        public GameCell(Coordinate location, Player owner)
        {
            Location = location;
            Owner = owner ?? Player.NonPlayer;
        }

        public Player Owner { get; set; }

        public Coordinate Location { get; set; }
    }
}