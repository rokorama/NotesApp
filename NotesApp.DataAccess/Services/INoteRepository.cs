using NotesApp.Models;

namespace NotesApp.DataAccess;

public interface INoteRepository
{
    public Note AddNote(NoteDto noteDto, Category category, Image image, Guid userId);
    public Note EditNote(Note note);
    public bool RemoveNote(Guid id);
    public ICollection<Note> GetNotes(Guid userId);
    public Note GetNote(Guid noteId);
}