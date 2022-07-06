namespace NotesApp.Models;

public class NoteDto
{
    public User User { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public NoteCategory Category { get; set; }
    public NoteImage Image { get; set; }
}