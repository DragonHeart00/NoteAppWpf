using NoteApp.Model;
using NoteApp.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.ViewModel
{
    public class LoginController
    {
        private User myVar;

        public User MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }



        public RegisterCommand RegisterCommand { get; set; }
        public LoginCommand LoginCommand { get; set; }
        public LoginController()
        {
            RegisterCommand = new RegisterCommand(this);
            LoginCommand = new LoginCommand(this);
        }

    }
}
