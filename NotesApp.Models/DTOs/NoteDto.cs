using Microsoft.AspNetCore.Http;
using NotesApp.Models.Attributes;

namespace NotesApp.Models;

public class NoteDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string CategoryName { get; set; }
    #nullable enable
    [MaxFileSize(5 * 1024 * 1024)]
    [AllowedExtensions(new string[] {"png", "jpg", "jpeg"})]
    public IFormFile? Image { get; set; }

}