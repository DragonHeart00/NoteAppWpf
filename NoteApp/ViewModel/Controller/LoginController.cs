using NoteApp.DB;
using NoteApp.Model;
using NoteApp.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NoteApp.ViewModel
{
    public class LoginController : INotifyPropertyChanged
    {
        private bool isShowingRegister = false;



        private User user;
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                User = new User
                {
                    Username = username,
                    Password = this.Password,
                    Name = this.Name,
                    Lastname = this.Lastame,
                    ConfirmPassword = this.ConfirmPassword
                };
                OnPropertyChanged("Username");
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                User = new User
                {
                    Username = this.Username,
                    Password = password,
                    Name = this.Name,
                    Lastname = this.Lastame,
                    ConfirmPassword = this.ConfirmPassword
                };
                OnPropertyChanged("Password");
            }
        }


        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                User = new User
                {
                    Username = this.Username,
                    Password = this.Password,
                    Name = name,
                    Lastname = this.Lastame,
                    ConfirmPassword = this.ConfirmPassword
                };
                OnPropertyChanged("Name");
            }
        }

        private string lastname;
        public string Lastame
        {
            get { return lastname; }
            set
            {
                lastname = value;
                User = new User
                {
                    Username = this.Username,
                    Password = this.Password,
                    Name = this.Name,
                    Lastname = lastname,
                    ConfirmPassword = this.ConfirmPassword
                };
                OnPropertyChanged("Lastame");
            }
        }

        private string confirmPassword;
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                User = new User
                {
                    Username = this.Username,
                    Password = this.Password,
                    Name = this.Name,
                    Lastname = this.Lastame,
                    ConfirmPassword = confirmPassword
                };
                OnPropertyChanged("ConfirmPassword");
            }
        }




        private Visibility logVisibility;
        public Visibility LogVisibility
        {
            get { return logVisibility; }
            set
            { 
                logVisibility = value;
                OnPropertyChanged("LogVisibility");
            }
        }


        private Visibility registerVisibility;

        public Visibility RegisterVisibility
        {
            get { return registerVisibility; }
            set
            {
                registerVisibility = value;
                OnPropertyChanged("RegisterVisibility");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public RegisterCommand RegisterCommand { get; set; }
        public LoginCommand LoginCommand { get; set; }
        public ShowRegiserCommand ShowRegiserCommand { get; set; }
      
        
        public LoginController()
        {

            LogVisibility = Visibility.Visible;
            RegisterVisibility = Visibility.Collapsed;


            RegisterCommand = new RegisterCommand(this);
            LoginCommand = new LoginCommand(this);
            ShowRegiserCommand = new ShowRegiserCommand(this);
           
            User = new User();
        }


        public void SwitchViews() 
        {
            isShowingRegister = !isShowingRegister;

            if (isShowingRegister)
            {
                RegisterVisibility = Visibility.Visible;
                LogVisibility = Visibility.Collapsed;
            }
            else
            {
                LogVisibility = Visibility.Visible;
                RegisterVisibility = Visibility.Collapsed;
            }
        }

       
        


        public void Login()
        {

        }

        public async void Register()
        {
            //todo
           await FirebaseAuth.Register(User);
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
