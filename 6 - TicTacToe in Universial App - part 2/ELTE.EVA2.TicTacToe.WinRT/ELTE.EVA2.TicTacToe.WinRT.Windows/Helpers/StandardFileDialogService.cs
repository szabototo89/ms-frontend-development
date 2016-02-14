using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using ELTE.EVA2.TicTacToe.WinRT.Library.Common;

namespace ELTE.EVA2.TicTacToe.WinRT.Helpers
{
    public class StandardFileDialogService: IFileDialogService
    {
        public async Task<StorageFile> ShowSaveFilePickerAsync()
        {
            var fileSavePicker = new FileSavePicker();
            fileSavePicker.SuggestedStartLocation = PickerLocationId.ComputerFolder;
            fileSavePicker.FileTypeChoices.Add("Game Status (*.json)", new List<String> { ".json" });

            return await fileSavePicker.PickSaveFileAsync();
        }

        public async Task<StorageFile> ShowOpenFilePickerAsync()
        {
            var fileOpenPicker = new FileOpenPicker();
            fileOpenPicker.SuggestedStartLocation = PickerLocationId.ComputerFolder;
            fileOpenPicker.FileTypeFilter.Add(".json");

            return await fileOpenPicker.PickSingleFileAsync();
        }
    }
}