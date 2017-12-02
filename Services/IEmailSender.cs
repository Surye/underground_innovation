using System.Threading.Tasks;

namespace UndergroundInnovation.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
