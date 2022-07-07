using NotesApp.Models;

namespace NotesApp.DataAccess;

public interface ICategoryRepository
{
    public Category AddCategory(CategoryDto categoryDto);
    public Category EditCategory(Category editedCategory);
    public bool RemoveCategory(Guid id);
    public Category GetCategory(string name);
}