namespace UserManagment.Services;
using UserManagment.Models;


public interface IUserService
{
    void AddUser(User user);
    void DeleteUser(int userId);
    User GetUser(int userId);
    string GetAllUsers();
}