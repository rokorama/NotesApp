using Microsoft.AspNetCore.Http;
using NotesApp.DataAccess;
using NotesApp.Models;
using NotesAppBusinessLogic;

namespace NotesApp.BusinessLogic;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepo;

    public ImageService(IImageRepository imageRepo)
    {
        _imageRepo = imageRepo;
    }

    public Image AddImage(IFormFile imageUpload, Guid noteId)
    {
        using var memoryStream = new MemoryStream();
        imageUpload.CopyTo(memoryStream);
        var imageBytes = memoryStream.ToArray();
        var entry = new Image()
        {
            Id = Guid.NewGuid(),
            Data = imageBytes,
            ContentType = imageUpload.ContentType,
            NoteId = noteId
        };
        return _imageRepo.AddImage(entry);
    }

    public Image EditImage(IFormFile imageUpload, Image imageToUpdate)
    {
        using var memoryStream = new MemoryStream();
        imageUpload.CopyTo(memoryStream);
        var imageBytes = memoryStream.ToArray();
        var updatedEntry = new Image()
        {
            Id = imageToUpdate.Id,
            Data = imageBytes,
            ContentType = imageUpload.ContentType,
            NoteId = imageToUpdate.Id
        };
        return _imageRepo.EditImage(imageToUpdate);
    }

    public bool RemoveImage(Guid id)
    {
        return _imageRepo.RemoveImage(id);
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