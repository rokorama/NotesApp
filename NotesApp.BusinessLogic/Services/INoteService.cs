using Microsoft.AspNetCore.Http;
using NotesApp.Models;

namespace NotesAppBusinessLogic;

public interface INoteService
{
    public Note AddNote(NoteDto noteDto, Category category, Image image, Guid userId);
    public Note EditNote(Guid noteId, Note editedNote);
    public bool RemoveNote(Guid noteId);
    public Note GetNote(Guid noteId);
    public ICollection<Note> GetNotes(Guid userId);
}