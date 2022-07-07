using Microsoft.AspNetCore.Http;
using NotesApp.Models.Attributes;

namespace NotesApp.Models;

public class ImageDto
{
    // public byte[] Data { get; set; }
    // public string ContentType { get; set; }
    // public Guid NoteId { get; set; }
    [MaxFileSize(5 * 1024 * 1024)]
    [AllowedExtensions(new string[] {"png", "jpg", "jpeg"})]
    public IFormFile Image { get; set; }
}