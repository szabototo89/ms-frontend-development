using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ELTE.EVA2.TicTacToe.WPF.ViewModels;

namespace ELTE.EVA2.TicTacToe.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ApplicationViewModel ViewModel
        {
            get { return DataContext as ApplicationViewModel; }
            set { DataContext = value; }
        }

        public MainWindow(ApplicationViewModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");

            InitializeComponent();
            ViewModel = viewModel;
        }
    }
}