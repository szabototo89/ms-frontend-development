﻿using System;
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
using ELTE.Lecture.SuperHeroManager.Models;
using ELTE.Lecture.SuperHeroManager.ViewModels;

namespace ELTE.Lecture.SuperHeroManager
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
            InitializeComponent();

            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));
            ViewModel = viewModel;
        }
    }
}