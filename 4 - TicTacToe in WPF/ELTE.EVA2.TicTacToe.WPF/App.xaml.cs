using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ELTE.EVA2.TicTacToe.Model;
using ELTE.EVA2.TicTacToe.WPF.ViewModels;

namespace ELTE.EVA2.TicTacToe.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IGameManager gameManager = new TicTacToeGameManager();
            gameManager.StartGame(new[]
            {
                new Player("John Doe"), 
                new Player("Jane Doe")
            });


            ApplicationViewModel applicationViewModel = new ApplicationViewModel(gameManager);
            MainWindow window = new MainWindow(applicationViewModel);

            window.Show();
        }
    }
}
