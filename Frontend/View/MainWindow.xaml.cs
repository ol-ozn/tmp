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
using Frontend.Model;
using IntroSE.Kanban.Backend.ServiceLayer;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
            this.viewModel = (MainViewModel)DataContext;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Response userModel = viewModel.Login();
            if (userModel.ErrorMessage == null)
            {
                //TODO: add board view 
                ShowMessageLbl.Content = "success";
            }
            else
            {
                ShowMessageLbl.Content = userModel.ErrorMessage;
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Response response = viewModel.Register();
            if (response.ErrorMessage != null)
            {
                ShowMessageLbl.Content = response.ErrorMessage;
            }
            else
            {
                ShowMessageLbl.Content = "Register success";
            }
        }
    }
}