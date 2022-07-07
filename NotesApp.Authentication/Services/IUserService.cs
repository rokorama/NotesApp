using NotesApp.Models;

namespace NotesApp.Authentication;

public interface IUserService
{
    public User CreateUser(string username, string password);
    public bool Login(string username, string password);
    public bool VerifyPasswordHash(string password, string passwordHash);
    public User GetUser(string username);
}