using NotesApp.DataAccess;
using NotesApp.Models;
using NotesAppBusinessLogic;

namespace NotesApp.BusinessLogic;

public class NoteService : INoteService
{
    private readonly INoteRepository _noteRepo;
    private readonly ICategoryRepository _categoryRepo;

    public NoteService(INoteRepository noteRepo, ICategoryRepository categoryRepo)
    {
        _noteRepo = noteRepo;
        _categoryRepo = categoryRepo;
    }

    public NoteCategory AddCategory()
    {
        throw new NotImplementedException();
    }

    public Note AddImage(Note note, NoteImage image)
    {
        throw new NotImplementedException();
    }

    public Note AddNote(NoteDto noteDto)
    {
        return _noteRepo.AddNote(noteDto);
    }

    public NoteCategory EditCategory(NoteCategory category)
    {
        throw new NotImplementedException();
    }

    public Note EditImage(NoteImage image)
    {
        throw new NotImplementedException();
    }

    public Note EditNote(Note note)
    {
        throw new NotImplementedException();
    }

    public NoteCategory RemoveCategory(Guid id)
    {
        throw new NotImplementedException();
    }

    public Note RemoveImage(Guid id)
    {
        throw new NotImplementedException();
    }

    public Note RemoveNote(Guid id)
    {
        throw new NotImplementedException();
    }
}