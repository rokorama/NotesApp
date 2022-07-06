namespace NotesApp.Authentication;

public interface IJwtService
{
    public string GetJwtToken(string username);
}