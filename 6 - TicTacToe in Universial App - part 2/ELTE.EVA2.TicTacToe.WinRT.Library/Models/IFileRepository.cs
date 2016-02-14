using System;
using System.Threading.Tasks;
using Windows.Storage;

namespace ELTE.EVA2.TicTacToe.WinRT.Library.Models
{
    public interface IFileRepository
    {
        Task<GameState> LoadGameAsync(StorageFile file);

        Task SaveGameAsync(StorageFile file, GameState gameState);
    }
}