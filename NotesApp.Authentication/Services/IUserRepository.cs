using NotesApp.Models;

namespace NotesApp.Authentication;

public interface IUserRepository
{
    public User AddNewUser(User user);
    public User GetUser(string username);
}