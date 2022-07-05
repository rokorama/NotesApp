using NotesApp.Models;

namespace NotesApp.DataAccess;

public interface ICategoryRepository
{
    public NoteCategory AddCategory();
    public NoteCategory RemoveCategory(Guid id);
    public NoteCategory EditCategory(NoteCategory category);
}