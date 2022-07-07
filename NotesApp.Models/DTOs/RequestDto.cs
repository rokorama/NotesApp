namespace NotesApp.Models;

public class RequestDto
{
    public bool Success { get; set; }
    # nullable enable
    public string? Message { get; set; }
}