using NotesApp.Models;

namespace NotesAppBusinessLogic;

public interface INoteService
{
    public Note AddNote();
    public Note EditNote(Note note);
    public Note RemoveNote(Guid id);
    public Note AddImage(Note note, NoteImage image);
    public Note EditImage(NoteImage image);
    public Note RemoveImage(Guid id);
    public NoteCategory AddCategory();
    public NoteCategory EditCategory(NoteCategory category);
    public NoteCategory RemoveCategory(Guid id);
}