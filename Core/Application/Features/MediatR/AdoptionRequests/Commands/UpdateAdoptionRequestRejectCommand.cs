using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.AdoptionRequests.Commands
{
    public class UpdateAdoptionRequestRejectCommand:IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
