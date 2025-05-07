using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.AdoptionRequests.Commands
{
    public class UpdateAdoptionRequestCommand:IRequest<Unit>
    {
        public int AdoptionRequestId { get; set; }
        public int PetId { get; set; }
        public int SenderId { get; set; }
        public int OwnerId { get; set; }
        public string Status { get; set; } // enum yapısı kullanacağız. pending, accepted , rejected
        public string? Note { get; set; } //istek yollarken kısa bir not yazabilecek
    }
}
