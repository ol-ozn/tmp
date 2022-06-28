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
using System.Windows.Shapes;
using Frontend.Model;

namespace Frontend.View
{
    /// <summary>
    /// Interaction logic for ViewTasks.xaml
    /// </summary>
    public partial class ViewTasks : Window
    {
        public ViewTasks(UserModel u)
        {
            InitializeComponent();
        }
    }
}
