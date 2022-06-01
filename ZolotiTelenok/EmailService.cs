using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;

namespace ZolotiTelenok
{
    public class EmailService
    {
        private readonly ILogger<EmailService> logger;

        public EmailService(ILogger<EmailService> logger)
        {
            this.logger = logger;
        }

        public void SendEmail(string email, string subject, string message)
        {
            try 
            { 
                MimeMessage Message = new MimeMessage();

                Message.From.Add(new MailboxAddress("Бот Золотой телёнок", "Kaipopzemli@gmail.com"));
                Message.To.Add(new MailboxAddress("",email));
                Message.Subject = subject;
                Message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = message
                };

                using (SmtpClient client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate("Kaipopzemli@gmail.com", "DAF!HnLDeA67EKk");
                    client.Send(Message);
                    client.DisconnectAsync(true);
                    logger.LogInformation("Сообщение успешно отправлено");
                }                
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }


    }
}