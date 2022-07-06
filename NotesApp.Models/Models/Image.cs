namespace NotesApp.Models;

public class Image
{
    public Guid Id { get; set; }
    public byte[] Data { get; set; }
    public string ContentType { get; set; }
    public Guid NoteId { get; set; }
}