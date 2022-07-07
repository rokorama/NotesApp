using Microsoft.AspNetCore.Http;
using NotesApp.Models;

namespace NotesAppBusinessLogic;

public interface INoteService
{
    public Note AddNote(NoteDto noteDto, Category category, Image image, Guid userId);
    public Note EditNote(Guid id, Note editedNote);
    public bool RemoveNote(Guid id);
    public ICollection<Note> GetNotes(Guid id);
    public Image AddImage(Image image);
    public Image EditImage(Note note, Image image);
    public bool RemoveImage(Guid id);
    public Image ConvertImageUploadToObject(IFormFile input);
    public Category AddCategory(CategoryDto categoryDto);
    public Category EditCategory(Guid id, string editedName);
    public bool RemoveCategory(Guid id);
    public Category GetCategory(string name);
}