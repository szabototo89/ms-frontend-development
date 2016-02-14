using System;
using System.Threading.Tasks;
using Windows.Storage;

namespace ELTE.EVA2.TicTacToe.WinRT.Library.Common
{
    public interface IFileDialogService
    {
        Task<StorageFile> ShowSaveFilePickerAsync();
        Task<StorageFile> ShowOpenFilePickerAsync();
    }
}