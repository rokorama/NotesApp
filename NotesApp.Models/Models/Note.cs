namespace NotesApp.Models;

public class Note
{
    public Guid Id { get; set;}
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid CategoryId { get; set; }
    #nullable enable
    public Guid? ImageId { get; set; }
}