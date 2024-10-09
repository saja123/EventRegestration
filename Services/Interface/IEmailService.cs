using System.Threading.Tasks;

namespace EventRegestration.Services.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(string recipientEmail, string subject, string message);
    }
}

