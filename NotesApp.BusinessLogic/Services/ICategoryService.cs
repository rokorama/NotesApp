using Microsoft.AspNetCore.Http;
using NotesApp.Models;

namespace NotesAppBusinessLogic;

public interface ICategoryService
{
    public Category AddCategory(CategoryDto categoryDto);
    public Category EditCategory(Guid categoryId, string editedName);
    public bool RemoveCategory(Guid categoryId);
    public Category GetCategory(string categoryName);
}