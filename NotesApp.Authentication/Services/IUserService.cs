using NotesApp.Models;

namespace NotesApp.Authentication;

public interface IUserService
{
    public User PostUserToDb(string username, string password);
    public User CreateUser(string username, string password);
    public void CreatePassword(string password, out string passwordHash);
    public bool Login(string username, string password);
    public bool VerifyPasswordHash(string password, string passwordHash);
    public User GetUser(string username);
}