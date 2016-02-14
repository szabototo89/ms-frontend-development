using System;
using System.Runtime.Serialization;

namespace ELTE.EVA2.TicTacToe.WinRT.Library.Models
{
    [DataContract]
    public class Player : IEquatable<Player>
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

        [DataMember]
        public String Name { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}";
        }

        public bool Equals(Player other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Player) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}