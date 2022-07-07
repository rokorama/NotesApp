using Microsoft.EntityFrameworkCore;
using NotesApp.Models;

namespace NotesApp.DataAccess;

public class NoteRepository : INoteRepository
{
    private readonly ApplicationDbContext _appDbContext;

    public NoteRepository(ApplicationDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public Note AddNote(NoteDto noteDto, Category category, Image image, Guid userId)
    {
        var entry = new Note()
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Title = noteDto.Title,
            Content = noteDto.Content,
            CategoryId = category.Id,
            Image = image
        };
        _appDbContext.Notes.Add(entry);
        var result = _appDbContext.SaveChanges();
        if (result == 0)
            return null;
        return entry;
    }
        
    public Note EditNote(Note editedNote)
    {
        var dbEntry = _appDbContext.Notes.SingleOrDefault(a => a.Id == editedNote.Id);
        dbEntry.Title = editedNote.Title;
        dbEntry.Content = editedNote.Content;
        dbEntry.CategoryId = editedNote.CategoryId;
        dbEntry.Image = editedNote.Image;

        _appDbContext.Entry(dbEntry).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        
        try
        {
            _appDbContext.SaveChanges();
            return editedNote;
        }
        catch (DbUpdateConcurrencyException)
        {
            return null;
        }
    }

    public bool RemoveNote(Guid id)
    {
        var result = _appDbContext.Notes.Find(id);
        _appDbContext.Notes.Remove(result);
        if (_appDbContext.SaveChanges() != 0)
            return true;
        return false;
    }

    public ICollection<Note> GetNotes(Guid id)
    {
        return _appDbContext.Notes.Where(n => n.UserId == id)
                                  .ToList();
    }
}