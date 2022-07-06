using NotesApp.DataAccess;
using NotesApp.Models;

namespace NotesApp.Authentication;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public User AddNewUser(User user)
    {
        _dbContext.Users.Add(user);
        if (_dbContext.SaveChanges() > 0)
            return user;
        else
            return null;
    }

    public User GetUser(string username)
    {
        return _dbContext.Users.FirstOrDefault(x => x.Username == username);
    }
}