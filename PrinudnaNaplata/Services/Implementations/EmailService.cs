using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using PrinudnaNaplata.Services.Interfaces;

namespace PrinudnaNaplata.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendAsync(string to, string subject, string htmlBody)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(configuration["Email:From"]));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlBody };

            using var smtp = new SmtpClient();

            smtp.CheckCertificateRevocation = false;

            await smtp.ConnectAsync(
                configuration["Email:Host"],
                int.Parse(configuration["Email:Port"]),
                SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(configuration["Email:Username"], configuration["Email:Password"]);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
