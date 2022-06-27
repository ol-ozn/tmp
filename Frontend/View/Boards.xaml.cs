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
using System.Windows.Shapes;
using Frontend.Model;
using Frontend.ViewModel;

namespace Frontend.View
{
    /// <summary>
    /// Interaction logic for Boards.xaml
    /// </summary>
    public partial class Boards : Window
    {
        private BoardsViewModel viewModel;
        public Boards(UserModel u)
        {
            InitializeComponent();
            this.viewModel = new BoardsViewModel(u);
            this.DataContext = viewModel;
        }

        private void ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }
        
        private void Remove_Button(object sender, RoutedEventArgs e)
        {
            // viewModel.RemoveMessage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            viewModel.logout();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
