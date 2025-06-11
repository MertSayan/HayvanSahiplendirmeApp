using Application.Events;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Common;


namespace Application.Observers
{
    public class EmailPetCreatedObserver : IPetCreatedObserver
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailPetCreatedObserver(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task OnPetCreatedAsync(PetCreatedEvent pet)
        {
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
                Console.WriteLine("[Observer-Email] Mail başarıyla gönderildi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Observer-Email] HATA: {ex.Message}");
            }
        }


    }
}
