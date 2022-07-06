using NotesApp.Models;

namespace NotesApp.DataAccess;

public interface INoteRepository
{
    public Note AddNote(NoteDto noteDto, Guid userId);
    public Note EditNote(Note note);
    public bool RemoveNote(Guid id);
}