using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;

namespace ELTE.EVA2.TicTacToe.WinRT.Library.Models
{
    public class JsonFileRepository : IFileRepository
    {
        public async Task<GameState> LoadGameAsync(StorageFile file)
        {
            if (file == null) throw new ArgumentNullException("file");

            using (var fileStream = await file.OpenStreamForReadAsync())
            {
                var serializer = new DataContractJsonSerializer(typeof(GameState));
                var state = serializer.ReadObject(fileStream) as GameState;
                return state;
            }
        }

        public async Task SaveGameAsync(StorageFile file, GameState gameState)
        {
            if (file == null) throw new ArgumentNullException("file");
            if (gameState == null) throw new ArgumentNullException("gameState");

            using (var fileStream = await file.OpenStreamForWriteAsync())
            {
                var serializer = new DataContractJsonSerializer(typeof(GameState));
                serializer.WriteObject(fileStream, gameState);

                await fileStream.FlushAsync();
            }
        }
    }
}
