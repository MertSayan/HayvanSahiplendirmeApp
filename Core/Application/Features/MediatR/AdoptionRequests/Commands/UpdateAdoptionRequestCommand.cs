using Application.Enums;
using MediatR;

namespace Application.Features.MediatR.AdoptionRequests.Commands
{
    public class UpdateAdoptionRequestCommand:IRequest<Unit>
    {
        public int AdoptionRequestId { get; set; }
        public AdoptionStatus Status { get; set; } // enum yapısı kullanacağız. pending, accepted , rejected
    }
}
