using System;
using System.Collections.Generic;
using NoteKeeper.Models;

namespace NoteKeeper.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Note Note { get; set; }
        public IList<String> CourseList { get; set; }

        // True when adding a new note; false when editing existing note
        public bool IsNewNote { get; set; }

        public String NoteHeading
        {
            get { return Note.Heading; }
            set
            {
                Note.Heading = value;
                OnPropertyChanged();
            }

        }

        public String NoteText
        {
            get { return Note.Text; }
            set
            {
                Note.Text = value;
                OnPropertyChanged();
            }

        }

        public String NoteCourse
        {
            get { return Note.Course; }
            set
            {
                Note.Course = value;
                OnPropertyChanged();
            }

        }

        public ItemDetailViewModel(Note note = null)
        {
            IsNewNote = note == null;

            Title = IsNewNote ? "Add note" : "Edit note";
            InitializeCourseList();
            Note = note ?? new Note();
        }

        async void InitializeCourseList()
        {
            CourseList = await PluralsightDataStore.GetCoursesAsync();
        }
    }
}
