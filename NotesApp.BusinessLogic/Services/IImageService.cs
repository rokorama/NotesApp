using Microsoft.AspNetCore.Http;
using NotesApp.Models;

namespace NotesAppBusinessLogic;

public interface IImageService
{
    public Image AddImage(IFormFile imageUpload, Guid noteId);
    public Image EditImage(IFormFile imageUpload, Image imageToUpdate);
    public bool RemoveImage(Guid imageId);
    public Image ConvertImageUploadToObject(IFormFile input);
}