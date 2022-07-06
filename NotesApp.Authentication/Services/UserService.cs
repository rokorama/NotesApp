using System.Security.Cryptography;
using NotesApp.Models;
using BCrypt;

namespace NotesApp.Authentication;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;
    private readonly IJwtService _jwtService;
    public UserService(IUserRepository userRepo, IJwtService jwtService)
    {
        _userRepo = userRepo;
        _jwtService = jwtService;
    }

    public User GetUser(string username)
    {
        return _userRepo.GetUser(username);
    }

    public User PostUserToDb(string username, string password)
    {
        var User = CreateUser(username, password);
        _userRepo.AddNewUser(User);
        return User;
    }

    public User CreateUser(string username, string password)
    {
        CreatePassword(password, out string passwordHash);
        var User = new User()
        {
            Id = Guid.NewGuid(),
            Username = username,
            PasswordHash = passwordHash
        };
        return User;
    }

    public void CreatePassword(string password, out string passwordHash)
    {
        passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Login(string username, string password)
    {
        var user = GetUser(username);
        if (user != null)
            return VerifyPasswordHash(password, user.PasswordHash);
        return false;
    }

    public bool VerifyPasswordHash(string password, string storedHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, storedHash);
    }
}