using Microsoft.AspNetCore.Http;
using NotesApp.DataAccess;
using NotesApp.Models;
using NotesAppBusinessLogic;

namespace NotesApp.BusinessLogic;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepo;

    public CategoryService(ICategoryRepository categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }

    public Category AddCategory(CategoryDto categoryDto)
    {
        return _categoryRepo.AddCategory(categoryDto);
    }

    public Category EditCategory(Guid id, string editedName)
    {
        var editedCategory = new Category()
        {
            Id = id,
            Name = editedName
        };
        return _categoryRepo.EditCategory(editedCategory);
    }

    public bool RemoveCategory(Guid id)
    {
        return _categoryRepo.RemoveCategory(id);
    }

    public Category GetCategory(string name)
    {
        return _categoryRepo.GetCategory(name);
    }
}