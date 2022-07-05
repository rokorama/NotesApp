using NotesApp.Models;

namespace NotesApp.DataAccess;

public class NoteRepository : INoteRepository
{
    public Note AddNote()
    {
        return new Note();
    }
    public Note EditNote(Note note)
    {
        return new Note();
    }

    public Note RemoveNote(Guid id)
    {
        return new Note();
    }

}