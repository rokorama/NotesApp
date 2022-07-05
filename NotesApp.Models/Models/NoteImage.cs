namespace NotesApp.Models;

public class NoteImage
{
    public Guid Id { get; set; }
    public byte[] Data { get; set; }
    public string ContentType { get; set; }
    public Guid NoteId { get; set; }
    public Note Note { get; set; }
}