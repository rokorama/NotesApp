using NotesApp.Models;

namespace NotesApp.Authentication;

public interface IUserService
{
    public User PostUserToDb(string username, string password);
    public User CreateUser(string username, string password);
    public void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt);
    public bool Login(string username, string password);
    public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    public User GetUser(string username);
}