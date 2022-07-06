namespace NotesApp.Models;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public ICollection<Note> Notes { get; set; }
}