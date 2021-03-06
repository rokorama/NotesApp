namespace NotesApp.Models;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<Note> Notes { get; set; }
}