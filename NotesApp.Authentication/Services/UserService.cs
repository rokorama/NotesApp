using System.Security.Cryptography;
using NotesApp.Models;

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
        CreatePassword(password, out byte[] passwordHash, out byte[] passwordSalt);
        var User = new User()
        {
            Username = username,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
        };
        return User;
    }

    public void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    }

    public bool Login(string username, string password)
    {
        var User = GetUser(username);
        if (User != null)
            return true;
        return false;

    }

    public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        return true;
    }
}