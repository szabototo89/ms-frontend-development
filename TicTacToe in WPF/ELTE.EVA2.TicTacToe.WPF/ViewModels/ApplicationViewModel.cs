using System;
using System.Text;
using System.Threading.Tasks;
using ELTE.EVA2.TicTacToe.Model;
using ELTE.EVA2.TicTacToe.WPF.Common;

namespace ELTE.EVA2.TicTacToe.WPF.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        public IGameManager GameManager { get; private set; }

        public GameTableViewModel GameTableViewModel { get; private set; }

        public ApplicationViewModel(IGameManager gameManager)
        {
            if (gameManager == null) throw new ArgumentNullException("gameManager");

            GameManager = gameManager;
            GameTableViewModel = new GameTableViewModel(gameManager);
        }
    }
}
