using Microsoft.EntityFrameworkCore;
using NotesApp.Models;

namespace NotesApp.DataAccess;

public class ImageRepository : IImageRepository
{
    private readonly ApplicationDbContext _dbContext;
    public ImageRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Image AddImage(Image image)
    {
        _dbContext.Images.Add(image);
        var result = _dbContext.SaveChanges();
        if (result == 0)
        {
            return image;
        }
        return null;
    }

    public Image GetImage(Guid id)
    {
        return _dbContext.Images.First(i => i.Id == id);
    }

    public Image EditImage(Image newImage)
    {
        var dbEntry = _dbContext.Images.SingleOrDefault(a => a.Id == newImage.Id);
        dbEntry.Data = newImage.Data;
        dbEntry.ContentType = newImage.ContentType;

        _dbContext.Entry(dbEntry).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        
        try
        {
            _dbContext.SaveChanges();
            return newImage;
        }
        catch (DbUpdateConcurrencyException)
        {
            return null;
        }
    }

    public bool RemoveImage(Guid id)
    {
        var result = _dbContext.Images.Find(id);
        _dbContext.Images.Remove(result);
        if (_dbContext.SaveChanges() != 0)
            return true;
        return false;
    }
}