using Application.Events;
using MassTransit;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Net.Mail;
using WebApi.Configurations;

namespace WebApi.Consumer
{
    public class PetCreatedEventConsumer : IConsumer<PetCreatedEvent>
    {
        private readonly SmtpSettings _smtpSettings;

        public PetCreatedEventConsumer(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task Consume(ConsumeContext<PetCreatedEvent> context)
        {
            var pet = context.Message;

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpSettings.UserName),
                Subject = "Yeni İlan Oluşturuldu",
                Body = $"'{pet.PetName}' isimli bir ilan oluşturuldu.",
                IsBodyHtml = true
            };

            mailMessage.To.Add(pet.UserEmail);

            using var smtpClient = new SmtpClient(_smtpSettings.Host)
            {
                Port = _smtpSettings.Port,
                Credentials = new NetworkCredential(_smtpSettings.UserName, _smtpSettings.Password),
                EnableSsl = _smtpSettings.EnableSsl
            };

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
                Console.WriteLine("[INFO] Mail başarıyla gönderildi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Mail gönderilemedi: {ex.Message}");
            }
        }
    }
}
