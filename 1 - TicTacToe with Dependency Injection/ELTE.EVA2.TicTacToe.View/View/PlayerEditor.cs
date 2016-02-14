using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELTE.EVA2.TicTacToe.View.Model;

namespace ELTE.EVA2.TicTacToe.View.View
{
    public partial class PlayerEditor : UserControl
    {
        public PlayerEditor()
        {
            InitializeComponent();
            validationLabel.Visible = false;
        }

        public String Value
        {
            get { return playerNameTextBox.Text; }
            set { playerNameTextBox.Text = value; }
        }

        public Player Player { get; private set; }
        public Boolean HasError { get; private set; }

        private void PlayerNameValueChanged(Object sender, EventArgs e)
        {
            var textBox = sender as TextBox;

            var playerName = textBox.Text;
            ValidatePlayer(playerName);

            if (!HasError)
            {
                Player = new Player(playerName);
            }
            else
            {
                Player = null;
            }
        }

        private void ValidatePlayer(String playerName)
        {
            var isPlayerValid = String.IsNullOrWhiteSpace(playerName);

            if (isPlayerValid)
            {
                SetErrorMessage("Player name cannot be blank.");
            }
            else
            {
                ClearErrorMessage();
            }
        }

        private void ClearErrorMessage()
        {
            HasError = false;

            validationLabel.Visible = false;
        }

        private void SetErrorMessage(String errorMessage)
        {
            HasError = true;

            validationLabel.Text = errorMessage;
            validationLabel.Visible = true;
        }
    }
}