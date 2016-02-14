using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ELTE.EVA2.TicTacToe.WinRT.Helpers;
using ELTE.EVA2.TicTacToe.WinRT.Library.Models;
using ELTE.EVA2.TicTacToe.WinRT.Library.ViewModels;
using ELTE.EVA2.TicTacToe.WinRT.Views;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ELTE.EVA2.TicTacToe.WinRT
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public IGameManager GameManager { get; private set; }

        public ApplicationViewModel ApplicationViewModel
        {
            get { return DataContext as ApplicationViewModel; }
            private set { DataContext = value; }
        }

        public void InitializeGame(String firstPlayerName, String secondPlayerName)
        {
            GameManager = new TicTacToeGameManager();
            GameManager.StartGame(new[]
            {
                new Player(firstPlayerName),
                new Player(secondPlayerName),
            });

            var messageDialogService = new StandardMessageDialogService();
            ApplicationViewModel = new ApplicationViewModel(messageDialogService, GameManager);
        }

        public MainPage()
        {
            InitializeComponent();
            InitializeGame("John Doe", "Jane Doe");
        }

        private void NewGameClick(Object sender, RoutedEventArgs e)
        {
            InitializeGame("John Doe", "Jane Doe");
            Frame.Navigate(typeof (NewGamePage), ApplicationViewModel);
        }
    }
}
