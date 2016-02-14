using System;

namespace ELTE.EVA2.TicTacToe.View.Model
{
    public class Player
    {
        public static Player NonPlayer { get; } = new Player();

        private Player()
        {
        }

        public Player(String name)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        public String Name { get; }
    }
}