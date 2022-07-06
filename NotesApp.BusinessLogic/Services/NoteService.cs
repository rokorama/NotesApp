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

    public Category AddCategory(CategoryDto categoryDto)
    {
        return _categoryRepo.AddCategory(categoryDto);
    }

    public Note AddImage(Note note, Image image)
    {
        throw new NotImplementedException();
    }

    public Note AddNote(NoteDto noteDto, Guid userId)
    {
        return _noteRepo.AddNote(noteDto, userId);
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

    public Note EditImage(Note note, Image image)
    {
        throw new NotImplementedException();
    }

    public Note EditNote(Guid id, Note note)
    {
        var editedNote = new Note()
        {
            Id = id,
            UserId = note.UserId,
            Title = note.Title,
            Content = note.Content,
            CategoryId = note.CategoryId,
            ImageId = null
        };
        return _noteRepo.EditNote(editedNote);
    }

    public bool RemoveCategory(Guid id)
    {
        return _categoryRepo.RemoveCategory(id);
    }

    public bool RemoveImage(Guid id)
    {
        throw new NotImplementedException();
    }

    public bool RemoveNote(Guid id)
    {
        return _noteRepo.RemoveNote(id);
    }
}