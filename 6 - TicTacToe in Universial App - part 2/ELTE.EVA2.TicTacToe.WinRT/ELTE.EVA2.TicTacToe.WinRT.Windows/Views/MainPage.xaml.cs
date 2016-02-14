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
using ELTE.EVA2.TicTacToe.WinRT.Common;
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
        private readonly String APPLICATION_VIEW_MODEL_STATE;
        public IGameManager GameManager { get; private set; }

        public ApplicationViewModel ApplicationViewModel
        {
            get { return DataContext as ApplicationViewModel; }
            private set { DataContext = value; }
        }

        public MainPage()
        {
            APPLICATION_VIEW_MODEL_STATE = "ApplicationViewModel";

            InitializeComponent();
            InitializeGame("John Doe", "Jane Doe");
        }

        public void InitializeGame(String firstPlayerName, String secondPlayerName)
        {
            GameManager = new TicTacToeGameManager();
            GameManager.NewGame(new[]
            {
                new Player(firstPlayerName),
                new Player(secondPlayerName),
            });

            var messageDialogService = new StandardMessageDialogService();
            var fileDialogService = new StandardFileDialogService();
            var fileRepository = new JsonFileRepository();

            ApplicationViewModel = new ApplicationViewModel(fileDialogService, messageDialogService, GameManager, fileRepository);
        }

        private void NewGameClick(Object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (NewGamePage), this);
        }

        //protected override void OnNavigatedFrom(NavigationEventArgs e)
        //{
        //    var frameState = SuspensionManager.SessionStateForFrame(this.Frame);

        //    frameState[APPLICATION_VIEW_MODEL_STATE] = ApplicationViewModel;
        //}

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    var frameState = SuspensionManager.SessionStateForFrame(this.Frame);

        //    if (frameState.ContainsKey(APPLICATION_VIEW_MODEL_STATE))
        //    {
        //        ApplicationViewModel = frameState[APPLICATION_VIEW_MODEL_STATE] as ApplicationViewModel;
        //    }
        //}
    }
}
