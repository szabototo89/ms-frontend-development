using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using ELTE.EVA2.TicTacToe.View.Model;
using ELTE.EVA2.TicTacToe.View.View;

namespace ELTE.EVA2.TicTacToe.View
{
    public partial class MainForm : Form
    {
        public IGameManager GameManager { get; }

        public IEnumerable<Player> Players { get; private set; }

        public MainForm(IGameManager gameManager)
        {
            if (gameManager == null) throw new ArgumentNullException(nameof(gameManager));

            InitializeComponent();
            GameManager = gameManager;
            DisableGameTable();
        }

        private void EnableGameTable()
        {
            MainLayoutPanel.Enabled = true;
        }

        private void DisableGameTable()
        {
            MainLayoutPanel.Enabled = false;
        }

        private void InitializeGameTable(IGameManager gameManager)
        {
            MainLayoutPanel.Controls.Clear();

            foreach (var gameCell in gameManager.GameCells)
            {
                var gameCellControl = new Button
                {
                    Tag = gameCell,
                    Dock = DockStyle.Fill,
                    Font = new Font(new FontFamily("Comic Sans MS", new InstalledFontCollection()), 40, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat
                };

                SetGameCellStyle(gameCellControl, gameCell.Owner);

                gameCellControl.Click += GameCellClick;
                MainLayoutPanel.Controls.Add(gameCellControl, gameCell.Location.X, gameCell.Location.Y);
            }
        }

        private void SetGameCellStyle(Button gameCellControl, Player owner)
        {
            if (gameCellControl == null) throw new ArgumentNullException(nameof(gameCellControl));

            var players = GameManager.Players.ToArray();

            if (owner == players[0])
            {
                gameCellControl.Text = "O";
                gameCellControl.BackColor = Color.Tomato;
            }
            else if (owner == players[1])
            {
                gameCellControl.Text = "X";
                gameCellControl.BackColor = Color.DarkOrange;
            }
        }

        private void UpdateGameTable(IGameManager gameManager)
        {
            foreach (var gameCellControl in MainLayoutPanel.Controls.OfType<Button>())
            {
                var gameCell = gameCellControl.Tag as GameCell;
                SetGameCellStyle(gameCellControl, gameCell?.Owner ?? Player.NonPlayer);
            }
        }

        private void NewGameMenuItemClick(Object sender, EventArgs e)
        {
            var newGameForm = new NewGameForm();
            if (newGameForm.ShowDialog() == DialogResult.OK)
            {
                var players = newGameForm.GetPlayers();
                Players = players;
                StartGame(players);

                playAgainButton.Enabled = true;
            }
        }

        private void GameCellClick(Object sender, EventArgs e)
        {
            var button = (sender as Button);
            if (button == null)
                throw new ArgumentException("It supports only Button controls.");

            var gameCell = (GameCell) button.Tag;
            GameManager.NextTurn(gameCell.Location.X, gameCell.Location.Y);
            UpdateGameTable(GameManager);

            if (GameManager.GameStatus == GameStatus.Stopped)
            {
                DisableGameTable();
            }

            UpdateGameInformation();
        }

        private void StartGame(IEnumerable<Player> players)
        {
            GameManager.StartGame(players);

            EnableGameTable();
            InitializeGameTable(GameManager);
            UpdateGameInformation();
        }

        private void UpdateGameInformation()
        {
            var player = GameManager.CurrentPlayer;
            if (player == Player.NonPlayer)
            {
                currentPlayerLabel.Text = "No current player";
            }
            else
            {
                currentPlayerLabel.Text = $"Current player: {player.Name}";
            }

            if (GameManager.GameStatus == GameStatus.Stopped)
            {
                if (GameManager.Winner != Player.NonPlayer)
                {
                    currentPlayerLabel.Text = $"The winner is {GameManager.Winner.Name}!";
                }
                else
                {
                    currentPlayerLabel.Text = "Game is tie!";
                }
            }
        }

        private void PlayAgainButtonClick(object sender, EventArgs e)
        {
            StartGame(Players);
        }
    }
}