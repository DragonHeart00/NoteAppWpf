using NoteApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NoteApp.ViewModel.Commands
{
    public class NewNoteCommand : ICommand
    {

        public NotesController Controller { get; set; }

        public NewNoteCommand(NotesController controller)
        {
            Controller = controller;
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            Notebook selectedNotebook = parameter as Notebook;
            if (selectedNotebook != null)
                return true;

            return false;
        }

        public void Execute(object parameter)
        {
            Notebook selectedNotebook = parameter as Notebook;
            //called createNote method
            Controller.CreateNote(selectedNotebook.Id);
        }
    }
}
