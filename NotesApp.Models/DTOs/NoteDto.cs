namespace NotesApp.Models;

public class NoteDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid CategoryId { get; set; }
}