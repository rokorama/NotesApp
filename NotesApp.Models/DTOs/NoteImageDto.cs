namespace NotesApp.Models;

public class ImageDto
{
    public byte[] Data { get; set; }
    public string ContentType { get; set; }
    public Guid NoteId { get; set; }
}