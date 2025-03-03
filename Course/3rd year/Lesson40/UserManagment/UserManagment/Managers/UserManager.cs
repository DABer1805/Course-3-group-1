using UserManagment.Models;
using UserManagment.Services;

namespace UserManagment.Managers;

public class UserService : IUserService
{
    private readonly List<User> _users = new List<User>();
    private readonly IEmailService _emailService;

    public UserService(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public void AddUser(User user)
    {
        // Добавление пользователя
        _users.Add(user);
        _emailService.SendWelcomeEmail(user.Email);
    }

    public void DeleteUser(int userId)
    {
        // Удаление пользователя
        var user = _users.FirstOrDefault(u => u.Id == userId);
        if (user != null) _users.Remove(user);
    }

    public User GetUser(int userId)
    {
        // Получение пользователя
        return _users.FirstOrDefault(u => u.Id == userId);
    }

    public string GetAllUsers()
    {
        // Получение всех пользователей
        return string.Join("<br/>", _users.Select(u => $"User: {u.Username}, Email: {u.Email}"));
    }
}
