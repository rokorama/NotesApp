using NotesApp.Models;

namespace NotesApp.DataAccess;

public interface IImageRepository
{
    public Image AddImage(Image image);
    public Image EditImage(Image newImage);
    public bool RemoveImage(Guid id);
}