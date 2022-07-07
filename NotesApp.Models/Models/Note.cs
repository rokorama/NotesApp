namespace NotesApp.Models;

public class Note
{
    public Guid Id { get; set;}
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    #nullable enable
    public Guid? CategoryId { get; set; }
    public Image? Image { get; set; }
}