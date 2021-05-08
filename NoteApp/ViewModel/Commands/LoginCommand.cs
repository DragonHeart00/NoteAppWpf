using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NoteApp.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {

        public LoginController Controller { get; set; }

        public event EventHandler CanExecuteChanged;

        public LoginCommand(LoginController controller)
        {
            Controller = controller;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //todo
        }
    }
}
