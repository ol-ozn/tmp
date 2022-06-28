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
using Frontend.View;
using IntroSE.Kanban.Backend.BusinessLayer;
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
            Response<string> userModel = viewModel.Login();
            string returnValue = (string)userModel.ReturnValue;
            if (userModel.ErrorMessage == null)
            {
                // UserModel u = new UserModel(viewModel.Controller,(string)(userModel.ReturnValue));
                UserModel u = new UserModel(viewModel.Controller, returnValue);

                Boards boardView = new Boards(u);
                boardView.Show();
                this.Close();
            }
            else
            {
                ShowMessageLbl.Content = userModel.ErrorMessage;
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Response<string> response = viewModel.Register();
            if (response.ErrorMessage != null)
            {
                ShowMessageLbl.Content = response.ErrorMessage;
            }
            else
            {
                UserModel u = new UserModel(viewModel.Controller, viewModel.Username);
                Boards boardView = new Boards(u);
                boardView.Show();
                this.Close();
            }
        }
    }
}