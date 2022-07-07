using Microsoft.AspNetCore.Http;
using NotesApp.DataAccess;
using NotesApp.Models;
using NotesAppBusinessLogic;

namespace NotesApp.BusinessLogic;

public class NoteService : INoteService
{
    private readonly INoteRepository _noteRepo;

    public NoteService(INoteRepository noteRepo)
    {
        _noteRepo = noteRepo;
    }

    public Note AddNote(NoteDto noteDto, Category category, Image image, Guid userId)
    {

        return _noteRepo.AddNote(noteDto, category, image, userId);
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
    public bool RemoveNote(Guid id)
    {
        return _noteRepo.RemoveNote(id);
    }

    public ICollection<Note> GetNotes(Guid userId)
    {
        return _noteRepo.GetNotes(userId);
    }

    public Note GetNote(Guid noteId)
    {
        return _noteRepo.GetNote(noteId);
    }
}