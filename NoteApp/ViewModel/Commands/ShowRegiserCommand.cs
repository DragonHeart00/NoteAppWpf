using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NoteApp.ViewModel.Commands
{
    public class ShowRegiserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public LoginController loginController { get; set; }

        public ShowRegiserCommand(LoginController login)
        {
            loginController = login;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            loginController.SwitchViews();
        }
    }
}
