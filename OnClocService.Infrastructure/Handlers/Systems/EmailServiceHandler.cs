using OnClocService.Domain.DataModels.Systems;
using OnClocService.Domain.Interfaces.Systems;
using OnClocService.Infrastructure.Services.Systems;
using System.Net;
using System.Net.Mail;

namespace OnClocService.Infrastructure.Handlers.Systems;

internal class EmailServiceHandler(EmailOptionsService emailOptions) : IEmailManagerService
{
    private readonly EmailOptionsService _EmailOptions = emailOptions;

    public Task SendEmailAsync(string email, string subject, string body)
    {
        EmailRecepients recepients = new() { To = email };
        List<Attachment> attachments = [];
        Execute(recepients, subject, body, attachments).Wait();
        return Task.FromResult(0);
    }

    public Task SendToEmailRecepientsAsync(EmailRecepients recepients, string subject, string message)
    {
        List<Attachment> attachments = [];
        Execute(recepients, subject, message, attachments).Wait();
        return Task.FromResult(0);
    }

    public Task SendEmailWithAttachmentsAsync(EmailRecepients recepients, string subject, string message, List<Attachment> attachments)
    {
        Execute(recepients, subject, message, attachments).Wait();
        return Task.FromResult(0);
    }

    public async Task Execute(EmailRecepients recepients, string subject, string message, List<Attachment> attachments)
    {
        var fromAddress = await _EmailOptions.GetFromAddress();
        var fromName = await _EmailOptions.GetFromName();
        // Create New Email
        MailMessage mail = new()
        {
            From = new MailAddress(fromAddress, fromName),
            Subject = subject,
            Body = message,
            IsBodyHtml = true,
            Priority = MailPriority.Normal
        };
        // Add Recepients
        if (recepients != null)
        {
            mail.To.Add(new MailAddress(recepients.To));

            if (!string.IsNullOrEmpty(recepients.Cc)) { mail.CC.Add(new MailAddress(recepients.Cc)); }

            if (!string.IsNullOrEmpty(recepients.Bcc)) { mail.Bcc.Add(new MailAddress(recepients.Bcc)); }
        }
        // Add Attachments
        if (attachments != null)
        {
            foreach (var item in attachments)
            {
                mail.Attachments.Add(item);
            }
        }
        // Send Email
        var emailHost = await _EmailOptions.GetHost();
        var emailPort = await _EmailOptions.GetPort();
        var emailUsername = await _EmailOptions.GetUsername();
        var emailPassword = await _EmailOptions.GetPassword();
        var emailUseSsl = await _EmailOptions.GetUseSsl();
        using var smtp = new SmtpClient(emailHost, emailPort);
        smtp.Credentials = new NetworkCredential(emailUsername, emailPassword);
        smtp.EnableSsl = emailUseSsl;
        await smtp.SendMailAsync(mail);
    }
}
