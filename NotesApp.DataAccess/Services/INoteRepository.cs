using NotesApp.Models;

namespace NotesApp.DataAccess;

public interface INoteRepository
{
    public Note AddNote();
    public Note RemoveNote(Guid id);
    public Note EditNote(Note note);
}