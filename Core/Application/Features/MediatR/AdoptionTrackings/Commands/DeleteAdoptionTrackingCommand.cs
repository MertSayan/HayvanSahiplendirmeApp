using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.AdoptionTrackings.Commands
{
    public class DeleteAdoptionTrackingCommand:IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteAdoptionTrackingCommand(int id)
        {
            Id = id;
        }
    }
}
