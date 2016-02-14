using System.Runtime.Serialization;

namespace ELTE.EVA2.TicTacToe.WinRT.Library.Models
{
    [DataContract]
    public class GameCell
    {
        public GameCell()
        {
            Owner = Player.NonPlayer;
        }

        public GameCell(Coordinate location, Player owner)
        {
            Location = location;
            Owner = owner ?? Player.NonPlayer;
        }

        [DataMember]
        public Player Owner { get; set; }

        [DataMember]
        public Coordinate Location { get; set; }

        //[OnDeserialized]
        //private void AfterDeserialization(StreamingContext context)
        //{
        //    Owner = Player.NonPlayer;
        //}

        public override string ToString()
        {
            return $"Owner: {Owner}, Location: {Location}";
        }
    }
}