using MediatR;

namespace Application.Features.MediatR.AdoptionTrackings.Commands
{
    public class CreateAdoptionTrackingCommand:IRequest<Unit>
    {
        public int AdoptionRequestId { get; set; }
        public int WeekNumber { get; set; }
        public string PhotoImageUrl { get; set; }
        public string? Note { get; set; }
    }
}
