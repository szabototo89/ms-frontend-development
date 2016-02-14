using System;
using System.Linq;
using System.Text;
using Windows.Storage;
using Windows.Storage.Pickers.Provider;
using Windows.UI.Popups;
using ELTE.EVA2.TicTacToe.WinRT.Library.Common;

namespace ELTE.EVA2.TicTacToe.WinRT.Helpers
{
    public class StandardMessageDialogService : IMessageDialogService
    {
        public void ShowMessage(String message)
        {
            new MessageDialog(message).ShowAsync();
        }
    }
}
