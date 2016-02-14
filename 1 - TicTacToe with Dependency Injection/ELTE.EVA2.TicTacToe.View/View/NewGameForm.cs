using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELTE.EVA2.TicTacToe.View.Model;

namespace ELTE.EVA2.TicTacToe.View.View
{
    public partial class NewGameForm : Form
    {
        public NewGameForm()
        {
            InitializeComponent();
        }

        public IEnumerable<Player> GetPlayers()
        {
            return new[]
            {
                firstPlayer.Player, secondPlayer.Player
            };
        }

        private Boolean HasError()
        {
            return !firstPlayer.HasError && !secondPlayer.HasError;
        }

        private void AcceptButtonClick(Object sender, EventArgs e)
        {
            if (!HasError())
            {
                Close();
            }
        }

        private void CancelButtonClick(Object sender, EventArgs e)
        {
            Close();
        }
    }
}