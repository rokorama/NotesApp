using NotesApp.Models;

namespace NotesApp.DataAccess;

public interface INoteRepository
{
    public Note AddNote(NoteDto noteDto);
    public Note EditNote(Guid id, Note note);
    public bool RemoveNote(Guid id);
}