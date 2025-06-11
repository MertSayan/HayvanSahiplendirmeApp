using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IMailSender
    {
        Task SendMailAsync(string to, string subject, string body);

    }
}
