using NotesApp.Models;

namespace NotesApp.DataAccess;

public interface ICategoryRepository
{
    public NoteCategory AddCategory(NoteCategoryDto categoryDto);
    public NoteCategory EditCategory(Guid id, NoteCategory editedCategory);
    public bool RemoveCategory(Guid id);
}