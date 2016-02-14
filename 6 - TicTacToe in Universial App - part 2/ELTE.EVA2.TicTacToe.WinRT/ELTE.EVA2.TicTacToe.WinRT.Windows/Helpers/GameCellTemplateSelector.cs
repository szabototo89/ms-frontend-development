using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ELTE.EVA2.TicTacToe.WinRT.Helpers
{
    public class GameCellTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FirstPlayerCellTemplate { get; set; }

        public DataTemplate SecondPlayerCellTemplate { get; set; }

        public DataTemplate EmptyCellTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(Object item, DependencyObject container)
        {
            var content = item as String;

            switch (content)
            {
                case "X":
                    return FirstPlayerCellTemplate;
                case "O":
                    return SecondPlayerCellTemplate;
                default:
                    return EmptyCellTemplate;
            }

        }
    }
}