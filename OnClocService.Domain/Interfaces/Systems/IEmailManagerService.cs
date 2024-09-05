
using OnClocService.Domain.DataModels.Systems;
using System.Net.Mail;

namespace OnClocService.Domain.Interfaces.Systems;

public interface IEmailManagerService
{
    Task SendEmailAsync(string email, string subject, string body);
    Task SendToEmailRecepientsAsync(EmailRecepients recepients, string subject, string message);
    Task SendEmailWithAttachmentsAsync(EmailRecepients recepients, string subject, string message, List<Attachment> attachments);
}
