namespace NotesApp.Models;

public class NoteImageDto
{
    public byte[] Data { get; set; }
    public string ContentType { get; set; }
    public Guid NoteId { get; set; }
}