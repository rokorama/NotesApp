using Microsoft.EntityFrameworkCore;
using NotesApp.Models;

namespace NotesApp.DataAccess;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _appDbContext;

    public CategoryRepository(ApplicationDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public Category AddCategory(CategoryDto categoryDto)
    {
        var entry = new Category()
        {
            Id = Guid.NewGuid(),
            Name = categoryDto.Name,
        };
        _appDbContext.Categories.Add(entry);
        var result = _appDbContext.SaveChanges();
        if (result == 0)
            return null;
        return entry;
    }
        
    public Category EditCategory(Category editedCategory)
    {
        var dbEntry = _appDbContext.Categories.SingleOrDefault(a => a.Id == editedCategory.Id);
        dbEntry.Name = editedCategory.Name;

        _appDbContext.Entry(dbEntry).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        
        try
        {
            _appDbContext.SaveChanges();
            return editedCategory;
        }
        catch (DbUpdateConcurrencyException)
        {
            return null;
        }
    }

    public bool RemoveCategory(Guid id)
    {
        var result = _appDbContext.Categories.Find(id);
        _appDbContext.Categories.Remove(result);
        if (_appDbContext.SaveChanges() != 0)
            return true;
        return false;
    }
}