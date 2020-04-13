using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoteKeeper.Models;

namespace NoteKeeper.Services
{
    public interface IPluralsightDataStore
    {
        Task<String> AddNoteAsync(Note courseNote);
        Task<bool> UpdateNoteAsync(Note courseNote);
        Task<Note> GetNoteAsync(String id);
        Task<IList<Note>> GetNotesAsync();
        Task<IList<String>> GetCoursesAsync(); 
    }
}
