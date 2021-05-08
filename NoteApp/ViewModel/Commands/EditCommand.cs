using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NoteApp.ViewModel.Commands
{
    public class EditCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public NotesController Controller { get; set; }

        public EditCommand(NotesController controller)
        {
            Controller = controller;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           Controller.StartEditing();
        }
    }
}
