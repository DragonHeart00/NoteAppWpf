using NoteApp.ViewModel;
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

namespace NoteApp.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        LoginController controller;
        public LoginWindow()
        {
            InitializeComponent();

            controller = Resources["vm"] as LoginController;
            controller.Authenticated += Controller_Authenticated;


        }

        private void Controller_Authenticated(object sender, EventArgs e)
        {
            Close();
        }
    }
}
