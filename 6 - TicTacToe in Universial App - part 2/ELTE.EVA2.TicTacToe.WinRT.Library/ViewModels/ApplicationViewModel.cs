using System;
using ELTE.EVA2.TicTacToe.WinRT.Library.Common;
using ELTE.EVA2.TicTacToe.WinRT.Library.Models;

namespace ELTE.EVA2.TicTacToe.WinRT.Library.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        private GameTableViewModel gameTableViewModel;
        public IGameManager GameManager { get; private set; }

        public IFileRepository FileRepository { get; private set; }

        public ActionCommand SaveGameCommand { get; private set; }

        public ActionCommand LoadGameCommand { get; private set; }

        public GameTableViewModel GameTableViewModel
        {
            get { return gameTableViewModel; }
            private set
            {
                gameTableViewModel = value;
                OnPropertyChanged("GameTableViewModel");
            }
        }

        public IFileDialogService FileDialogService { get; private set; }

        public ApplicationViewModel(IFileDialogService fileDialogService, IMessageDialogService messageDialogService, IGameManager gameManager, IFileRepository fileRepository)
        {
            if (fileDialogService == null) throw new ArgumentNullException("fileDialogService");
            if (messageDialogService == null) throw new ArgumentNullException("messageDialogService");
            if (gameManager == null) throw new ArgumentNullException("gameManager");
            if (fileRepository == null) throw new ArgumentNullException("fileRepository");

            FileDialogService = fileDialogService;
            GameManager = gameManager;
            FileRepository = fileRepository;
            GameTableViewModel = new GameTableViewModel(messageDialogService, gameManager);

            SaveGameCommand = new ActionCommand(async () =>
            {
                var fileName = await FileDialogService.ShowSaveFilePickerAsync();
                await FileRepository.SaveGameAsync(fileName, GameManager.GameState);
            });

            LoadGameCommand = new ActionCommand(async () =>
            {
                var file = await FileDialogService.ShowOpenFilePickerAsync();
                var gameState = await FileRepository.LoadGameAsync(file);
                GameManager.LoadGameState(gameState);
                
                GameTableViewModel = new GameTableViewModel(messageDialogService, GameManager);
            });
        }
    }
}
