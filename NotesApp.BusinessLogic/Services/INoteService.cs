using NotesApp.Models;

namespace NotesAppBusinessLogic;

public interface INoteService
{
    public Note AddNote(NoteDto noteDto, Guid userId);
    public Note EditNote(Guid id, Note editedNote);
    public bool RemoveNote(Guid id);
    public Note AddImage(Note note, Image image);
    public Note EditImage(Note note, Image image);
    public bool RemoveImage(Guid id);
    public Category AddCategory(CategoryDto categoryDto);
    public Category EditCategory(Guid id, string editedName);
    public bool RemoveCategory(Guid id);
}