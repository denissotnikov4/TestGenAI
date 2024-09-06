using System.Threading.Tasks;
using Application.Configuration.Emails;

namespace Application.Configuration.Emails
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailMessage message);
    }
}