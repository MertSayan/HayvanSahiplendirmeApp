using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.AdoptionRequests.Commands
{
    public class DeleteAdoptionRequestCommand:IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteAdoptionRequestCommand(int id)
        {
            Id = id;
        }
    }
}
