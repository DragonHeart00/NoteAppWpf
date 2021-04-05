using NoteApp.Model;
using NoteApp.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.ViewModel
{
    public class NotesController
    {
        
        public ObservableCollection<Notebook> Notebooks { get; set; }
        private Notebook selectedNotebook;

        public Notebook SelectedNotebook
        {
            get { return selectedNotebook; }
            set 
            { 
                selectedNotebook = value;
                //todo get the notes
            }
        }


        public ObservableCollection<Note> Notes { get; set; }



        //call comamnd methods 
        public NewNotebookCommand NewNotebookCommand { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }


        public NotesController()
        {
            NewNotebookCommand = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);
        }
    }
}
