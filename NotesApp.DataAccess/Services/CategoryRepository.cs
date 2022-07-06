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
    public NoteCategory AddCategory(NoteCategoryDto categoryDto)
    {
        var entry = new NoteCategory()
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
        
    public NoteCategory EditCategory(Guid id, NoteCategory editedCategory)
    {
        var dbEntry = _appDbContext.Categories.SingleOrDefault(a => a.Id == id);
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