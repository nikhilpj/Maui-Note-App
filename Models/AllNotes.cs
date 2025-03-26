using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    internal class AllNotes
    {
        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();
        public AllNotes() => LoadNotes(); 

        public void LoadNotes()
        {
            Notes.Clear();

            //get the folder where the notes are stored
            string appDataPath = FileSystem.AppDataDirectory;


            //use linq extensions to load the *.notes.txt files
            IEnumerable<Note> notes = Directory
                //select the filenames from the directory
                .EnumerateFiles(appDataPath, "*.notes.text")

                //each filename is used to create new Note
                .Select(filename => new Note()
                {
                    FileName = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                })

                //with the final collection of notes, order them by date
                .OrderBy(note => note.Date);

            //add each note into the observable collection
            foreach(Note note in notes)
            {
                Notes.Add(note);
            }

        }
    }
}
