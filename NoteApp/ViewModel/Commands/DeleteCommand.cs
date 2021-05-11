using NoteApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NoteApp.ViewModel.Commands
{

    //todo not use it yet 
    public class DeleteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
       
        public NotesController Controller { get; set; }

        public DeleteCommand(NotesController controller)
        {
            Controller = controller;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //todo add delete func
            
            Notebook notebook = parameter as Notebook;
            if (notebook != null)
                Controller.DeleteNotebook(notebook);
        }
    }
}
