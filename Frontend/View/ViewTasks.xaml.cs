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
    /// Interaction logic for ViewTasks.xaml
    /// </summary>
    public partial class ViewTasks : Window
    {
        private ViewTasksViewModel viewModel;
        public ViewTasks(UserModel u, BoardModel b)
        {
            InitializeComponent();
            this.viewModel = new ViewTasksViewModel(u,b);
            this.DataContext = viewModel;
        }
    }
}
