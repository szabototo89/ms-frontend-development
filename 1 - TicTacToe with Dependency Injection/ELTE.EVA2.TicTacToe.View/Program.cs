using System;
using System.Windows.Forms;
using ELTE.EVA2.TicTacToe.View.Model;

namespace ELTE.EVA2.TicTacToe.View
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IGameManager gameManager = new TicTacToeGameManager();

            Application.Run(new MainForm(gameManager));
        }
    }
}
