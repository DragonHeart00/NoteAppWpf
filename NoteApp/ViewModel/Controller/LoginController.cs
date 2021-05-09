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
            set { user = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
       
        
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

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }

    }
}
