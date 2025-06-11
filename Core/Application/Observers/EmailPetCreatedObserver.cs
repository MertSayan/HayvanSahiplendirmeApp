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
using Application.Interfaces.Services;
using Microsoft.Extensions.Logging;


namespace Application.Observers
{
    public class EmailPetCreatedObserver : IPetCreatedObserver
    {
        private readonly IMailSender _mailSender;
        private readonly ILogger<EmailPetCreatedObserver> _logger;

        public EmailPetCreatedObserver(IMailSender mailSender, ILogger<EmailPetCreatedObserver> logger)
        {
            _mailSender = mailSender;
            _logger = logger;
        }

        public async Task OnPetCreatedAsync(PetCreatedEvent pet)
        {
            var subject = "Yeni İlan Oluşturuldu";
            var body = $"'{pet.PetName}' isimli bir ilan oluşturuldu.";
            var to = pet.UserEmail;

            try
            {
                await _mailSender.SendMailAsync(to, subject, body);
                _logger.LogInformation("[Observer-Email] Mail başarıyla gönderildi.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[Observer-Email] Mail gönderiminde hata.");
            }
        }


    }
}
