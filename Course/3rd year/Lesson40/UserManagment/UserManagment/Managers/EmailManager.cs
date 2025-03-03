using UserManagment.Models;
using UserManagment.Services;

namespace UserManagment.Managers;

public class EmailService : IEmailService
{
    public void SendWelcomeEmail(string email)
    {
        // Логика отправки email
        Console.WriteLine($"Sending welcome email to {email}");
    }
}