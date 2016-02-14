using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
