using Microsoft.AspNetCore.Http;
using NotesApp.DataAccess;
using NotesApp.Models;
using NotesAppBusinessLogic;

namespace NotesApp.BusinessLogic;

public class NoteService : INoteService
{
    private readonly INoteRepository _noteRepo;
    private readonly ICategoryRepository _categoryRepo;
    private readonly IImageRepository _imageRepo;

    public NoteService(INoteRepository noteRepo, ICategoryRepository categoryRepo, IImageRepository imageRepo)
    {
        _noteRepo = noteRepo;
        _categoryRepo = categoryRepo;
        _imageRepo = imageRepo;
    }

    public Category AddCategory(CategoryDto categoryDto)
    {
        return _categoryRepo.AddCategory(categoryDto);
    }

    public Image AddImage(Image image)
    {
        return _imageRepo.AddImage(image);
    }

    public Note AddNote(NoteDto noteDto, Category category, Image image, Guid userId)
    {

        return _noteRepo.AddNote(noteDto, category, image, userId);
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

    public Image EditImage(Note note, Image image)
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
            Image = note.Image
        };
        return _noteRepo.EditNote(editedNote);
    }

    public bool RemoveCategory(Guid id)
    {
        return _categoryRepo.RemoveCategory(id);
    }

    public bool RemoveImage(Guid id)
    {
        return _imageRepo.RemoveImage(id);
    }

    public bool RemoveNote(Guid id)
    {
        return _noteRepo.RemoveNote(id);
    }

    public ICollection<Note> GetNotes(Guid userId)
    {
        return _noteRepo.GetNotes(userId);
    }

    public Category GetCategory(string name)
    {
        return _categoryRepo.GetCategory(name);
    }

    public Image ConvertImageUploadToObject(IFormFile input)
    {
        using var memoryStream = new MemoryStream();
        input.CopyTo(memoryStream);
        var imageBytes = memoryStream.ToArray();
        var output = new Image()
        {
            Id = Guid.NewGuid(),
            Data = imageBytes,
            ContentType = input.ContentType
        };
        return output;
    }
}