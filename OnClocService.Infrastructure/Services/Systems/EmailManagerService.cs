using OnClocService.Domain.DataModels.Systems;
using OnClocService.Domain.Interfaces.Systems;
using System.Net.Mail;

namespace OnClocService.Infrastructure.Services.Systems;

public class EmailManagerService(IEmailManagerService emailService)
{
    public async Task SendEmailAsync(string email, string subject, string body) => await emailService.SendEmailAsync(email, subject, body);
    public async Task SendToEmailRecepientsAsync(EmailRecepients recepients, string subject, string message) => await emailService.SendToEmailRecepientsAsync(recepients, subject, message);
    public async Task SendEmailWithAttachmentsAsync(EmailRecepients recepients, string subject, string message, List<Attachment> attachments) => await emailService.SendEmailWithAttachmentsAsync(recepients, subject, message, attachments);
}