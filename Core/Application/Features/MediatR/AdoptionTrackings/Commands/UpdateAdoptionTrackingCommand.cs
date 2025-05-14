using MediatR;

namespace Application.Features.MediatR.AdoptionTrackings.Commands
{
    public class UpdateAdoptionTrackingCommand:IRequest<Unit>
    {
        public int AdoptionTrackingId { get; set; }
        public int WeekNumber { get; set; }
        public string PhotoImageUrl { get; set; }
        public string? Note { get; set; }
    }
}
